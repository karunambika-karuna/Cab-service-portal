using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
using Cabsystem.Repository;
using System.Data.SqlClient;

namespace Cabsystem.Services
{
    public class VehicleSvc : IVehcileRepo
    {
        public List<Dropdownlist> ddlVehiclelist()
        {
            #region
            var details = new List<Dropdownlist>();
            details.Clear();
            details.TrimExcess();

            #region
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Dropdownlist>(" Select '0' as Value,'' as Text union all Select VehicleID as Value,VName+''+Vehicle_type as Text from Tbl_Vehicle_Mst where Status='Active' ").ToList();

                foreach (var item in result.ToList())
                {
                    Dropdownlist obj = new Dropdownlist
                    {
                        Text = item.Text,
                        Value = item.Value
                    };
                    details.Add(obj);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            #endregion

            return details;
            #endregion
        }

        public string DeleteVehicle(int VehicleID)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec Vehicle_Mst_Delete " + VehicleID + "").FirstOrDefault();
                msg = "Vehicle Deleted Successfully...";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public Vehcile_Model Edit_Vehicle_byVNo(int VechileID)
        {
            #region
            Vehcile_Model obj = new Vehcile_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Vehcile_Model>("Exec Vehicle_Mst_Edit " + VechileID + " ").FirstOrDefault();

                obj.VehicleID = result.VehicleID;
                obj.Vehicle_type = result.Vehicle_type;
                obj.No_of_Seats = result.No_of_Seats;
                obj.VName = result.VName;
                obj.Status = result.Status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
            #endregion
        }

        public List<Vehcile_Model> GetAllVehicleList()
        {
            #region 
            var details = new List<Vehcile_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Vehcile_Model>("Exec Vehicle_Mst_display").ToList();
                foreach (var item in result.ToList())
                {
                    Vehcile_Model obj = new Vehcile_Model
                    {
                        VehicleID = item.VehicleID,
                        Vehicle_type = item.Vehicle_type,
                        VName = item.VName,
                        No_of_Seats = item.No_of_Seats,
                        Status = item.Status
                    };
                    details.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return details;
            #endregion 
        }

        public string SaveVehcile(Vehcile_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Vehicle_Mst_Create '" + ph.Vehicle_type + "','" + ph.No_of_Seats + "','" + ph.VName + "','" + ph.Status + "'  ").FirstOrDefault();
                msg = "Vehicle Created Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public string UpdateVehicle(Vehcile_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Vehicle_Mst_Update "+ph.VehicleID+", '" + ph.Vehicle_type + "','" + ph.No_of_Seats + "','" + ph.VName + "','" + ph.Status + "'  ").FirstOrDefault();
                msg = "Vehicle Updated Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }
    }
}
