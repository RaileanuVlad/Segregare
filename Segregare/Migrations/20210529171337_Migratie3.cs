using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CladireIntrebari");

            migrationBuilder.DropTable(
                name: "Cladiri");

            migrationBuilder.AddColumn<int>(
                name: "NrCladiri",
                table: "Unitati",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FurnizorDate",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrFurnizor",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semnatura",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sirues",
                table: "Scoli",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cifra = table.Column<string>(nullable: true),
                    Litera = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    Romi = table.Column<string>(nullable: true),
                    Dizabilitati = table.Column<string>(nullable: true),
                    Parinti = table.Column<string>(nullable: true),
                    Burse = table.Column<string>(nullable: true),
                    Repetenti = table.Column<string>(nullable: true),
                    Online = table.Column<string>(nullable: true),
                    Remediala = table.Column<string>(nullable: true),
                    Total2b = table.Column<string>(nullable: true),
                    Romi2b = table.Column<string>(nullable: true),
                    Dizabilitati2b = table.Column<string>(nullable: true),
                    Parinti2b = table.Column<string>(nullable: true),
                    Burse2b = table.Column<string>(nullable: true),
                    Repetenti2b = table.Column<string>(nullable: true),
                    Online2b = table.Column<string>(nullable: true),
                    Remediala2b = table.Column<string>(nullable: true),
                    Cladire = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    UnitateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clase_Unitati_UnitateId",
                        column: x => x.UnitateId,
                        principalTable: "Unitati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoalaIntrebari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScoalaId = table.Column<int>(nullable: false),
                    IntrebareId = table.Column<int>(nullable: false),
                    Raspuns = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    ClasaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoalaIntrebari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoalaIntrebari_Clase_ClasaId",
                        column: x => x.ClasaId,
                        principalTable: "Clase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScoalaIntrebari_Intrebari_IntrebareId",
                        column: x => x.IntrebareId,
                        principalTable: "Intrebari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoalaIntrebari_Scoli_ScoalaId",
                        column: x => x.ScoalaId,
                        principalTable: "Scoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clase_UnitateId",
                table: "Clase",
                column: "UnitateId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoalaIntrebari_ClasaId",
                table: "ScoalaIntrebari",
                column: "ClasaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoalaIntrebari_IntrebareId",
                table: "ScoalaIntrebari",
                column: "IntrebareId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoalaIntrebari_ScoalaId",
                table: "ScoalaIntrebari",
                column: "ScoalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoalaIntrebari");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropColumn(
                name: "NrCladiri",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "FurnizorDate",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "NrFurnizor",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Semnatura",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "Sirues",
                table: "Scoli");

            migrationBuilder.CreateTable(
                name: "Cladiri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    UnitateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cladiri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cladiri_Unitati_UnitateId",
                        column: x => x.UnitateId,
                        principalTable: "Unitati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CladireIntrebari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CladireId = table.Column<int>(nullable: false),
                    Clasa = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    IntrebareId = table.Column<int>(nullable: false),
                    Litera = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Raspuns = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CladireIntrebari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CladireIntrebari_Cladiri_CladireId",
                        column: x => x.CladireId,
                        principalTable: "Cladiri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CladireIntrebari_Intrebari_IntrebareId",
                        column: x => x.IntrebareId,
                        principalTable: "Intrebari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CladireIntrebari_CladireId",
                table: "CladireIntrebari",
                column: "CladireId");

            migrationBuilder.CreateIndex(
                name: "IX_CladireIntrebari_IntrebareId",
                table: "CladireIntrebari",
                column: "IntrebareId");

            migrationBuilder.CreateIndex(
                name: "IX_Cladiri_UnitateId",
                table: "Cladiri",
                column: "UnitateId");
        }
    }
}
