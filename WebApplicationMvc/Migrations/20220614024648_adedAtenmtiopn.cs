using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class adedAtenmtiopn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UsuarioPacienteId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_UsuarioDoctorId",
                table: "Atencions",
                column: "UsuarioDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_UsuarioPacienteId",
                table: "Atencions",
                column: "UsuarioPacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atencions");
        }
    }
}
