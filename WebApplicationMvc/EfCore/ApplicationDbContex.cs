using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    public class ApplicationDbContex : AbpDbContext<ApplicationDbContex>
    {
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        
        
        
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }
        
    }
}