using System;

namespace WebApplicationMvc.Models
{
    public class Atencion
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; }
        public string Recomendaciones { get; set; }
        public DateTime Fecha { get; set; }
        public string Receta { get; set; }
        
        public int UsuarioDoctorId { get; set; }
        public Usuario UsuarioDoctor { get; set; }
        
        public int UsuarioPacienteId { get; set; }
        public Usuario UsuarioPaciente { get; set; }

        // TODO: improve as required
        public Cita Cita { get; set; }
        public int CitaId { get; set; }
    }
}