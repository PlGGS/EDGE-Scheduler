using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGE_Scheduler
{
    class Class
    {
        public enum Campuses { LincolnPark, Loop }

        public string Name { get; set; }
        public string[] Days { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Campuses Campus { get; set; }
    }
}
