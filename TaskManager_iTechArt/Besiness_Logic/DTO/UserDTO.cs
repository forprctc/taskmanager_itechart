using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager_iTechArt.Besiness_Logic.DTO
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public bool is_admin { get; set; }
        public string user_details { get; set; }
    }
}