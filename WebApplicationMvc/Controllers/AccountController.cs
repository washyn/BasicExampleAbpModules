using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.ViewModels.Account;

namespace WebApplicationMvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                //
                if (input.User == "1" && input.Password == "1")
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, "sakjhdkjas@asd.dsa"),
                        new Claim(ClaimTypes.Role, "dsadsa"),
                        new Claim(ClaimTypes.Name, "ttttttt"),
                        new Claim(ClaimTypes.Role, "uuuttttt"),
                    };
            
                    var authProps = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.MaxValue,
                        AllowRefresh = true,
                    };
            
                    var identityClaims = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(identityClaims),
                        authProps);
                    // if returnUrl has val  redirect
                    return RedirectToAction("Index", "Home");
                }
                else
                {   
                    ModelState.AddModelError("Error","El usuario o contrasña es incorrecto.");
                    return View(input);
                }
            }
            
            return View(input);
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
        
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
    }
}