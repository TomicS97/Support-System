using SupportSystemSrdjan.DBModels;
using SupportSystemSrdjan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                var main = context.Mains.Select(m =>
                new MainViewModel()
                {
                    ID = m.ID,
                    SugestionNo = m.SugestionNo,
                    CreatedBy = m.CreatedBy,
                    CreatedOn = m.CreatedOn,
                    StatusID = m.StatusID,
                    StatusName = m.SupportSystemStatu.StatusName,
                    CategoryID = m.CategoryID,
                    CategoryName = m.SupportSystemCategory.CategoryName,
                    SectionID = m.SectionID,
                    SectionName = m.SupportSystemSection.SectionName,
                    SeverityID = m.SeverityID,
                    SeverityName = m.SupportSystemSeverity.SeverityName,
                    Title = m.Title,
                    StepsToReproduce = m.StepsToReproduce,
                    PriorityID = m.PriorityID,
                    PriorityName = m.SupportSystemPriority.PriorityName,
                    AcceptedOn = m.AcceptedOn,
                    DueOn = m.DueOn,
                    ResolvedOn = m.ResolvedOn,
                    ResolveNotes = m.Notes,
                    CommentID = m.Comment.CommentID,
                    CommentName = m.Comment.CommentName
                }).ToList();

                ViewBag.Status = context.SupportSystemStatus
                   .Select(s => new StatusViewModel()
                   {
                       StatusName = s.StatusName,
                       StatusID = s.StatusID
                   }).ToList();

                ViewBag.Section = context.SupportSystemSections
                    .Select(a => new SectionViewModel()
                    {
                        SectionName = a.SectionName,
                        SectionID = a.SectionID
                    }).ToList();

                ViewBag.Severity = context.SupportSystemSeverities
                    .Select(b => new SeverityViewModel()
                    {
                        SeverityName = b.SeverityName,
                        SeverityID = b.SeverityID
                    }).ToList();

                ViewBag.Category = context.SupportSystemCategories
                    .Select(c => new CategoryViewModel()
                    {
                        CategoryName = c.CategoryName,
                        CategoryID = c.CategoryID
                    }).ToList();

                ViewBag.Priority = context.SupportSystemPriorities
                    .Select(p => new PriorityViewModel()
                    {
                        PriorityName = p.PriorityName,
                        PriorityID = p.PriorityID
                    }).ToList();
                return View(main);
            }
        }

        public ActionResult Create()
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                ViewBag.Status = context.SupportSystemStatus
                   .Select(s => new SelectListItem()
                   {
                       Text = s.StatusName,
                       Value = "" + s.StatusID
                   }).ToList();

                ViewBag.Section = context.SupportSystemSections
                    .Select(a => new SelectListItem()
                    {
                        Text = a.SectionName,
                        Value = "" + a.SectionID
                    }).ToList();

                ViewBag.Severity = context.SupportSystemSeverities
                    .Select(b => new SelectListItem()
                    {
                        Text = b.SeverityName,
                        Value = "" + b.SeverityID
                    }).ToList();

                ViewBag.Category = context.SupportSystemCategories
                    .Select(c => new SelectListItem()
                    {
                        Text = c.CategoryName,
                        Value = "" + c.CategoryID
                    }).ToList();

                ViewBag.Priority = context.SupportSystemPriorities
                    .Select(p => new SelectListItem()
                    {
                        Text = p.PriorityName,
                        Value = "" + p.PriorityID
                    }).ToList();

                ViewBag.Comment = context.Comments
                      .Select(s => new CommentViewModel()
                      {
                          CommentName = s.CommentName,
                          CommentID = s.CommentID
                      }).ToList();

                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(MainViewModel mainViewModel)
        {
             using (var context = new SupportSystemSrdjanContext())
                {
                    Main main = new Main()
                    {
                        SugestionNo = mainViewModel.SugestionNo,
                        CreatedBy = mainViewModel.CreatedBy,
                        CreatedOn = mainViewModel.CreatedOn,
                        StatusID = mainViewModel.StatusID,
                        CategoryID = mainViewModel.CategoryID,
                        SectionID = mainViewModel.SectionID,
                        SeverityID = mainViewModel.SeverityID,
                        Title = mainViewModel.Title,
                        StepsToReproduce = mainViewModel.StepsToReproduce,
                        PriorityID = mainViewModel.PriorityID,
                        AcceptedOn = mainViewModel.AcceptedOn,
                        DueOn = mainViewModel.DueOn,
                        ResolvedOn = mainViewModel.ResolvedOn,
                        Notes = mainViewModel.ResolveNotes
                    };
                    context.Mains.Add(main);
                    context.SaveChanges();

                    return RedirectToAction("Index", "Main");
                }
        
        }

        public ActionResult Edit(int id)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                Main main = context.Mains.Find(id);
                MainViewModel mainViewModel = new MainViewModel()
                {
                    ID = main.ID,
                    SugestionNo = main.SugestionNo,
                    CreatedBy = main.CreatedBy,
                    CreatedOn = main.CreatedOn,
                    StatusID = main.StatusID,
                    StatusName = main.SupportSystemStatu.StatusName,
                    CategoryID = main.CategoryID,
                    CategoryName=main.SupportSystemCategory.CategoryName,
                    SectionID = main.SectionID,
                    SectionName = main.SupportSystemSection.SectionName,
                    SeverityID = main.SeverityID,
                    SeverityName=main.SupportSystemSeverity.SeverityName,
                    Title = main.Title,
                    StepsToReproduce = main.StepsToReproduce,
                    PriorityID = main.PriorityID,
                    PriorityName=main.SupportSystemPriority.PriorityName,
                    AcceptedOn = main.AcceptedOn,
                    DueOn = main.DueOn,
                    ResolvedOn = main.ResolvedOn,
                    ResolveNotes = main.Notes
                    
                };

                ViewBag.Status = context.SupportSystemStatus
                   .Select(s => new SelectListItem()
                   {
                       Text = s.StatusName,
                       Value = "" + s.StatusID
                   }).ToList();

                ViewBag.Section = context.SupportSystemSections
                    .Select(a => new SelectListItem()
                    {
                        Text = a.SectionName,
                        Value = "" + a.SectionID
                    }).ToList();

                ViewBag.Severity = context.SupportSystemSeverities
                    .Select(b => new SelectListItem()
                    {
                        Text = b.SeverityName,
                        Value = "" + b.SeverityID
                    }).ToList();

                ViewBag.Category = context.SupportSystemCategories
                    .Select(c => new SelectListItem()
                    {
                        Text = c.CategoryName,
                        Value = "" + c.CategoryID
                    }).ToList();

                ViewBag.Priority = context.SupportSystemPriorities
                    .Select(p => new SelectListItem()
                    {
                        Text = p.PriorityName,
                        Value = "" + p.PriorityID
                    }).ToList();

                ViewBag.Comment = context.Comments
                     .Select(s => new CommentViewModel()
                     {
                         CommentName = s.CommentName,
                         CommentID = s.CommentID
                     }).ToList();

                return View(mainViewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, int sugestionNo, string createdBy, DateTime createdOn, int statusID, int categoryID, int sectionID, int severityID, string title, string stepsToReproduce, int priorityID, DateTime acceptedOn, DateTime dueOn, string resolvedOn, string resolveNotes)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                Main main = context.Mains.Find(id);

                main.SugestionNo = sugestionNo;
                main.CreatedBy = createdBy;
                main.CreatedOn = createdOn;
                main.StatusID = statusID;
                main.CategoryID = categoryID;
                main.SectionID = sectionID;
                main.SeverityID = severityID;
                main.Title = title;
                main.StepsToReproduce = stepsToReproduce;
                main.PriorityID = priorityID;
                main.AcceptedOn = acceptedOn;
                main.DueOn = dueOn;
                main.ResolvedOn = resolvedOn;
                main.Notes = resolveNotes;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            int mainid = Convert.ToInt32(id);

            using (var context = new SupportSystemSrdjanContext())
            {
                Main main = context.Mains.Where(m=> m.ID == mainid).FirstOrDefault();
                MainViewModel mainViewModel = new MainViewModel()
                {
                    ID = main.ID,
                    SugestionNo = main.SugestionNo,
                    CreatedBy = main.CreatedBy,
                    CreatedOn = main.CreatedOn,
                    StatusID = main.StatusID,
                    StatusName = main.SupportSystemStatu.StatusName,
                    CategoryID = main.CategoryID,
                    CategoryName = main.SupportSystemCategory.CategoryName,
                    SectionID = main.SectionID,
                    SectionName = main.SupportSystemSection.SectionName,
                    SeverityID = main.SeverityID,
                    SeverityName = main.SupportSystemSeverity.SeverityName,
                    Title = main.Title,
                    StepsToReproduce = main.StepsToReproduce,
                    PriorityID = main.PriorityID,
                    PriorityName = main.SupportSystemPriority.PriorityName,
                    AcceptedOn = main.AcceptedOn,
                    DueOn = main.DueOn,
                    ResolvedOn = main.ResolvedOn,
                    ResolveNotes = main.Notes,
                   
                };
                return View(mainViewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var context = new SupportSystemSrdjanContext())
            {
                context.Mains.Remove(context.Mains.Find(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateComment(string comment)
        {
            using (var context = new SupportSystemSrdjanContext())
            {
                Comment commentModel = new Comment()
                {
                    CommentName = comment
                };

                context.Comments.Add(commentModel);
                context.SaveChanges();
                return RedirectToAction("Index", "Main");
               
            }
        }
    }
}