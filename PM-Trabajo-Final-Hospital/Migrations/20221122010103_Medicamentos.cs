using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM_Trabajo_Final_Hospital.Migrations
{
    public partial class Medicamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Categorias_CategoriaIdCateogira",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Stocks_StockIdStock",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_CategoriaIdCateogira",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_StockIdStock",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCateogira",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "IdStocks",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "StockIdStock",
                table: "Medicamentos");

            migrationBuilder.AddColumn<string>(
                name: "Categorias",
                table: "Medicamentos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stocks",
                table: "Medicamentos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "Stocks",
                table: "Medicamentos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCateogira",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Medicamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdStocks",
                table: "Medicamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockIdStock",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_CategoriaIdCateogira",
                table: "Medicamentos",
                column: "CategoriaIdCateogira");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_StockIdStock",
                table: "Medicamentos",
                column: "StockIdStock");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Categorias_CategoriaIdCateogira",
                table: "Medicamentos",
                column: "CategoriaIdCateogira",
                principalTable: "Categorias",
                principalColumn: "IdCateogira");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Stocks_StockIdStock",
                table: "Medicamentos",
                column: "StockIdStock",
                principalTable: "Stocks",
                principalColumn: "IdStock");
        }
    }
}
