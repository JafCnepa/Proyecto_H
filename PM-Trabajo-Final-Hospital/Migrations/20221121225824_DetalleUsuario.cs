using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM_Trabajo_Final_Hospital.Migrations
{
    public partial class DetalleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuario_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Detalle_Usuario",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetalleUsuario",
                columns: table => new
                {
                    DetalleUsuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleUsuario", x => x.DetalleUsuario_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Detalle_Usuario",
                table: "AspNetUsers",
                column: "Detalle_Usuario",
                unique: true,
                filter: "[Detalle_Usuario] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DetalleUsuario_Detalle_Usuario",
                table: "AspNetUsers",
                column: "Detalle_Usuario",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DetalleUsuario_Detalle_Usuario",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DetalleUsuario");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Detalle_Usuario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DetalleUsuario_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Detalle_Usuario",
                table: "AspNetUsers");
        }
    }
}
