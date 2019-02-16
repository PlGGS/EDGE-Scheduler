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
        
        DataGridView dgvTimes;

        public IList<IList<object>> Columns;
        public IList<IList<object>> Submissions; //TODO make forms that appear if these ranges are not defined in your spreadsheet

        public SheetReader(DataGridView dgvTimes)
        {
            this.dgvTimes = dgvTimes;

            Columns = SheetReader.ReadRange("Columns");
            Submissions = SheetReader.ReadRange("Submissions");
        }
        
        public void LoadGoogleSheet()
        {
            dgvTimes.Columns.Clear();
            dgvTimes.Rows.Clear();

            if (Columns != null && Columns.Count > 0)
            {
                for (int i = 0; i < Columns[0].Count; i++)
                {
                    dgvTimes.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = Columns[0][i].ToString(),
                    });
                }
            }
            
            if (Submissions != null && Submissions.Count > 0)
            {
                for (int i = 0; i < Submissions.Count; i++)
                {
                    dgvTimes.Rows.Add(new DataGridViewRow()
                    {
                        HeaderCell = new DataGridViewRowHeaderCell(),
                    });

                    for (int o = 0; o < Submissions[i].Count; o++)
                    {
                        dgvTimes.Rows[i].Cells[o].Value = Submissions[i][o];
                    }
                }
            }
            else
            {
                MessageBox.Show("No submissions data found. Please make sure you have provided a valid Google Sheet and that you have added the named ranges: 'Columms' and 'Submissions'", Properties.Settings.Default.ApplicationName);
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
                MessageBox.Show($"Please choose a Google account to use {Properties.Settings.Default.ApplicationName} with.", Properties.Settings.Default.ApplicationName);
            }
            catch (Google.GoogleApiException)
            {
                MessageBox.Show($"Please make sure you have provided a valid Google Sheet.", Properties.Settings.Default.ApplicationName);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show($"Please check your internet connection.", Properties.Settings.Default.ApplicationName);
            }
            
            return null;
        }
    }
}
