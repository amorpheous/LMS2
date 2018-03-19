using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [StringLength(200, ErrorMessage = "The description can at most be 200 characters long")]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }
        [Display(Name = "Duration (days)")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive integers are valid")]
        public int DurationDays { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate
        { get { return StartDate.AddDays(DurationDays - 1); } }
        [Display(Name = "Urgent information")]
        public string UrgentInfo { get; set; }
        protected bool historic;
        public bool Historic
        {
            get {
                return historic; }
            set
            {
                if (EndDate < DateTime.Now.Date)
                    historic = true;
                else historic = false;
            }
        }


        //Appendices/Documents
 

        public virtual ICollection<ApplicationUser> AttendingStudents { get; set; }
        public virtual ICollection<Module> Modules { get; set; }

        
    }
}