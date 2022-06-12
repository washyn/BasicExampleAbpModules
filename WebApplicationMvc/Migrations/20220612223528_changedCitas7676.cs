using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class changedCitas7676 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioDoctorId",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioPacienteId",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioDoctorId",
                table: "Citas",
                column: "UsuarioDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioPacienteId",
                table: "Citas",
                column: "UsuarioPacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_UsuarioDoctorId",
                table: "Citas",
                column: "UsuarioDoctorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_UsuarioPacienteId",
                table: "Citas",
                column: "UsuarioPacienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UsuarioDoctorId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UsuarioPacienteId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_UsuarioDoctorId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_UsuarioPacienteId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UsuarioDoctorId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UsuarioPacienteId",
                table: "Citas");
        }
    }
}
