using KClick.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KClick
{


    public partial class RerolForm : Form
    {
        private static Configuration.GlobalConfig GlobalConfig = new Configuration.GlobalConfig();
        private static List<Configuration.Config> Configs = new List<Configuration.Config>();

        private GlobalHotkey ghk;
        private static bool isRun = true;
        private static readonly object padlock = new object();

        public RerolForm()
        {
            InitializeComponent();

            MaximumSize = Size;

            //btnFindControl.Click += BtnFindControl_Click;
            btnFindControl.MouseUp += BtnFindControl_MouseUp;
            btnFindControl.MouseDown += BtnFindControl_MouseDown;
            btnFindControl.MouseHover += BtnFindControl_MouseHover;

            btnFixControl.Click += BtnFixControl_Click;

            btnRun.Click += async (sender, e) => await BtnRun_ClickAsync(sender, e);
            btnStop.Click += async (sender, e) => await BtnStop_ClickAsync(sender, e);

            btnImport.Click += BtnImport_Click;
            btnExport.Click += BtnExport_Click;

            btnDelete.Click += BtnDelete_Click;
            btnClearScripts.Click += BtnClearScripts_Click;

            //btnFixColor.Click += async (sender, e) => await BtnFixColor_ClickAsync(sender, e);//BtnFixColor_Click;
        }

        private void BtnClearScripts_Click(object sender, EventArgs e)
        {
            lsvScripts.Items.Clear();
            Configs.Clear();
        }

        private async Task BtnFixColor_ClickAsync(object sender, EventArgs e)
        {
            if (GlobalConfig.IsValid == false)
            {
                MessageBox.Show("Application not found. Please click on Take Control first!");
                return;
            }

            if (Configs.Count == 0)
            {
                MessageBox.Show("No scripts found to fix color!");
                return;
            }

            try
            {
                foreach (var config in Configs)
                {
                    if (config.IsPosition1Valid)
                    {
                        var point1 = new Point(config.XPos, config.YPos);
                        var color1 = MouseOperation.GetColorAt(point1);
                        if (color1.IsKnownColor)
                        {
                            config.ColorName = color1.Name;
                        }
                    }

                    if (config.IsPosition2Valid)
                    {
                        var point2 = new Point(config.X2Pos, config.Y2Pos);
                        var color2 = MouseOperation.GetColorAt(point2);
                        if (color2.IsKnownColor)
                        {
                            config.Color2Name = color2.Name;
                        }
                    }

                    if (config.IsPositionIgnoredValid)
                    {
                        var pointIgnored = new Point(config.XPosIgnored, config.YPosIgnored);
                        var colorIgnored = MouseOperation.GetColorAt(pointIgnored);
                        if (colorIgnored.IsKnownColor)
                        {
                            config.ColorIgnoredName = colorIgnored.Name;
                        }
                    }

                    if (config.IsPositionMovedValid)
                    {
                        var pointMoved = new Point(config.XPosMoved, config.YPosMoved);
                        var colorMoved = MouseOperation.GetColorAt(pointMoved);
                        if (colorMoved.IsKnownColor)
                        {
                            config.ColorMovedName = colorMoved.Name;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (Configs.Count == 0)
            {
                MessageBox.Show("No scripts found to save!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "KClick file|*.xml";
            saveFileDialog.Title = "Save a KScript";

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
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
                            new XElement("IsSequential", config.IsSequential),
                            new XElement("IsDrag", config.IsDrag),
                            new XElement("Description", config.Description)
                        );

                        script.SetAttributeValue("No", config.No);

                        xML.Element("KScrips").Add(script);
                    }

                    //testXML.Element("KScripts").Add(newStudent);
                    xML.Save(saveFileDialog.FileName);

                    MessageBox.Show("Saved!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
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
                    Configs.Clear();

                    XDocument xml = XDocument.Load(openFileDialog.FileName);

                    var scripts = xml.Descendants("KScript");

                    if (scripts != null && scripts.Any())
                    {
                        int i = 0;
                        foreach (var item in scripts)
                        {
                            lsvScripts.Items.Add(item.Element("No").Value);
                            lsvScripts.Items[i].SubItems.Add(
                                $"X1:{item.Element("X").Value}, Y1:{item.Element("Y").Value}, Color1:{item.Element("Color").Value} | X2:{item.Element("X2").Value}, Y2:{item.Element("Y2").Value}, Color2:{item.Element("Color2").Value} | XMoved:{item.Element("XMoved").Value}, YMoved:{item.Element("YMoved").Value}, ColorMoved:{item.Element("ColorMoved").Value}"
                            );
                            lsvScripts.Items[i].SubItems.Add(item.Element("Description").Value);

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

                                Description = (item.Element("Description").Value),
                                Delay = int.Parse(item.Element("Delay").Value),
                                IsSequential = bool.Parse(item.Element("IsSequential").Value),
                                IsDrag = bool.Parse(item.Element("IsDrag").Value),
                            });

                            i++;
                        }

                        MessageBox.Show(scripts.Count() + " script(s) found!");
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

        private void BtnFindControl_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void BtnFindControl_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void BtnFindControl_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var point = MouseOperation.GetCursorPosition();

                var hwnd = MouseOperation.WindowFromPoint(new POINT { X = point.X, Y = point.Y });
                if (hwnd.ToInt64() > 0)
                {
                    StringBuilder className = new StringBuilder(256);
                    var nRet = MouseOperation.GetClassName(hwnd, className, className.Capacity);

                    //For Parent 
                    IntPtr hWndParent = ClickOnPointTool.GetParent(hwnd);
                    if (hWndParent.ToInt64() > 0)
                    {
                        if (string.IsNullOrWhiteSpace(GlobalConfig.WindowName))
                        {
                            Text += "(" + ClickOnPointTool.GetCaptionOfWindow(hWndParent) + ")";
                        }

                        GlobalConfig.WindowClass = ClickOnPointTool.GetClassNameOfWindow(hWndParent);
                        GlobalConfig.WindowName = ClickOnPointTool.GetCaptionOfWindow(hWndParent);
                        GlobalConfig.WindowHandle = hWndParent;

                        ghk = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, hWndParent);
                        ghk.Register();

                        if (Configs.Count > 0)
                        {
                            foreach (var config in Configs)
                            {
                                config.WindowClass = GlobalConfig.WindowClass;
                                config.WindowName = GlobalConfig.WindowName;
                                config.WindowHandle = GlobalConfig.WindowHandle;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No parent application found!");
                    }
                }
                else
                {
                    MessageBox.Show("No application found!");
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnFixControl_Click(object sender, EventArgs e)
        {
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            try
            {
                if (GlobalConfig.IsValid == false)
                {
                    MessageBox.Show("Application not found. Please click on Take Control first!");
                }
                else
                {
                    // Find (the first-in-Z-order) Notepad window.
                    var wHandle = MouseOperation.FindWindow(GlobalConfig.WindowClass, GlobalConfig.WindowName);

                    // If found, position it.
                    if (wHandle != IntPtr.Zero)
                    {
                        // Move the window to (0,0)
                        MouseOperation.SetWindowPos(wHandle, IntPtr.Zero, 0, 0, GlobalConfig.WindowWidth, GlobalConfig.WindowHigh, SWP_NOZORDER | SWP_SHOWWINDOW);
                    }
                    else
                    {
                        MessageBox.Show("Application not found. Please click on Take Control first!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async Task BtnStop_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await StopAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task BtnRun_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                // Verify that Calculator is a running process.
                if (GlobalConfig.IsValid == false)
                {
                    MessageBox.Show("Application not found. Please click on Take Control first!");
                    return;
                }

                if (Configs.Count == 0)
                {
                    MessageBox.Show("No scripts found!");
                    return;
                }

                //var x = 1;
                isRun = true;
                btnRun.Enabled = false;
                btnStop.Enabled = true;
                while (isRun)
                {
                    await RunAsync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task RunAsync()
        {
            List<Task> tasks = new List<Task>();

            foreach (var config in Configs)
            {
                tasks.Add(RunAsync(config));
                //await RunAsync(config);
            }

            await Task.WhenAll(tasks);
        }

        private async Task RunAsync(Configuration.Config config)
        {
            await Task.Delay(config.Delay);

            lock (padlock)
            {
                if (isRun == false)
                {
                    return;
                }
            }

            // Make Calculator the foreground application and send it 
            MouseOperation.SetForegroundWindow(config.WindowHandle);

            //if (LoadingConfigs != null && LoadingConfigs.Count > 0)
            //{
            //    var loadingItem = LoadingConfigs[0];
            //    var loadingColor = await MouseOperation.GetColorAt(new Point(loadingItem.XPos, loadingItem.YPos));
            //    while (loadingColor.Name == loadingItem.ColorName)
            //    {
            //        txtProgress.AppendText($"- Script No : {config.No}. Loading.... {Environment.NewLine}");

            //        loadingColor = await MouseOperation.GetColorAt(new Point(loadingItem.XPos, loadingItem.YPos));

            //    }
            //}

            if (config.IsDrag)
            {
                await MouseOperation.ClickAndDragAsync(config.WindowHandle, new Point(config.XPos, config.YPos), config.ColorName, new Point(config.XPosMoved, config.YPosMoved), new Point(config.XPosIgnored, config.XPosIgnored), config.ColorMovedName);
            }
            else
            {
                var isOk = await MouseOperation.ClickSpeedModeAsync(config.WindowHandle, config);

                if (isOk)
                {
                    // do something else

                }
                //await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                //    (int)MouseOperation.MouseEventFlags.LeftDown, 1, config);

                //Debug.WriteLine($"- Script No : {config.No}. Left down");
                //await MouseOperation.SendMessageSpeedModeAsync(config.WindowHandle,
                //    (int)MouseOperation.MouseEventFlags.LeftUp, 0, config);

                //Debug.WriteLine($"- Script No : {config.No}. Left up");

                //await Task.Delay(100);

            }
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
            await Task.Delay(100);
        }
    }
}
