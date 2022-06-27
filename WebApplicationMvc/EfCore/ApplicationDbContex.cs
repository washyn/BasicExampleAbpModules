using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.EfCore
{
    public class ApplicationDbContex : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Atencion> Atencions { get; set; }
        // public DbSet<Rol> Roles { get; set; }
        
        
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new CitaEntityTypeConfiguration().Configure(modelBuilder.Entity<Cita>());
            new AtencionEntityTypeConfiguration().Configure(modelBuilder.Entity<Atencion>());
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
            
            builder.HasOne(a => a.Atencion)
                .WithOne(a => a.Cita)
                .HasForeignKey<Atencion>(b => b.CitaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    
    public class AtencionEntityTypeConfiguration : IEntityTypeConfiguration<Atencion>
    {
        public void Configure(EntityTypeBuilder<Atencion> builder)
        {
            builder.HasOne(a => a.UsuarioDoctor)
                .WithMany(a => a.AtencionDoctor)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(a => a.UsuarioPaciente)
                .WithMany(a => a.AtencionPaciente)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(a => a.Cita)
                .WithOne(a => a.Atencion)
                .HasForeignKey<Cita>(b => b.AtencionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}