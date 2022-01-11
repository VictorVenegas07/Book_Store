using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class primera_migracion_v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.IdLog);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUser", "Name", "Password", "Role", "User" },
                values: new object[] { 1, "Victor Venegas", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "Administrador", "vvenegas" });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "Genero", "IdUsuario", "Precio", "Publicador", "Titulo" },
                values: new object[] { 1, "Robin Sharma", "Fictions", 1, 141.0, "Jaiko Publishing House", "The Monk Who Sold His Ferrari" });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "Genero", "IdUsuario", "Precio", "Publicador", "Titulo" },
                values: new object[] { 2, "Stiphen Hawking", "Engineering And Technology", 1, 149.0, "Jaiko Publishing House", "The Theory Of Everything" });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "Genero", "IdUsuario", "Precio", "Publicador", "Titulo" },
                values: new object[] { 3, "Robert Kiyosaki", "Personal finance", 1, 288.0, "Plata publishing", "Rich Dad Poor Dad" });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdUsuario",
                table: "Libros",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IdUsuario",
                table: "Logs",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
