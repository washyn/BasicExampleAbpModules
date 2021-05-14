using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    public class ApplicationDbContex : DbContext
    {
        public DbSet<Detalle> Detalles { get; set; }

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }
        
    }
}