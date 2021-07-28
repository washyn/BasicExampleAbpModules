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
    /// <summary>
    /// AllowAnonymous, esto permite que no requiera login entrar a las acciones de este
    /// controller
    /// </summary>
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public AccountController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }
        
        
        
        /// <summary>
        /// HttpGet -> para que acepte el metodo get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// HttpPost, para que acepte el metodo post
        /// , por defecto cuando input => es un objecto(compuesto), se toma del cuerpo de la peticion,
        /// returnUrl -> valor que se toma por URL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
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
                    ModelState.AddModelError("Error","Usuario no encontrado.");
                    return View(input);
                }
                else
                {
                    var resultCOmpare = user.ComparePasswordBase64(input.Password);
                    // si la conraseña es correcta, se hace el login
                    if (resultCOmpare)
                    {
                        // se crea una lista de claims(key par valyes) con datos del usuario
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
                        // TODO: cambiar por un nombre custom
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
            // se hace el logout especificando el esquema de autenticacion
            // para este caso esquema de autenticacion por cookies
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