using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atencions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Receta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioDoctorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioPacienteId = table.Column<int>(type: "int", nullable: false),
                    CitaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atencions_Usuarios_UsuarioDoctorId",
                        column: x => x.UsuarioDoctorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atencions_Usuarios_UsuarioPacienteId",
                        column: x => x.UsuarioPacienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioPacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioDoctorId = table.Column<int>(type: "int", nullable: false),
                    AtencionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Atencions_AtencionId",
                        column: x => x.AtencionId,
                        principalTable: "Atencions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_UsuarioDoctorId",
                        column: x => x.UsuarioDoctorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_UsuarioPacienteId",
                        column: x => x.UsuarioPacienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_UsuarioDoctorId",
                table: "Atencions",
                column: "UsuarioDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_UsuarioPacienteId",
                table: "Atencions",
                column: "UsuarioPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_AtencionId",
                table: "Citas",
                column: "AtencionId",
                unique: true,
                filter: "[AtencionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioDoctorId",
                table: "Citas",
                column: "UsuarioDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioPacienteId",
                table: "Citas",
                column: "UsuarioPacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Atencions");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
