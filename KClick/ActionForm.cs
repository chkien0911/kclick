﻿using KClick.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Action = KClick.Configuration.Action;

namespace KClick
{
    public partial class ActionForm : Form
    {
        public MainFForm MainFForm { get; set; }
        public Action Action { get; set; } = new Action();

        private DateTimePicker colDtpDate;
        private DateTimePicker colDtpFrom;
        private DateTimePicker colDtpTo;

        public ActionForm()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            btnLoadScript.Click += BtnLoadScript_Click;

            btnDelete.Click += BtnDelete_Click;
            btnNewScript.Click += BtnNewScript_Click;
            btnEditScript.Click += BtnEditScript_Click;
            btnClearScripts.Click += BtnClearScripts_Click1;

            Load += ActionForm_Load;

            colDtpDate = new DateTimePicker();
            colDtpDate.Format = DateTimePickerFormat.Custom;
            colDtpDate.CustomFormat = "MM/dd/yyyy";
            colDtpDate.ValueChanged += new EventHandler(colDtpDateValueChanged);
            colDtpDate.Visible = false;
            dgvFromTo.Controls.Add(colDtpDate);

            this.colDtpFrom = new DateTimePicker();
            colDtpFrom.Format = DateTimePickerFormat.Custom;
            colDtpFrom.CustomFormat = "hh:mm tt";
            this.colDtpFrom.ValueChanged += new EventHandler(colDtpFromValueChanged);
            this.colDtpFrom.Visible = false;
            colDtpFrom.ShowUpDown = true;
            this.dgvFromTo.Controls.Add(colDtpFrom);

            this.colDtpTo = new DateTimePicker();
            colDtpTo.Format = DateTimePickerFormat.Custom;
            colDtpTo.CustomFormat = "hh:mm tt";
            this.colDtpTo.ValueChanged += new EventHandler(colDtpToValueChanged);
            this.colDtpTo.Visible = false;
            colDtpTo.ShowUpDown = true;
            this.dgvFromTo.Controls.Add(colDtpTo);

            dgvFromTo.CellClick += DgvFromTo_CellClick;

        }
        
