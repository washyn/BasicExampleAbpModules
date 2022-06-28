using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using WebApplicationMvc.CustomHandler;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels.Cita;

namespace WebApplicationMvc.Controllers
{
    [Authorize(Roles = Rol.Medico)]
    public class AtencionController : Controller
    {
        private readonly ApplicationDbContex _dbContex;
        private readonly IHostEnvironment _hostEnvironment;

        public AtencionController(ApplicationDbContex dbContex,
            IHostEnvironment hostEnvironment)
        {
            _dbContex = dbContex;
            _hostEnvironment = hostEnvironment;
        }
        
        // public IActionResult Pacientes()
        // {
        //     // mostrara pacientes con cita... para atenderslos
        //     return View();
        // }


        public IActionResult Index()
        {
            // get user id
            var currentUser = this.User.GetUserId().To<int>();
            var pacientes = _dbContex.Citas
                .Include(a => a.UsuarioPaciente)
                .Where(a => a.UsuarioDoctorId == currentUser)
                .Where(a => a.Estado == EstadoCita.Pendiente)
                .ToList();
            return View(pacientes);
        }
        

        // registra atencion
        [HttpGet]
        public IActionResult Registrar([FromQuery]int pacienteId, [FromQuery]int citaId)
        {
            // ViewData
            // ViewBag
            // TempData
            ViewData["pacienteId"] = pacienteId;
            ViewData["citaId"] = citaId;
            var paciente = _dbContex.Usuarios.AsNoTracking().FirstOrDefault(a => a.Id == pacienteId);
            ViewData["nombrePaciente"] = paciente.ToString();
            return View();
        }
        
        [HttpPost]
        public IActionResult Registrar([FromQuery]int pacienteId,[FromQuery]int citaId, [FromForm]RegistrarAtencionViewModel model)
        {
            ViewData["pacienteId"] = pacienteId;
            ViewData["citaId"] = citaId;
            var paciente = _dbContex.Usuarios.AsNoTracking().FirstOrDefault(a => a.Id == pacienteId);
            ViewData["nombrePaciente"] = paciente.ToString();
            
            
            if (ModelState.IsValid)
            {
                var user = User.GetUserId().To<int>();
                _dbContex.Atencions.Add(new Atencion()
                {
                    Fecha = DateTime.Now,
                    Diagnostico = model.Diagnostico,
                    Receta = model.Receta,
                    Recomendaciones = model.Recomendaciones,
                    UsuarioPacienteId = pacienteId,
                    UsuarioDoctorId = user,
                    CitaId = citaId,
                });
                var cita = _dbContex.Citas.FirstOrDefault(a => a.Id == citaId);
                cita.Estado = EstadoCita.Atendido;
                _dbContex.Citas.Update(cita);
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}