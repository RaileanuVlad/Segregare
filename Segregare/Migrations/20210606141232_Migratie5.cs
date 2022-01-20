using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "MonitorIntrebari",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnitateIntrebari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitateId = table.Column<int>(nullable: false),
                    IntrebareId = table.Column<int>(nullable: false),
                    Raspuns = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitateIntrebari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitateIntrebari_Intrebari_IntrebareId",
                        column: x => x.IntrebareId,
                        principalTable: "Intrebari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitateIntrebari_Unitati_UnitateId",
                        column: x => x.UnitateId,
                        principalTable: "Unitati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitateIntrebari_IntrebareId",
                table: "UnitateIntrebari",
                column: "IntrebareId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitateIntrebari_UnitateId",
                table: "UnitateIntrebari",
                column: "UnitateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitateIntrebari");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "MonitorIntrebari");
        }
    }
}
