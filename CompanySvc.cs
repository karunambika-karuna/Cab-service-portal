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
    public class CompanySvc : ICompanyRepo
    {
        public List<Dropdownlist> ddlCompanylist()
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
                var result = cmd.Query<Dropdownlist>(" Select '0' as Value,'' as Text union all Select CompanyID as Value,CmpName as Text from Tbl_Company_Mst where Status='Active' ").ToList();

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

      
        public string DeleteCompany(int CompanyID)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec Company_Mst_Delete " + CompanyID + "").FirstOrDefault();
                msg = "Company Deleted Successfully...";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public Company_Model Edit_Company_byCmpId(int CompanyID)
        {
            #region
            Company_Model obj = new Company_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Company_Model>("Exec Company_Mst_Edit " + CompanyID + " ").FirstOrDefault();

                obj.CompanyID = result.CompanyID;
                obj.CompanyName = result.CompanyName;
                obj.ContactPerson = result.ContactPerson;
                obj.PhoneNo = result.PhoneNo;
                obj.Email = result.Email;
                obj.Address = result.Address;
                obj.Payment_Mode = result.Payment_Mode;
                obj.Payment_Type = result.Payment_Type;
                obj.SelectedStatus = result.SelectedStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
            #endregion
        }
        public List<Dropdownlist_Status> Status()
        {
            var details = new List<Dropdownlist_Status>();
            var con = CommonClassFile.ConnectionString;
            var cmd = new SqlConnection(con);
            var result = cmd.Query<Dropdownlist_Status>("select Label,Text from Tbl_Status").ToList();
            foreach(var item in result.ToList())
            {
                Dropdownlist_Status obj = new Dropdownlist_Status
                {
                    Label = item.Label,
                    Text = item.Text
                };
                details.Add(obj);
            }
            return details;
        }
        public List<Company_Model> GetAllCompanylist()
        {
            #region 
            var details = new List<Company_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Company_Model>("Exec Company_Mst_Display").ToList();
                foreach (var item in result.ToList())
                {
                    Company_Model obj = new Company_Model
                    {
                        CompanyID = item.CompanyID,
                        CompanyName = item.CompanyName,
                        ContactPerson = item.ContactPerson,
                        PhoneNo = item.PhoneNo,
                        Email = item.Email,
                        Address =item.Address,
                        Payment_Mode =item.Payment_Mode,
                        Payment_Type =item.Payment_Type,
                        SelectedStatus = item.SelectedStatus
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

        public string SaveCompany(Company_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Company_Mst_Create '" + ph.CompanyName + "','" + ph.ContactPerson + "','" + ph.PhoneNo + "','" + ph.Email + "','" + ph.Address + "','"+ph.Payment_Mode+"','"+ph.Payment_Type+"','"+ph.SelectedStatus+"'  ").FirstOrDefault();
                msg = "Company Created Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public string UpdateCompany(Company_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Company_Mst_Update "+ph.CompanyID+",'" + ph.CompanyName + "','" + ph.ContactPerson + "','" + ph.PhoneNo + "','" + ph.Email + "','" + ph.Address + "','" + ph.Payment_Mode + "','" + ph.Payment_Type + "','" + ph.SelectedStatus + "'  ").FirstOrDefault();
                msg = "Company Updated Successfully..";
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
