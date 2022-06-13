using System;

namespace WebApplicationMvc.ViewModels.Cita
{
    public class HistoriaPaciente
    {
        public string Doctor { get; set; }
        public string Diagnostico { get; set; }
        public DateTime FechaAtencion { get; set; }
        // fk a medico, paciente, cita
        
    }
}