using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ani",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Mixt",
                table: "Clase",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ani",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Mixt",
                table: "Clase");
        }
    }
}
