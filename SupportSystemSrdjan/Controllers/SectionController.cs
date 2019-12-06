using SupportSystemSrdjan.DBModels;
using SupportSystemSrdjan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                var section = context.SupportSystemSections.Select(s =>
                new SectionViewModel()
                {
                    SectionID = s.SectionID,
                    SectionName = s.SectionName,
                    Description = s.Description,
                }).ToList();
                return View(section);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SectionViewModel section)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                context.SupportSystemSections.Add(new SupportSystemSection
                {
                    SectionID = section.SectionID,
                    SectionName = section.SectionName,
                    Description = section.Description,
                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemSection section = context.SupportSystemSections.Find(id);
                SectionViewModel sectionViewModel = new SectionViewModel()
                {
                    SectionID = section.SectionID,
                    SectionName = section.SectionName,
                    Description = section.Description,
                };
                return View(sectionViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(int sectionid, string sectionName, string description)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemSection section = context.SupportSystemSections.Find(sectionid);
                section.SectionName = sectionName;
                section.Description = description;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            int sectionid = Convert.ToInt32(id);

            using (var context = new SupportSystemSrdjanContext())
            {
                SupportSystemSection section = context.SupportSystemSections.Where(u => u.SectionID == sectionid).FirstOrDefault();
                SectionViewModel sectionViewModel = new SectionViewModel()
                {
                    SectionID = section.SectionID,
                    SectionName = section.SectionName,
                    Description = section.Description
                };
                return View(sectionViewModel);

            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                context.SupportSystemSections.Remove(context.SupportSystemSections.Find(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}