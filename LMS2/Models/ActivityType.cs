using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS2.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        [Display(Name = "Activity Type")]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        [Required]
        public string ActivityTypeName { get; set; }
        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; } = DateTime.Now;

    }
}