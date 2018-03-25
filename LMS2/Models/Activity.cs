using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LMS2.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        [Display(Name = "Activity name")]
        [Required]
        public string ActivityName
        {
            get
            { return activityName; }
            set
            {
                activityName = InitialCapital(value);
            }
        }
        protected string activityName { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        [Required]
        public string Description { get; set; }

        [DefaultDateTimeValue("Now")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Time (start)")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Only 00:00 to 23:59 are valid start times")]
        [Required]
        public TimeSpan StartTime { get; set; }

       

        [Display(Name = "Time (stop)")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^((([0-1]\d|2[0-3]):([0-5]?[0-9])(:([0-5]\d))?)|24:00)$",
        ErrorMessage = "Only 00:00 to 24:00 are valid stop times")]
        [Required]
        public TimeSpan StopTime { get; set; }

        [StringLength(5000, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        [Display(Name = "Activity info")]
        public string ActivityInfo { get; set; }
        
        //navigational property
        public int ModuleId { get; set; }
        public IEnumerable<Module> Modules { get; set; }
        public virtual Module Module { get; set; }

        //   Appendices
        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        
        //for drop down list
        public IEnumerable<ActivityType> ActivityTypes { get; set; }


        public string InitialCapital(string value)
    {
        if (value == null | value.Trim().Length == 0) value = "";
        if (value.Trim().Length > 1)
            value = value.Trim().Substring(0, 1).ToUpper() + value.Trim().Substring(1, value.Length - 1).ToLower();
        else
            value = value.Trim().ToUpper();
        return value;
    }
        [AttributeUsage(AttributeTargets.Property)]
        public sealed class DefaultDateTimeValueAttribute : ValidationAttribute
        {
            public string DefaultValue { get; set; }

            public DefaultDateTimeValueAttribute(string defaultValue)
            {
                DefaultValue = defaultValue;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                PropertyInfo property = validationContext.ObjectType.GetProperty(validationContext.MemberName);

                // Set default value only if no value is already specified 
                if (value == null)
                {
                    DateTime defaultValue = DateTime.Now.Date;
                    property.SetValue(validationContext.ObjectInstance, defaultValue);
                }

                return ValidationResult.Success;
            }
        }
    }
}



