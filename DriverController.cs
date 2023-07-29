using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Services;
using Cabsystem.Models;
using System.Data;

namespace Cabsystem.Controllers
{
    public class DriverController : Controller
    {
        DriverSvc obj = new DriverSvc();
        // GET: DriverController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllDriverlist()
        {
            return Json(obj.GetAllDriverlist());
        }


        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Driver_byDrvId(id));
        }
        public List<Dropdownlist_Status> getddlStatus()
        {
            List<Dropdownlist_Status> ListofColors = new List<Dropdownlist_Status>();
            ListofColors.Add(new Dropdownlist_Status { Label = "0", Text = "" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Active", Text = "Active" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Inactive", Text = "Inactive" });

            return ListofColors;
        }

        // GET: DriverController/Create
        public ActionResult Create()
        {
            ViewBag.ListStatus = getddlStatus();
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Driver_Model objdv = new Driver_Model();

                objdv.DrvName = collection["DrvName"];
                objdv.MobNo   = collection["MobNo"];
                objdv.Dob     = collection["Dob"];
                objdv.Age     = collection["Age"];
                objdv.Address = collection["Address"];
                objdv.DLNo    = collection["DLNo"];
                objdv.DLExpiryDate  = collection["DLExpiryDate"];
                objdv.Status        = collection["Status"];
                obj.SaveDriver(objdv);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Driver_byDrvId(id));
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Driver_Model objdv = new Driver_Model();
                objdv.DriverID = collection["DriverID"];
                objdv.DrvName = collection["DrvName"];
                objdv.MobNo = collection["MobNo"];
                objdv.Dob = collection["Dob"];
                objdv.Age = collection["Age"];
                objdv.Address = collection["Address"];
                objdv.DLNo = collection["DLNo"];
                objdv.DLExpiryDate = collection["DLExpiryDate"];
                objdv.Status = collection["Status"];
                obj.UpdateDriver(objdv);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Driver_byDrvId(id));
        }

        // POST: DriverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                obj.DeleteDriver(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
