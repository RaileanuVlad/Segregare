using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataIntr",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrIntr",
                table: "Scoli",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataIntr",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "NrIntr",
                table: "Scoli");
        }
    }
}
