using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    precio = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id_factura);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_productos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id_productos);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ruc = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facturaid_factura = table.Column<int>(type: "int", nullable: true),
                    Productosid_productos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Facturas_Facturaid_factura",
                        column: x => x.Facturaid_factura,
                        principalTable: "Facturas",
                        principalColumn: "id_factura");
                    table.ForeignKey(
                        name: "FK_Usuario_Productos_Productosid_productos",
                        column: x => x.Productosid_productos,
                        principalTable: "Productos",
                        principalColumn: "id_productos");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    id_medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    salon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuariosid_usuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.id_medico);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_Usuariosid_usuario",
                        column: x => x.Usuariosid_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Usuariosid_usuario",
                table: "Medico",
                column: "Usuariosid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Facturaid_factura",
                table: "Usuario",
                column: "Facturaid_factura");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Productosid_productos",
                table: "Usuario",
                column: "Productosid_productos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
