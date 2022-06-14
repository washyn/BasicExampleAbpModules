﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationMvc.EfCore;

namespace WebApplicationMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContex))]
    [Migration("20220614024648_adedAtenmtiopn")]
    partial class adedAtenmtiopn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationMvc.Models.Atencion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Receta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioPacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioDoctorId");

                    b.HasIndex("UsuarioPacienteId");

                    b.ToTable("Atencions");
                });

            modelBuilder.Entity("WebApplicationMvc.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioPacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioDoctorId");

                    b.HasIndex("UsuarioPacienteId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("WebApplicationMvc.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApplicationMvc.Models.Atencion", b =>
                {
                    b.HasOne("WebApplicationMvc.Models.Usuario", "UsuarioDoctor")
                        .WithMany("AtencionDoctor")
                        .HasForeignKey("UsuarioDoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplicationMvc.Models.Usuario", "UsuarioPaciente")
                        .WithMany("AtencionPaciente")
                        .HasForeignKey("UsuarioPacienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioDoctor");

                    b.Navigation("UsuarioPaciente");
                });

            modelBuilder.Entity("WebApplicationMvc.Models.Cita", b =>
                {
                    b.HasOne("WebApplicationMvc.Models.Usuario", "UsuarioDoctor")
                        .WithMany("CitasDoctor")
                        .HasForeignKey("UsuarioDoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplicationMvc.Models.Usuario", "UsuarioPaciente")
                        .WithMany("CitasPaciente")
                        .HasForeignKey("UsuarioPacienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioDoctor");

                    b.Navigation("UsuarioPaciente");
                });

            modelBuilder.Entity("WebApplicationMvc.Models.Usuario", b =>
                {
                    b.Navigation("AtencionDoctor");

                    b.Navigation("AtencionPaciente");

                    b.Navigation("CitasDoctor");

                    b.Navigation("CitasPaciente");
                });
#pragma warning restore 612, 618
        }
    }
}