        private void DgvFromTo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Rectangle tempRect = dgvFromTo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                colDtpDate.Location = tempRect.Location;
                colDtpDate.Width = tempRect.Width;
                colDtpDate.Visible = true;
            }
            else if (e.ColumnIndex == 1)
            {
                Rectangle tempRect = dgvFromTo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                colDtpFrom.Location = tempRect.Location;
                colDtpFrom.Width = tempRect.Width;
                colDtpFrom.Visible = true;
            }
            else if (e.ColumnIndex == 2)
            {
                Rectangle tempRect = dgvFromTo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                colDtpTo.Location = tempRect.Location;
                colDtpTo.Width = tempRect.Width;
                colDtpTo.Visible = true;
            }
        }

        void colDtpDateValueChanged(object sender, EventArgs e)
        {
            dgvFromTo.CurrentCell.Value = colDtpDate.Value.ToString("MM/dd/yyyy");
            colDtpDate.Visible = false;

            // Then simply do this:
            //dgvFromTo.BeginEdit(true);
            //dgvFromTo.EndEdit();
            //dgvFromTo.NotifyCurrentCellDirty(true);
        }

        void colDtpToValueChanged(object sender, EventArgs e)
        {
            dgvFromTo.CurrentCell.Value = colDtpTo.Value.ToString("hh:mm tt");//convert the date as per your format
            colDtpTo.Visible = false;

            // Then simply do this:
            //dgvFromTo.BeginEdit(true);
            //dgvFromTo.EndEdit();
            //dgvFromTo.NotifyCurrentCellDirty(true);
        }
        void colDtpFromValueChanged(object sender, EventArgs e)
        {
            dgvFromTo.CurrentCell.Value = colDtpFrom.Value.ToString("hh:mm tt");//convert the date as per your format
            colDtpFrom.Visible = false;

            // Then simply do this:
            //dgvFromTo.BeginEdit(true);
            //dgvFromTo.EndEdit();
            //dgvFromTo.NotifyCurrentCellDirty(true);
        }

        public void AddScript(Configuration.Config config)
        {
            if (Action != null)
            {
                var no = lsvScripts.Items.Count + 1;
                ListViewItem item = new ListViewItem((no).ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Delay.ToString()));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"X1:{config.XPos}, Y1:{config.YPos}, Color1:{config.ColorName} | X2:{config.X2Pos}, Y2:{config.Y2Pos}, Color2:{config.Color2Name} | XMoved:{config.XPosMoved}, YMoved:{config.YPosMoved}, ColorMoved:{config.ColorMovedName}"));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Description));
                lsvScripts.Items.Add(item);

                config.No = no;
                Action.Configs.Add(config);
            }
        }

        public void UpdateScript(Configuration.Config config)
        {
            if (config.No <= 0)
            {
                return;
            }

            if (Action != null)
            {
                foreach (ListViewItem eachItem in lsvScripts.Items)
                {
                    if (eachItem.SubItems[0].Text == config.No.ToString())
                    {
                        //eachItem.SubItems[1].Text = $"X1:{config.XPos}, Y1:{config.YPos}, Color1:{config.ColorName} | X2:{config.X2Pos}, Y2:{config.Y2Pos}, Color2:{config.Color2Name} | XMoved:{config.XPosMoved}, YMoved:{config.YPosMoved}, ColorMoved:{config.ColorMovedName}";
                        eachItem.SubItems[2].Text = config.Delay.ToString();
                        eachItem.SubItems[2].Text = config.Description;

                        break;
                    }
                }

                foreach (var item in Action.Configs)
                {
                    if (item.No == config.No)
                    {
                        item.XPos = config.XPos;
                        item.YPos = config.YPos;
                        item.ColorName = config.ColorName;

                        item.XPosIgnored = config.XPosIgnored;
                        item.YPosIgnored = config.YPosIgnored;
                        item.ColorIgnoredName = config.ColorIgnoredName;

                        item.X2Pos = config.X2Pos;
                        item.Y2Pos = config.Y2Pos;
                        item.Color2Name = config.Color2Name;

                        item.IsDrag = config.IsDrag;
                        item.XPosMoved = config.XPosMoved;
                        item.YPosMoved = config.YPosMoved;
                        item.ColorMovedName = config.ColorMovedName;

                        item.IsSequential = config.IsSequential;
                        item.Description = config.Description;
                        item.Delay = config.Delay;

                        item.IsStartIcon = config.IsStartIcon;
                        item.RunOnce = config.RunOnce;

                        item.EndWholeScripts = config.EndWholeScripts;
                        item.RunAfterScript = config.RunAfterScript;

                        item.IsClosedPosition = config.IsClosedPosition;

                        break;
                    }
                }
            }
        }

        private void BtnClearScripts_Click1(object sender, EventArgs e)
        {
            if (Action != null)
            {
                Action.Configs.Clear();
                lsvScripts.Items.Clear();
            }
        }

        private void BtnEditScript_Click(object sender, EventArgs e)
        {
            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var config = Action?.Configs.FirstOrDefault(s => s.No == no);
                    if (config != null)
                    {
                        using (var form = new ConfigForm())
                        {
                            form.ActionForm = this;
                            form.Config = config;
                            form.Configs = Action?.Configs;
                            form.ShowDialog();
                        }
                    }
                }
            }
        }

        private void BtnNewScript_Click(object sender, EventArgs e)
        {
            if (Action != null)
            {
                using (var form = new ConfigForm())
                {
                    form.ActionForm = this;
                    form.Configs = Action.Configs;
                    form.ShowDialog();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Action != null)
            {
                foreach (ListViewItem eachItem in lsvScripts.SelectedItems)
                {
                    lsvScripts.Items.Remove(eachItem);

                    var no = int.Parse(eachItem.SubItems[0].Text);
                    Action.Configs.Remove(Action.Configs.FirstOrDefault(s => s.No == no));
                }

                // reorder
                for (int i = 0; i < Action.Configs.Count; i++)
                {
                    lsvScripts.Items[i].SubItems[0].Text = (i + 1).ToString();
                    Action.Configs[i].No = i + 1;
                }
            }
        }

        private void BtnLoadScript_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "KClick file|*.xml";
                openFileDialog.Title = "Select a KScript";
                openFileDialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    lsvScripts.Items.Clear();
                    Action.Configs.Clear();

                    Action.Configs = ImportScript(openFileDialog.FileName);
                    if (Action.Configs.Count > 0)
                    {
                        DisplayListView(Action.Configs);
                        MessageBox.Show(Action.Configs.Count + " script(s) found!");
                    }
                    else
                    {
                        MessageBox.Show("No scripts found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayListView(IReadOnlyList<Config> configs)
        {
            if (configs.Count > 0)
            {
                for (int i = 0; i < configs.Count; i++)
                {
                    lsvScripts.Items.Add(configs[i].No.ToString());
                    lsvScripts.Items[i].SubItems.Add(configs[i].Delay.ToString());
                    //lsvScripts.Items[i].SubItems.Add(
                    //    $"X1:{configs[i].XPos}, Y1:{configs[i].YPos}, Color1:{configs[i].ColorName} | X2:{configs[i].X2Pos}, Y2:{configs[i].Y2Pos}, Color2:{configs[i].Color2Name} | XMoved:{configs[i].XPosMoved}, YMoved:{configs[i].YPosMoved}, ColorMoved:{configs[i].ColorMovedName}"
                    //);
                    lsvScripts.Items[i].SubItems.Add(configs[i].Description);

                }
            }
        }

        private static List<Config> ImportScript(string path)
        {
            var xml = XDocument.Load(path);

            var scripts = xml.Descendants("KScript").ToList();

            var configs = new List<Config>();

            if (scripts.Count > 0)
            {
                foreach (var item in scripts)
                {
                    configs.Add(new Configuration.Config
                    {
                        No = int.Parse(item.Element("No").Value),
                        XPos = int.Parse(item.Element("X").Value),
                        YPos = int.Parse(item.Element("Y").Value),
                        ColorName = item.Element("Color").Value,

                        XPosIgnored = int.Parse(item.Element("XIgnored").Value),
                        YPosIgnored = int.Parse(item.Element("YIgnored").Value),
                        ColorIgnoredName = item.Element("ColorIgnored").Value,

                        X2Pos = int.Parse(item.Element("X2").Value),
                        Y2Pos = int.Parse(item.Element("Y2").Value),
                        Color2Name = item.Element("Color2").Value,

                        XPosMoved = int.Parse(item.Element("XMoved").Value),
                        YPosMoved = int.Parse(item.Element("YMoved").Value),
                        ColorMovedName = item.Element("ColorMoved").Value,

                        Description = (item.Element("Description").Value),
                        Delay = int.Parse(item.Element("Delay").Value),
                        IsSequential = bool.Parse(item.Element("IsSequential").Value),
                        IsDrag = bool.Parse(item.Element("IsDrag").Value),
                        IsStartIcon = item.Element("IsStartIcon") == null
                            ? false
                            : bool.Parse(item.Element("IsStartIcon").Value),
                        RunOnce = item.Element("RunOnce") == null ? false : bool.Parse(item.Element("RunOnce").Value),
                        EndWholeScripts = item.Element("EndWholeScripts") == null
                            ? false
                            : bool.Parse(item.Element("EndWholeScripts").Value),
                        IsClosedPosition = item.Element("IsClosedPosition") == null
                            ? false
                            : bool.Parse(item.Element("IsClosedPosition").Value),
                        RunAfterScript = item.Element("RunAfterScript") == null
                            ? 0
                            : int.Parse(item.Element("RunAfterScript").Value),
                    });
                }
            }

            return configs;
        }


        private void ActionForm_Load(object sender, EventArgs e)
        {
            if (Action.No != 0)
            {
                txtNo.Text = Action.No.ToString();
                txtName.Text = Action.Name;

                if (Action.Durations.Count > 0)
                {
                    var bindingList = new BindingList<Duration>(Action.Durations);
                    var source = new BindingSource(bindingList, null);
                    dgvFromTo.DataSource = source;
                }
                //if (Action.FromTime != null)
                //    dtpFrom.Value = Action.FromTime.Value;
                //if (Action.ToTime != null)
                //    dtpTo.Value = Action.ToTime.Value;

                DisplayListView(Action.Configs);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Action.No = int.Parse(txtNo.Text);
            Action.Name = txtName.Text;

            for (int rows = 0; rows < dgvFromTo.Rows.Count; rows++)
            {
                if (dgvFromTo.Rows[rows].Cells[0].Value != null && dgvFromTo.Rows[rows].Cells[1].Value != null)
                {
                    var from = DateTime.Parse(dgvFromTo.Rows[rows].Cells[0].Value.ToString());
                    var to = DateTime.Parse(dgvFromTo.Rows[rows].Cells[1].Value.ToString());
                    Action.Durations.Add(new Duration { FromTime = from, ToTime = to });
                }
            }

            if (Action.No == 0)
            {
                MainFForm.AddAction(Action);
            }
            else
            {
                MainFForm.EditAction(Action);
            }

            Close();
        }
    }
}
