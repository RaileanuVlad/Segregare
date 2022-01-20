using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flavor",
                table: "Intrebari",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Upload",
                table: "Intrebari",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Clasa",
                table: "CladireIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Litera",
                table: "CladireIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "CladireIntrebari",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flavor",
                table: "Intrebari");

            migrationBuilder.DropColumn(
                name: "Upload",
                table: "Intrebari");

            migrationBuilder.DropColumn(
                name: "Clasa",
                table: "CladireIntrebari");

            migrationBuilder.DropColumn(
                name: "Litera",
                table: "CladireIntrebari");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "CladireIntrebari");
        }
    }
}
