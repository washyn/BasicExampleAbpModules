using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationMvc.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        // public string Hora { get; set; }
        public EstadoCita Estado { get; set; }
        public DateTime FechaHora { get; set; }
        
        // public int Doctor { get; set; }
        // fk a usuario.
        
        public Usuario UsuarioPaciente { get; set; }
        public int UsuarioPacienteId { get; set; }
        
        public Usuario UsuarioDoctor { get; set; }
        public int UsuarioDoctorId { get; set; }
    }

    public enum EstadoCita
    {
        Atendido,
        Pendiente
    }
    
    public class Categorias
    {
        public static List<SelectListItem> GetCategorias()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem("Cardiologia","Cardiologia"),
                new SelectListItem("Pediatría","Pediatría"),
                new SelectListItem("Gastroenterologia","Gastroenterologia"),
                new SelectListItem("Odontología","Odontología"),
            };
        }
    }
}