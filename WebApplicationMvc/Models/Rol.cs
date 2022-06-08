using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationMvc.Models
{
    public class Rol
    {
        // public int Id { get; set; }
        // public string Nombre { get; set; }
        // public string Descripcion { get; set; }
        //
        // public const string Admin = "Admin";
        // public const string Usuario = "Usuario";
        //
        public const string Paciente = "Paciente";
        public const string Asistente = "Asistente";
        public const string Medico = "Medico";

        public static List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem("Paciente", "Paciente"),
                new SelectListItem("Asistente", "Asistente"),
                new SelectListItem("Medico", "Medico"),
            };
        }
    }
}