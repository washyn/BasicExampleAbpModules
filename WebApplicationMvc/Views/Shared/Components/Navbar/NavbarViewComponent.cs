using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}