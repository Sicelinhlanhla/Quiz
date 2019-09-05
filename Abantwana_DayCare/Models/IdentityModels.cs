using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Abantwana_DayCare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

		public string ContactNo { get; set; }
		public string Address { get; set; }
		public string FullName { get; set; }
		public bool isAdmin { get; set; }
		public bool isInstructor { get; set; }
		
		
		public string Comm_Method { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Toodler> Toodlers { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Parent_Model> Parent_Model { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.StaffMember> StaffMembers { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Enrollment> Enrollments { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Course> Courses { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Quiz> Quizs { get; set; }

		public System.Data.Entity.DbSet<Abantwana_DayCare.Models.Learning_Material> Learning_Material { get; set; }
	}
}