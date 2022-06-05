using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels.Usuarios;

namespace WebApplicationMvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public UsuariosController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }
        public IActionResult Index()
        {
            var usersTemp = _dbContex.Usuarios
                .Include(a => a.Rol)
                .Select(b => new UsuarioViewModel()
                {
                    Rol = b.Role,
                    FullName = b.Apellidos + " " + b.Nombres,
                    Id = b.Identificador,
                    UserName = b.User
                })
                .ToList();
            
            return View(usersTemp);
        }
        
        
        public IActionResult Create()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                 _dbContex.Usuarios
                    .Add(new Usuario()
                    {
                        Apellidos = model.Apellidos,
                        Nombres = model.Nombres,
                        Role = model.Rol,
                        User = model.UserName,
                        Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password))
                    });
                 _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        public IActionResult Eliminar(int id)
        {
            var user = _dbContex.Usuarios.FirstOrDefault(a => a.Identificador == id);
            _dbContex.Usuarios.Remove(user);
            _dbContex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int id)
        {
            var user = _dbContex.Usuarios.FirstOrDefault(a => a.Identificador == id);
            if (user != null)
            {
                var model = new UpdateUserViewModel()
                {
                    Apellidos = user.Apellidos,
                    Id = user.Identificador,
                    Nombres = user.Nombres,
                    Password = user.Password,
                    Rol = user.Role,
                    UserName = user.User,
                };
                return View(model);
            }

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult Update(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContex.Usuarios.FirstOrDefault(a => a.Identificador == model.Id);
                if (user != null)
                {
                    user.Apellidos = model.Apellidos;
                    user.Identificador = model.Id;
                    user.Nombres = model.Nombres;
                    user.Password = model.Password;
                    user.Role = model.Rol;
                    user.User = model.UserName;
                    
                    _dbContex.Usuarios.Update(user);
                    _dbContex.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}