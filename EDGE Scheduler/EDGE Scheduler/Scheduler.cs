using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDGE_Scheduler
{
    class Scheduler
    {
        public Dictionary<string, GreenTeamStudent> Students { get; set; }

        private Panel Panel;
        private SheetReader sheetReader;

        public Scheduler(Panel panel, SheetReader sheetReader)
        {
            Panel = panel;
            this.sheetReader = sheetReader;
            Students = new Dictionary<string, GreenTeamStudent>();
        }

        public void CreateSchedule(string team, double shiftLength, DateTime startTime, DateTime endTime)
        {
            CreateStudents();


        }

        /// <summary>
        /// Create students objects for easy grouping
        /// </summary>
        private void CreateStudents()
        {
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
            Panel.BackColor = color;
        }
    }
}
