using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                historia.AddRange(new []
                {
                    new HistoriaPaciente()
                    {
                        Diagnostico = "Inflamacion de cabeza.",
                        Doctor = "Doctor",
                        FechaAtencion = DateTime.Now,
                    },
                    new HistoriaPaciente()
                    {
                        Diagnostico = "Inflamacion de cabeza.",
                        Doctor = "Doctor",
                        FechaAtencion = DateTime.Now,
                    },
                    new HistoriaPaciente()
                    {
                        Diagnostico = "Inflamacion de cabeza.",
                        Doctor = "Doctor",
                        FechaAtencion = DateTime.Now,
                    }
                });
            }
            return View(historia);
        }
    }
}