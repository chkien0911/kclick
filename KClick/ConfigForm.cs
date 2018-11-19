using Gma.System.MouseKeyHook;
using KClick.Configuration;
using KClick.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClick
{
    public partial class ConfigForm : Form
    {
        public ClubForm ClubForm { get; set; }
        public RerolForm RerolForm { get; set; }
        public ClubShareForm ClubShareForm { get; set; }

        public MainFForm MainFForm { get; set; }
        public ActionForm ActionForm { get; set; }

        public List<Config> Configs { get; set; } = new List<Config>();
        public Configuration.Config Config { get; set; } = new Config();
        public Configuration.GlobalConfig GlobalConfig { get; set; } = new GlobalConfig();

        private IKeyboardMouseEvents m_GlobalHook;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();

            //m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            //m_GlobalHook.MouseDragStarted += M_GlobalHook_MouseDragStarted;
            //m_GlobalHook.MouseDragFinishedExt += M_GlobalHook_MouseDragFinishedExt;
            //m_GlobalHook.MouseUp += M_GlobalHook_MouseUp;
        }

        //private void M_GlobalHook_MouseUp(object sender, MouseEventArgs e)
        //{
        //    txtProgress.AppendText(string.Format("MouseUp: \t{0}; \t Location: \t{1}", e.Button, e.Location));
        //}

        //private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        //{
        //    txtProgress.AppendText(string.Format("MouseMove: \t{0}; \t Location: \t{1}", e.Button, e.Location));
        //}

        //private void M_GlobalHook_MouseDragFinishedExt(object sender, MouseEventExtArgs e)
        //{
        //    txtProgress.AppendText(string.Format("MouseDragFinishedExt: \t{0}; \t Location: \t{1}", e.Button, e.Location));
        //}

        //private void M_GlobalHook_MouseDragStarted(object sender, MouseEventArgs e)
        //{
        //    txtProgress.AppendText(string.Format("MouseDragStarted: \t{0}; \t Location: \t{1}", e.Button, e.Location));
        //}

        //private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //txtProgress.AppendText(string.Format("KeyPress:: \t{0}; \t Location: \t{1}", e.KeyChar));
        //}

        //private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        //{
        //    txtProgress.Clear();
        //    txtProgress.AppendText(string.Format("MouseDownExt: \t{0}; \t Location: \t{1}", e.Button, e.Location));
        //    // uncommenting the following line will suppress the middle mouse button click
        //    // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        //}
        public void Unsubscribe()
        {
            //m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            //m_GlobalHook.MouseDragStarted -= M_GlobalHook_MouseDragStarted;
            //m_GlobalHook.MouseDragFinishedExt -= M_GlobalHook_MouseDragFinishedExt;
            //m_GlobalHook.MouseUp -= M_GlobalHook_MouseUp;

            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }

        public ConfigForm()
        {
            InitializeComponent();

            Load += ConfigForm_Load;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            btnGetPosition.MouseUp += BtnGetPosition_MouseUp;
            btnGetPosition.MouseDown += GetPosition_MouseDown;
            btnGetPosition.MouseHover += GetPosition_MouseHover;

            btnGetPosition2.MouseUp += BtnGetPosition2_MouseUp;
            btnGetPosition2.MouseDown += GetPosition_MouseDown;
            btnGetPosition2.MouseHover += GetPosition_MouseHover;

            btnGetPositionIgnored1.MouseUp += BtnGetPositionIgnored1_MouseUp;
            btnGetPositionIgnored1.MouseDown += GetPosition_MouseDown;
            btnGetPositionIgnored1.MouseHover += GetPosition_MouseHover;

            btnGetPositionMoved.MouseUp += BtnGetPositionMoved_MouseUp;
            btnGetPositionMoved.MouseDown += GetPosition_MouseDown;
            btnGetPositionMoved.MouseHover += GetPosition_MouseHover;

            btnClear1.Click += BtnClear1_Click;
            btnClear2.Click += BtnClear2_Click;
            btnClearIgnored.Click += BtnClearIgnored_Click;
            btnClearMoved.Click += BtnClearMoved_Click;

            chkDrag.CheckedChanged += ChkDrag_CheckedChanged;

            btnReload.Click += BtnReload_Click;
            btnTryClick.Click += async (sender, e) => await btnTryClick_ClickAsync(sender, e);

            //Subscribe();

            FormClosed += ConfigForm_FormClosed;
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Unsubscribe();   
        }

        private async Task btnTryClick_ClickAsync(object sender, EventArgs e)
        {
            var config = GetConfig();
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
                        await MouseOperation.ClickAndDragAsync(GlobalConfig.WindowHandle, new Point(config.XPos, config.YPos), config.ColorName, new Point(config.XPosMoved, config.YPosMoved), new Point(config.XPosIgnored, config.XPosIgnored), config.ColorMovedName);
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

        private void BtnReload_Click(object sender, EventArgs e)
        {
            ConfigForm_Load(sender, e);
        }

        private void BtnClearMoved_Click(object sender, EventArgs e)
        {
            txtXMoved.Clear();
            txtYMoved.Clear();
            txtColorMoved.Clear();
            chkDrag.Checked = false;
            btnGetPositionMoved.Enabled = false;
        }

        private void BtnClearIgnored_Click(object sender, EventArgs e)
        {
            txtXIgnored1.Clear();
            txtYIgnored1.Clear();
            txtColorIgnored1.Clear();
        }
        private void BtnClear2_Click(object sender, EventArgs e)
        {
            txtX2.Clear();
            txtY2.Clear();
            txtColor2.Clear();
        }
        private void BtnClear1_Click(object sender, EventArgs e)
        {
            txtXPos.Clear();
            txtYPos.Clear();
            txtColor1.Clear();
        }

        private void BtnGetPosition_MouseUp(object sender, MouseEventArgs e)
        {
            var point = MouseOperation.GetCursorPosition();

            txtXPos.Text = point.X.ToString();
            txtYPos.Text = point.Y.ToString();

            var color = MouseOperation.GetColorAt(point);
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

        private void GetPosition_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void GetPosition_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private Config GetConfig()
        {
            var config = new Configuration.Config
            {
                No = Config.No,

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

                Description = txtDescription.Text,
                Delay = string.IsNullOrWhiteSpace(txtDelay.Text) ? 200 : int.Parse(txtDelay.Text),
                IsDrag = chkDrag.Checked,

                IsStartIcon = chkIsStartIcon.Checked,
                RunOnce = chkRunOnce.Checked,

                EndWholeScripts = chkEndWholeScripts.Checked,
                IsClosedPosition = chkIsClosedPosition.Checked,

                RunAfterScript = ((Config)cboRunAfterScript.SelectedItem)?.No ?? 0
            };

            return config;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Config.No == 0)
            {
                var config = GetConfig();
                // Add
                if (RerolForm != null)
                {
                    RerolForm.AddScript(config);
                }
                else if (ClubShareForm != null)
                {
                    ClubShareForm.AddScript(config);
                }
                else if (ClubForm != null)
                {
                    ClubForm.AddScript(config);
                }
                else if (MainFForm != null)
                {
                    MainFForm.AddScript(config);
                }
                else if (ActionForm != null)
                {
                    ActionForm.AddScript(config);
                }
            }
            else
            {
                var config = GetConfig();

                // Edit
                if (RerolForm != null)
                {
                    RerolForm.UpdateScript(config);
                }
                else if (ClubShareForm != null)
                {
                    ClubShareForm.UpdateScript(config);
                }
                else if (ClubForm != null)
                {
                    ClubForm.UpdateScript(config);
                }
                else if (MainFForm != null)
                {
                    MainFForm.UpdateScript(config);
                }
                else if (ActionForm != null)
                {
                    ActionForm.UpdateScript(config);
                }
            }

            Close();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            txtXPos.Text = Config.XPos.ToString();
            txtYPos.Text = Config.YPos.ToString();
            txtColor1.Text = Config.ColorName;

            txtX2.Text = Config.X2Pos.ToString();
            txtY2.Text = Config.Y2Pos.ToString();
            txtColor2.Text = Config.Color2Name;

            txtXIgnored1.Text = Config.XPosIgnored.ToString();
            txtYIgnored1.Text = Config.YPosIgnored.ToString();
            txtColorIgnored1.Text = Config.ColorIgnoredName;

            chkDrag.Checked = Config.IsDrag;
            txtXMoved.Text = Config.XPosMoved.ToString();
            txtYMoved.Text = Config.YPosMoved.ToString();
            txtColorMoved.Text = Config.ColorMovedName;

            txtDescription.Text = Config.Description;
            txtDelay.Text = Config.Delay.ToString();

            chkIsStartIcon.Checked = Config.IsStartIcon;
            chkRunOnce.Checked = Config.RunOnce;

            chkEndWholeScripts.Checked = Config.EndWholeScripts;

            chkIsClosedPosition.Checked = Config.IsClosedPosition;

            var source = Configs.ToList();
            source.Insert(0, new Config());
            cboRunAfterScript.DataSource = source;
            cboRunAfterScript.ValueMember = "No";
            cboRunAfterScript.DisplayMember = "DisplayMember";
            cboRunAfterScript.SelectedItem = Configs.FirstOrDefault(s => s.No == Config.RunAfterScript);
        }
    }
}
