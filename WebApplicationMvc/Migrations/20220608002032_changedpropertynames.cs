using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMvc.Migrations
{
    public partial class changedpropertynames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_Roles_RolId",
                table: "USUARIOS");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_RolId",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "USUARIOS");

            migrationBuilder.RenameTable(
                name: "USUARIOS",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "STR_USUARIO",
                table: "Usuarios",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "STR_NOMB",
                table: "Usuarios",
                newName: "Nombres");

            migrationBuilder.RenameColumn(
                name: "STR_CONTRA",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "STR_APE",
                table: "Usuarios",
                newName: "Apellidos");

            migrationBuilder.RenameColumn(
                name: "Identificador",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "USUARIOS",
                newName: "STR_USUARIO");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "USUARIOS",
                newName: "STR_CONTRA");

            migrationBuilder.RenameColumn(
                name: "Nombres",
                table: "USUARIOS",
                newName: "STR_NOMB");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "USUARIOS",
                newName: "STR_APE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USUARIOS",
                newName: "Identificador");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "USUARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS",
                column: "Identificador");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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
    }
}
