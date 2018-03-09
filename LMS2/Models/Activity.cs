using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS2.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Activity Type")]
        public string ActivityType { get; set; }
        [StringLength(200, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        public string Description { get; set; }
        
        //Navigational property
        [Display(Name = "Module")]
        public virtual Module Module { get; set; }

        [Display(Name = "Activity Type")]
        public virtual ActivityType ActivityType_ { get; set; }  //????????
        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Duration (days)")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive integers are valid")]
        public int DurationDays { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; } = DateTime.Now;
        [Display(Name = "Activity info")]
        [StringLength(5000, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        public string ActivityInfo { get; set; }

        /*        Appendices*/
}
}