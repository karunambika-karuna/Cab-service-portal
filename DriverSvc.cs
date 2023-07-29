using System;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
using Cabsystem.Repository;

namespace Cabsystem.Services
{
    public class DriverSvc : IDriverRepo
    {
        public void Create_Driver_Attendance(Driver_Attendance ph)
        {
            #region
            try
            {
                string ADate = "";
                if (ph.AttDate != "")
                {
                    ADate = ph.AttDate.Split('/')[2] + "-" + ph.AttDate.Split('/')[1] + "-" + ph.AttDate.Split('/')[0];
                }
                else
                {
                    ADate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Driver_Attendance_Create '" + ADate + "'," +
                    ""+ph.DriverID+"," +
                    ""+ph.CompanyID+"," +
                    ""+ph.StaffID+"," +
                    ""+ph.RootID+"," +
                    ""+ph.VehicleID+"," +
                    "'"+ph.VType+"'," +
                    "'"+ph.VNo+"'," +
                    "'"+ph.Pickuped_From+"'," +
                    "'"+ph.Droped_To+"'," +
                    "'"+ph.Pickuped_Time+"'," +
                    "'"+ph.Droped_Time+"'," +
                    "'"+ph.Pikup_Type+"'," +
                    "'"+ph.KmDriven+"' ").FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            #endregion
        }

        public string DeleteDriver(int DriverId)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec Driver_Mst_Delete " + DriverId + "").FirstOrDefault();
                msg = "Driver Deleted Successfully...";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public void Delete_Driver_Attendance_By_DriverID(int DriverId)
        {
            #region
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec Driver_Attendance_Delete "+DriverId+" ").FirstOrDefault();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            #endregion
        }

        public Driver_Attendance Edit_DriverAttendance_byDriverId(int DriverID, string AttDate)
        {
            #region
            Driver_Attendance objdvr = new Driver_Attendance();
            try
            {
                string ADate = "";
                
                if(AttDate != "" ||  !string.IsNullOrEmpty( AttDate))
                {
                    if (AttDate == null)
                    {
                        AttDate = DateTime.Now.ToString("dd/MM/yyyy");
                        ADate = AttDate.Split('-')[2] + "-" + AttDate.Split('-')[1] + "-" + AttDate.Split('-')[0];
                    }
                    else
                    {
                        ADate = AttDate.Split('/')[2] + "-" + AttDate.Split('/')[1] + "-" + AttDate.Split('/')[0];
                    }
                    
                }
                else
                {
                    ADate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Driver_Attendance>("Exec Driver_Attendance_Edit " + DriverID + ",'"+ADate+"' ").ToList();

                foreach(var item in result.ToList())
                {
                    objdvr.AttNo = item.AttNo;
                    objdvr.AttDate = item.AttDate;
                    objdvr.DriverID = item.DriverID;
                    objdvr.CompanyID = item.CompanyID;
                    objdvr.StaffID = item.StaffID;
                    objdvr.VehicleID = item.VehicleID;
                    objdvr.RootID = item.RootID;
                    objdvr.Pickuped_From = item.Pickuped_From;
                    objdvr.Droped_To = item.Droped_To;
                    objdvr.Pickuped_Time = item.Pickuped_Time;
                    objdvr.Droped_Time = item.Droped_Time;
                    objdvr.KmDriven = item.KmDriven;
                    objdvr.VType = item.VType;
                    objdvr.VNo = item.VNo;
                     
                }
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objdvr;
            #endregion
        }

        public Driver_Model Edit_Driver_byDrvId(int DriverID)
        {
            #region
            Driver_Model obj = new Driver_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Driver_Model>("Exec Driver_Mst_Edit " + DriverID + " ").FirstOrDefault();

                obj.DriverID = result.DriverID;
                obj.DrvName = result.DrvName;
                obj.MobNo = result.MobNo;
                obj.Age = result.Age;
                string _dob  = result.Dob.Split('/')[1]+'/'+ result.Dob.Split('/')[0]+'/'+ result.Dob.Split('/')[2];
                obj.Dob = _dob.Replace(" 00:00:00", "");
                obj.Address = result.Address;
                obj.DLNo = result.DLNo;
                string _dlbexpdate = result.DLExpiryDate.Split('/')[0] + '/' + result.DLExpiryDate.Split('/')[1] + '/' + result.DLExpiryDate.Split('/')[2]; ;
                obj.DLExpiryDate = _dlbexpdate.Replace(" 00:00:00", "");
                obj.Status = result.Status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
            #endregion
        }

        public List<Driver_Model> GetAllDriverlist()
        {
            #region 
            var details = new List<Driver_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Driver_Model>("Exec Driver_Mst_Display").ToList();
                foreach (var item in result.ToList())
                {
                    Driver_Model obj = new Driver_Model
                    {
                        DriverID = item.DriverID,
                        DrvName = item.DrvName,
                        MobNo = item.MobNo,
                        Age = item.Age,
                        Dob = item.Dob,
                        Address = item.Address,
                        DLNo = item.DLNo,
                        DLExpiryDate = item.DLExpiryDate,
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

        public List<Driver_Attendance> Getall_DriverAttendancelist(int DriverId)
        {
            #region
            var details = new List<Driver_Attendance>();
            details.Clear();
            details.TrimExcess();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Driver_Attendance>("Exec Driver_Attendance_Display "+DriverId+" ").ToList();
                if (result.Count > 0)
                {
                    details = result;
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return details;
            #endregion

        }

        public List<Dropdownlist> GetddlDriverlist()
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
                var result = cmd.Query<Dropdownlist>("Select '0' as Value,'' as Text union all Select DriverID as Value,DrvName as Text from Tbl_Driver_Mst where Status='Active'").ToList();

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

        public string SaveDriver(Driver_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";
                string _dvrexpdate = "";
                if(ph.Dob != "")
                {
                    _dob = ph.Dob.Split('/')[2] + "-" + ph.Dob.Split('/')[1] + "-" + ph.Dob.Split('/')[0];
                   
                }
                if (ph.DLExpiryDate !="")
                {
                    _dvrexpdate = ph.DLExpiryDate.Split('/')[2] + "-" + ph.DLExpiryDate.Split('/')[1] + "-" + ph.DLExpiryDate.Split('/')[0];
                }
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Driver_Mst_Create '" + ph.DrvName + "','" + ph.MobNo + "','" + _dob + "','" + ph.Age + "','" + ph.Address + "','" + ph.DLNo + "','" + _dvrexpdate + "','" + ph.Status + "'  ").FirstOrDefault();
                msg = "Company Created Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public string UpdateDriver(Driver_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";
                string _dvrexpdate = "";
                if (ph.Dob != "")
                {
                    _dob = ph.Dob.Split('/')[2] + "-" + ph.Dob.Split('/')[1] + "-" + ph.Dob.Split('/')[0];

                }
                if (ph.DLExpiryDate != "")
                {
                    _dvrexpdate = ph.DLExpiryDate.Split('/')[2] + "-" + ph.DLExpiryDate.Split('/')[1] + "-" + ph.DLExpiryDate.Split('/')[0];
                }
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Driver_Mst_Update "+ph.DriverID+",'" + ph.DrvName + "','" + ph.MobNo + "','" + _dob + "','" + ph.Age + "','" + ph.Address + "','" + ph.DLNo + "','" + _dvrexpdate + "','" + ph.Status + "'  ").FirstOrDefault();
                msg = "Company Updated Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public void Update_Driver_Attendance(Driver_Attendance ph)
        {
            #region
            try
            {
                string ADate = "";
                if (ph.AttDate != "")
                {
                    ADate = ph.AttDate.Split('/')[2] + "-" + ph.AttDate.Split('/')[1] + "-" + ph.AttDate.Split('/')[0];
                }
                else
                {
                    ADate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Driver_Attendance_Update "+ph.AttNo+", '" + ADate + "'," +
                    "" + ph.DriverID + "," +
                    "" + ph.CompanyID + "," +
                    "" + ph.StaffID + "," +
                    "" + ph.RootID + "," +
                    "" + ph.VehicleID + "," +
                    "'" + ph.VType + "'," +
                    "'" + ph.VNo + "'," +
                    "'" + ph.Pickuped_From + "'," +
                    "'" + ph.Droped_To + "'," +
                    "'" + ph.Pickuped_Time + "'," +
                    "'" + ph.Droped_Time + "'," +
                    "'" + ph.Pikup_Type + "'," +
                    "'" + ph.KmDriven + "' ").FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            #endregion
        }
    }
}
