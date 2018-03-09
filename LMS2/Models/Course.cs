using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [StringLength(200, ErrorMessage = "The description can not be more than 200 characters long")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive integers are valid")]
        [Display(Name = "Duration (days)")]
        public int DurationDays { get; set; }

        public DateTime CreationTime { get; } = DateTime.Now;

        [Display(Name = "Urgent information")]
        public string UrgentInfo { get; set; }
        //Appendices/Documents

        public virtual ICollection<ApplicationUser> AttendingStudents { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}