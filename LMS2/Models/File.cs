using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS2.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CourseId { get; set; }
        public string ModuleId { get; set; }
        public string ActivityId { get; set; }


        //Navigational properties
        
        public virtual ApplicationUser ApplicationUserId { get; set; }
    }
}