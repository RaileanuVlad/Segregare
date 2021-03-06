// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Segregare.Contexts;

namespace Segregare.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210615225651_Migratie6")]
    partial class Migratie6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Segregare.Models.Clasa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Burse");

                    b.Property<string>("Burse2b");

                    b.Property<string>("Cifra");

                    b.Property<string>("Cladire");

                    b.Property<string>("Data");

                    b.Property<string>("Dizabilitati");

                    b.Property<string>("Dizabilitati2b");

                    b.Property<string>("Litera");

                    b.Property<string>("Online");

                    b.Property<string>("Online2b");

                    b.Property<string>("Parinti");

                    b.Property<string>("Parinti2b");

                    b.Property<string>("Predare");

                    b.Property<string>("Remediala");

                    b.Property<string>("Remediala2b");

                    b.Property<string>("Repetenti");

                    b.Property<string>("Repetenti2b");

                    b.Property<string>("Romi");

                    b.Property<string>("Romi2b");

                    b.Property<string>("Total");

                    b.Property<string>("Total2b");

                    b.Property<int>("UnitateId");

                    b.HasKey("Id");

                    b.HasIndex("UnitateId");

                    b.ToTable("Clase");
                });

            modelBuilder.Entity("Segregare.Models.Intrebare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flavor");

                    b.Property<string>("Pentru");

                    b.Property<string>("Text");

                    b.Property<string>("Tip");

                    b.Property<bool>("Upload");

                    b.HasKey("Id");

                    b.ToTable("Intrebari");
                });

            modelBuilder.Entity("Segregare.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Parola");

                    b.HasKey("Id");

                    b.ToTable("Monitori");
                });

            modelBuilder.Entity("Segregare.Models.MonitorIntrebare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.Property<int>("IntrebareId");

                    b.Property<int>("MonitorId");

                    b.Property<string>("Path");

                    b.Property<string>("Raspuns");

                    b.HasKey("Id");

                    b.HasIndex("IntrebareId");

                    b.HasIndex("MonitorId");

                    b.ToTable("MonitorIntrebari");
                });

            modelBuilder.Entity("Segregare.Models.Scoala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director");

                    b.Property<string>("Email");

                    b.Property<string>("FurnizorDate");

                    b.Property<string>("Judet");

                    b.Property<string>("Mediu");

                    b.Property<string>("NrFurnizor");

                    b.Property<string>("Nume");

                    b.Property<string>("Parola");

                    b.Property<string>("Semnatura");

                    b.Property<string>("Sirues");

                    b.HasKey("Id");

                    b.ToTable("Scoli");
                });

            modelBuilder.Entity("Segregare.Models.ScoalaIntrebare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.Property<int>("IntrebareId");

                    b.Property<string>("Path");

                    b.Property<string>("Raspuns");

                    b.Property<int>("ScoalaId");

                    b.HasKey("Id");

                    b.HasIndex("IntrebareId");

                    b.HasIndex("ScoalaId");

                    b.ToTable("ScoalaIntrebari");
                });

            modelBuilder.Entity("Segregare.Models.Unitate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal");

                    b.Property<string>("Fax");

                    b.Property<string>("Localitate");

                    b.Property<string>("Nivel");

                    b.Property<int>("NrCladiri");

                    b.Property<string>("NrStrada");

                    b.Property<string>("Nume");

                    b.Property<int>("ScoalaId");

                    b.Property<string>("Statut");

                    b.Property<string>("Strada");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("ScoalaId");

                    b.ToTable("Unitati");
                });

            modelBuilder.Entity("Segregare.Models.UnitateIntrebare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.Property<int>("IntrebareId");

                    b.Property<string>("Path");

                    b.Property<string>("Raspuns");

                    b.Property<int>("UnitateId");

                    b.HasKey("Id");

                    b.HasIndex("IntrebareId");

                    b.HasIndex("UnitateId");

                    b.ToTable("UnitateIntrebari");
                });

            modelBuilder.Entity("Segregare.Models.Clasa", b =>
                {
                    b.HasOne("Segregare.Models.Unitate", "Unitate")
                        .WithMany("Clasa")
                        .HasForeignKey("UnitateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Segregare.Models.MonitorIntrebare", b =>
                {
                    b.HasOne("Segregare.Models.Intrebare", "Intrebare")
                        .WithMany("MonitorIntrebare")
                        .HasForeignKey("IntrebareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Segregare.Models.Monitor", "Monitor")
                        .WithMany("MonitorIntrebare")
                        .HasForeignKey("MonitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Segregare.Models.ScoalaIntrebare", b =>
                {
                    b.HasOne("Segregare.Models.Intrebare", "Intrebare")
                        .WithMany("ScoalaIntrebare")
                        .HasForeignKey("IntrebareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Segregare.Models.Scoala", "Scoala")
                        .WithMany("ScoalaIntrebare")
                        .HasForeignKey("ScoalaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Segregare.Models.Unitate", b =>
                {
                    b.HasOne("Segregare.Models.Scoala", "Scoala")
                        .WithMany("Unitate")
                        .HasForeignKey("ScoalaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Segregare.Models.UnitateIntrebare", b =>
                {
                    b.HasOne("Segregare.Models.Intrebare", "Intrebare")
                        .WithMany()
                        .HasForeignKey("IntrebareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Segregare.Models.Unitate", "Unitate")
                        .WithMany()
                        .HasForeignKey("UnitateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
