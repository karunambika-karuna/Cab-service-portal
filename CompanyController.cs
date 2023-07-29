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
    public class CompanyController : Controller
    {
        CompanySvc obj = new CompanySvc();
        // GET: CompanyController
        public ActionResult Index()
        {
              
            return View();
        }

        
        [HttpGet]
        public JsonResult GetAllCompanylist()
        {
            return Json(obj.GetAllCompanylist());
        }
         
        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Company_byCmpId(id));
        }
        public List<Dropdownlist_Status> getddlStatus()
        {
            List<Dropdownlist_Status> ListofColors = new List<Dropdownlist_Status>();
            ListofColors.Add(new Dropdownlist_Status { Label = "0", Text = "" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Active", Text = "Active" });
            ListofColors.Add(new Dropdownlist_Status { Label = "Inactive", Text = "Inactive" });

            return ListofColors;
        }
        // GET: CompanyController/Create
        public ActionResult Create()
        { 
            ViewBag.ListStatus = getddlStatus();
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Company_Model objcmp = new Company_Model();
                objcmp.CompanyName = collection["CompanyName"];
                objcmp.ContactPerson = collection["ContactPerson"];
                objcmp.PhoneNo = collection["PhoneNo"];
                objcmp.Email = collection["Email"];
                objcmp.Address = collection["Address"];
                objcmp.Payment_Mode = collection["Payment_Mode"];
                objcmp.Payment_Type = collection["Payment_Type"];
                objcmp.SelectedStatus = collection["SelectedStatus"];

                obj.SaveCompany(objcmp);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Company_byCmpId(id));
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Company_Model objcmp = new Company_Model();
                objcmp.CompanyID = collection["CompanyID"];
                objcmp.CompanyName = collection["CompanyName"];
                objcmp.ContactPerson = collection["ContactPerson"];
                objcmp.PhoneNo = collection["PhoneNo"];
                objcmp.Email = collection["Email"];
                objcmp.Address = collection["Address"];
                objcmp.Payment_Mode = collection["Payment_Mode"];
                objcmp.Payment_Type = collection["Payment_Type"];
                objcmp.SelectedStatus = collection["SelectedStatus"];

                obj.UpdateCompany(objcmp);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ListStatus = getddlStatus();
            return View(obj.Edit_Company_byCmpId(id));
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                obj.DeleteCompany(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

    }
}
