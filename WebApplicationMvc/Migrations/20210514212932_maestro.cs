using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class maestro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaestroId",
                table: "Detalles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaestroId1",
                table: "Detalles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEntero = table.Column<int>(type: "int", nullable: true),
                    Flotante = table.Column<float>(type: "real", nullable: true),
                    Enum = table.Column<int>(type: "int", nullable: true),
                    CualquierNombreDeCadena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Decimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Booleano = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_MaestroId1",
                table: "Detalles",
                column: "MaestroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Maestros_MaestroId1",
                table: "Detalles",
                column: "MaestroId1",
                principalTable: "Maestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Maestros_MaestroId1",
                table: "Detalles");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropIndex(
                name: "IX_Detalles_MaestroId1",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "MaestroId",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "MaestroId1",
                table: "Detalles");
        }
    }
}
