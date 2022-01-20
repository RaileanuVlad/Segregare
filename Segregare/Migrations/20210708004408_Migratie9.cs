using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Checked",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Explicatie",
                table: "Scoli",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Explicatie",
                table: "Scoli");
        }
    }
}
