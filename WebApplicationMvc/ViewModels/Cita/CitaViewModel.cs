using System;

namespace WebApplicationMvc.ViewModels.Cita
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaHora { get; set; }
        public string Paciente { get; set; }
        public string Doctor { get; set; }
    }
}