namespace WebApplicationMvc.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public const string Admin = "Admin";
        public const string Usuario = "Usuario";
    }
}