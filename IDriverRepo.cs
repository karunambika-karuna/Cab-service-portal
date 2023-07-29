using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;

namespace Cabsystem.Repository
{
    interface IDriverRepo
    {
        public List<Dropdownlist> GetddlDriverlist();
        List<Driver_Model> GetAllDriverlist();
        Driver_Model Edit_Driver_byDrvId(int DriverID);

        string SaveDriver(Driver_Model ph);
        string UpdateDriver(Driver_Model ph);
        string DeleteDriver(int DriverId);

        public List<Driver_Attendance> Getall_DriverAttendancelist(int DriverId);
        Driver_Attendance Edit_DriverAttendance_byDriverId(int DriverID,string AttDate);
        void Create_Driver_Attendance(Driver_Attendance ph);
        void Update_Driver_Attendance(Driver_Attendance ph);
        void Delete_Driver_Attendance_By_DriverID(int DriverId);
    }
}
