using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class changedAsOptionalRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "USUARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_RolId",
                table: "USUARIOS",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_Roles_RolId",
                table: "USUARIOS",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_Roles_RolId",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_RolId",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "USUARIOS");

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Descripcion",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
