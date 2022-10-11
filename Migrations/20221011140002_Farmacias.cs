using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    public partial class Farmacias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    stock = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", maxLength: 1000, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", maxLength: 1000, nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_farmacias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "Farmacias",
                columns: table => new
                {
                    id_farmacia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Productoid_producto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmacias", x => x.id_farmacia);
                    table.ForeignKey(
                        name: "FK_Farmacias_Productos_Productoid_producto",
                        column: x => x.Productoid_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Productoid_producto",
                table: "Usuarios",
                column: "Productoid_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Farmacias_Productoid_producto",
                table: "Farmacias",
                column: "Productoid_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Productos_Productoid_producto",
                table: "Usuarios",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Productos_Productoid_producto",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Farmacias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Productoid_producto",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Usuarios");
        }
    }
}
