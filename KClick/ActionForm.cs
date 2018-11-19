using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KClick.Configuration;
using Action = KClick.Configuration.Action;

namespace KClick
{
    public partial class ActionForm : Form
    {
        public MainFForm MainFForm { get; set; }
        public Action Action { get; set; } = new Action();

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

            if (Action.No == 0)
            {
                Action.No = int.Parse(txtNo.Text);
                Action.Name = txtName.Text;

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
