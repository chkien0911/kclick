using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using KClick.Utilities;

namespace KClick
{
    public partial class MouseHookKeyForm : Form
    {
        public ZMainForm ZMainForm { get; set; }
        public MouseHookKeyForm()
        {
            InitializeComponent();

            Subscribe();

            Closed += MouseHookKeyForm_Closed;
        }

        private void MouseHookKeyForm_Closed(object sender, EventArgs e)
        {
            Unsubscribe();
            ZMainForm.Show();
        }

        #region Global key


        private IKeyboardMouseEvents m_GlobalHook;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;

            btnStart.Click += BtnStart_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static bool _isStarted;
        private void BtnStart_Click(object sender, EventArgs e)
        {
            _isStarted = !_isStarted;
            btnStart.Text = _isStarted ? "Stop" : "Start";
        }

        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isStarted)
            {
                txtXPos.Text = e.Location.X.ToString();
                txtYPos.Text = e.Location.Y.ToString();
                txtColor1.Text = MouseOperation.GetColorAt(new Point { X = e.Location.X, Y = e.Location.Y }).Name;
            }

        }

        public void Unsubscribe()
        {
            m_GlobalHook.MouseMove -= M_GlobalHook_MouseMove;

            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }
        #endregion
    }
}
