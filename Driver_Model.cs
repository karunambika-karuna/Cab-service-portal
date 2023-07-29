using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Driver_Model
    {

        public string DriverID { get; set; }
        public string DrvName { get; set; }
        public string MobNo { get; set; }
        public string Age { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string DLNo { get; set; }
        public string DLExpiryDate { get; set; }
        public string Status { get; set; }
    }

    public class Driver_Attendance
    {
        public string AttID { get; set; }
        public string AttDate { get; set; }
        public string AttNo { get; set; }
        public string DriverID { get; set; }
        public string DriverName { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string VehicleID { get; set; }
        public string VType { get; set; }
        public string VName { get; set; }
        public string VNo { get; set; }
        public string RootID { get; set; }
        public string RootName { get; set; }
        public string Pickuped_From { get; set; }
        public string Droped_To { get; set; }
        public string Pikup_Type { get; set; }
        public string KmDriven { get; set; }

        public string Pickuped_Time { get; set; }
        public string Droped_Time { get; set; }
    }
}
