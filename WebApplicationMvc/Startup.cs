using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.CustomHandler;
using WebApplicationMvc.EfCore;

namespace WebApplicationMvc
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
            // se agrega la configuracion de contexto de base de datos para poder resolverlo en la DI,
            services.AddDbContext<ApplicationDbContex>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // agregamos autenticacion basada en cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // public static readonly PathString LoginPath = new PathString("/Account/Login");
                    // public static readonly PathString LogoutPath = new PathString("/Account/Logout");
                    // public static readonly PathString AccessDeniedPath = new PathString("/Account/AccessDenied");
                    // public static readonly string ReturnUrlParameter = "ReturnUrl";
                    
                    
                    // se defien rutas para el login, logout y acceso denegado
                    options.LoginPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.AccessDeniedPath = new PathString("/Account/AccessDenied");

                    options.ReturnUrlParameter = "ReturnUrl";
                    
                    // tiempo de duracion de la cookie
                    options.ExpireTimeSpan = TimeSpan.MaxValue;
                });
            
            // Se agrega el handler(manejador) de authorizacion, custom
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
            
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // se agrega authenticacion, verificacion de creadenciasles
            app.UseAuthentication(); 
            
            // se agrega, autorizacion, rol
            // verificacion de permisos
            app.UseAuthorization(); 

            
            app.UseEndpoints(endpoints =>
            {
                // configuracion de rutas, 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
