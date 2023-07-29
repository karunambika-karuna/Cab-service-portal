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
    public class RootSvc : IRootRepo
    {
        public List<Dropdownlist> Getddl_RootNolist() 
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
                var result = cmd.Query<Dropdownlist>(" Select '0' as Value,'' as Text union all Select RootID as Value,RootNo as Text from Tbl_Root_Mst where Status='Active' ").ToList();

                foreach(var item in result.ToList())
                {
                    Dropdownlist obj = new Dropdownlist
                    {
                        Text = item.Text,
                        Value = item.Value
                    };
                    details.Add(obj);
                }
               
            }
            catch(Exception ex)
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

        public string DeleteRoot(int RootID)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Delete from Tbl_Root_Mst where RootID="+RootID+"").FirstOrDefault();
                msg = "Root Deleted Successfully...";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public Root_Model Edit_Root_byID(int RootID)
        {
            #region
            Root_Model obj = new Root_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Root_Model>("Exec Root_Mst_Edit "+ RootID + " ").FirstOrDefault();

                obj.RootID = result.RootID;
                obj.RootNo = result.RootNo;
                obj.Source = result.Source;
                obj.Destination = result.Destination;
                obj.Stops = result.Stops;
                obj.Status = result.Status;
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
                #endregion
        }

        public List<Root_Model> GetAllRootlist()
        {
            #region 
            var details = new List<Root_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<Root_Model>("Exec Root_Mst_Display").ToList();
                foreach(var item in result.ToList())
                {
                    Root_Model obj = new Root_Model
                    {
                        RootID = item.RootID,
                        RootNo = item.RootNo,
                        Source = item.Source,
                        Destination = item.Destination,
                        Stops = item.Stops,
                        Status = item.Status
                    };
                    details.Add(obj);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return details;
            #endregion 
        }

        public string SaveRoot(Root_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Root_Mst_Create '"+ph.RootNo+"','"+ph.Source+"','"+ph.Destination+"','"+ph.Stops+"','"+ph.Status+"'  ").FirstOrDefault();
                msg = "Root Created Successfully..";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public string UpdateRoot(Root_Model ph)
        {
            #region
            string msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec Root_Mst_Update "+ph.RootID+",'" + ph.RootNo + "','" + ph.Source + "','" + ph.Destination + "','" + ph.Stops + "','" + ph.Status + "'  ").FirstOrDefault();
                msg = "Root Created Successfully..";
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
