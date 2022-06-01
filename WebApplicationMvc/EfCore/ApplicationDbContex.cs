using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    public class ApplicationDbContex : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        
        
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }
    }
}