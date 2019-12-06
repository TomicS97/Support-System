using SupportSystemSrdjan.Models;
using SupportSystemSrdjan.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                var user = context.Users.Select(u =>
                new UserViewModel()
                {
                    UserID = u.UserID,
                    FullName = u.FullName,
                    Address = u.Address,
                    City = u.City,
                    Country = u.Country,
                    Phone = u.Phone,
                    Username = u.Username,
                    Password = u.Password,
                    RolesID = u.RolesID,
                    RolesName = u.SupportSystemRole.RolesName,
                    Aktivan = u.Aktivan
                }).ToList();

                ViewBag.Roles = context.SupportSystemRoles
                   .Select(r => new RolasViewModel()
                   {
                       RolesName = r.RolesName,
                       RolesID = r.RolesID
                   }).ToList();

                return View(user);
            }
        }

        public ActionResult Create()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                ViewBag.Roles = context.SupportSystemRoles
                   .Select(r => new SelectListItem()
                   {
                       Text = r.RolesName,
                       Value = "" + r.RolesID
                   }).ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        User user = new User()
                        {
                            FullName = userViewModel.FullName,
                            Address = userViewModel.Address,
                            City = userViewModel.City,
                            Country = userViewModel.Country,
                            Phone = userViewModel.Phone,
                            Username = userViewModel.Username,
                            Password = userViewModel.Password,
                            RolesID = userViewModel.RolesID,
                            Aktivan = userViewModel.Aktivan
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "");
                    }
                }
                ViewBag.Roles = context.SupportSystemRoles
                          .Select(r => new SelectListItem()
                          {
                              Text = r.RolesName,
                              Value = "" + r.RolesID
                          }).ToList();
                return View(userViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                User user = context.Users.Find(id);
                UserViewModel userViewModel = new UserViewModel()
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Username = user.Username,
                    Password = user.Password,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    Phone = user.Phone,
                    RolesID = user.RolesID,
                    RolesName = user.SupportSystemRole.RolesName,
                    Aktivan = user.Aktivan
                };

                ViewBag.Roles = context.SupportSystemRoles
                   .Select(r => new SelectListItem()
                   {
                       Text = r.RolesName,
                       Value = "" + r.RolesID
                   }).ToList();

                return View(userViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(int userid, string fullname, string username, string password, string address, string city, string country, string phone, int rolesid, bool aktivan)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                User user = context.Users.Find(userid);

                user.FullName = fullname;
                user.Username = username;
                user.Password = password;
                user.Address = address;
                user.City = city;
                user.Country = country;
                user.Phone = phone;
                user.RolesID = rolesid;
                user.Aktivan = aktivan;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(string id)
        {
            int userid = Convert.ToInt32(id);

            using (var context = new SupportSystemSrdjanContext())
            {
                User user = context.Users.Where(u => u.UserID == userid).FirstOrDefault();
                UserViewModel userViewModel = new UserViewModel()
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Username = user.Username,
                    Password = user.Password,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    Phone = user.Phone,
                    RolesID = user.RolesID,
                    RolesName = user.SupportSystemRole.RolesName,
                    Aktivan = user.Aktivan
                };
                return View(userViewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                context.Users.Remove(context.Users.Find(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}