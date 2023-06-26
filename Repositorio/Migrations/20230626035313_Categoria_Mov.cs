using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Categoria_Mov : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDespesa",
                table: "Movimentacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaReceita",
                table: "Movimentacoes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaDespesa",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "CategoriaReceita",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
