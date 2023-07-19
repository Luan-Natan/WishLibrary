using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishLibrary.Infra.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_GENERO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GENERO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_LIVRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LIVRO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_LIVRO_T_GENERO_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "T_GENERO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LIVRO_GeneroId",
                table: "T_LIVRO",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_LIVRO");

            migrationBuilder.DropTable(
                name: "T_GENERO");
        }
    }
}
