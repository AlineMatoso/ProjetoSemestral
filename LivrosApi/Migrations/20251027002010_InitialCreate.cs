using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivrosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    AutorModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivrosModel_Autores_AutorModelId",
                        column: x => x.AutorModelId,
                        principalTable: "Autores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivrosModel_AutorModelId",
                table: "LivrosModel",
                column: "AutorModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrosModel");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
