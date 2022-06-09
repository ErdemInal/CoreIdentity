using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CoreIdentity.Context;
using CoreIdentity.CustomValidator;
using Microsoft.AspNetCore.Http;

namespace CoreIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                //opt.Password.RequireDigit = false;
                //opt.Password.RequireLowercase = false;
                //opt.Password.RequireUppercase = false;
                //opt.Password.RequiredLength = 1;
                //opt.Password.RequireNonAlphanumeric = false;
                //opt.SignIn.RequireConfirmedEmail = true;
            }).AddPasswordValidator<CustomPasswordValidator>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/Index");
                opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "IdentityCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                
            });

            //claim bazlý yetkilendirme sadece kadýnlar girsin...
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("FemalePolicy", cnf => { cnf.RequireClaim("gender", "female"); });
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
