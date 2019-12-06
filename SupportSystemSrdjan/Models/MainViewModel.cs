using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystemSrdjan.Models
{
    public class MainViewModel
    {
        public int ID { get; set; }
        [DisplayName("Sugestion No")]
        public int? SugestionNo { get; set; }
        [DisplayName("Raised by")]
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Raised On")]
        public DateTime? CreatedOn { get; set; }
        [DisplayName("Status")]
        public int? StatusID { get; set; }
        [DisplayName("Category")]
        public int? CategoryID { get; set; }
        [DisplayName("Section")]
        public int? SectionID { get; set; }
        [DisplayName("Severity")]
        public int? SeverityID { get; set; }
        public string Title { get; set; }
        [DisplayName("Steps To Reproduce")]
        public string StepsToReproduce { get; set; }
        [DisplayName("Priority")]
        public int? PriorityID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Accepted On")]
        public DateTime? AcceptedOn { get; set; }
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DueOn { get; set; }
        [DisplayName("Resolved On")]
        public string ResolvedOn { get; set; }
        [DisplayName("Resolve Notes")]
        public string ResolveNotes { get; set; }
        [DisplayName("Status")]
        public string StatusName { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        [DisplayName("Severity")]
        public string SeverityName { get; set; }
        [DisplayName("Priority")]
        public string PriorityName { get; set; }
        [DisplayName("Section")]
        public string SectionName { get; set; }

        public int? CommentID { get; set; }
        public string CommentName { get; set; }
        
        public List<SelectListItem> Status { get; set; }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Severity { get; set; }
        public List<SelectListItem> Section { get; set; }
        public List<SelectListItem> Priority { get; set; }
        public List<SelectListItem> Comments { get; set; }

    }
}