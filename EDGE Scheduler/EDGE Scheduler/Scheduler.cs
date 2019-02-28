using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGE_Scheduler
{
    class Scheduler
    {
        public Dictionary<string, GreenTeamStudent> Students { get; set; }

        private Panel panel;
        private DataGridView dgvUnavailability;
        private SheetReader sheetReader;
        
        public Scheduler(Panel panel, DataGridView dgvUnavailability, SheetReader sheetReader)
        {
            this.panel = panel;
            this.dgvUnavailability = dgvUnavailability;
            this.sheetReader = sheetReader;
            Students = new Dictionary<string, GreenTeamStudent>();
        }

        public void CreateSchedule(string team, double shiftLength, DateTime startTime, DateTime endTime)
        {
            CreateStudents();
            FillUnavailability(Properties.Settings.Default.Team);
        }

        private void FillUnavailability(int team)
        {
            dgvUnavailability.Rows.Clear();

            //Add proper amount of rows based off of start and end times
            DateTime tmpTime = Properties.Settings.Default.StartTime;

            while (Properties.Settings.Default.EndTime.TimeOfDay - tmpTime.TimeOfDay >= TimeSpan.FromHours(Properties.Settings.Default.ShiftLength))
            {
                dgvUnavailability.Rows.Add(new DataGridViewRow()
                {
                    HeaderCell = new DataGridViewRowHeaderCell(),
                });
                
                string displayTime = tmpTime.ToString("hh:mm:ss tt");
                dgvUnavailability.Rows[dgvUnavailability.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = displayTime;
                
                tmpTime = tmpTime.AddHours(Properties.Settings.Default.ShiftLength);
            }

            if (team >= 0 && team <= 2)
            {
                //Fill each spot with a list of the names of all students elidgable to be scheduled for that time slot
                AddNames((GreenTeamStudent.Teams)team);

                if (Students.Count > 0)
                {
                    RemoveNames((GreenTeamStudent.Teams)team);
                }
                else
                {
                    MessageBox.Show("No submissions data found. Please make sure you have provided a valid Google Sheet and that you have added the named ranges: 'Columms' and 'Submissions'", Properties.Settings.Default.ApplicationName);
                }
            }
            else
            {
                MessageBox.Show($"GreenTeamStudent.Team must be either 0, 1, or 2. Could not fill unavailability for team #{team}");
            }
        }

        private void AddNames(GreenTeamStudent.Teams team)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (team == GreenTeamStudent.Teams.Both || Students.Values.ToArray()[i].Team == team)
                {
                    for (int o = 0; o < dgvUnavailability.Rows.Count; o++)
                    {
                        for (int p = 1 /* set to 1 to make sure we don't place names in the time column */; p < dgvUnavailability.Rows[o].Cells.Count; p++)
                        {
                            if (dgvUnavailability.Rows[o].Cells[p].Value == null)
                            {
                                dgvUnavailability.Rows[o].Cells[p].Value = Students.Values.ToArray()[i].Name;
                            }
                            else
                            {
                                dgvUnavailability.Rows[o].Cells[p].Value += $", {Students.Values.ToArray()[i].Name}";
                            }
                        }
                    }
                }
            }
        }

        private void RemoveNames(GreenTeamStudent.Teams team)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (team == GreenTeamStudent.Teams.Both || Students.Values.ToArray()[i].Team == team)
                {
                    for (int o = 0; o < Students.Values.ToArray()[i].Classes.Count; o++)
                    {
                        DateTime classStart = Students.Values.ToArray()[i].Classes[o].StartTime;
                        DateTime classEnd = Students.Values.ToArray()[i].Classes[o].EndTime;

                        //Add time to get back from loop if necessary
                        if (Students.Values.ToArray()[i].Classes[o].Campus == Class.Campuses.Loop)
                        {
                            classEnd.AddMinutes(Properties.Settings.Default.TimeFromLoop);
                        }

                        for (int p = 0; p < dgvUnavailability.Rows.Count; p++)
                        {
                            DataGridViewRow row = dgvUnavailability.Rows[p];

                            if (row.Cells[0].Value != null)
                            {
                                DateTime timeSlot;

                                //Get current office hours time slot for comparison to class times
                                try
                                {
                                    timeSlot = DateTime.ParseExact(row.Cells[0].Value.ToString(), "hh:mm:ss tt", CultureInfo.InvariantCulture);
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show($"Could not parse {row.Cells[0].Value.ToString()} as a valid DateTime");
                                    break;
                                }

                                //TODO Do better checks to tell if student is available
                                if (timeSlot.TimeOfDay > classStart.TimeOfDay && timeSlot.TimeOfDay < classEnd.TimeOfDay)
                                {
                                    Console.WriteLine($"For {Students.Values.ToArray()[i].Name},{timeSlot.TimeOfDay} is between {classStart.TimeOfDay} and {classEnd.TimeOfDay}");
                                }
                                else
                                {
                                    Console.WriteLine($"For {Students.Values.ToArray()[i].Name},{timeSlot.TimeOfDay} is either later than {classEnd.TimeOfDay} and or earlier than {classStart.TimeOfDay}");
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create students objects for easy grouping
        /// </summary>
        private void CreateStudents()
        {
            Students.Clear();

            for (int i = 0; i < sheetReader.Submissions.Count; i++)
            {
                CreateStudent(sheetReader.Columns[0], sheetReader.Submissions[i]);
            }
        }

        /// <summary>
        /// Instantiates a new GreenTeamStudentObject for easy access to submission fields
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="submissionParams"></param>
        public void CreateStudent(IList<object> columns, IList<object> submissionParams)
        {
            GreenTeamStudent tmpStudent = new GreenTeamStudent(columns, submissionParams);
            Students.Add(tmpStudent.Name, tmpStudent);
        }

        public GreenTeamStudent GetStudent(string name)
        {
            return Students[name];
        }

        public void SetStudent(GreenTeamStudent student)
        {
            Students[student.Name] = student;
        }

        public void SetBackColor(Color color)
        {
            panel.BackColor = color;
        }
    }
}
