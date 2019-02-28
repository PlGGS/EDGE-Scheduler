using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGE_Scheduler
{
    class GreenTeamStudent
    {
        public enum Teams { Both, East, West }

        public string Timestamp = "Invalid";
        public string Email = "Invalid";
        public string Name = "Invalid";
        public Teams Team { get; set; }
        public IList<Class> Classes = new List<Class>();
        public string Extracurriculars = "Invalid";
        public string Jobs = "Invalid";
        public string FamilyObligations = "Invalid";

        public GreenTeamStudent(IList<object> columns, IList<object> submissionParams)
        {
            InitializeFields(columns, submissionParams);
        }

        private void InitializeFields(IList<object> columns, IList<object> submissionParams)
        {
            Class tmpClass;

            Timestamp = submissionParams[0].ToString();
            Email = submissionParams[1].ToString();
            Name = submissionParams[2].ToString();
            Team = (submissionParams[3].ToString() == "East") ? Teams.East : Teams.West;

            int tmp = 4;
            for (int i = 0; i < 6 /*Amount of classes in sheet*/; i++)
            {
                if (tmp < submissionParams.Count)
                {
                    tmpClass = new Class();

                    tmpClass.Name = submissionParams[tmp].ToString();
                    tmpClass.Days = submissionParams[tmp + 1].ToString().Split(", ".ToCharArray());

                    if (submissionParams[tmp + 2].ToString() != "")
                    {
                        string[] startTimeSpan = submissionParams[tmp + 2].ToString().Substring(0, submissionParams[tmp + 2].ToString().Length - 3).Split(':');
                        tmpClass.StartTime = tmpClass.StartTime.Date + new TimeSpan(Convert.ToInt32(startTimeSpan[0]), Convert.ToInt32(startTimeSpan[1]), Convert.ToInt32(startTimeSpan[2]));
                    }
                    if (submissionParams[tmp + 3].ToString() != "")
                    {
                        string[] endTimeSpan = submissionParams[tmp + 3].ToString().Substring(0, submissionParams[tmp + 3].ToString().Length - 3).Split(':');
                        tmpClass.EndTime = tmpClass.EndTime.Date + new TimeSpan(Convert.ToInt32(endTimeSpan[0]), Convert.ToInt32(endTimeSpan[1]), Convert.ToInt32(endTimeSpan[2]));
                    }

                    tmpClass.Campus = (submissionParams[tmp + 4].ToString() == "Lincoln Park") ? Class.Campuses.LincolnPark : Class.Campuses.Loop;

                    tmp += 5;

                    Classes.Add(tmpClass);
                }
            }

            Extracurriculars = 34 < submissionParams.Count ? submissionParams[34].ToString() : "Invalid";
            Jobs = 35 < submissionParams.Count ? submissionParams[35].ToString() : "Invalid";
            FamilyObligations = 36 < submissionParams.Count ? submissionParams[36].ToString() : "Invalid";
        }
    }
}
