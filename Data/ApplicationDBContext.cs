
using System.Reflection;
using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNetIdentity.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //Models
        public DbSet<User> Users { get; set; }
    }
}