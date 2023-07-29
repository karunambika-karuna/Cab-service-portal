using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface IStaffRepo
    {
        List<Staff_Model> GetAllStaffList();
        Staff_Model Edit_Staff_byStaffId(int StaffID);
        string SaveStaff(Staff_Model ph);
        string UpdateStaff(Staff_Model ph);
        string  DeleteStaff(int StaffID);

        List<Dropdownlist> GetStaff_ddl();
    }
}
