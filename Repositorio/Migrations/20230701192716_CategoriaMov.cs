using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaMov : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaDespesa",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "CategoriaReceita",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Movimentacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "Tipo",
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
    }
}
