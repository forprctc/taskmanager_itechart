using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager_iTechArt.Besiness_Logic.DTO
{
    public class LogDTO
    {
        public int log_id { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }
        public int task_id { get; set; }
        public int? user_id { get; set; }
    }
}