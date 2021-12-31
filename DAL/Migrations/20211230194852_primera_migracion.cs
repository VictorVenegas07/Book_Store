using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class primera_migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.User);
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "IdLibro", "Autor", "Genero", "Precio", "Publicador", "Titulo" },
                values: new object[,]
                {
                    { 1, "Robin Sharma", "Fictions", 141.0, "Jaiko Publishing House", "The Monk Who Sold His Ferrari" },
                    { 2, "Stiphen Hawking", "Engineering And Technology", 149.0, "Jaiko Publishing House", "The Theory Of Everything" },
                    { 3, "Robert Kiyosaki", "Personal finance", 288.0, "Plata publishing", "Rich Dad Poor Dad" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "User", "Name", "Password", "Role" },
                values: new object[] { "vvenegas", "Victor Venegas", "12345", "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
