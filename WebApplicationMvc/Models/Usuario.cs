using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplicationMvc.Models
{
    // Este decorador es para especificar en nombre de la tabla que se va ah crear con EF, o 
    // si es qye ya existe una tabla el nombre al cual se hara el mapeo
    [Table("Usuarios")]
    public class Usuario
    {
        // el decorador KEy  es para especificar el primary key o la clave primaria
        [Key] public int Id { get; set; }

        // Column -> le especifica el nombre de columna donde se mapeara
        // [Column("STR_NOMB")] 
        public string Nombres { get; set; } = "Sin Nombre";

        // [Column("STR_APE")] 
        public string Apellidos { get; set; } = "No registrado";

        

        // [Column("STR_USUARIO")] 
        public string User { get; set; }

        // [Column("STR_CONTRA")] 
        public string Password { get; set; }

        // public Rol Rol { get; set; }
        
        // TODO: no de deja poner como fk ...
        // [ForeignKey("RolId")]
        // public int? RolId { get; set; }

        public string Role { get; set; }
        
        /// <summary>
        /// Funciona para comparar la contraseña al iniciar sesion(login),
        /// la contrasena se guarda en base64 para agregarle algo de seguridad basica 
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <returns></returns>
        public bool ComparePasswordBase64(string plainPassword)
        {
            // El guardado de contraseña deberia hacerce con BCript Sha156, SHA512 o una forma parecida,
            // debido a que el usuario solicito no usar un framework o cosas complejas se esta guardando en base64
            
            var encodedPlain = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword));
            return encodedPlain == Password;
        }

        public IEnumerable<Cita> CitasDoctor { get; set; }
        public IEnumerable<Cita> CitasPaciente { get; set; }
        
        public IEnumerable<Atencion> AtencionPaciente { get; set; }
        public IEnumerable<Atencion> AtencionDoctor { get; set; }
        
        public override string ToString()
        {
            return $"{Nombres} {Apellidos}";
        }
    }
}