using System;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    public class AtencionPdfViewModel
    {

        public int Numero { get; set; }
        public string Diagnostico { get; set; }
        public string Recomendaciones { get; set; }
        public DateTime Fecha { get; set; }
        public string Receta { get; set; }
        
        // public int UsuarioDoctorId { get; set; }
        public string UsuarioDoctor { get; set; }
        
        // public int UsuarioPacienteId { get; set; }
        public string UsuarioPaciente { get; set; }

        // TODO: improve as required
        // public Cita Cita { get; set; }
        // public int CitaId { get; set; }
        
        public string Categoria { get; set; }
    }
}