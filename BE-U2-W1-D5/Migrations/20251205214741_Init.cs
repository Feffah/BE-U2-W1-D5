using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_U2_W1_D5.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafica",
                columns: table => new
                {
                    IDAnagrafica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafica", x => x.IDAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipoViolazione",
                columns: table => new
                {
                    IDViolazione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViolazione", x => x.IDViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbale",
                columns: table => new
                {
                    IDVerbale = table.Column<int>(type: "int", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbale", x => x.IDVerbale);
                    table.ForeignKey(
                        name: "FK_Verbale_Anagrafica_IDVerbale",
                        column: x => x.IDVerbale,
                        principalTable: "Anagrafica",
                        principalColumn: "IDAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verbale_Violazione",
                columns: table => new
                {
                    IDVerbale = table.Column<int>(type: "int", nullable: false),
                    IDViolazione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbale_Violazione", x => new { x.IDVerbale, x.IDViolazione });
                    table.ForeignKey(
                        name: "FK_Verbale_Violazione_TipoViolazione_IDViolazione",
                        column: x => x.IDViolazione,
                        principalTable: "TipoViolazione",
                        principalColumn: "IDViolazione",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbale_Violazione_Verbale_IDVerbale",
                        column: x => x.IDVerbale,
                        principalTable: "Verbale",
                        principalColumn: "IDVerbale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_Violazione_IDViolazione",
                table: "Verbale_Violazione",
                column: "IDViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbale_Violazione");

            migrationBuilder.DropTable(
                name: "TipoViolazione");

            migrationBuilder.DropTable(
                name: "Verbale");

            migrationBuilder.DropTable(
                name: "Anagrafica");
        }
    }
}
