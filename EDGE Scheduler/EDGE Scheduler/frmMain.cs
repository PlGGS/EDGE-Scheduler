using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSpreadsheetID.Text = Properties.Settings.Default.SpreadsheetID;
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
    }
}
