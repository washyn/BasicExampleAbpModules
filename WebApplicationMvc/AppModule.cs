using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using WebApplicationMvc.EfCore;

namespace WebApplicationMvc
{
    // TODO: add autofact
    // TODO: add automapper
    // TODO: add serilog and configs
    // Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form
    [DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBundlingModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            // se agrega la configuracion de contexto de base de datos para poder resolverlo en la DI,
            context.Services.AddDbContext<ApplicationDbContex>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // agregamos autenticacion basada en cookies
            context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
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
            // services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            context.Services.AddControllersWithViews();
        }


        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

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
            // se agrega, autorizacion, rol verificacion de permisos
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