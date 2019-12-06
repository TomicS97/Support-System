using SupportSystemSrdjan.DBModels;
using SupportSystemSrdjan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                var status = context.SupportSystemStatus.Select(s =>
                new StatusViewModel()
                {
                    StatusID = s.StatusID,
                    StatusName = s.StatusName,
                    Description = s.Description,
                }).ToList();
                return View(status);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StatusViewModel status)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                context.SupportSystemStatus.Add(new SupportSystemStatu
                {
                    StatusID = status.StatusID,
                    StatusName = status.StatusName,
                    Description = status.Description,
                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemStatu status = context.SupportSystemStatus.Find(id);
                StatusViewModel statusViewModel = new StatusViewModel()
                {
                    StatusID = status.StatusID,
                    StatusName = status.StatusName,
                    Description = status.Description,
                };
                return View(statusViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(int statusid, string statusName, string description)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemStatu status = context.SupportSystemStatus.Find(statusid);
                status.StatusName = statusName;
                status.Description = description;
              
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            int statusid = Convert.ToInt32(id);

            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemStatu status = context.SupportSystemStatus.Where(u => u.StatusID == statusid).FirstOrDefault();
                StatusViewModel statusViewModel = new StatusViewModel()
                {
                    StatusID = status.StatusID,
                    StatusName = status.StatusName,
                    Description = status.Description
                };
                return View(statusViewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                context.SupportSystemStatus.Remove(context.SupportSystemStatus.Find(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}