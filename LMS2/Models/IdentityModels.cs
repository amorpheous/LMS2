using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LMS2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LMS2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public int UserId { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {

                if (NickName != null && NickName.Length > 0)
                    return NickName + " " + LastName;
                else
                    return FirstName + " " + LastName;
            }
        }

        [StringLength(20, ErrorMessage = "Not more than 20 characters long, please")]
        public string NickName { get; set; }
        //  public string Email { get; set; }

        [Display(Name = "Is the user active?")]
        public bool IsActive { get; set; }

        [Display(Name = "About me")]
        [StringLength(200, ErrorMessage = "Additional info can at most be 200 characters long")]
        public string AdditionalInfo { get; set; }


        [StringLength(200, ErrorMessage = "Special info can at most be 200 characters long")]
        public string SpecialInfo { get; set; }

        public virtual Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public int? CourseId { get; set; }
          



        //fundera på det här
        // public virtual Roles Role_ { get; set; }





        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            
         //   userIdentity.AddClaim(new Claim("FirstName", this.FirstName));


            return userIdentity;
        }

        //public string GetFirstName(this System.Security.Principal.IPrincipal usr)
        //{
        //    var firstNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("FirstName");
        //    if (firstNameClaim != null)
        //        return firstNameClaim.Value;
        // @using HelperNamespace skall läggas i partiallogin

        //    return "";
        //}


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<LMS2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<LMS2.Models.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<LMS2.Models.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<LMS2.Models.ActivityType> ActivityTypes { get; set; }

      

        // public System.Data.Entity.DbSet<LMS2.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}