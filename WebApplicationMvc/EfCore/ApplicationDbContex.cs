using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    // se agrega un db context, para el acceso a bd con EF
    public class ApplicationDbContex : DbContext
    {
        // esta propiedad hace referencia a la tabla, para poder hacer consultas a la propiedad
        // Detalles
        public DbSet<Detalle> Detalles { get; set; }

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }
        
    }
}