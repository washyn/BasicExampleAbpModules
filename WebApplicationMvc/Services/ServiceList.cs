using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services
{
    public class ServiceList
    {
        private readonly ApplicationDbContex _dbContex;

        public ServiceList(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        public List<SelectListItem> GetDoctores()
        {
            return _dbContex.Usuarios.Where(a => a.Role == Rol.Medico)
                .ToList()
                .Select(a => new SelectListItem(a.ToString(), a.Id.ToString()))
                .ToList();
        }
        
        public List<SelectListItem> GetPacientes()
        {
            return _dbContex.Usuarios.Where(a => a.Role == Rol.Paciente)
                .ToList()
                .Select(a => new SelectListItem(a.ToString(), a.Id.ToString()))
                .ToList();
        }
    }
}