using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvc.Controllers
{
    public class DetailController : Controller
    {
        public DetailController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}