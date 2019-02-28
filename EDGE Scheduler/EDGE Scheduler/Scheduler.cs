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
        private DataGridView dgvAvailability;
        private SheetReader sheetReader;
        
        public Scheduler(Panel panel, DataGridView dgvAvailability, SheetReader sheetReader)
        {
            this.panel = panel;
            this.dgvAvailability = dgvAvailability;
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
            dgvAvailability.Rows.Clear();

            //Add proper amount of rows based off of start and end times
            DateTime tmpTime = Properties.Settings.Default.StartTime;

            while (Properties.Settings.Default.EndTime.TimeOfDay - tmpTime.TimeOfDay >= TimeSpan.FromHours(Properties.Settings.Default.ShiftLength))
            {
                dgvAvailability.Rows.Add(new DataGridViewRow()
                {
                    HeaderCell = new DataGridViewRowHeaderCell(),
                });
                
                string displayTime = tmpTime.ToString("hh:mm:ss tt");
                dgvAvailability.Rows[dgvAvailability.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = displayTime;
                
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
                    for (int o = 0; o < dgvAvailability.Rows.Count; o++)
                    {
                        for (int p = 1 /* set to 1 to make sure we don't place names in the time column */; p < dgvAvailability.Rows[o].Cells.Count; p++)
                        {
                            if (dgvAvailability.Rows[o].Cells[p].Value == null)
                            {
                                dgvAvailability.Rows[o].Cells[p].Value = Students.Values.ToArray()[i].Name;
                            }
                            else
                            {
                                dgvAvailability.Rows[o].Cells[p].Value += $",{Students.Values.ToArray()[i].Name}";
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

                        for (int p = 0; p < dgvAvailability.Rows.Count; p++)
                        {
                            DataGridViewRow row = dgvAvailability.Rows[p];

                            if (row.Cells[0].Value != null)
                            {
                                DateTime timeSlotStart;
                                DateTime timeSlotEnd;

                                //Get current office hours time slot for comparison to class times
                                try
                                {
                                    timeSlotStart = DateTime.ParseExact(row.Cells[0].Value.ToString(), "hh:mm:ss tt", CultureInfo.InvariantCulture);

                                    timeSlotEnd = DateTime.ParseExact(row.Cells[0].Value.ToString(), "hh:mm:ss tt", CultureInfo.InvariantCulture);
                                    timeSlotEnd = timeSlotEnd.AddHours(Properties.Settings.Default.ShiftLength);
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show($"Could not parse {row.Cells[0].Value.ToString()} as a valid DateTime");
                                    break;
                                }

                                //Check to see if class time makes the student is unavailable
                                if (classStart.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay || /*Class starts during timeSlot*/
                                    classEnd.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay ||   /*Class ends during timeSlot*/
                                    classStart.TimeOfDay <= timeSlotStart.TimeOfDay && classEnd.TimeOfDay >= timeSlotEnd.TimeOfDay)     /*Class starts before and ends after timeSlot*/
                                {
                                    Console.WriteLine(classStart.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine(classEnd.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine(classStart.TimeOfDay <= timeSlotStart.TimeOfDay && classEnd.TimeOfDay >= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine($"{Students.Values.ToArray()[i].Name}'s {Students.Values.ToArray()[i].Classes[o].Name} class that starts  at {classStart} and ends at {classEnd} DOES CONFLICT with the time slot starting at {timeSlotStart} and ending at {timeSlotEnd}");

                                    //if so, remove their name from each day they have that class
                                    for (int q = 0; q < Students.Values.ToArray()[i].Classes[o].Days.Length; q++)
                                    {
                                        for (int r = 1; r < dgvAvailability.Columns.Count; r++)
                                        {
                                            if (Students.Values.ToArray()[i].Classes[o].Days[q] == dgvAvailability.Columns[r].HeaderCell.Value.ToString())
                                            {
                                                //Check if cell value is string before editing it
                                                if (row.Cells[r].Value is string)
                                                {
                                                    string tmpNames = "";
                                                    
                                                    //Remove name from cell
                                                    for (int s = 0; s < row.Cells[r].Value.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length; s++)
                                                    {
                                                        //Add all names other than the one of the student we now know is not available
                                                        
                                                        if (row.Cells[r].Value.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[s] != Students.Values.ToArray()[i].Name)
                                                        {
                                                            if (tmpNames == "")
                                                            {
                                                                //if we working on first name just add it, otherwise we need ',' as well
                                                                tmpNames += row.Cells[r].Value.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[s];
                                                            }
                                                            else
                                                            {
                                                                tmpNames += $",{row.Cells[r].Value.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[s]}";
                                                            }
                                                        }
                                                    }

                                                    //Reset the cell value to the new set of names
                                                    row.Cells[r].Value = tmpNames;
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"Couldn't remove {Students.Values.ToArray()[i].Name} from dgvAvailability, as the cell value was not a string");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(classStart.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine(classEnd.TimeOfDay >= timeSlotStart.TimeOfDay && classStart.TimeOfDay <= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine(classStart.TimeOfDay <= timeSlotStart.TimeOfDay && classEnd.TimeOfDay >= timeSlotEnd.TimeOfDay);
                                    Console.WriteLine($"{Students.Values.ToArray()[i].Name}'s {Students.Values.ToArray()[i].Classes[o].Name} class that starts  at {classStart} and ends at {classEnd} does not conflict with the time slot starting at {timeSlotStart} and ending at {timeSlotEnd}");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RemoveName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {

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
