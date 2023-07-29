using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class TripSheet_Model
    {
        public string TSID { get; set; }
        public string TSDate { get; set; }
        public string TripType { get; set; }
        public string Pickup_Time { get; set; }
        public string Drop_Time { get; set; }
        public string Pickup_From { get; set; }
        public string Drop_To { get; set; }
        public string DriverID { get; set; }
        public string DrvName { get; set; }
        public string RootID { get; set; }
        public string RootNo { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string CompanyID { get; set; }
        public string CmpName { get; set; }
        public string Remarks { get; set; }
    }
}
