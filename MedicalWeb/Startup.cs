using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.data.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalWeb
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EfUnitOfWork>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Medical.data.EF")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => 
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                    options.AccessDeniedPath = "/User/Forbidden/";
                });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}"); 
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default2", template: "{controller=Home}/{action=Details}/{id?}");
            });
        }
    }
}
