using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Services;
using Cabsystem.Models;
namespace Cabsystem.Controllers
{
    public class RootController : Controller
    {
        RootSvc obj = new RootSvc();
        // GET: RootController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllRootlist()
        {
            return Json(obj.GetAllRootlist());
        }

        // GET: RootController/Details/5
        public ActionResult Details(int id)
        {
            return View(obj.Edit_Root_byID(id));
        }

        // GET: RootController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RootController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                Root_Model objRoot = new Root_Model();

                objRoot.RootNo = collection["RootNo"];
                objRoot.Source = collection["Source"];
                objRoot.Destination = collection["Destination"];
                objRoot.Stops = collection["Stops"];
                objRoot.Status = collection["Status"];

                string result = obj.SaveRoot(objRoot);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

        // GET: RootController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(obj.Edit_Root_byID(id));
        }

        // POST: RootController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Root_Model objRoot = new Root_Model();
                objRoot.RootID = collection["RootID"];
                objRoot.RootNo = collection["RootNo"];
                objRoot.Source = collection["Source"];
                objRoot.Destination = collection["Destination"];
                objRoot.Stops = collection["Stops"];
                objRoot.Status = collection["Status"];

                string result = obj.UpdateRoot(objRoot);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: RootController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(obj.Edit_Root_byID(id));
        }

        // POST: RootController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                obj.DeleteRoot(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
