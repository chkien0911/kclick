﻿using KClick.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KClick.Configuration;

namespace KClick
{
    public partial class MainForm : Form
    {
        private static List<Configuration.Config> Configs = new List<Configuration.Config>();
        private static List<Configuration.Config> LoadingConfigs = new List<Configuration.Config>();
        private GlobalHotkey ghk;
        private GlobalHotkey ghkMain;

        private static bool isRun = true;
        private static readonly object padlock = new object();

        public MainForm()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            //btnFindControl.Click += BtnFindControl_Click;
            btnFindControl.MouseUp += BtnFindControl_MouseUp;
            btnFindControl.MouseDown += BtnGetPosition_MouseDown;
            btnFindControl.MouseHover += BtnGetPosition_MouseHover;

            btnGetPosition.MouseUp += BtnGetPosition_MouseUp;
            btnGetPosition.MouseDown += BtnGetPosition_MouseDown;
            btnGetPosition.MouseHover += BtnGetPosition_MouseHover;

            btnGetPosition2.MouseUp += BtnGetPosition2_MouseUp;
            btnGetPosition2.MouseDown += BtnGetPosition_MouseDown;
            btnGetPosition2.MouseHover += BtnGetPosition_MouseHover;

            btnGetPositionIgnored1.MouseUp += BtnGetPositionIgnored1_MouseUp;
            btnGetPositionIgnored1.MouseDown += BtnGetPosition_MouseDown;
            btnGetPositionIgnored1.MouseHover += BtnGetPosition_MouseHover;

            btnRun.Click += async (sender, e) => await BtnRun_ClickAsync(sender, e);
            btnStop.Click += async (sender, e) => await BtnStop_ClickAsync(sender, e);

            btnClearScripts.Click += BtnClearScripts_Click;


            //btnGetAppInfo.MouseUp += BtnGetAppInfo_MouseUp;
            btnDelete.Click += BtnDelete_Click;

            btnExport.Click += BtnExport_Click;
            btnImport.Click += BtnImport_Click;

            rdoInfinity.CheckedChanged += RdoInfinity_CheckedChanged;
            rdoLimit.CheckedChanged += RdoLimit_CheckedChanged;

            btnFixControl.Click += BtnFixControl_Click;
            btnApplyDelay.Click += BtnApplyDelay_Click;

            rdoSpeed.CheckedChanged += RdoSpeed_CheckedChanged;
            rdoSequencial.CheckedChanged += RdoSequencial_CheckedChanged;

            //lsvScripts.ItemSelectionChanged += LsvScripts_ItemSelectionChanged;

            //btnUpdateScript.Click += BtnUpdateScript_Click;

            chkDrag.CheckedChanged += ChkDrag_CheckedChanged;

            btnGetPositionMoved.MouseUp += BtnGetPositionMoved_MouseUp;
            btnGetPositionMoved.MouseDown += BtnGetPosition_MouseDown;
            btnGetPositionMoved.MouseHover += BtnGetPosition_MouseHover;
        }

        private void ChkDrag_CheckedChanged(object sender, EventArgs e)
        {
            txtXMoved.Enabled = chkDrag.Checked;
            txtYMoved.Enabled = chkDrag.Checked;
            txtColorMoved.Enabled = chkDrag.Checked;
            btnGetPositionMoved.Enabled = chkDrag.Checked;

            if (chkDrag.Checked == false)
            {
                txtXMoved.Clear();
                txtYMoved.Clear();
                txtColorMoved.Clear();
            }
        }

        private void BtnUpdateScript_Click(object sender, EventArgs e)
        {
            //var isOk = int.TryParse(txtNo.Text, out int no);
            //if (isOk)
            //{
            //    foreach (ListViewItem eachItem in lsvScripts.Items)
            //    {
            //        if (eachItem.SubItems[0].Text == no.ToString())
            //        {
            //            eachItem.SubItems[1].Text = txtDelay.Text;
            //            eachItem.SubItems[2].Text = $"X1:{txtXPos.Text}, Y1:{txtYPos.Text}, Color1:{txtColor1.Text} | X2:{txtX2.Text}, Y2:{txtY2.Text}, Color2:{txtColor2.Text}";
            //            eachItem.SubItems[3].Text = txtDescription.Text;

            //            break;
            //        }
            //    }

            //    foreach (var item in Configs)
            //    {
            //        if (item.No == no)
            //        {
            //            item.XPos = string.IsNullOrWhiteSpace(txtXPos.Text) ? 0 : int.Parse(txtXPos.Text);
            //            item.XPosIgnored = string.IsNullOrWhiteSpace(txtXIgnored1.Text) ? 0 : int.Parse(txtXIgnored1.Text);
            //            item.X2Pos = string.IsNullOrWhiteSpace(txtX2.Text) ? 0 : int.Parse(txtX2.Text);
            //            item.YPos = string.IsNullOrWhiteSpace(txtYPos.Text) ? 0 : int.Parse(txtYPos.Text);
            //            item.YPosIgnored = string.IsNullOrWhiteSpace(txtYIgnored1.Text) ? 0 : int.Parse(txtYIgnored1.Text);
            //            item.Y2Pos = string.IsNullOrWhiteSpace(txtY2.Text) ? 0 : int.Parse(txtY2.Text);
            //            item.ColorName = txtColor1.Text;
            //            item.ColorIgnoredName = txtColorIgnored1.Text;
            //            item.Color2Name = txtColor2.Text;
            //            item.Description = txtDescription.Text;
            //            item.IsDrag = chkDrag.Checked;

            //            break;
            //        }
            //    }
            //}
        }

