using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager_iTechArt.Besiness_Logic.DTO
{
    public class Task_statusDTO
    {
        public int status_id { get; set; }
        public string status { get; set; }
        public string status_details { get; set; }
    }
}