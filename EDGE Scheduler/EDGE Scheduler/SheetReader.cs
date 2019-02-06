using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EDGE_Scheduler
{
    class SheetReader
    {
        static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        
        DataGridView _dgvTimes;

        public IList<IList<object>> Columns;
        public IList<IList<object>> Submissions; //TODO make forms that appear if these ranges are not defined in your spreadsheet

        public SheetReader(DataGridView dgvTimes)
        {
            _dgvTimes = dgvTimes;
        }
        
        public void LoadGoogleSheet()
        {
            _dgvTimes.Columns.Clear();
            _dgvTimes.Rows.Clear();

            try
            {
                Columns = SheetReader.ReadRange("Columns");
                Submissions = SheetReader.ReadRange("Submissions");
            }
            catch (Google.GoogleApiException)
            {
                MessageBox.Show("Please make sure you have provided a valid Google Sheet and that you have added the named ranges: 'Columms' and 'Submissions'");
            }

            if (Columns != null && Columns.Count > 0)
            {
                for (int i = 0; i < Columns[0].Count; i++)
                {
                    _dgvTimes.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = Columns[0][i].ToString(),
                    });
                }
            }
            
            if (Submissions != null && Submissions.Count > 0)
            {
                for (int i = 0; i < Submissions.Count; i++)
                {
                    _dgvTimes.Rows.Add(new DataGridViewRow()
                    {
                        HeaderCell = new DataGridViewRowHeaderCell(),
                    });

                    for (int o = 0; o < Submissions[i].Count; o++)
                    {
                        //Console.WriteLine(Submissions[i][o].ToString());
                        _dgvTimes.Rows[i].Cells[o].Value = Submissions[i][o];
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        public static IList<IList<object>> ReadRange(string range)
        {
            try
            {
                UserCredential credential;
                Console.WriteLine(Properties.Settings.Default.SpreadsheetID);

                using (var stream =
                new FileStream($"{Properties.Settings.Default.ExecutableDirectoryPath}credentials.json", FileMode.Open, FileAccess.Read))
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

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = Properties.Settings.Default.ApplicationName,
                });

                return service.Spreadsheets.Values.Get(Properties.Settings.Default.SpreadsheetID, range).Execute().Values;
            }
            catch (System.AggregateException)
            {
                MessageBox.Show($"Please choose a Google account to use {Properties.Settings.Default.ApplicationName} with.");
            }
            catch (Google.GoogleApiException)
            {
                MessageBox.Show($"Please make sure you have provided a valid Google Sheet.");
            }
            
            return null;
        }
    }
}
