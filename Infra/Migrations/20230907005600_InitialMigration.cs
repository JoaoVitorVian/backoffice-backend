using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDepartamento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoPessoa = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    documento = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    apelido = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    localidade = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    bairro = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    qualificacoes = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
