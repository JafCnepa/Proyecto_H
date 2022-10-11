using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    public partial class Medicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    id_medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    especialidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    certificado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.id_medico);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    stock = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Pais = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ruc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicoid_medico = table.Column<int>(type: "int", nullable: true),
                    Productoid_producto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Medicos_Medicoid_medico",
                        column: x => x.Medicoid_medico,
                        principalTable: "Medicos",
                        principalColumn: "id_medico");
                    table.ForeignKey(
                        name: "FK_Usuarios_Productos_Productoid_producto",
                        column: x => x.Productoid_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmacias_Productoid_producto",
                table: "Farmacias",
                column: "Productoid_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Medicoid_medico",
                table: "Usuarios",
                column: "Medicoid_medico");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Productoid_producto",
                table: "Usuarios",
                column: "Productoid_producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmacias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
