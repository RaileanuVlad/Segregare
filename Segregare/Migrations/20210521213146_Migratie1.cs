using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intrebari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Tip = table.Column<string>(nullable: true),
                    Pentru = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrebari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monitori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scoli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Judet = table.Column<string>(nullable: true),
                    Mediu = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scoli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitorIntrebari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MonitorId = table.Column<int>(nullable: false),
                    IntrebareId = table.Column<int>(nullable: false),
                    Raspuns = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorIntrebari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitorIntrebari_Intrebari_IntrebareId",
                        column: x => x.IntrebareId,
                        principalTable: "Intrebari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitorIntrebari_Monitori_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "Monitori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unitati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Localitate = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true),
                    Nivel = table.Column<string>(nullable: true),
                    Strada = table.Column<string>(nullable: true),
                    NrStrada = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    ScoalaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unitati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unitati_Scoli_ScoalaId",
                        column: x => x.ScoalaId,
                        principalTable: "Scoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    IntrebareId = table.Column<int>(nullable: false),
                    Raspuns = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_MonitorIntrebari_IntrebareId",
                table: "MonitorIntrebari",
                column: "IntrebareId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorIntrebari_MonitorId",
                table: "MonitorIntrebari",
                column: "MonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Unitati_ScoalaId",
                table: "Unitati",
                column: "ScoalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CladireIntrebari");

            migrationBuilder.DropTable(
                name: "MonitorIntrebari");

            migrationBuilder.DropTable(
                name: "Cladiri");

            migrationBuilder.DropTable(
                name: "Intrebari");

            migrationBuilder.DropTable(
                name: "Monitori");

            migrationBuilder.DropTable(
                name: "Unitati");

            migrationBuilder.DropTable(
                name: "Scoli");
        }
    }
}
