using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class adedfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Maestros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Maestros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Maestros");
        }
    }
}
