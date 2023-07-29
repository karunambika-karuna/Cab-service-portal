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
    public class TripSheetSvc : ITripSheetRepo
    {
        public string DeleteTS(int TSID)
        {
            #region
            var msg = "";
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<int>("Exec TripSheet_Delete " + TSID + "").FirstOrDefault();
                msg = "TripSheet Deleted Successfully...";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public TripSheet_Model Edit_TripSheet_byTSId(int TSID)
        {
            #region
            TripSheet_Model obj = new TripSheet_Model();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<TripSheet_Model>("Exec TripSheet_Edit " + TSID + " ").FirstOrDefault();

                obj.TSID = result.TSID;
                string _dob = result.TSDate.Split('/')[0] + '/' + result.TSDate.Split('/')[1] + '/' + result.TSDate.Split('/')[2];
                obj.TSDate = _dob.Replace(" 00:00:00", "");
                obj.TripType  = result.TripType;
                obj.Pickup_Time = result.Pickup_Time;
                obj.Drop_Time = result.Drop_Time;
                obj.Pickup_From = result.Pickup_From;
                obj.Remarks = result.Remarks;
                obj.Drop_To = result.Drop_To;
                obj.DriverID = result.DriverID;
                obj.DrvName = CommonClassFile.GetSingleValue("select DrvName from Tbl_Driver_Mst where DriverID=" + result.DriverID + " ");
                obj.RootID = result.RootNo;
                obj.RootNo = CommonClassFile.GetSingleValue("Select RootNo from Tbl_Root_Mst where RootID=" + result.RootNo + "");
                obj.StaffID = result.StaffID;
                obj.StaffName = CommonClassFile.GetSingleValue("Select StfName from Tbl_Staff_Mst where StaffID=" + result.StaffID + "");
                obj.CompanyID = result.CompanyID;
                obj.CmpName = CommonClassFile.GetSingleValue("select CmpName from Tbl_Company_Mst where CompanyID=" + result.CompanyID + " ");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
            #endregion
        }

        public List<TripSheet_Model> GetAllTripSheetlist()
        {
            #region 
            var details = new List<TripSheet_Model>();
            try
            {
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<TripSheet_Model>("Exec TripSheet_Display").ToList();
                foreach (var item in result.ToList())
                {
                    TripSheet_Model obj = new TripSheet_Model
                    {
                        TSID = item.TSID,
                        TSDate = item.TSDate,
                        TripType = item.TripType,
                        Pickup_Time = item.Pickup_Time,
                        Drop_Time = item.Drop_Time,
                        Pickup_From = item.Pickup_From,
                        Remarks =item.Remarks,
                        Drop_To = item.Drop_To,
                        DriverID = item.DriverID,
                        DrvName  = CommonClassFile.GetSingleValue("select DrvName from Tbl_Driver_Mst where DriverID="+ item.DriverID + " "),
                        RootID = item.RootNo,
                        RootNo = CommonClassFile.GetSingleValue("Select RootNo from Tbl_Root_Mst where RootID="+ item.RootNo + ""),
                        StaffID = item.StaffID,
                        StaffName = CommonClassFile.GetSingleValue("Select StfName from Tbl_Staff_Mst where StaffID=" + item.StaffID + ""),
                        CompanyID = item.CompanyID,
                        CmpName = CommonClassFile.GetSingleValue("select CmpName from Tbl_Company_Mst where CompanyID=" + item.CompanyID+" ")
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

        public string SaveTS(TripSheet_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";
                 
                if (ph.TSDate  != "")
                {
                    _dob = ph.TSDate.Split('/')[2] + "-" + ph.TSDate.Split('/')[1] + "-" + ph.TSDate.Split('/')[0];

                }
                
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec TripSheet_Create '" + _dob + "','" + ph.TripType + "','" + ph.Pickup_Time + "','" + ph.Drop_Time + "','" + ph.Pickup_From + "','" + ph.Drop_To + "'," + ph.DriverID + "," + ph.RootNo + ","+ph.StaffID+","+ph.CompanyID+",'"+ph.Remarks+"'  ").FirstOrDefault();
                msg = "TripSheet Created Successfully..";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
            #endregion
        }

        public List<TripSheet_Model> TripSheet_Rpt(string FromDate, string ToDate)
        {
            #region 
            var details = new List<TripSheet_Model>();
            try
            {
                #region
                string SDate = "";
                string EDate = "";
                if (FromDate != "")
                {
                    SDate = FromDate.Split('/')[2] + "-" + FromDate.Split('/')[1] + "-" + FromDate.Split('/')[0];

                }
                else
                {
                    SDate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (ToDate != "")
                {
                    EDate = ToDate.Split('/')[2] + "-" + ToDate.Split('/')[1] + "-" + ToDate.Split('/')[0];

                }
                else
                {
                    EDate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                #endregion

                #region
                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<TripSheet_Model>("Exec TripSheet_Report '"+ SDate + "','"+ EDate + "' ").ToList();
                foreach (var item in result.ToList())
                {
                    TripSheet_Model obj = new TripSheet_Model
                    {
                        TSID = item.TSID,
                        TSDate = item.TSDate,
                        TripType = item.TripType,
                        Pickup_Time = item.Pickup_Time,
                        Drop_Time = item.Drop_Time,
                        Pickup_From = item.Pickup_From,
                        Drop_To = item.Drop_To,
                        DriverID = item.DriverID,
                        RootID = item.RootNo,
                        StaffID = item.StaffID,
                        CompanyID = item.CompanyID,
                        Remarks =item.Remarks
                    };
                    details.Add(obj);
                }
                #endregion
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

        public string UpdateTS(TripSheet_Model ph)
        {
            #region
            string msg = "";
            try
            {
                string _dob = "";

                if (ph.TSDate != "")
                {
                    _dob = ph.TSDate.Split('/')[2] + "-" + ph.TSDate.Split('/')[1] + "-" + ph.TSDate.Split('/')[0];

                }

                var con = CommonClassFile.ConnectionString;
                var cmd = new SqlConnection(con);
                var result = cmd.Query<object>("Exec TripSheet_Update  "+ph.TSID+",'" + _dob + "','" + ph.TripType + "','" + ph.Pickup_Time + "','" + ph.Drop_Time + "','" + ph.Pickup_From + "','" + ph.Drop_To + "'," + ph.DriverID + "," + ph.RootNo + "," + ph.StaffID + "," + ph.CompanyID + ",'"+ph.Remarks+"'  ").FirstOrDefault();
                msg = "TripSheet Updated Successfully..";
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
