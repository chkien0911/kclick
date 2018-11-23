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
using KClick.Configuration;
using Action = KClick.Configuration.Action;

namespace KClick
{
    public enum Actions
    {
        Club_Join = 1,
        Club_Share = 2,
        Global_Join = 3,
        Global_Share = 4,
        Panel_Shootout = 5,
        Event_Mission = 6,
        Tsucup_Regular = 7,
    }


    public partial class ClubForm : Form
    {
        public ZMainForm ZMainForm { get; set; }

        private static List<Configuration.Raid> Raids = new List<Configuration.Raid>()
        {
            new Raid(){ No = 1, Name = "Get Hidden Drills"}
        };

        private static List<Configuration.Nox> Noxes = new List<Nox>();
        private static List<Configuration.Config> SystemConfigs = new List<Configuration.Config>();
        private static List<Configuration.Config> LoadingConfigs = new List<Configuration.Config>();

        private GlobalHotkey ghk;
        private static readonly object padlock = new object();

        public ClubForm()
        {
            InitializeComponent();

            MaximumSize = Size;

            btnFindControl.MouseUp += BtnFindControl_MouseUp;
            btnFindControl.MouseDown += BtnFindControl_MouseDown;
            btnFindControl.MouseHover += BtnFindControl_MouseHover;

            btnFixControl.Click += BtnFixControl_Click;

            btnRun.Click += async (sender, e) => await BtnRun_ClickAsync(sender, e);
            btnStop.Click += async (sender, e) => await BtnStop_ClickAsync(sender, e);

            btnDelete.Click += BtnDelete_Click;
            btnNewScript.Click += BtnNewScript_Click;
            btnEditScript.Click += BtnEditScript_Click;
            btnClearScript.Click += BtnClearScript_Click;

            btnTryClick.Click += async (sender, e) => await btnTryClick_ClickAsync(sender, e);
            btnGetMousePosition.Click += BtnGetMousePosition_Click;


            lsvScripts.DoubleClick += LsvScripts_DoubleClick;

            Closed += RerolForm_Closed;

            Load += RerolForm_Load;

            lsvNox.SelectedValueChanged += LsvNox_SelectedValueChanged;
            lsvAction.ItemCheck += async (sender, e) => await LsvAction_ItemCheckAsync(sender, e);//+= LsvAction_ItemCheck;
            lsvNox.ItemCheck += async (sender, e) => await LsvNox_ItemCheckAsync(sender, e);//LsvNox_ItemCheck;

            btnExport.Click += BtnExport_Click;
        }

        private async Task LsvAction_ItemCheckAsync(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                await StopAsync();
            }

            var nox = GetSelectedNox();
            if (nox == null)
            {
                //MessageBox.Show("Please take control & select a Nox");
                return;
            }

            //nox.Actions.Clear();
            //nox.Configs.Clear();
            //for (int i = 0; i < lsvAction.Items.Count; i++)
            //{
            //    if (i != e.Index)
            //    {
            //        lsvAction.SetItemChecked(i, false);
            //    }
            //}
            //lsvScripts.Items.Clear();

            if (e.NewValue == CheckState.Checked)
            {
                nox.Actions = new List<Action>() { (Action)lsvAction.Items[e.Index] };

                if (nox.IsRun)
                {
                    MessageBox.Show("Nox is runing");

                    btnStop.Enabled = true;
                    btnRun.Enabled = false;
                }
                else
                {
                    LoadScripts(nox);
                }
            }
        }

        private async Task LsvNox_ItemCheckAsync(object sender, ItemCheckEventArgs e)
        {
            var selectedNox = (Nox)lsvNox.SelectedItem;
            var nox = Noxes.FirstOrDefault(s => s.No == selectedNox.No);

            for (int i = 0; i < lsvAction.Items.Count; i++)
            {
                lsvAction.SetItemChecked(i, false);
            }
            lsvScripts.Items.Clear();
            nox.Actions.Clear();
            nox.Configs.Clear();

            if (nox.IsRun)
            {
                btnStop.Enabled = true;
                btnRun.Enabled = false;
            }
            else
            {
                btnStop.Enabled = false;
                btnRun.Enabled = true;
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                await StopAsync();
            }

            nox.IsSelected = e.NewValue == CheckState.Checked;
        }

