using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class addNomeResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nomeResponsavel",
                table: "Departamento",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nomeResponsavel",
                table: "Departamento");
        }
    }
}
