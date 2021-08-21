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
                            // se agrega el nombre del rol del usaurio para verificar la autorizacion
                            // TODO: add Rol name and remove custom role checher
                            new Claim(ClaimTypes.Role, user.Rol.Nombre),
                            new Claim(ClaimTypes.Name, user.User),
                        };
                        // agregar rol y date of bird
            
                        // se crea un obj con las propuedades de la Authebticacion
                        var authProps = new AuthenticationProperties()
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.MaxValue,
                            AllowRefresh = true,
                        };
            
                        // se crear un identity claims
                        var identityClaims = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                        // se hace un logout si es que ya habia un sesion anterior
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        
                        // se hace el login, con los claims, el equema q se usara y las propiedades
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, 
                            new ClaimsPrincipal(identityClaims),
                            authProps);
                        
                        // if returnUrl has val  redirect
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