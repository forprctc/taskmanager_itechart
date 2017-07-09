using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ITechArt.DAL.Entities
{
    public class Task_status
    {
        public int status_id { get; set; }
        public string status { get; set; }
        public string status_details { get; set; }
    }
}
