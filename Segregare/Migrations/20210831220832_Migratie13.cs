using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathChestionar",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiE",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiE",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raspuns2",
                table: "MonitorIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raspuns3",
                table: "MonitorIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raspuns4",
                table: "MonitorIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiE",
                table: "Clase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathChestionar",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "RomiE",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "RomiE",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Raspuns2",
                table: "MonitorIntrebari");

            migrationBuilder.DropColumn(
                name: "Raspuns3",
                table: "MonitorIntrebari");

            migrationBuilder.DropColumn(
                name: "Raspuns4",
                table: "MonitorIntrebari");

            migrationBuilder.DropColumn(
                name: "RomiE",
                table: "Clase");
        }
    }
}
