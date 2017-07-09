using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ITechArt.DAL.Entities
{
    public class Task
    {
        public int task_id { get; set; }
        public string title { get; set; }
        public DateTime task_beginning { get; set; }
        public DateTime task_end { get; set; }
        public TimeSpan period { get; set; }
        public string descriptions { get; set; }
        public int category { get; set; }
        public int owner_id { get; set; }
        public int status { get; set; }
        public string task_details { get; set; }
    }
}
