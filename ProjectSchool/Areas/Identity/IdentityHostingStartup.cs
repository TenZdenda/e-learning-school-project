using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectSchool.Areas.Identity.Data;
using ProjectSchool.Data;

[assembly: HostingStartup(typeof(ProjectSchool.Areas.Identity.IdentityHostingStartup))]
namespace ProjectSchool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjectSchoolDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProjectSchoolDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ProjectSchoolDbContext>();
            });
        }
    }
}