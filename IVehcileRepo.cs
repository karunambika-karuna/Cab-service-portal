using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface IVehcileRepo 
    {

        public List<Vehcile_Model> GetAllVehicleList();
        Vehcile_Model Edit_Vehicle_byVNo(int VechileID);
        string SaveVehcile(Vehcile_Model ph);
        string UpdateVehicle(Vehcile_Model ph);
        string DeleteVehicle(int VehicleID);
        List<Dropdownlist> ddlVehiclelist();
    }
}
