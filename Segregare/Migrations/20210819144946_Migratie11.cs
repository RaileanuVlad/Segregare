using Microsoft.EntityFrameworkCore.Migrations;

namespace Segregare.Migrations
{
    public partial class Migratie11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BurseC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DizabilitatiC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NivelC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrCladiriC",
                table: "Unitati",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OnlineC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParintiC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemedialaC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepetentiC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalC",
                table: "Unitati",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataC",
                table: "UnitateIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathC",
                table: "UnitateIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaspunsC",
                table: "UnitateIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BurseC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckedC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DizabilitatiC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExplicatieC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FurnizorDateC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrFurnizorC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrInregC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OnlineC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParintiC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemedialaC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepetentiC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SemnaturaC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiruesC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalC",
                table: "Scoli",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataC",
                table: "ScoalaIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathC",
                table: "ScoalaIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaspunsC",
                table: "ScoalaIntrebari",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Unitate",
                table: "MonitorIntrebari",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Judet",
                table: "Monitori",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AniC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Burse2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BurseC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CifraC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CladireC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dizabilitati2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DizabilitatiC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LiteraC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MixtC",
                table: "Clase",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Moderator",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Online2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OnlineC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parinti2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParintiC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PredareC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remediala2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemedialaC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Repetenti2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepetentiC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Romi2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RomiC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Total2bC",
                table: "Clase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalC",
                table: "Clase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurseC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "DizabilitatiC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "NivelC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "NrCladiriC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "OnlineC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "ParintiC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "RemedialaC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "RepetentiC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "RomiC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "TotalC",
                table: "Unitati");

            migrationBuilder.DropColumn(
                name: "DataC",
                table: "UnitateIntrebari");

            migrationBuilder.DropColumn(
                name: "PathC",
                table: "UnitateIntrebari");

            migrationBuilder.DropColumn(
                name: "RaspunsC",
                table: "UnitateIntrebari");

            migrationBuilder.DropColumn(
                name: "BurseC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "CheckedC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "DirectorC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "DizabilitatiC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "ExplicatieC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "FurnizorDateC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "NrFurnizorC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "NrInregC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "OnlineC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "ParintiC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "RemedialaC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "RepetentiC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "RomiC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "SemnaturaC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "SiruesC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "TotalC",
                table: "Scoli");

            migrationBuilder.DropColumn(
                name: "DataC",
                table: "ScoalaIntrebari");

            migrationBuilder.DropColumn(
                name: "PathC",
                table: "ScoalaIntrebari");

            migrationBuilder.DropColumn(
                name: "RaspunsC",
                table: "ScoalaIntrebari");

            migrationBuilder.DropColumn(
                name: "Unitate",
                table: "MonitorIntrebari");

            migrationBuilder.DropColumn(
                name: "Judet",
                table: "Monitori");

            migrationBuilder.DropColumn(
                name: "AniC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Burse2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "BurseC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "CifraC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "CladireC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "DataC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Dizabilitati2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "DizabilitatiC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "LiteraC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "MixtC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Moderator",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Online2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "OnlineC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Parinti2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "ParintiC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "PredareC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Remediala2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "RemedialaC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Repetenti2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "RepetentiC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Romi2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "RomiC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Total2bC",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "TotalC",
                table: "Clase");
        }
    }
}
