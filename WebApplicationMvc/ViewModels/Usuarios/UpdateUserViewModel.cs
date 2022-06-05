using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels.Usuarios
{
    public class UpdateUserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public string Rol { get; set; }
    }
}