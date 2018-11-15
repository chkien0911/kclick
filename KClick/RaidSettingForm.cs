using KClick.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KClick
{
    public partial class RaidSettingForm : Form
    {
        public ZMainForm ZMainForm { get; set; }
        public RaidSettingForm()
        {
            InitializeComponent();

            btnGetPosition.MouseUp += BtnGetPosition_MouseUp;
            btnGetPosition.MouseDown += GetPosition_MouseDown;
            btnGetPosition.MouseHover += GetPosition_MouseHover;

            btnGetPosition2.MouseUp += BtnGetPosition2_MouseUp;
            btnGetPosition2.MouseDown += GetPosition_MouseDown;
            btnGetPosition2.MouseHover += GetPosition_MouseHover;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                var xmlPath = "/templates/system/raids.xml";

                var xml = XDocument.Load($"{appPath}/{xmlPath}");

                var raids = xml.Descendants("Raid").ToList();
                var no = raids.Count + 1;
                
                XElement raid = new XElement("Raid",
                new XElement("No", no),
                new XElement("Name", txtName.Text),

                new XElement("X", txtXPos.Text),
                new XElement("Y", txtYPos.Text),
                new XElement("Color", txtColor1.Text),

                new XElement("X2", txtX2.Text),
                new XElement("Y2", txtY2.Text),
                new XElement("Color2", txtColor2.Text)

                );
                xml.Element("Raids").Add(raid);

                xml.Save($"{appPath}/{xmlPath}");

                MessageBox.Show("Saved!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void GetPosition_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void GetPosition_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
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
        private void BtnGetPosition_MouseUp(object sender, MouseEventArgs e)
        {
            var point = MouseOperation.GetCursorPosition();

            txtXPos.Text = point.X.ToString();
            txtYPos.Text = point.Y.ToString();

            var color = MouseOperation.GetColorAt(point);
            txtColor1.Text = color.Name;

            Cursor.Current = Cursors.Default;
        }
    }
}
