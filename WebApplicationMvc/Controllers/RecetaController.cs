using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.CustomHandler;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Controllers
{
    [Authorize(Roles = Rol.Paciente)]
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public RecetaController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        public ActionResult Index()
        {
            var pacienteId = User.GetUserId().To<int>();
            // TODO: enviar una receta a la vista y crear el modelo apartir de la ultima atencion a este paciente.
            var receta = _dbContex.Atencions
                .Include(a => a.UsuarioDoctor)
                .Where(a => a.UsuarioPacienteId == pacienteId)
                .OrderByDescending(a => a.Fecha)
                .Select(a => new RecetaViewModel()
                {
                    Id = a.Id,
                    Doctor = a.UsuarioDoctor.ToString(),
                    Receta = a.Receta,
                    Fecha = a.Fecha
                    
                })
                .FirstOrDefault();
            
            return View(receta);
        }
    }

    public class RecetaViewModel
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Receta { get; set; }
        public DateTime Fecha { get; set; }
    }
}