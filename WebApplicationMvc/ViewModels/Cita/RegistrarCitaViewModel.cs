using System;
using System.ComponentModel.DataAnnotations;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels.Cita
{
    public class RegistrarCitaViewModel
    {
        // public int Id { get; set; }
        [Required]
        public string Categoria { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string Descripcion { get; set; }
        // public EstadoCita Estado { get; set; }
        
        [Display(Name = "Fecha y hora")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        // public Usuario Paciente { get; set; }
        [Display(Name = "Paciente")]
        [Required]
        public int PacienteId { get; set; }
        
        // public Usuario Doctor { get; set; }
        [Display(Name = "Doctor")]
        [Required]
        public int DoctorId { get; set; }
    }
}