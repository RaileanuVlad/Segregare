using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Burse",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dizabilitati",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Online",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parinti",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remediala",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Repetenti",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Romi",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Burse",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dizabilitati",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrInreg",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Online",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parinti",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remediala",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Repetenti",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Romi",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "Scoli",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Burse",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Dizabilitati",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Parinti",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Remediala",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Repetenti",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Romi",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Burse",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Dizabilitati",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "NrInreg",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Parinti",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Remediala",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Repetenti",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Romi",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Scoli");
        }
    }
}
