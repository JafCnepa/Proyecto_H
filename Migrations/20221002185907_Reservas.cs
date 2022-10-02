using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    public partial class Reservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reservasid_reserva",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reservasid_reserva",
                table: "Medico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_medico = table.Column<int>(type: "int", nullable: false),
                    id_productos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id_reserva);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Reservasid_reserva",
                table: "Productos",
                column: "Reservasid_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Reservasid_reserva",
                table: "Medico",
                column: "Reservasid_reserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Reservas_Reservasid_reserva",
                table: "Medico",
                column: "Reservasid_reserva",
                principalTable: "Reservas",
                principalColumn: "id_reserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Reservas_Reservasid_reserva",
                table: "Productos",
                column: "Reservasid_reserva",
                principalTable: "Reservas",
                principalColumn: "id_reserva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Reservas_Reservasid_reserva",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Reservas_Reservasid_reserva",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Reservasid_reserva",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Medico_Reservasid_reserva",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Reservasid_reserva",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Reservasid_reserva",
                table: "Medico");
        }
    }
}
