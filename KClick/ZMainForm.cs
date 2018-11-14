using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClick
{
    public partial class ZMainForm : Form
    {
        public ZMainForm()
        {
            InitializeComponent();

            btnGetPosition.Click += BtnGetPosition_Click;
            btnReroll.Click += BtnReroll_Click;
            btnMainForm.Click += BtnMainForm_Click;
            btnScriptMaking.Click += BtnScriptMaking_Click;
        }

        private void BtnScriptMaking_Click(object sender, EventArgs e)
        {
            Hide();

            var form = new ScriptMakingForm();
            form.ZMainForm = this;
            form.Show();
        }

        private void BtnMainForm_Click(object sender, EventArgs e)
        {
            Hide();

            var form = new MainForm();
            form.ZMainForm = this;
            form.Show();
        }

        private void BtnReroll_Click(object sender, EventArgs e)
        {
            Hide();

            var form = new RerolForm();
            form.ZMainForm = this;
            form.Show();
        }

        private void BtnGetPosition_Click(object sender, EventArgs e)
        {
            Hide();

            var form = new MouseHookKeyForm();
            form.ZMainForm = this;
            form.Show();
        }
    }
}
