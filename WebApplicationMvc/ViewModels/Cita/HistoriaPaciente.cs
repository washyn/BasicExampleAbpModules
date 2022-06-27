using System;

namespace WebApplicationMvc.ViewModels.Cita
{
    public class HistoriaPaciente
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Diagnostico { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string Categoria { get; set; }
        // fk a medico, paciente, cita
        
    }
}