using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.BootstrapDatepicker;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Core;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.DatatablesNetBs4;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.FontAwesome;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.MalihuCustomScrollbar;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Toastr;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace WebApplicationMvc.Bundling
{
    // [DependsOn(
    //     typeof(CoreStyleContributor),
    //     typeof(BootstrapStyleContributor),
    //     typeof(FontAwesomeStyleContributor),
    //     typeof(ToastrStyleBundleContributor),
    //     typeof(Select2StyleContributor),
    //     typeof(MalihuCustomScrollbarPluginStyleBundleContributor),
    //     typeof(DatatablesNetBs4StyleContributor),
    //     typeof(BootstrapDatepickerStyleContributor)
    // )]
    [DependsOn(typeof(SharedThemeGlobalStyleContributor))]
    public class GlobalStyleContributor : BundleContributor
    {
        // TODO: add styles and test datatable 
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // context.Files.AddRange(new[]
            // {
            //     "/libs/abp/aspnetcore-mvc-ui-theme-shared/datatables/datatables-styles.css"
            // });
        }

        public override void PostConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/css/site.css");
        }
    }
}
