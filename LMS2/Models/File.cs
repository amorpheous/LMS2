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
        public int Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public int CourseId { get; set; }
        public int moduleId { get; set; }
        public int ActivityId { get; set; }



        //Navigational properties
        public string UploaderId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}