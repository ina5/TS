using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TargetSystem.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(500)]
        public string Surname { get; set; }

        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public int WorkNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public int Pass { get; set; }

        [ForeignKey("Positions")]
        public int PositionId { get; set; }

        public virtual Positions Position { get; set; }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}