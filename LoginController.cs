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
    public class LoginController : Controller
    {
        LoginSvc objlogin = new LoginSvc();

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            string returntype = "";
            try
            {

                string UserName = collection["UserName"];
                string Password = collection["Password"];

                
                string loginStatus = objlogin.CheckLogin(UserName,Password);


                if (loginStatus == "1")
                {

                    DataTable dtemp = CommonClassFile.SelectTable("Select Distinct UserID, UserName,UserType,STFID,DRVID  from Login where UserName='" + UserName + "' and Password='" + Password + "' ");
                    if (dtemp.Rows.Count > 0)
                    {


                        HttpContext.Session.SetString("UserName", UserName);
                        HttpContext.Session.SetString("UserType", dtemp.Rows[0]["UserType"].ToString());
                        HttpContext.Session.SetInt32("UserID",Convert.ToInt32( dtemp.Rows[0]["UserID"].ToString()));
                        HttpContext.Session.SetInt32("STFID", Convert.ToInt32(dtemp.Rows[0]["STFID"].ToString()));
                        HttpContext.Session.SetInt32("DRVID", Convert.ToInt32(dtemp.Rows[0]["DRVID"].ToString()));

                        
                        
                        TempData["Msg"] = "Logged In Successfully...";

                        if (dtemp.Rows[0]["UserType"].ToString() == "Admin")
                        {
                            returntype = Url.Action("Index", "Dashboard");
                        }
                        else if (dtemp.Rows[0]["UserType"].ToString() == "Staff")
                        {
                            returntype = Url.Action("Index", "TripSheet");
                        }
                        if (dtemp.Rows[0]["UserType"].ToString() == "Driver")
                        {
                            returntype = Url.Action("Index", "Driver_Attendance");
                        }

                       
                    }




                }
                else
                {
                    loginStatus = "0";

                    TempData["Msg"] = "Invalid UserName or Password";
                    returntype = Url.Action("Index", "Login");
                }

            }
            catch(Exception ex)
            {
                 
                return View(ex.Message);
            }
            return Redirect(returntype);
            //return  Redirect (Url.Action("Index", "CME"));

        }


        [HttpPost]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
           
            return RedirectToAction("Index", "Login");
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
