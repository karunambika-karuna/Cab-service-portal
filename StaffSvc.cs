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
    public class StaffSvc : IStaffRepo
    {
        public string DeleteStaff(int StaffID)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec Staff_Mst_Delete " + StaffID + "").FirstOrDefault();
                msg = "Staff Deleted Successfully...";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public Staff_Model Edit_Staff_byStaffId(int StaffID)
        {
            #region
            Staff_Model obj = new Staff_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Staff_Model>("Exec Staff_Mst_Edit " + StaffID + " ").FirstOrDefault();

                obj.StaffID = result.StaffID;
                obj.StfName = result.StfName;
                obj.Gender = result.Gender;
                obj.Age = result.Age;
                string _dob = result.Dob.Split('/')[1] + '/' + result.Dob.Split('/')[0] + '/' + result.Dob.Split('/')[2];
                obj.Dob = _dob.Replace(" 00:00:00", "");
                obj.Address = result.Address;
                obj.ContactNo = result.ContactNo;
                obj.AltContactNo = result.AltContactNo;
                obj.Email = result.Email;
                obj.Pickup = result.Pickup;
                obj.DropTo = result.DropTo;
                obj.Status = result.Status;
                obj.CompanyID = result.CompanyID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
            #endregion
        }

        public List<Staff_Model> GetAllStaffList()
        {

            #region 
            var details = new List<Staff_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Staff_Model>("Exec Staff_Mst_Display").ToList();
                foreach (var item in result.ToList())
                {
                    Staff_Model obj = new Staff_Model
                    {
                        StaffID = item.StaffID,
                        StfName = item.StfName,
                        Gender = item.Gender,
                        Age = item.Age,
                        Dob = item.Dob,
                        Email = item.Email,
                        Address = item.Address,
                        ContactNo = item.ContactNo,
                        AltContactNo = item.AltContactNo,
                        Pickup = item.Pickup,
                        DropTo =item.DropTo,
                        Status = item.Status,
                        CompanyID =CommonClassFile.GetSingleValue("Select CmpName from Tbl_Company_MSt where CompanyID="+item.CompanyID+"")
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

        public List<Dropdownlist> GetStaff_ddl()
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
                var result = cmd.Query<Dropdownlist>("Select '0' as Value ,'' as Text union all    Select StaffID as Value ,StfName as Text from Tbl_Staff_Mst where Status='Active'").ToList();

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

        public string SaveStaff(Staff_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";
 
                if (ph.Dob != "")
                {
                    _dob = ph.Dob.Split('/')[2] + "-" + ph.Dob.Split('/')[1] + "-" + ph.Dob.Split('/')[0];

                }
                
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Staff_Mst_Create '" + ph.StfName + "','" + ph.Gender + "','" + _dob + "','" + ph.Age + "','" + ph.ContactNo + "','" + ph.AltContactNo + "','" + ph.Email + "','" + ph.Address + "','"+ph.Pickup+"','"+ph.DropTo+"','"+ph.Status+"',"+ph.CompanyID+"  ").FirstOrDefault();
                msg = "Staff Created Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public string UpdateStaff(Staff_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";

                if (ph.Dob != "")
                {
                    _dob = ph.Dob.Split('/')[2] + "-" + ph.Dob.Split('/')[1] + "-" + ph.Dob.Split('/')[0];

                }

                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Staff_Mst_Update "+ph.StaffID+",'" + ph.StfName + "','" + ph.Gender + "','" + _dob + "','" + ph.Age + "','" + ph.ContactNo + "','" + ph.AltContactNo + "','" + ph.Email + "','" + ph.Address + "','" + ph.Pickup + "','" + ph.DropTo + "','" + ph.Status + "'," + ph.CompanyID + "  ").FirstOrDefault();
                msg = "Staff Updated Successfully..";
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
