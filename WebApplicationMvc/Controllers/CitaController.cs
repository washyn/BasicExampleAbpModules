using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels.Cita;

namespace WebApplicationMvc.Controllers
{
    public class CitaController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public CitaController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        [AllowAnonymous]
        public IActionResult Index(DateTime? date)
        {
            // date = date ?? DateTime.Now;
            ViewData["date"] = date;
            
            var model = _dbContex.Citas
                .Include(a => a.UsuarioDoctor)
                .Include(a => a.UsuarioPaciente)
                .WhereIf(date.HasValue, cita => cita.FechaHora.Date == date.Value.Date)
                .Where(a => a.Estado == EstadoCita.Pendiente)
                .ToList()
                .Select(a => new CitaViewModel()
                {
                    Id = a.Id,
                    Categoria = a.Categoria,
                    Doctor = a.UsuarioDoctor.ToString(),
                    Paciente = a.UsuarioPaciente.ToString(),
                    FechaHora = a.FechaHora,
                })
                .ToList();
            
            return View(model);
        }
        
        [Authorize(Roles = Rol.Asistente)]
        [HttpPost]
        public IActionResult Registrar(RegistrarCitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                _dbContex.Citas.Add(new Cita()
                {
                    Categoria = model.Categoria,
                    Descripcion = model.Descripcion,
                    Estado = EstadoCita.Pendiente,
                    UsuarioPacienteId = model.PacienteId,
                    UsuarioDoctorId = model.DoctorId,
                    FechaHora = model.FechaHora,
                });
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        [Authorize(Roles = Rol.Asistente)]
        public IActionResult Registrar()
        {
            return View();
        }
        
        [Authorize(Roles = Rol.Asistente)]
        [HttpGet]
        public IActionResult Cancelar(int id)
        {
            var user = _dbContex.Citas.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                user.Estado = EstadoCita.Cancelado;
                _dbContex.Citas.Update(user);
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}