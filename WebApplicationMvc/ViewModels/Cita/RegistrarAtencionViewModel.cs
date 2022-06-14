using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels.Cita
{
    public class RegistrarAtencionViewModel
    {
        [Required]
        public string Diagnostico { get; set; }
        [Required]
        public string Recomendaciones { get; set; }
        
        [Required]
        public string Receta { get; set; }
        
        [Required]
        public int PacienteId { get; set; }
        
        // [Required]
        // public int CitaId { get; set; }
    }
}