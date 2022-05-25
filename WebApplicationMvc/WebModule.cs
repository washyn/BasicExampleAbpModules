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
using Volo.Abp.AspNetCore.Mvc.UI.Packages;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using WebApplicationMvc.Bundling;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Localization;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace WebApplicationMvc
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiBundlingModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpLocalizationModule))]
    public class WebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddDbContext<ApplicationDbContex>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            context.Services.AddAbpDbContext<ApplicationDbContex>(builder =>
            {
                builder.AddDefaultRepositories(includeAllEntities: true);
            });
            
            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                {
                    configurationContext.UseSqlServer();
                });
            });
            
            #region Localization


            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<WebModule>("WebApplicationMvc");
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

            ConfigureAuth(context);
            ConfigureBundles();
            
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


        public void ConfigureAuth(ServiceConfigurationContext context)
        {
              
            context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                    options.ReturnUrlParameter = "ReturnUrl";
                    options.ExpireTimeSpan = TimeSpan.MaxValue;
                });
        }

        public void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    StandardBundles.Styles.Global,
                    bundle =>
                    {
                        // bundle.AddFiles("/global-styles.css");
                        bundle.Contributors.Add<GlobalStyleContributor>();
                    }
                );
            
                options.ScriptBundles.Configure(
                    StandardBundles.Scripts.Global,
                    bundle =>
                    {
                        // bundle.AddFiles("/global-script.js");
                        bundle.Contributors.Add(typeof(GlobalScriptContributor));
                    }
                );
            });
        }
    }
}