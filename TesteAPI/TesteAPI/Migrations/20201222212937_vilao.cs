using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteAPI.Migrations
{
    public partial class vilao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VilaoId",
                table: "Armas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Viloes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viloes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_VilaoId",
                table: "Armas",
                column: "VilaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Viloes_VilaoId",
                table: "Armas",
                column: "VilaoId",
                principalTable: "Viloes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Viloes_VilaoId",
                table: "Armas");

            migrationBuilder.DropTable(
                name: "Viloes");

            migrationBuilder.DropIndex(
                name: "IX_Armas_VilaoId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "VilaoId",
                table: "Armas");
        }
    }
}
