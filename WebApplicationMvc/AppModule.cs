using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Localization;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace WebApplicationMvc
{

    // TODO: add configs
    // TODO: add abp front base libs, used by default abp theme or add lepton theme
    // TODO: add boostrap default libs for abp-tag-helpers used by tag helpers
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiBootstrapModule),
        typeof(AbpAspNetCoreMvcUiBundlingModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreModule),
        typeof(AbpLocalizationModule))]
    // [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddDbContext<ApplicationDbContex>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #region Localization


            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AppModule>("WebApplicationMvc");
            });
            
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<TestResource>("en")
                    .AddVirtualJson("/Localization/Application");
            });            

            // Configure<AbpLocalizationOptions>(options =>
            // {
            //     options.DefaultResourceType = typeof(TestResource);
            // });
            //
            #endregion

            
            context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                    options.ReturnUrlParameter = "ReturnUrl";
                    options.ExpireTimeSpan = TimeSpan.MaxValue;
                });
            
            // https://github.com/HakanL/WkHtmlToPdf-DotNet
            context.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
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
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}