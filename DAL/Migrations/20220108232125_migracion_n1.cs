using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migracion_n1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "User",
                keyValue: "vvenegas");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "IdUser");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUser", "Name", "Password", "Role", "User" },
                values: new object[] { 1, "Victor Venegas", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "Administrador", "vvenegas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "User");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "User",
                keyValue: "vvenegas",
                column: "Password",
                value: "12345");
        }
    }
}
