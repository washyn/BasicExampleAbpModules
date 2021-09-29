using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // admin 123qwe
            if (ModelState.IsValid)
            {
                var user = _dbContex
                    .Usuarios
                    .Include(s => s.Rol)
                    .FirstOrDefault(a => a.User == input.User);

                if (user == null)
                {
                    ModelState.AddModelError(nameof(input.User),"Usuario no encontrado.");
                    return View(input);
                }
                else
                {
                    var resultCOmpare = user.ComparePasswordBase64(input.Password);
                    if (resultCOmpare)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim("UserId", user.Identificador.ToString()),
                            new Claim("FullName", $"{user.Nombres} {user.Apellidos}"),
                            new Claim(ClaimTypes.Role, user.Rol.Nombre),
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
                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password","Contraseña incorrecta.");
                        ModelState.AddModelError("Error","Revisa la contraseña.");
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