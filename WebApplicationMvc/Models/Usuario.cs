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

        public Rol Rol { get; set; }
        
        // TODO: how to add as FK, not works 
        [ForeignKey("RolId")]
        public int? RolId { get; set; }
        
        
        // TODO: fix way for save passsword
        public bool ComparePasswordBase64(string plainPassword)
        {
            var encodedPlain = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword));
            return encodedPlain == Password;
        }
        
    }
}