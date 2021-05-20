using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplicationMvc.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key] public int Identificador { get; set; }

        [Column("STR_NOMB")] public string Nombres { get; set; } = "Sin Nombre";

        [Column("STR_APE")] public string Apellidos { get; set; } = "No registrado";

        

        [Column("STR_USUARIO")] public string User { get; set; }

        [Column("STR_CONTRA")] public string Password { get; set; }

        public bool ComparePasswordBase64(string plainPassword)
        {
            // El guardado de contraseña deberia hacerce con BCript Sha156, SHA512 o una forma parecida,
            // debido a que el usuario solicito no usar un framework o cosas complejas se esta guardando en base64
            
            var encodedPlain = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword));
            return encodedPlain == Password;
        }
        
    }
}