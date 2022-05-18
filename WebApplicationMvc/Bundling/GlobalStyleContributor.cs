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
    [DependsOn(typeof(SharedThemeGlobalStyleContributor))]
    public class GlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
        }

        public override void PostConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/css/site.css");
        }
    }
}
