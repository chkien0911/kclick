using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KClick.Configuration;
using KClick.Utilities;

namespace KClick
{
    public partial class ConfigForm : Form
    {
        public RerolForm RerolForm { get; set; }
        public Configuration.Config Config { get; set; } = new Config();
        public Configuration.GlobalConfig GlobalConfig { get; set; } = new GlobalConfig();

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Config.No == 0)
            {
                // Add
                RerolForm.AddScript(new Configuration.Config
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
                });
            }
            else
            {
                // Edit
                RerolForm.UpdateScript(new Configuration.Config
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
                });
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
        }
    }
}