        private void LsvScripts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //var no = int.Parse(e.Item.SubItems[0].Text);
            //if (no > 0)
            //{
            //    var config = Configs.FirstOrDefault(s => s.No == no);
            //    if (config != null)
            //    {
            //        txtXPos.Text = config.XPos.ToString();
            //        txtYPos.Text = config.YPos.ToString();
            //        txtColor1.Text = config.ColorName;
            //        txtX2.Text = config.X2Pos.ToString();
            //        txtY2.Text = config.Y2Pos.ToString();
            //        txtColor2.Text = config.Color2Name;

            //        txtXIgnored1.Text = config.XPosIgnored.ToString();
            //        txtYIgnored1.Text = config.YPosIgnored.ToString();
            //        txtColorIgnored1.Text = config.ColorIgnoredName;

            //        chkDrag.Checked = config.IsDrag;
            //        txtDescription.Text = config.Description;

            //        txtNo.Text = no.ToString();
            //    }
            //}
        }

        private void RdoSequencial_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in Configs)
            {
                item.IsSequential = rdoSequencial.Checked;
            }
        }

        private void RdoSpeed_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in Configs)
            {
                item.IsSequential = rdoSequencial.Checked;
            }
        }

        private void BtnApplyDelay_Click(object sender, EventArgs e)
        {
            var isOk = int.TryParse(txtDelay.Text, out int delay);
            if (!isOk)
            {
                MessageBox.Show("Delay must be a number");
            }
            else
            {
                foreach (ListViewItem eachItem in lsvScripts.Items)
                {
                    eachItem.SubItems[1].Text = delay.ToString();
                }

                foreach (var item in Configs)
                {
                    item.Delay = delay;
                }
            }
        }

        private void BtnFixControl_Click(object sender, EventArgs e)
        {
            const uint SWP_NOSIZE = 0x0001;
            const uint SWP_NOZORDER = 0x0004;

            if (!string.IsNullOrWhiteSpace(txtClass.Text))
            {
                // Find (the first-in-Z-order) Notepad window.
                var wHandle = ClickOnPointTool.FindWindow(txtClass.Text, txtName.Text);
                // If found, position it.
                if (wHandle != IntPtr.Zero)
                {
                    //MouseOperation.RECT rct;
                    //GetWindowRect(handle, out rct);
                    //Rectangle screen = Screen.FromHandle(handle).Bounds;
                    //Point pt = new Point(screen.Left + screen.Width / 2 - (rct.Right - rct.Left) / 2, screen.Top + screen.Height / 2 - (rct.Bottom - rct.Top) / 2);

                    // Move the window to (0,0) without changing its size or position
                    // in the Z order.
                    MouseOperation.SetWindowPos(wHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
                }
            }
            else
            {
                MessageBox.Show("Please click on Take Control first!");
            }
        }

        private void RdoLimit_CheckedChanged(object sender, EventArgs e)
        {
            txtLoopTime.Enabled = true;
        }

        private void RdoInfinity_CheckedChanged(object sender, EventArgs e)
        {
            txtLoopTime.Enabled = false;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "KClick file|*.xml";
                openFileDialog.Title = "Save an Script";
                openFileDialog.ShowDialog();
                if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    lsvScripts.Items.Clear();
                    Configs.Clear();

                    XDocument xml = XDocument.Load(openFileDialog.FileName);

                    var scripts = xml.Descendants("KScript");

                    int i = 0;
                    foreach (var item in scripts)
                    {
                        lsvScripts.Items.Add(item.Element("No").Value);
                        lsvScripts.Items[i].SubItems.Add(item.Element("Delay").Value);
                        lsvScripts.Items[i].SubItems.Add(
                            $"X1:{item.Element("X").Value}, Y1:{item.Element("Y").Value}, Color1:{item.Element("Color").Value} | X2:{item.Element("X2").Value}, Y2:{item.Element("Y2").Value}, Color2:{item.Element("Color2").Value}"
                        );
                        lsvScripts.Items[i].SubItems.Add(item.Element("Description").Value);

                        txtClass.Text = item.Element("Class").Value;
                        txtName.Text = item.Element("Name").Value;

                        Configs.Add(new Configuration.Config
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

                            WindowClass = item.Element("Class").Value,
                            WindowName = item.Element("Name").Value,
                            WindowHandle = (IntPtr)int.Parse(item.Element("WHandle").Value),
                            Description = (item.Element("Description").Value),
                            Delay = int.Parse(item.Element("Delay").Value),
                            IsSequential = bool.Parse(item.Element("IsSequential").Value),
                            IsDrag = bool.Parse(item.Element("IsDrag").Value),
                        });


                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "KClick file|*.xml";
            saveFileDialog1.Title = "Save an Script";

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XDocument xML = new XDocument();
                    xML.Add(new XElement("KScrips"));

                    for (int i = 0; i < Configs.Count; i++)
                    {
                        var config = Configs[i];

                        XElement script = new XElement("KScript",
                        new XElement("No", config.No),
                        new XElement("MouseKey", "Left"),

                        new XElement("X", config.XPos),
                        new XElement("Y", config.YPos),
                        new XElement("Color", config.ColorName),

                        new XElement("X2", config.X2Pos),
                        new XElement("Y2", config.Y2Pos),
                        new XElement("Color2", config.Color2Name),

                            new XElement("XMoved", config.XPosMoved),
                            new XElement("YMoved", config.YPosMoved),
                            new XElement("ColorMoved", config.ColorMovedName),

                        new XElement("XIgnored", config.XPosIgnored),
                        new XElement("YIgnored", config.YPosIgnored),
                        new XElement("ColorIgnored", config.ColorIgnoredName),

                        new XElement("Delay", config.Delay),
                        new XElement("Class", config.WindowClass),
                        new XElement("Name", config.WindowName),
                        new XElement("WHandle", config.WindowHandle),
                            new XElement("IsSequential", config.IsSequential),
                            new XElement("IsDrag", config.IsDrag),
                            new XElement("Description", config.Description)
                        );

                        script.SetAttributeValue("No", config.No);

                        xML.Element("KScrips").Add(script);
                    }

                    //testXML.Element("KScripts").Add(newStudent);
                    xML.Save(saveFileDialog1.FileName);

                    MessageBox.Show("Saved!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in lsvScripts.SelectedItems)
            {
                lsvScripts.Items.Remove(eachItem);

                var no = int.Parse(eachItem.SubItems[0].Text);
                Configs.Remove(Configs.FirstOrDefault(s => s.No == no));
            }

            // reorder
            for (int i = 0; i < Configs.Count; i++)
            {
                lsvScripts.Items[i].SubItems[0].Text = (i + 1).ToString();
                Configs[i].No = i + 1;
            }
        }


        private void BtnGetPosition_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void BtnGetPosition_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void BtnGetPosition_MouseUp(object sender, MouseEventArgs e)
        {
            var point = ClickOnPointTool.GetCursorPosition();

            txtXPos.Text = point.X.ToString();
            txtYPos.Text = point.Y.ToString();

            var color = ClickOnPointTool.GetColorAt(point);
            txtColor1.Text = color.Name;

            Cursor.Current = Cursors.Default;
        }

        private void BtnGetPositionMoved_MouseUp(object sender, MouseEventArgs e)
        {
            var point = ClickOnPointTool.GetCursorPosition();

            txtXMoved.Text = point.X.ToString();
            txtYMoved.Text = point.Y.ToString();

            var color = ClickOnPointTool.GetColorAt(point);
            txtColorMoved.Text = color.Name;

            Cursor.Current = Cursors.Default;
        }


        private void BtnGetPosition2_MouseUp(object sender, MouseEventArgs e)
        {
            var point = ClickOnPointTool.GetCursorPosition();

            txtX2.Text = point.X.ToString();
            txtY2.Text = point.Y.ToString();

            var color = ClickOnPointTool.GetColorAt(point);
            txtColor2.Text = color.Name;

            Cursor.Current = Cursors.Default;
        }

        private void BtnGetPositionIgnored1_MouseUp(object sender, MouseEventArgs e)
        {
            var point = ClickOnPointTool.GetCursorPosition();
            txtXIgnored1.Text = point.X.ToString();
            txtYIgnored1.Text = point.Y.ToString();

            var color = ClickOnPointTool.GetColorAt(point);
            txtColorIgnored1.Text = color.Name;

            Cursor.Current = Cursors.Default;
        }

        private void BtnClearScripts_Click(object sender, EventArgs e)
        {
            lsvScripts.Items.Clear();
            Configs.Clear();
        }

        private void BtnFindControl_MouseUp(object sender, MouseEventArgs e)
        {
            var point = ClickOnPointTool.GetCursorPosition();

            var hwnd = ClickOnPointTool.WindowFromPoint(new POINT { X = point.X, Y = point.Y });
            if (hwnd.ToInt64() > 0)
            {
                StringBuilder className = new StringBuilder(256);
                var nRet = ClickOnPointTool.GetClassName(hwnd, className, className.Capacity);

                //For Parent 
                IntPtr hWndParent = ClickOnPointTool.GetParent(hwnd);
                if (hWndParent.ToInt64() > 0)
                {
                    txtClass.Text = ClickOnPointTool.GetClassNameOfWindow(hWndParent);
                    txtName.Text = ClickOnPointTool.GetCaptionOfWindow(hWndParent);

                    ghk = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, hwnd);
                    ghkMain = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, this.Handle);
                    var isSuccess = ghk.Register();
                    var isSuccessMain = ghkMain.Register();
                    //if (isSuccess || isSuccessMain)
                    //MessageBox.Show("Hotkey registered.");
                    LoadingConfigs = new List<Configuration.Config>()
            {
                new Configuration.Config
                {
                    No = 1, Delay = 500, XPos = 439, YPos = 387, ColorName = "ff222222",
                    WindowClass = txtClass.Text, WindowName =txtName.Text, WindowHandle = hWndParent
                }
            };

                }
            }

            Cursor.Current = Cursors.Default;


        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY_MSG_ID)
            {
                lock (padlock)
                {
                    if (isRun)
                    {
                        isRun = false;
                    }
                }

                btnRun.Enabled = true;
                btnStop.Enabled = false;
                MessageBox.Show("Stop!");
            }

            base.WndProc(ref m);
        }


        private void BtnConfig_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async Task BtnStop_ClickAsync(object sender, EventArgs e)
        {
            await StopAsync();
        }

        private async Task StopAsync()
        {
            lock (padlock)
            {
                if (isRun)
                {
                    isRun = false;
                }
            }

            btnRun.Enabled = true;
            btnStop.Enabled = false;
        }

        private async Task BtnRun_ClickAsync(object sender, EventArgs e)
        {
            if (Configs.Count == 0)
            {
                MessageBox.Show("No scripts found!");
                return;
            }


            //var x = 1;
            if (rdoInfinity.Checked)
            {
                isRun = true;
                btnRun.Enabled = false;
                btnStop.Enabled = true;

                while (isRun)
                {
                    await RunAsync();
                }
            }
            else
            {
                var isOk = int.TryParse(txtLoopTime.Text, out int loop);
                if (isOk)
                {
                    isRun = true;
                    btnRun.Enabled = false;
                    btnStop.Enabled = true;

                    for (int i = 0; i < loop; i++)
                    {
                        await RunAsync();
                    }
                    MessageBox.Show("Done!");
                    btnRun.Enabled = true;
                    btnStop.Enabled = false;
                    isRun = false;
                }
                else
                {
                    MessageBox.Show("Loop time invalid! Must be a number");
                    txtLoopTime.Enabled = true;
                    txtLoopTime.Focus();
                }
            }
        }

        private async Task RunAsync()
        {
            foreach (var config in Configs)
            {
                await RunAsync(config);
            }
        }

        private async Task RunAsync(Configuration.Config config)
        {
            //txtProgress.AppendText($"- Script No : {config.No}. Description: {config.Description}. {Environment.NewLine}");

            await Task.Delay(config.Delay);

            // Verify that Calculator is a running process.
            if (config.WindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Application not found.");
                return;
            }

            lock (padlock)
            {
                if (isRun == false)
                {
                    return;
                }
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.

            ClickOnPointTool.SetForegroundWindow(config.WindowHandle);
            //ClickOnPointTool.ShowActiveWindow(config.WindowHandle);

            if (LoadingConfigs != null && LoadingConfigs.Count > 0)
            {
                
                var loadingItem = LoadingConfigs[0];
                var loadingColor = await MouseOperation.GetColorAt(new Point(loadingItem.XPos, loadingItem.YPos));
                while (loadingColor.Name == loadingItem.ColorName)
                {
                    //txtProgress.AppendText($"- Script No : {config.No}. Loading.... {Environment.NewLine}");

                    loadingColor = await MouseOperation.GetColorAt(new Point(loadingItem.XPos, loadingItem.YPos));
                    
                }
            }

            if (config.IsSequential)
            {
                if (config.IsDrag)
                {
                    await MouseOperation.SendMessageAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftDown, 1, config.XPos, config.YPos, config.ColorName, LoadingConfigs);
                    await MouseOperation.SendMessageAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.MouseMove, 1, config.XPosMoved, config.YPosMoved, config.ColorMovedName, LoadingConfigs);
                    await MouseOperation.SendMessageAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftUp, 0, config.XPosMoved, config.YPosMoved, config.ColorMovedName, LoadingConfigs);
                }
                else
                {
                    var dResult = await MouseOperation.SendMessageAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftDown, 1, config, LoadingConfigs);
                    var uResult = await MouseOperation.SendMessageAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftUp, 0, config, LoadingConfigs);
                }
            }
            else // Speed mode
            {
                if (config.IsDrag)
                {
                    await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftDown, 1, config.XPos, config.YPos, config.ColorName, LoadingConfigs);
                    await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.MouseMove, 1, config.XPosMoved, config.YPosMoved, config.ColorMovedName, LoadingConfigs);
                    await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftUp, 0, config.XPosMoved, config.YPosMoved, config.ColorMovedName, LoadingConfigs);
                }
                else
                {
                    var dResult = await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftDown, 1, config, LoadingConfigs);
                    var uResult = await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                        (int)MouseOperation.MouseEventFlags.LeftUp, 0, config, LoadingConfigs);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var wHandle = ClickOnPointTool.FindWindow(txtClass.Text, txtName.Text);
            if (wHandle.ToInt64() > 0)
            {
                var no = lsvScripts.Items.Count + 1;
                ListViewItem item = new ListViewItem((no).ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, txtDelay.Text));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"X1:{txtXPos.Text}, Y1:{txtYPos.Text}, Color1:{txtColor1.Text} | X2:{txtX2.Text}, Y2:{txtY2.Text}, Color2:{txtColor2.Text}"));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, txtDescription.Text));
                lsvScripts.Items.Add(item);

                Configs.Add(new Configuration.Config
                {
                    No = no,

                    XPos = string.IsNullOrWhiteSpace(txtXPos.Text) ? 0 : int.Parse(txtXPos.Text),
                    YPos = string.IsNullOrWhiteSpace(txtYPos.Text) ? 0 : int.Parse(txtYPos.Text),
                    ColorName = txtColor1.Text,

                    X2Pos = string.IsNullOrWhiteSpace(txtX2.Text) ? 0 : int.Parse(txtX2.Text),
                    Y2Pos = string.IsNullOrWhiteSpace(txtY2.Text) ? 0 : int.Parse(txtY2.Text),
                    Color2Name = txtColor2.Text,

                    XPosIgnored = string.IsNullOrWhiteSpace(txtXIgnored1.Text) ? 0 : int.Parse(txtXIgnored1.Text),
                    YPosIgnored = string.IsNullOrWhiteSpace(txtYIgnored1.Text) ? 0 : int.Parse(txtYIgnored1.Text),
                    ColorIgnoredName = txtColorIgnored1.Text,

                    XPosMoved = string.IsNullOrWhiteSpace(txtXMoved.Text) ? 0 : int.Parse(txtXMoved.Text),
                    YPosMoved = string.IsNullOrWhiteSpace(txtYMoved.Text) ? 0 : int.Parse(txtYMoved.Text),
                    ColorMovedName = txtColorMoved.Text,

                    WindowClass = txtClass.Text,
                    WindowName = txtName.Text,
                    WindowHandle = wHandle,
                    IsSequential = rdoSequencial.Checked,
                    Description = txtDescription.Text,
                    Delay = string.IsNullOrWhiteSpace(txtDelay.Text) ? 200 : int.Parse(txtDelay.Text),
                    IsDrag = chkDrag.Checked,

                });

                // Reset click points
                txtXPos.Clear();
                txtYPos.Clear();
                txtColor1.Clear();
                txtX2.Clear();
                txtY2.Clear();
                txtColor2.Clear();
                txtXIgnored1.Clear();
                txtYIgnored1.Clear();
                txtColorIgnored1.Clear();
            }
            else
            {
                MessageBox.Show("Application not found. Please re-take the control");
            }
        }
    }
}