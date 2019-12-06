using SupportSystemSrdjan.DBModels;
using SupportSystemSrdjan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SupportSystemSrdjan.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel u, LoginViewModel viewModel)
        {
            using (SupportSystemSrdjanContext dc = new SupportSystemSrdjanContext())
            {
                var user = dc.Users.FirstOrDefault(k => k.Username == viewModel.Username && k.Password == viewModel.Password);
                if (user != null)
                {
                    if (ModelState.IsValid)
                    {

                        var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();

                        if (v != null)
                        {
                            Session["Rola"] = v.RolesID;
                            Session["User"] = v.FullName;
                        }

                        if (v != null)
                        {
                            Session["LogedUserID"] = v.UserID.ToString();
                            Session["LogedUserFullname"] = v.FullName.ToString();
                            return RedirectToAction("Index", "Main");
                        }
                    }
                    return View(u);
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}