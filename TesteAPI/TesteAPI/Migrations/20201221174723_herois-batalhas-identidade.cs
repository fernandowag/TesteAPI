using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteAPI.Migrations
{
    public partial class heroisbatalhasidentidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois");

            migrationBuilder.DropIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Herois");

            migrationBuilder.AddColumn<int>(
                name: "IdentidadeId",
                table: "Herois",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HeroiBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroiBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroiBatalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadesSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadesSecretas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Herois_IdentidadeId",
                table: "Herois",
                column: "IdentidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroiBatalhas_HeroiId",
                table: "HeroiBatalhas",
                column: "HeroiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_IdentidadesSecretas_IdentidadeId",
                table: "Herois",
                column: "IdentidadeId",
                principalTable: "IdentidadesSecretas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_IdentidadesSecretas_IdentidadeId",
                table: "Herois");

            migrationBuilder.DropTable(
                name: "HeroiBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadesSecretas");

            migrationBuilder.DropIndex(
                name: "IX_Herois_IdentidadeId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "IdentidadeId",
                table: "Herois");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Herois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
