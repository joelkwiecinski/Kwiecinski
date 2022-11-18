using Microsoft.EntityFrameworkCore.Migrations;

namespace WSAuto.Migrations
{
    public partial class CrearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", nullable: true),
                    Precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
