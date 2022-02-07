using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelePSocial.Areas.Identity.Data;
using TelePSocial.Data;

[assembly: HostingStartup(typeof(TelePSocial.Areas.Identity.IdentityHostingStartup))]
namespace TelePSocial.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TelePSociaDblContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TelePSociaDblContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;

                })
                    .AddEntityFrameworkStores<TelePSociaDblContext>();
            });
        }
    }
}