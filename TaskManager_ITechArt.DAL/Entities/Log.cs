﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ITechArt.DAL.Entities
{
    public class Log
    {
        public int log_id { get; set; }
        public int ta_id { get; set; }
        public DateTime date {get;set;}
        public int status { get; set; }
        public int task_id { get; set; }
        public int user_id { get; set; }
    }
}
