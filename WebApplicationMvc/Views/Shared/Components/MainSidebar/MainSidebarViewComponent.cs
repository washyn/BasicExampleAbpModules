using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Views.Shared.Components.MainSidebar
{
    public class MainSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}