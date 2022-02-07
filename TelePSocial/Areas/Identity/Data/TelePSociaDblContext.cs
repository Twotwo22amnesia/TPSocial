using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TelePSocial.Areas.Identity.Data;
using TelePSocial.Entidades;

namespace TelePSocial.Data
{
    public class TelePSociaDblContext : IdentityDbContext<ApplicationUser>
    {
        public TelePSociaDblContext(DbContextOptions<TelePSociaDblContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Ignore(c => c.LockoutEnd);
            builder.Entity<LogSes>().ToTable("LogSes");
            builder.Entity<PubliUsers>().ToTable("PubliUsers");
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<LogSes> LogSes { get; set; }
        public DbSet<PubliUsers> PubliUsers { get; set; }
        

    }
}
