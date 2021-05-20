using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.ViewModels.Account;

namespace WebApplicationMvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public AccountController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }
        
        
        
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
                var user = _dbContex.Usuarios.FirstOrDefault(a => a.User == input.User);

                if (user == null)
                {
                    ModelState.AddModelError("Error","Usuario no encontrado.");
                    return View(input);
                }
                else
                {
                    var resultCOmpare = user.ComparePasswordBase64(input.Password);
                    if (resultCOmpare)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Email, String.Empty),
                            new Claim(ClaimTypes.Role, String.Empty),
                            new Claim(ClaimTypes.Name, user.User),
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
                        ModelState.AddModelError("Error","Contraseña incorrecta.");
                        return View(input);
                    }
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