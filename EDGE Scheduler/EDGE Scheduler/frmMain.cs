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
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "EDGE Scheduler";
        static string ExecutableDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        string SpreadsheetID;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SpreadsheetID = Properties.Settings.Default.SpreadsheetID;
            txtSpreadsheetID.Text = SpreadsheetID;
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            UserCredential credential;
            Console.WriteLine(ExecutableDirectoryPath);

            try
            {
                using (var stream =
                new FileStream($"{ExecutableDirectoryPath}credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
            }
            catch (System.AggregateException)
            {
                MessageBox.Show($"Please choose a Google account to use {ApplicationName} with.");
                return;
            }
            

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            string range = "Games";
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(SpreadsheetID, range);

            IList<IList<Object>> values = request.Execute().Values;

            for (int i = 0; i < values.Count(); i++)
            {
                Console.WriteLine(values[i][0]);
            }

            if (values != null && values.Count > 0)
            {
                List<string> items = new List<string>();
                foreach (var row in values)
                {
                    dgvTimes.Rows.Add(row[0]);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private void txtSpreadsheetID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SpreadsheetID = txtSpreadsheetID.Text;
            Properties.Settings.Default.Save();
        }
    }
}
