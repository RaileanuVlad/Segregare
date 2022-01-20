using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoalaIntrebari_Clase_ClasaId",
                table: "ScoalaIntrebari");

            migrationBuilder.DropIndex(
                name: "IX_ScoalaIntrebari_ClasaId",
                table: "ScoalaIntrebari");

            migrationBuilder.DropColumn(
                name: "ClasaId",
                table: "ScoalaIntrebari");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasaId",
                table: "ScoalaIntrebari",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoalaIntrebari_ClasaId",
                table: "ScoalaIntrebari",
                column: "ClasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoalaIntrebari_Clase_ClasaId",
                table: "ScoalaIntrebari",
                column: "ClasaId",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
