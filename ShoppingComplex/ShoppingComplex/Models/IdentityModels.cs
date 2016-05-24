using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingComplex.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("MvcShoppingComplex") {}
        public DbSet<WebAction> WebActions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public virtual List<Permission> Permissions { get; set; }
    }

    public class WebAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }

        public virtual List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public int Id { get; set; }
        public int WebActionId { get; set; }
        public string RoleId { get; set; }
        public bool Allowable { get; set; }

        public virtual WebAction Action { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}