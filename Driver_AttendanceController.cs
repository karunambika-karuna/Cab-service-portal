using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Services;
using Cabsystem.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Cabsystem.Controllers
{
    public class Driver_AttendanceController : Controller
    {
        DriverSvc objdrv = new DriverSvc();
        // GET: Driver_AttendanceController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllDriverAttendance(int DriverID)
        {
            return Json(objdrv.Getall_DriverAttendancelist(DriverID));
        }

        // GET: Driver_AttendanceController/Details/5
        public ActionResult Details(int id,string AttDate)
        {
            ViewBag.TripTyplist = getddlTripType();
            ViewBag.Driverlist = GetDriveList();
            ViewBag.Stafflist = GetStaffList();
            ViewBag.Rootlist = GetRootList();
            ViewBag.CompanyList = GetCompanyList();
            ViewBag.VehicleList = GetVehicleList();
            ViewBag.Vtyplist = getVehcileType();
            return View(objdrv.Edit_DriverAttendance_byDriverId(id,AttDate));
        }

        public List<Dropdownlist_Status> getddlTripType()
        {
            List<Dropdownlist_Status> ListofColors = new List<Dropdownlist_Status>();
            ListofColors.Add(new Dropdownlist_Status { Label = "0", Text = "" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Single", Text = "Single Trip" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Round", Text = "Round Trip" });

            return ListofColors;
        }

        public List<Dropdownlist_Status> getVehcileType()
        {
            List<Dropdownlist_Status> ListofColors = new List<Dropdownlist_Status>();
            ListofColors.Add(new Dropdownlist_Status { Label = "0", Text = "" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Sedan", Text = "Sedan" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Hatchback", Text = "Hatchback" });
            ListofColors.Add(new Dropdownlist_Status { Label = "MUV", Text = "MUV" });
            ListofColors.Add(new Dropdownlist_Status { Label = "SUV", Text = "SUV" });

            return ListofColors;
        }
        // GET: Driver_AttendanceController/Create
        public ActionResult Create()
        {
            ViewBag.TripTyplist = getddlTripType();
            ViewBag.Driverlist = GetDriveList();
            ViewBag.Stafflist = GetStaffList();
            ViewBag.Rootlist = GetRootList();
            ViewBag.CompanyList = GetCompanyList();
            ViewBag.VehicleList = GetVehicleList();
            ViewBag.Vtyplist = getVehcileType();
            return View();
        }

        // POST: Driver_AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Driver_Attendance obj = new Driver_Attendance();

                obj.AttDate = collection["AttDate"];
                obj.DriverID = collection["DriverID"];
                obj.CompanyID = collection["CompanyID"];
                obj.StaffID = collection["StaffID"];
                obj.VehicleID = collection["VehicleID"];
                obj.VType = collection["VType"];
                obj.VNo = collection["VNo"];
                obj.RootID = collection["RootID"];
                obj.Pickuped_From = collection["Pickuped_From"];
                obj.Droped_To = collection["Droped_To"];
                obj.Pikup_Type = collection["Pikup_Type"];
                obj.KmDriven = collection["KmDriven"];
                obj.Pickuped_Time = collection["Pickuped_Time"];
                obj.Droped_Time = collection["Droped_Time"];
                objdrv.Create_Driver_Attendance(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver_AttendanceController/Edit/5
        public ActionResult Edit(int id,string AttDate)
        {
            ViewBag.TripTyplist = getddlTripType();
            ViewBag.Driverlist = GetDriveList();
            ViewBag.Stafflist = GetStaffList();
            ViewBag.Rootlist = GetRootList();
            ViewBag.CompanyList = GetCompanyList();
            ViewBag.VehicleList = GetVehicleList();
            ViewBag.Vtyplist = getVehcileType();
            return View(objdrv.Edit_DriverAttendance_byDriverId(id, AttDate));
        }

        public List<Dropdownlist> Getddl_Triplist()
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
                var result = cmd.Query<Dropdownlist>(" Select Label,Text from Tbl_TripType ").ToList();

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

        

        // POST: Driver_AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Driver_Attendance obj = new Driver_Attendance();
                obj.AttNo = collection["AttNo"];
                obj.AttDate = collection["AttDate"];
                obj.DriverID = collection["DriverID"];
                obj.CompanyID = collection["CompanyID"];
                obj.StaffID = collection["StaffID"];
                obj.VehicleID = collection["VehicleID"];
                obj.VType = collection["VType"];
                obj.VNo = collection["VNo"];
                obj.RootID = collection["RootID"];
                obj.Pickuped_From = collection["Pickuped_From"];
                obj.Droped_To = collection["Droped_To"];
                obj.Pikup_Type = collection["Pikup_Type"];
                obj.KmDriven = collection["KmDriven"];
                obj.Pickuped_Time = collection["Pickuped_Time"];
                obj.Droped_Time = collection["Droped_Time"];
                objdrv.Update_Driver_Attendance(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver_AttendanceController/Delete/5
        public ActionResult Delete(int id,string AttDate)
        {
            ViewBag.TripTyplist = getddlTripType();
            ViewBag.Driverlist = GetDriveList();
            ViewBag.Stafflist = GetStaffList();
            ViewBag.Rootlist = GetRootList();
            ViewBag.CompanyList = GetCompanyList();
            ViewBag.VehicleList = GetVehicleList();
            ViewBag.Vtyplist = getVehcileType();
            return View(objdrv.Edit_DriverAttendance_byDriverId(id,AttDate));
        }

        // POST: Driver_AttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                objdrv.Delete_Driver_Attendance_By_DriverID(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<Dropdownlist> GetCompanyList()
        {
            #region
            CompanySvc cmp = new CompanySvc();
            List<Dropdownlist> lstcmp = new List<Dropdownlist>();
            lstcmp = cmp.ddlCompanylist();
            return lstcmp;
            #endregion
        }

        public List<Dropdownlist> GetStaffList()
        {
            #region
            StaffSvc stf = new StaffSvc();
            List<Dropdownlist> lststf = new List<Dropdownlist>();
            lststf = stf.GetStaff_ddl();
            return lststf;
            #endregion
        }

        public List<Dropdownlist> ddlTripTyplist()
        {
            #region
            StaffSvc stf = new StaffSvc();
            List<Dropdownlist> lststf = new List<Dropdownlist>();
            lststf = Getddl_Triplist();
            return lststf;
            #endregion
        }

        public List<Dropdownlist> GetRootList()
        {
            #region
            RootSvc Root = new RootSvc();
            List<Dropdownlist> lstRoot = new List<Dropdownlist>();
            lstRoot = Root.Getddl_RootNolist();
            return lstRoot;
            #endregion
        }

        public List<Dropdownlist> GetDriveList()
        {
            #region
            DriverSvc drv = new DriverSvc();
            List<Dropdownlist> lstDrv = new List<Dropdownlist>();
            lstDrv = drv.GetddlDriverlist();
            return lstDrv;
            #endregion
        }

        public List<Dropdownlist> GetVehicleList()
        {
            #region
            DriverSvc drv = new DriverSvc();
            VehicleSvc vhl = new VehicleSvc();
            List<Dropdownlist> lstDrv = new List<Dropdownlist>();
            lstDrv = vhl.ddlVehiclelist();
            return lstDrv;
            #endregion
        }
    }
}
