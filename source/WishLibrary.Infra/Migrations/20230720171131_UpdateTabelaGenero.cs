using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishLibrary.Infra.Migrations
{
    public partial class UpdateTabelaGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_GENERO_Nome",
                table: "T_GENERO",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_GENERO_Nome",
                table: "T_GENERO");
        }
    }
}
