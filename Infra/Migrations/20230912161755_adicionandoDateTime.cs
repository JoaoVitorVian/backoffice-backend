using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Departamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Departamento");
        }
    }
}
