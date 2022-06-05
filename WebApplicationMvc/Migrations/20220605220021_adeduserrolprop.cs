using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class adeduserrolprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "USUARIOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "USUARIOS");

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booleano = table.Column<bool>(type: "bit", nullable: true),
                    CualquierNombreDeCadena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NombreEntero = table.Column<int>(type: "int", nullable: true),
                    Enum = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Flotante = table.Column<float>(type: "real", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cadena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entero = table.Column<int>(type: "int", nullable: false),
                    Enum = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flotante = table.Column<float>(type: "real", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaestroId = table.Column<int>(type: "int", nullable: true),
                    MaestroId1 = table.Column<long>(type: "bigint", nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    booleano = table.Column<bool>(type: "bit", nullable: false),
                    decimanl = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalles_Maestros_MaestroId1",
                        column: x => x.MaestroId1,
                        principalTable: "Maestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_MaestroId1",
                table: "Detalles",
                column: "MaestroId1");
        }
    }
}
