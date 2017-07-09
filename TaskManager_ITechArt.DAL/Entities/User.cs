using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ITechArt.DAL.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public bool is_admin { get; set; }
        public string user_details { get; set; }
    }
}
