using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM_Trabajo_Final_Hospital.Migrations
{
    public partial class Farmacia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avenida",
                table: "Farmacia",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avenida",
                table: "Farmacia");
        }
    }
}
