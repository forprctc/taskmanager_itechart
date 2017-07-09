using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager_iTechArt.Besiness_Logic.DTO
{
    public class Task_auditDTO
    {
        public int ta_id { get; set; }
        public int user_id { get; set; }
        public string status { get; set; }
        public int queue { get; set; }
    }
}