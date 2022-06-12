using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.CustomHandler;

namespace WebApplicationMvc.Views.Shared.Components.UserInfo
{
    public class UserInfoViewComponent : ViewComponent
    {
        public UserInfoViewComponent()
        {
            
        }
        
        public IViewComponentResult Invoke()
        {
            var model = new UserInfoViewModel()
            {
                UserName = this.UserClaimsPrincipal.GetLoggedInUserName(),
                Rol = UserClaimsPrincipal.GetRol()
            };
            return View(model);
        }
    }
}