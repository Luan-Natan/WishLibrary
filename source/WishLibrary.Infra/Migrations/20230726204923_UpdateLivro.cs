using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishLibrary.Infra.Migrations
{
    public partial class UpdateLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoLancamento",
                table: "T_LIVRO");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "T_LIVRO",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "T_LIVRO");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnoLancamento",
                table: "T_LIVRO",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
