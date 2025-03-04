using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmagApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DernierDiplome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiliereId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matiere_Filiere_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filiere",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreHeure = table.Column<double>(type: "float", nullable: false),
                    SeanceTenue = table.Column<bool>(type: "bit", nullable: false),
                    CommencerA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminerA = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Professeurs_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeanceMatiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeanceId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeanceMatiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeanceMatiere_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeanceMatiere_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_FiliereId",
                table: "Matiere",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_SeanceMatiere_MatiereId",
                table: "SeanceMatiere",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_SeanceMatiere_SeanceId",
                table: "SeanceMatiere",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ProfesseurId",
                table: "Seances",
                column: "ProfesseurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeanceMatiere");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Professeurs");
        }
    }
}
