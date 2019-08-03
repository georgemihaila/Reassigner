using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using Microsoft.Extensions.Logging;
using Reassigner.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Reassigner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFrameworkSqlServer();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddHostedService<ReassigningService>();
            services.AddSingleton<IActiveDirectoryAuthenticationService, MockActiveDirectoryAuthenticationService>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(CookieAuthenticationDefaults.AuthenticationScheme, authBuilder =>
                {
                    authBuilder.RequireRole("User");
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/auth/Login";
                options.LogoutPath = "/auth/Logout";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
