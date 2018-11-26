using KClick.Configuration;
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
    public partial class BoostTimeForm : Form
    {
        public ActionForm ActionForm { get; set; }
        public BoostTime BoostTime { get; set; } = new BoostTime();

        public BoostTimeForm()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            Load += BoostTimeForm_Load;
        }

        private void BoostTimeForm_Load(object sender, EventArgs e)
        {
            if (BoostTime.No != 0)
            {
                txtNo.Text = BoostTime.No.ToString();
                dtpDate.Value = BoostTime.FromTime.Date;
                dtpFrom.Value = BoostTime.FromTime;
                dtpTo.Value = BoostTime.ToTime;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BoostTime = new BoostTime();

            BoostTime.No = int.Parse(txtNo.Text);
            BoostTime.FromTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpFrom.Value.Hour, dtpFrom.Value.Minute, 0);
            BoostTime.ToTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpTo.Value.Hour, dtpTo.Value.Minute, 0);
            
            if (BoostTime.No == 0)
            {
                ActionForm.AddBoostTime(BoostTime);
            }
            else
            {
                ActionForm.UpdateBoostTime(BoostTime);

                Close();
            }
        }
    }
}
