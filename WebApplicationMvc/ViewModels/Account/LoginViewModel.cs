using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels.Account
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        [Required]
        public string User { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required]
        public string Password { get; set; }
    }
}