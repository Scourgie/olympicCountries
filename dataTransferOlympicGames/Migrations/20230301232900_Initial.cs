using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dataTransferOlympicGames.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "i", "Indoor" },
                    { "o", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "po", "Paralympics" },
                    { "so", "Summer Olympics" },
                    { "wo", "Winter Olympics" },
                    { "yo", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "GameID", "LogoImage", "Name" },
                values: new object[,]
                {
                    { "aus", "o", "po", "AUS.png", "Austria" },
                    { "bra", "o", "so", "BRA.png", "Brazil" },
                    { "can", "i", "wo", "CAN.png", "Canada" },
                    { "chi", "i", "so", "CHI.png", "China" },
                    { "cyp", "i", "yo", "CYP.png", "Cyprus" },
                    { "fin", "o", "yo", "FIN.png", "Finland" },
                    { "fra", "i", "yo", "FRA.png", "France" },
                    { "gbr", "i", "wo", "GBR.png", "Great Britain" },
                    { "ger", "i", "so", "GER.png", "Germany" },
                    { "ita", "o", "wo", "ITA.png", "Italy" },
                    { "jam", "o", "wo", "JAM.png", "Jamaica" },
                    { "jap", "o", "wo", "JAP.png", "Japan" },
                    { "mex", "i", "so", "MEX.png", "Mexico" },
                    { "net", "o", "so", "NET.png", "Netherlands" },
                    { "pak", "o", "po", "PAK.png", "Pakistan" },
                    { "por", "o", "yo", "POR.png", "Portugal" },
                    { "rus", "i", "yo", "RUS.png", "Russia" },
                    { "slo", "o", "yo", "SLO.png", "Slovakia" },
                    { "swe", "i", "wo", "SWE.png", "Sweden" },
                    { "tha", "i", "po", "THA.png", "Thailand" },
                    { "ukr", "i", "po", "UKR.png", "Ukraine" },
                    { "uru", "i", "po", "URU.png", "Uruguay" },
                    { "usa", "o", "so", "USA.png", "USA" },
                    { "zim", "o", "po", "ZIM.png", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