        private void LsvNox_SelectedValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < lsvAction.Items.Count; i++)
            {
                lsvAction.SetItemChecked(i, false);
            }
            lsvScripts.Items.Clear();

            if (lsvNox.SelectedItems.Count > 0)
            {
                var nox = GetSelectedNox();
                if (nox != null)
                {
                    for (int i = 0; i < lsvAction.Items.Count; i++)
                    {
                        var item = (Action)lsvAction.Items[i];
                        if (item.No == nox.Actions?.FirstOrDefault()?.No)
                        {
                            lsvAction.SetItemChecked(i, true);
                        }
                    }

                    if (nox.IsRun)
                    {
                        //MessageBox.Show("Nox is runing");

                        btnStop.Enabled = true;
                        btnRun.Enabled = false;
                    }
                    else
                    {
                        LoadScripts(nox);
                    }
                }
            }
        }


        private void BtnClearScript_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            nox.Configs.Clear();

            lsvScripts.Items.Clear();
        }


        private void RerolForm_Load(object sender, EventArgs e)
        {
            try
            {
                var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                var systemXmlPath = "/templates/system/main_actions.xml";
                SystemConfigs = ImportScript($"{appPath}/{systemXmlPath}");

                //var loadingXmlPath = "/templates/system/loading.xml";
                //LoadingConfigs = ImportScript($"{appPath}/{loadingXmlPath}");

                //var closeGameXmlPath = "/templates/system/close_game.xml";
                //ClosePositionConfigs = ImportScript($"{appPath}/{closeGameXmlPath}");

                cboRaidNumber.DataSource = Raids;
                cboRaidNumber.DisplayMember = "Name";
                cboRaidNumber.ValueMember = "No";
                cboRaidNumber.SelectedIndex = 0;

                lsvAction.DataSource = Enum.GetValues(typeof(Actions))
                    .Cast<Actions>()
                    .Select(p => new Action { No = (int)p, Name = p.ToString()})
                    .ToList();
                lsvAction.DisplayMember = "Name";
                lsvAction.ValueMember = "No";

                //lsvNox.DataSource = Noxes;
                lsvNox.DisplayMember = "Name";
                lsvNox.ValueMember = "No";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadScripts(Nox nox)
        {
            if (nox.Actions.Count > 0)
            {
                if (nox.Configs.Count == 0)
                {
                    var xmlPath = GetXmlPath(nox.Actions.FirstOrDefault());

                    //nox.Actions = new List<Action>() { (Action)lsvAction.CheckedItems[0] };
                    nox.Configs = ImportScript(xmlPath);
                }

                DisplayListView(nox.Configs);
            }
        }


        private string GetXmlPath(Action action)
        {
            var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var xmlPath = "";

            switch (action.No)
            {
                case (int)Actions.Club_Join:
                    xmlPath = "/templates/custom/club_join.xml";
                    break;
                case (int)Actions.Club_Share:
                    xmlPath = "/templates/custom/club_share_hiddendrill.xml";
                    break;
                case (int)Actions.Event_Mission:
                    xmlPath = "/templates/custom/event_mission.xml";
                    break;
                case (int)Actions.Global_Join:
                    xmlPath = "/templates/custom/global_join.xml";
                    break;
                case (int)Actions.Global_Share:
                    xmlPath = "/templates/custom/global_share.xml";
                    break;
                case (int)Actions.Panel_Shootout:
                    xmlPath = "/templates/custom/panel_shootout.xml";
                    break;
                case (int)Actions.Tsucup_Regular:
                    xmlPath = "/templates/custom/tsucup_regular.xml";
                    break;
                default:
                    break;
            }

            return $"{appPath}/{xmlPath}";
        }

        private static List<Config> ImportScript(string path)
        {
            var configs = new List<Config>();

            try
            {
                var xml = XDocument.Load(path);

                var scripts = xml.Descendants("KScript").ToList();


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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return configs;
        }

        private void DisplayListView(IReadOnlyList<Config> configs)
        {
            lsvScripts.Items.Clear();
            if (configs.Count > 0)
            {
                for (int i = 0; i < configs.Count; i++)
                {
                    lsvScripts.Items.Add(configs[i].No.ToString());
                    //lsvScripts.Items[i].SubItems.Add(
                    //    $"X1:{configs[i].XPos}, Y1:{configs[i].YPos}, Color1:{configs[i].ColorName} | X2:{configs[i].X2Pos}, Y2:{configs[i].Y2Pos}, Color2:{configs[i].Color2Name} | XMoved:{configs[i].XPosMoved}, YMoved:{configs[i].YPosMoved}, ColorMoved:{configs[i].ColorMovedName}"
                    //);
                    lsvScripts.Items[i].SubItems.Add(configs[i].Delay.ToString());
                    lsvScripts.Items[i].SubItems.Add(configs[i].Description);

                }
            }
        }

        private void RerolForm_Closed(object sender, EventArgs e)
        {
            ZMainForm?.Show();
        }

        private Nox GetSelectedNox()
        {
            if (lsvNox.CheckedItems.Count <= 0) return null;
            if (lsvNox.SelectedItems.Count <= 0) return null;


            foreach (var selectedItem in lsvNox.SelectedItems)
            {
                var selectedI = (Nox)selectedItem;

                foreach (var checkedItem in lsvNox.CheckedItems)
                {
                    var checkedI = (Nox)checkedItem;

                    if (selectedI.No == checkedI.No)
                    {
                        return Noxes.Find(s => s.No == selectedI.No && s.IsSelected);
                    }
                }
            }

            return null;
        }

        private void BtnEditScript_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            if (lsvScripts.SelectedItems.Count > 0)
            {
                if (nox.IsRun)
                {
                    MessageBox.Show("Nox is runing");
                }
                else
                {
                    var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                    if (no > 0)
                    {
                        var configs = nox.Configs;
                        var config = configs.FirstOrDefault(s => s.No == no);
                        if (config != null)
                        {
                            using (var form = new ConfigForm())
                            {
                                form.ClubForm = this;
                                form.Config = config;
                                form.Configs = configs;
                                form.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void BtnNewScript_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            if (nox.IsRun)
            {
                MessageBox.Show("Nox is runing");
                return;
            }

            var configs = nox.Configs;

            using (var form = new ConfigForm())
            {
                form.ClubForm = this;
                form.Configs = configs;
                form.ShowDialog();
            }

        }

        public void AddScript(Configuration.Config config)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            var no = lsvScripts.Items.Count + 1;
            ListViewItem item = new ListViewItem((no).ToString());
            //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"X1:{config.XPos}, Y1:{config.YPos}, Color1:{config.ColorName} | X2:{config.X2Pos}, Y2:{config.Y2Pos}, Color2:{config.Color2Name} | XMoved:{config.XPosMoved}, YMoved:{config.YPosMoved}, ColorMoved:{config.ColorMovedName}"));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Delay.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Description));
            lsvScripts.Items.Add(item);

            config.No = no;

            nox.Configs.Add(config);
        }

        public void UpdateScript(Configuration.Config config)
        {
            if (config.No <= 0)
            {
                return;
            }

            foreach (ListViewItem eachItem in lsvScripts.Items)
            {
                if (eachItem.SubItems[0].Text == config.No.ToString())
                {
                    //eachItem.SubItems[1].Text = $"X1:{config.XPos}, Y1:{config.YPos}, Color1:{config.ColorName} | X2:{config.X2Pos}, Y2:{config.Y2Pos}, Color2:{config.Color2Name} | XMoved:{config.XPosMoved}, YMoved:{config.YPosMoved}, ColorMoved:{config.ColorMovedName}";
                    eachItem.SubItems[1].Text = config.Delay.ToString();
                    eachItem.SubItems[2].Text = config.Description;

                    break;
                }
            }

            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }
            foreach (var item in nox.Configs)
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

        private void LsvScripts_DoubleClick(object sender, EventArgs e)
        {
            btnEditScript.PerformClick();
        }

        public sealed override Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
        }

        private void BtnGetMousePosition_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var configs = nox.Configs;
                    var config = configs.FirstOrDefault(s => s.No == no);
                    if (config != null)
                    {
                        Cursor.Position = new Point(config.XPos, config.YPos);
                    }
                }
            }
        }

        private async Task btnTryClick_ClickAsync(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var configs = nox.Configs;
                    var config = configs.FirstOrDefault(s => s.No == no);
                    if (config != null)
                    {
                        if (config.IsDisabledTemp)
                        {
                            MessageBox.Show("Script was disabled temporarily!");
                        }
                        else
                        {
                            var isOk = await MouseOperation.ClickSpeedModeAsync(nox.Handle, config);
                            if (!isOk)
                            {
                                MessageBox.Show("Position not found!");
                            }
                        }
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            var configs = nox.Configs;
            foreach (ListViewItem eachItem in lsvScripts.SelectedItems)
            {
                lsvScripts.Items.Remove(eachItem);

                var no = int.Parse(eachItem.SubItems[0].Text);
                configs.Remove(configs.FirstOrDefault(s => s.No == no));
            }

            // reorder
            for (int i = 0; i < configs.Count; i++)
            {
                lsvScripts.Items[i].SubItems[0].Text = (i + 1).ToString();
                configs[i].No = i + 1;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var nox = GetSelectedNox();
            if (nox == null)
            {
                MessageBox.Show("Please take control & select a Nox");
                return;
            }

            var configs = nox.Configs;
            if (configs.Count == 0)
            {
                MessageBox.Show("No scripts found to save!");
                return;
            }

            try
            {
                XDocument xML = new XDocument();
                xML.Add(new XElement("KScrips"));

                for (int i = 0; i < configs.Count; i++)
                {
                    var config = configs[i];

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
                        new XElement("Description", config.Description),
                        new XElement("IsStartIcon", config.IsStartIcon),
                        new XElement("RunOnce", config.RunOnce),
                        new XElement("EndWholeScripts", config.EndWholeScripts),
                        new XElement("IsClosedPosition", config.IsClosedPosition),
                        new XElement("RunAfterScript", config.RunAfterScript)
                    );

                    script.SetAttributeValue("No", config.No);

                    xML.Element("KScrips").Add(script);
                }

                xML.Save(GetXmlPath(nox.Actions.FirstOrDefault()));

                MessageBox.Show("Saved!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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

                    var nox = GetSelectedNox();
                    if (nox == null)
                    {
                        MessageBox.Show("Please take control & select a Nox");
                        return;
                    }
                    nox.Configs.Clear();

                    List<Config> configs = ImportScript(openFileDialog.FileName);
                    if (configs.Count > 0)
                    {
                        DisplayListView(configs);
                        MessageBox.Show(configs.Count + " script(s) found!");
                    }
                    else
                    {
                        MessageBox.Show("No scripts found!");
                    }

                    nox.Configs = configs;
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
                    var className = new StringBuilder(256);
                    var nRet = MouseOperation.GetClassName(hwnd, className, className.Capacity);

                    //For Parent 
                    IntPtr hWndParent = ClickOnPointTool.GetParent(hwnd);
                    if (hWndParent.ToInt64() > 0)
                    {
                        //if (string.IsNullOrWhiteSpace(GlobalConfig.WindowName))
                        //{
                        //    Text += "(" + ClickOnPointTool.GetCaptionOfWindow(hWndParent) + ")";
                        //}

                        //GlobalConfig.WindowClass = ClickOnPointTool.GetClassNameOfWindow(hWndParent);
                        //GlobalConfig.WindowName = ClickOnPointTool.GetCaptionOfWindow(hWndParent);
                        //GlobalConfig.WindowHandle = hWndParent;

                        var name = ClickOnPointTool.GetCaptionOfWindow(hWndParent);

                        //ghk = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, hWndParent);
                        //ghk.Register();

                        //if (Configs.Count > 0)
                        //{
                        //    foreach (var config in Configs)
                        //    {
                        //        config.WindowClass = GlobalConfig.WindowClass;
                        //        config.WindowName = GlobalConfig.WindowName;
                        //        config.WindowHandle = GlobalConfig.WindowHandle;
                        //    }
                        //}

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            if (Noxes.All(s => s.Name != name))
                            {
                                var nox = new Nox()
                                {
                                    No = lsvNox.Items.Count + 1,
                                    Name = name,
                                    Class = ClickOnPointTool.GetClassNameOfWindow(hWndParent),
                                    Handle = hWndParent
                                };

                                Noxes.Add(nox);

                                lsvNox.Items.Add(nox);
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
                if (lsvNox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Application not found. Please click on Take Control first!");
                }
                else
                {
                    for (int i = 0; i < lsvNox.CheckedItems.Count; i++)
                    {
                        var checkedItem = lsvNox.CheckedItems[i] is Nox ? (Nox)lsvNox.CheckedItems[i] : default(Nox);

                        var item = Noxes.FirstOrDefault(s => s.No == checkedItem.No);

                        if (item != null)
                        {
                            item.X = (item.Width * i) + (50 * i);
                            item.Y = 0;

                            var wHandle = MouseOperation.FindWindow(item.Class, item.Name);

                            // If found, position it.
                            if (wHandle != IntPtr.Zero)
                            {
                                // Move the window
                                MouseOperation.SetWindowPos(wHandle, IntPtr.Zero, item.X, item.Y, item.Width, item.High, SWP_NOZORDER | SWP_SHOWWINDOW);
                            }
                            else
                            {
                                MessageBox.Show("Application not found. Please click on Take Control first!");
                            }
                        }
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
                if (Noxes.Count == 0)
                {
                    MessageBox.Show("Application not found. Please click on Take Control first!");
                    return;
                }

                //var x = 1;

                btnRun.Enabled = false;
                btnStop.Enabled = true;

                var nox = GetSelectedNox();
                if (nox == null)
                {
                    MessageBox.Show("Please take control & select a Nox");
                    return;
                }

                //foreach (var nox in Noxes)
                //{
                nox.IsRun = true;

                while (nox.IsRun)
                {
                    await RunAsync(nox);

                    if (nox.Configs.Any(s => s.IsDisabledWholeScripts))
                    {
                        nox.IsRun = false;
                    }
                }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task RunAsync(Nox nox)
        {
            List<Task> tasks = new List<Task>();

            foreach (var config in SystemConfigs)
            {
                if (config.IsDisabledTemp == false && config.CanRun)
                {
                    tasks.Add(RunAsync(nox, config));
                }
            }

            foreach (var config in LoadingConfigs)
            {
                if (config.IsDisabledTemp == false && config.CanRun)
                {
                    tasks.Add(RunAsync(nox, config));
                }
            }

            if (!nox.Configs.Any(s => s.IsDisabledWholeScripts))
            {
                foreach (var config in nox.Configs)
                {
                    if (config.IsDisabledTemp == false && config.CanRun)
                    {
                        tasks.Add(RunAsync(nox, config));
                    }
                }
            }

            await Task.WhenAll(tasks);
        }

        private async Task RunAsync(Nox nox, Configuration.Config config)
        {
            await Task.Delay(config.Delay);

            lock (padlock)
            {
                if (nox.IsRun == false)
                {
                    return;
                }
            }

            // Make Calculator the foreground application and send it 
            MouseOperation.SetForegroundWindow(nox.Handle);

            if (LoadingConfigs != null && LoadingConfigs.Count > 0)
            {
                var loadingItem = LoadingConfigs[0];

                // wait for 10s
                //bool isOk = false;
                //for (var i = 0; i < 30; i++)
                //{
                //    var loadingColor = MouseOperation.GetColorAt(new Point(loadingItem.XPos, loadingItem.YPos));
                //    if (loadingColor.Name != loadingItem.ColorName)
                //    {
                //        isOk = true;
                //        break;
                //    }

                //    Debug.WriteLine("Loading...");
                //    await Task.Delay(1000);
                //}

                //if (isOk == false)
                //{
                //    // click on button Close to restart
                //    foreach (var closedPos in ClosePositionConfigs)
                //    {
                //        await MouseOperation.ClickSpeedModeAsync(GlobalConfig.WindowHandle, closedPos);
                //    }
                //}
            }

            if (config.IsDrag)
            {
                await MouseOperation.ClickAndDragAsync(nox.Handle, new Point(config.XPos, config.YPos), config.ColorName, new Point(config.XPosMoved, config.YPosMoved), new Point(config.XPosIgnored, config.XPosIgnored), config.ColorMovedName);
            }
            else
            {
                var isOk = await MouseOperation.ClickSpeedModeAsync(nox.Handle, config);

                if (isOk)
                {
                    // Do something else
                    if (config.RunOnce)
                    {
                        config.IsDisabledTemp = true;
                    }

                    if (config.EndWholeScripts)
                    {
                        config.IsDisabledWholeScripts = true;
                    }

                    var configs = nox.Configs.Where(s => s.RunAfterScript == config.No).ToList();
                    if (configs.Count > 0)
                    {
                        foreach (var config1 in configs)
                        {
                            config1.CanRun = true;
                        }
                    }

                    if (config.CanRun && config.RunAfterScript > 0)
                    {
                        var subConfigs = nox.Configs.Where(s => s.RunAfterScript == config.RunAfterScript).ToList();
                        foreach (var subConfig in subConfigs)
                        {
                            subConfig.CanRun = false;
                        }
                    }
                }
            }
        }

        private async Task StopAsync()
        {
            lock (padlock)
            {
                var nox = GetSelectedNox();
                if (nox == null)
                {
                    //MessageBox.Show("Please take control & select a Nox");
                    return;
                }
                if (nox.IsRun)
                {
                    nox.IsRun = false;
                }
            }

            btnRun.Enabled = true;
            btnStop.Enabled = false;

            await Task.Delay(100);
        }
    }
}
