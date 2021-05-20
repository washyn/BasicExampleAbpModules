using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels.Account
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string User { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Password { get; set; }
    }
}