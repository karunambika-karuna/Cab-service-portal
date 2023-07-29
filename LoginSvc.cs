using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
using Cabsystem.Repository;
using System.Data;

namespace Cabsystem.Services
{
    public class LoginSvc : ILoginRepo
    {
        public string CheckLogin(string UserName, string Password)
        {
            #region
            string status = string.Empty;

            DataTable dtck = CommonClassFile.SelectTable("exec Spr_AdminLogin '" + UserName + "','" + Password + "' ");
            //DataTable dtck = CommonClassFile.SelectTable("exec spr_login 'Gokul','123'");
            if (dtck.Rows.Count > 0)
            {

                status = dtck.Rows[0]["Column1"].ToString();



            }

            return status;
            #endregion
        }

        public void DeleteLogin(int LoginID)
        {
            throw new NotImplementedException();
        }

        public Login_Model Edit_Login_ByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public List<Login_Model> GetAllUserList()
        {
            throw new NotImplementedException();
        }

       
        public void SaveLogin(Login_Model ph)
        {
            #region
            
            try
            {
                string   StaffID = "";
                string  DriverID ="";

                if (ph.Usertype == "Admin")
                {
                    StaffID ="0";
                    DriverID = "0";
                }
                else if (ph.Usertype == "Staff")
                {
                    StaffID = ph.StaffID;
                    DriverID = "0";
                }
                else if (ph.Usertype == "Driver")
                {
                    StaffID ="0";
                    DriverID =ph.DriverID;
                }
                int result = CommonClassFile.InsertOrUpdateorDelete("Insert into  Login (UserName,Password,UserType,STFID,DrvID,Status) Values ('"+ph.UserName+"','"+ph.Password+"','"+ph.Usertype+"',"+StaffID+","+DriverID+",'Active')  ");
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
            #endregion
        }

        public void UpdateLogin(Login_Model ph)
        {
            string StaffID = "";
            string DriverID = "";

            if (ph.Usertype == "Admin")
            {
                StaffID = "0";
                DriverID = "0";
            }
            else if (ph.Usertype == "Staff")
            {
                StaffID = ph.StaffID;
                DriverID = "0";
            }
            else if (ph.Usertype == "Driver")
            {
                StaffID = "0";
                DriverID = ph.DriverID;
            }
            int result = CommonClassFile.InsertOrUpdateorDelete("Update Login SET UserName='" + ph.UserName + "',Password='" + ph.Password + "',UserType'" + ph.Usertype + "',STFID=" + StaffID + ",DrvID=" + DriverID + "  where UserID="+ph.UserID+"  ");
        }
    }
}
