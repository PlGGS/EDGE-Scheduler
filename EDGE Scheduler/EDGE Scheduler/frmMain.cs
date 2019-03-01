using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGE_Scheduler
{
    public partial class frmMain : Form
    {
        SheetReader sheetReader;
        Scheduler scheduler;

        public frmMain()
        {
            InitializeComponent();

            sheetReader = new SheetReader(dgvTimes);
            scheduler = new Scheduler(scrMain.Panel1, dgvAvailability, sheetReader);

            Properties.Settings.Default.ExecutableDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            Properties.Settings.Default.Save();

            dtpStart.Format = DateTimePickerFormat.Time;
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Time;
            dtpEnd.ShowUpDown = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Form frmLoading = new frmLoading();
            frmLoading.Show();

            cbxTeam.SelectedIndex = 0;
            Properties.Settings.Default.Team = cbxTeam.SelectedIndex;
            Properties.Settings.Default.Save();

            txtShiftLength.Text = Properties.Settings.Default.ShiftLength.ToString();
            txtTimeFromLoop.Text = Properties.Settings.Default.TimeFromLoop.ToString();

            try
            {
                dtpStart.Value = Properties.Settings.Default.StartTime;
            }
            catch (ArgumentOutOfRangeException)
            {
                Properties.Settings.Default.StartTime = dtpStart.Value;
                Properties.Settings.Default.Save();
            }

            try
            {
                dtpEnd.Value = Properties.Settings.Default.EndTime;
            }
            catch (ArgumentOutOfRangeException)
            {
                Properties.Settings.Default.EndTime = dtpEnd.Value;
                Properties.Settings.Default.Save();
            }

            scrMain.Panel2MinSize = scrMain.Panel2.Height;

            sheetReader.LoadGoogleSheet();

            frmLoading.Close();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            sheetReader.LoadGoogleSheet();
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            scheduler.CreateSchedule(cbxTeam.Text, Properties.Settings.Default.ShiftLength, Properties.Settings.Default.StartTime, Properties.Settings.Default.EndTime);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartTime = dtpStart.Value;
            Properties.Settings.Default.Save();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EndTime = dtpEnd.Value;
            Properties.Settings.Default.Save();
        }

        private void txtShiftLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtShiftLength_TextChanged(object sender, EventArgs e)
        {
            if (txtShiftLength.Text == "" || txtShiftLength.Text == ".")
            {
                Properties.Settings.Default.ShiftLength = 0;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.ShiftLength = Convert.ToDouble(txtShiftLength.Text);
                Properties.Settings.Default.Save();
            }
        }

        private void scrMain_Panel2_SizeChanged(object sender, EventArgs e)
        {
            btnReadData.Bounds = new Rectangle(new Point(btnReadData.Location.X, cbxTeam.Top + 206), new Size(btnReadData.Width, scrMain.Panel2.Height - btnReadData.Top));
            btnCreateSchedule.Bounds = new Rectangle(new Point(btnCreateSchedule.Location.X, cbxTeam.Top + 206), new Size(btnCreateSchedule.Width, scrMain.Panel2.Height - btnCreateSchedule.Top));
        }

        private void txtTimeFromLoop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTimeFromLoop_TextChanged(object sender, EventArgs e)
        {
            if (txtTimeFromLoop.Text == "" || txtTimeFromLoop.Text == ".")
            {
                Properties.Settings.Default.TimeFromLoop = 0;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.TimeFromLoop = Convert.ToDouble(txtTimeFromLoop.Text);
                Properties.Settings.Default.Save();
            }
        }

        private void cbxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Team = cbxTeam.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
