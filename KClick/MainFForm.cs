﻿using KClick.Configuration;
using KClick.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Action = KClick.Configuration.Action;

namespace KClick
{
    public partial class MainFForm : Form
    {
        public ZMainForm ZMainForm { get; set; }

        private static List<Configuration.Action> Actions = new List<Configuration.Action>();
        private static Configuration.GlobalConfig GlobalConfig = new Configuration.GlobalConfig();
        private static List<Configuration.Config> SystemConfigs = new List<Configuration.Config>();
        private static List<Configuration.Config> LoadingConfigs = new List<Configuration.Config>();

        private GlobalHotkey ghk;
        private GlobalHotkey ghkMain;
        private static readonly object padlock = new object();

        public MainFForm()
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
            btnNewScript.Click += BtnNewScript_Click;
            btnEditScript.Click += BtnEditScript_Click;
            btnClearScripts.Click += BtnClearScripts_Click1;

            btnTryClick.Click += async (sender, e) => await btnTryClick_ClickAsync(sender, e);
            btnGetMousePosition.Click += BtnGetMousePosition_Click;


            lsvScripts.DoubleClick += LsvScripts_DoubleClick;
            //btnFixColor.Click += async (sender, e) => await BtnFixColor_ClickAsync(sender, e);//BtnFixColor_Click;

            Closed += RerolForm_Closed;


            Load += RerolForm_Load;

            btnAddAction.Click += BtnAddAction_Click;
            btnEditAction.Click += BtnEditAction_Click;

            lsvAction.SelectedValueChanged += LsvAction_SelectedValueChanged;
        }

