using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    public class ApplicationDbContex : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        // public DbSet<Rol> Roles { get; set; }
        
        
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new CitaEntityTypeConfiguration().Configure(modelBuilder.Entity<Cita>());
        }
    }
    
    public class CitaEntityTypeConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.HasOne(a => a.UsuarioDoctor)
                .WithMany(a => a.CitasDoctor)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(a => a.UsuarioPaciente)
                .WithMany(a => a.CitasPaciente)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}