using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.ViewModels.Cita;

namespace WebApplicationMvc.Controllers
{
    [Authorize(Roles = Rol.Asistente + "," + Rol.Medico)]
    public class HistorialController : Controller
    {
        private readonly ServiceList _serviceList;
        private readonly ApplicationDbContex _dbContex;

        public HistorialController(Services.ServiceList serviceList, 
            ApplicationDbContex dbContex)
        {
            _serviceList = serviceList;
            _dbContex = dbContex;
        }

        public IActionResult Index(int? pacienteId)
        {
            ViewData["pacienteId"] = pacienteId;
            ViewData["pacientes"] = _serviceList.GetPacientes();
            
            var historia = new List<HistoriaPaciente>();

            if (pacienteId.HasValue)
            {
                var paciente = _dbContex.Usuarios.FirstOrDefault(a => a.Id == pacienteId.Value);
                ViewData["nombre"] = paciente.ToString();

                var atenciones = _dbContex.Atencions
                    .Include(a => a.UsuarioDoctor)
                    .Where(a => a.UsuarioPacienteId == pacienteId.Value)
                    .Select(a => new HistoriaPaciente()
                    {
                        Diagnostico = a.Diagnostico,
                        FechaAtencion = a.Fecha,
                        Doctor = a.UsuarioDoctor.ToString()
                    })
                    .ToList();
                
                historia.AddRange(atenciones);
            }
            return View(historia);
        }
    }
}