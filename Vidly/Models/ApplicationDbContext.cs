using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Vidly.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Vidly
{
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }

  public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("name=ApplicationDataModel")
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      base.OnModelCreating(modelBuilder);
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}