        private void LsvAction_SelectedValueChanged(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                DisplayListView(action.Configs);
            }
        }

        private int GetX()
        {
            var isOk = int.TryParse(txtX.Text, out int x);
            return isOk ? x : 0;
        }

        private int GetY()
        {
            var isOk = int.TryParse(txtY.Text, out int y);
            return isOk ? y : 0;
        }

        private Action GetSelectedAction()
        {
            return (Action)lsvAction.SelectedItem;
        }

        private IEnumerable<Action> GetCheckedActions()
        {
            var items = lsvAction.CheckedItems;
            foreach (Action item in items)
            {
                yield return item;
            }
        }

        private IEnumerable<Action> GetAllActions()
        {
            var items = lsvAction.Items;
            foreach (Action item in items)
            {
                yield return item;
            }
        }

        private void BtnEditAction_Click(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                using (var form = new ActionForm())
                {
                    form.MainFForm = this;
                    form.Action = action;
                    form.ShowDialog();
                }
            }
        }

        private void BtnAddAction_Click(object sender, EventArgs e)
        {
            using (var form = new ActionForm())
            {
                form.MainFForm = this;
                form.ShowDialog();
            }
        }

        private void BtnClearScripts_Click1(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                action.Configs.Clear();
                lsvScripts.Items.Clear();
            }
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

                //// Merge
                //Configs = Configs
                //    .Union(SystemConfigs)
                //    .Union(LoadingConfigs)
                //    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        DragSlow = item.Element("DragSlow") == null ? false : bool.Parse(item.Element("DragSlow").Value),
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

        private void DisplayListView(IReadOnlyList<Config> configs)
        {
            lsvScripts.Items.Clear();
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


        private void RerolForm_Closed(object sender, EventArgs e)
        {
            ZMainForm?.Show();
        }

        private void BtnEditScript_Click(object sender, EventArgs e)
        {
            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var action = GetSelectedAction();
                    if (action != null)
                    {
                        var config = action?.Configs.FirstOrDefault(s => s.No == no);
                        if (config != null)
                        {
                            using (var form = new ConfigForm())
                            {
                                form.MainFForm = this;
                                form.Config = config;
                                form.Configs = action?.Configs;
                                form.GlobalConfig = GlobalConfig;
                                form.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select an action");
                    }
                }
            }

        }

        private void BtnNewScript_Click(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                using (var form = new ConfigForm())
                {
                    form.MainFForm = this;
                    form.Configs = action.Configs;
                    form.GlobalConfig = GlobalConfig;
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Select an action");
            }
        }

        public void AddScript(Configuration.Config config)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                var no = lsvScripts.Items.Count + 1;
                ListViewItem item = new ListViewItem((no).ToString());
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Delay.ToString()));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"X1:{config.XPos}, Y1:{config.YPos}, Color1:{config.ColorName} | X2:{config.X2Pos}, Y2:{config.Y2Pos}, Color2:{config.Color2Name} | XMoved:{config.XPosMoved}, YMoved:{config.YPosMoved}, ColorMoved:{config.ColorMovedName}"));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, config.Description));
                lsvScripts.Items.Add(item);

                config.No = no;
                action.Configs.Add(config);
            }
        }

        public void UpdateScript(Configuration.Config config)
        {
            if (config.No <= 0)
            {
                return;
            }

            var action = GetSelectedAction();
            if (action != null)
            {
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

                foreach (var item in action.Configs)
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
                        item.DragSlow = config.DragSlow;
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
            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var action = GetSelectedAction();
                    var config = action?.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY()).Find(s => s.No == no);
                    if (config != null)
                    {
                        Cursor.Position = new Point(config.XPos, config.YPos);
                    }
                }
            }
        }

        private async Task btnTryClick_ClickAsync(object sender, EventArgs e)
        {
            if (lsvScripts.SelectedItems.Count > 0)
            {
                var no = int.Parse(lsvScripts.SelectedItems[0].SubItems[0].Text);
                if (no > 0)
                {
                    var action = GetSelectedAction();
                    var config = action?.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY()).FirstOrDefault(s => s.No == no);
                    if (config != null)
                    {
                        if (config.IsDisabledTemp)
                        {
                            MessageBox.Show("Script was disabled temporarily!");
                        }
                        else
                        {
                            if (config.IsDrag)
                            {
                                await MouseOperation.ClickAndDragAsync(GlobalConfig.WindowHandle, config);
                            }
                            else
                            {
                                var isOk = await MouseOperation.ClickSpeedModeAsync(GlobalConfig.WindowHandle, config);
                                if (!isOk)
                                {
                                    MessageBox.Show("Position not found!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BtnClearScripts_Click(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                lsvScripts.Items.Clear();
                action.Configs.Clear();
            }
        }

        private async Task BtnFixColor_ClickAsync(object sender, EventArgs e)
        {
            if (GlobalConfig.IsValid == false)
            {
                MessageBox.Show("Application not found. Please click on Take Control first!");
                return;
            }

            var action = GetSelectedAction();
            if (action != null)
            {
                if (action.Configs.Count == 0)
                {
                    MessageBox.Show("No scripts found to fix color!");
                    return;
                }

                try
                {
                    foreach (var config in action.Configs)
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
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var action = GetSelectedAction();
            if (action != null)
            {
                foreach (ListViewItem eachItem in lsvScripts.SelectedItems)
                {
                    lsvScripts.Items.Remove(eachItem);

                    var no = int.Parse(eachItem.SubItems[0].Text);
                    action.Configs.Remove(action.Configs.FirstOrDefault(s => s.No == no));
                }

                // reorder
                for (int i = 0; i < action.Configs.Count; i++)
                {
                    lsvScripts.Items[i].SubItems[0].Text = (i + 1).ToString();
                    action.Configs[i].No = i + 1;
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var actions = GetAllActions();
            if (actions != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "KClick file|*.xml";
                saveFileDialog.Title = "Save a KScript";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XDocument xML = new XDocument();
                        xML.Add(new XElement("Actions"));

                        foreach (var action in actions)
                        {
                            XElement xmlElement = new XElement("Action",
                                        new XElement("No", action.No),
                                        new XElement("Name", action.Name),
                                new XElement("KScripts")
                                    //new XElement("KScripts")
                                    );

                            //XElement scripts = new XElement("KScripts");
                            if (action.Configs.Count > 0)
                            {
                                foreach (var config in action.Configs)
                                {
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
                                        new XElement("DragSlow", config.DragSlow),
                                        new XElement("Description", config.Description),
                                        new XElement("IsStartIcon", config.IsStartIcon),
                                        new XElement("RunOnce", config.RunOnce),
                                        new XElement("EndWholeScripts", config.EndWholeScripts),
                                        new XElement("IsClosedPosition", config.IsClosedPosition),
                                        new XElement("RunAfterScript", config.RunAfterScript)
                                    );

                                    script.SetAttributeValue("No", config.No);

                                    xmlElement.Element("KScripts").Add(script);
                                }
                            }

                            xmlElement.SetAttributeValue("No", action.No);

                            xML.Element("Actions").Add(xmlElement);
                            //xmlElement.Element("Action").Add(scripts);
                        }

                        xML.Save(saveFileDialog.FileName);

                        MessageBox.Show("Saved!");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
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
                    lsvAction.Items.Clear();
                    lsvScripts.Items.Clear();

                    Actions.Clear();

                    Actions = ImportActions(openFileDialog.FileName);
                    //action.Configs = ImportScript(openFileDialog.FileName);
                    if (Actions.Count > 0)
                    {
                        DisplayAction(Actions);

                        MessageBox.Show(Actions.Count + " action(s) found!");
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

        private void DisplayAction(List<Action> actions)
        {
            lsvAction.Items.Clear();
            if (actions.Count > 0)
            {
                for (int i = 0; i < actions.Count; i++)
                {
                    lsvAction.Items.Add(actions[i]);
                    lsvAction.DisplayMember = "Name";
                    lsvAction.ValueMember = "No";

                    lsvScripts.Items.Clear();
                    for (int j = 0; j < actions[i].Configs.Count; j++)
                    {
                        lsvScripts.Items.Add(actions[i].Configs[j].No.ToString());
                        lsvScripts.Items[j].SubItems.Add(actions[i].Configs[j].Delay.ToString());
                        lsvScripts.Items[j].SubItems.Add(actions[i].Configs[j].Description);
                    }
                }
            }
        }

        private List<Action> ImportActions(string path)
        {
            var xml = XDocument.Load(path);

            var actions = new List<Action>();
            var actionXmls = xml.Descendants("Action").ToList();
            if (actionXmls.Count > 0)
            {
                foreach (var actionXml in actionXmls)
                {
                    var action = new Configuration.Action
                    {
                        No = int.Parse(actionXml.Element("No").Value),
                        Name = (actionXml.Element("Name").Value),
                    };

                    var scripts = actionXml.Descendants("KScript").ToList();

                    if (scripts.Count > 0)
                    {
                        foreach (var item in scripts)
                        {
                            action.Configs.Add(new Configuration.Config
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
                                DragSlow = item.Element("DragSlow") == null
                                    ? false
                                    : bool.Parse(item.Element("DragSlow").Value),
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


                    actions.Add(action);
                }
            }

            return actions;
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

                    //App
                    IntPtr hWndParent = ClickOnPointTool.GetParent(hwnd);

                    if (hWndParent.ToInt64() > 0)
                    {
                        var rct1 = new MouseOperation.RECT();
                        var isOk1 = MouseOperation.GetWindowRect(hWndParent, ref rct1);

                        var caption1 = ClickOnPointTool.GetCaptionOfWindow(hWndParent);

                        // Nox
                        var rctMain = new MouseOperation.RECT();
                        var isOk = MouseOperation.GetWindowRect(hWndParent, ref rctMain);

                        Text = ClickOnPointTool.GetCaptionOfWindow(hWndParent);

                        var width = (rctMain.Right - rctMain.Left);
                        var heigh = (rctMain.Bottom - rctMain.Top);
                        //Text = ClickOnPointTool.GetCaptionOfWindow(hWndParent);

                        GlobalConfig.WindowClass = ClickOnPointTool.GetClassNameOfWindow(hWndParent);
                        GlobalConfig.WindowName = ClickOnPointTool.GetCaptionOfWindow(hWndParent);
                        GlobalConfig.WindowHandle = hWndParent;


                        if (!isOk)
                        {
                            txtX.Text = "0";
                            txtY.Text = "0";

                            GlobalConfig.X = 0;
                            GlobalConfig.Y = 0;
                            GlobalConfig.WindowWidth = 504;
                            GlobalConfig.WindowHigh = 432;
                        }
                        else
                        {
                            txtX.Text = rctMain.Left.ToString();
                            txtY.Text = rctMain.Top.ToString();

                            GlobalConfig.X = rctMain.Left;
                            GlobalConfig.Y = rctMain.Top;
                            GlobalConfig.WindowWidth = width;
                            GlobalConfig.WindowHigh = heigh;
                        }

                        ghk = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, hWndParent);
                        ghkMain = new GlobalHotkey(GlobalHotkey.ALT, Keys.S, this.Handle);
                        ghk.Register();
                        ghkMain.Register();

                        var action = GetSelectedAction();
                        if (action != null)
                        {
                            if (action.Configs.Count > 0)
                            {
                                foreach (var config in action.Configs)
                                {
                                    config.WindowClass = GlobalConfig.WindowClass;
                                    config.WindowName = GlobalConfig.WindowName;
                                    config.WindowHandle = GlobalConfig.WindowHandle;
                                }
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
                        var isOkX = int.TryParse(txtX.Text, out int x);
                        var isOkY = int.TryParse(txtY.Text, out int y);
                        GlobalConfig.X = isOkX ? x : 0;
                        GlobalConfig.Y = isOkY ? y : 0;

                        // Move the window to (0,0)
                        MouseOperation.SetWindowPos(wHandle, IntPtr.Zero, GlobalConfig.X, GlobalConfig.Y, GlobalConfig.WindowWidth, GlobalConfig.WindowHigh, SWP_NOZORDER | SWP_SHOWWINDOW);
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

                var actions = GetCheckedActions();
                if (actions != null)
                {
                    foreach (var action in actions)
                    {
                        if (action != null && action.Configs.Count != 0)
                        {
                            var current = DateTime.Now;

                            //var x = 1;
                            action.IsRun = true;
                            btnRun.Enabled = false;
                            btnStop.Enabled = true;

                            await RunAsync(action);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task RunAsync(Action action)
        {
            while (action.IsRun)
            {
                if (action.BoostTime.Count == 0
                                || action.BoostTime.Any(s => s.FromTime <= DateTime.Now && DateTime.Now <= s.ToTime))
                {
                    if (action.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY()).Any(s => s.IsDisabledWholeScripts))
                    {
                        action.IsRun = false;
                        return;
                    }

                    var tasks = new List<Task>();

                    var configs = action.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY());
                    if (!configs.Any(s => s.IsDisabledWholeScripts))
                    {
                        foreach (var config in configs)
                        {
                            if (config.IsDisabledTemp == false && config.CanRun)
                            {
                                tasks.Add(RunAsync(config));
                            }
                        }
                    }

                    await Task.WhenAll(tasks);
                }
                else
                {
                    var delay = 60 * 1000;
                    await Task.Delay(delay);
                }
            }

        }

        private async Task RunAsync(Configuration.Config config)
        {
            await Task.Delay(config.Delay);

            //lock (padlock)
            //{
            //    if (isRun == false)
            //    {
            //        return;
            //    }
            //}

            // Make Calculator the foreground application and send it 
            MouseOperation.SetForegroundWindow(GlobalConfig.WindowHandle);

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
                await MouseOperation.ClickAndDragAsync(GlobalConfig.WindowHandle, config);
            }
            else
            {
                var isOk = await MouseOperation.ClickSpeedModeAsync(GlobalConfig.WindowHandle, config);

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

                    var action = GetSelectedAction();
                    if (action != null)
                    {
                        var configs = action.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY()).Where(s => s.RunAfterScript == config.No).ToList();
                        if (configs.Count > 0)
                        {
                            foreach (var config1 in configs)
                            {
                                config1.CanRun = true;
                            }
                        }

                        if (config.CanRun && config.RunAfterScript > 0)
                        {
                            var subConfigs = action.GetAdjustedConfigs(chkAdjustAuto.Checked, GetX(), GetY()).Where(s => s.RunAfterScript == config.RunAfterScript).ToList();
                            foreach (var subConfig in subConfigs)
                            {
                                subConfig.CanRun = false;
                            }
                        }
                    }
                }
            }
        }

        private async Task StopAsync()
        {
            lock (padlock)
            {
                foreach (var action in Actions)
                {
                    if (action.IsRun)
                    {
                        action.IsRun = false;
                    }
                }
            }

            btnRun.Enabled = true;
            btnStop.Enabled = false;
            await Task.Delay(100);
        }

        public void AddAction(Configuration.Action action)
        {
            var no = lsvAction.Items.Count + 1;
            action.No = no;

            lsvAction.Items.Add(action);
            lsvAction.DisplayMember = "Name";
            lsvAction.ValueMember = "No";

            DisplayListView(action.Configs);

            Actions.Add(action);
        }

        public void EditAction(Configuration.Action action)
        {
            if (action.No <= 0)
            {
                return;
            }

            foreach (Action item in lsvAction.Items)
            {
                if (item.No == action.No)
                {
                    item.Name = action.Name;
                }
            }

            foreach (var item in Actions)
            {
                if (item.No == action.No)
                {
                    item.Name = action.Name;

                    break;
                }
            }

            DisplayListView(action.Configs);
        }
    }
}
