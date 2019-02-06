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

        public frmMain()
        {
            InitializeComponent();

            sheetReader = new SheetReader(dgvTimes);

            Properties.Settings.Default.ExecutableDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            Properties.Settings.Default.Save();

            dtpStart.Format = DateTimePickerFormat.Time;
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Time;
            dtpEnd.ShowUpDown = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSpreadsheetID.Text = Properties.Settings.Default.SpreadsheetID;

            try
            {
                dtpStart.Value = Properties.Settings.Default.StartTime;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Properties.Settings.Default.StartTime = dtpStart.Value;
                Properties.Settings.Default.Save();
            }

            try
            {
                dtpEnd.Value = Properties.Settings.Default.EndTime;
            }
            catch (Exception)
            {
                Properties.Settings.Default.EndTime = dtpEnd.Value;
                Properties.Settings.Default.Save();
            }
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            sheetReader.LoadGoogleSheet();
        }

        private void txtSpreadsheetID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SpreadsheetID = txtSpreadsheetID.Text;
            Properties.Settings.Default.Save();
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
    }
}
