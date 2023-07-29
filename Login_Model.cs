using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Login_Model
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Usertype { get; set; }
        public string Password { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string DriverID { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }
    }
}
