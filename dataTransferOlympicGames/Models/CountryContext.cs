using Microsoft.EntityFrameworkCore;
using dataTransferOlympicGames.Models;

namespace dataTransferOlympicGames.Models
{
    public class CountryContext : DbContext
    {

        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                    new Game { GameID = "wo", Name = "Winter Olympics" },
                    new Game { GameID = "so", Name = "Summer Olympics" },
                    new Game { GameID = "po", Name = "Paralympics" },
                    new Game { GameID = "yo", Name = "Youth Olympic Games" }
                );

            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryID = "i", Name = "Indoor" },
                    new Category { CategoryID = "o", Name = "Outdoor" }
                );

            modelBuilder.Entity<Country>().HasData(
                    new { CountryID = "can", Name = "Canada", GameID = "wo", CategoryID = "i", LogoImage = "CAN.png" },
                    new { CountryID = "swe", Name = "Sweden", GameID = "wo", CategoryID = "i", LogoImage = "SWE.png" },
                    new { CountryID = "gbr", Name = "Great Britain", GameID = "wo", CategoryID = "i", LogoImage = "GBR.png" },
                    new { CountryID = "jam", Name = "Jamaica", GameID = "wo", CategoryID = "o", LogoImage = "JAM.png" },
                    new { CountryID = "ita", Name = "Italy", GameID = "wo", CategoryID = "o", LogoImage = "ITA.png" },
                    new { CountryID = "jap", Name = "Japan", GameID = "wo", CategoryID = "o", LogoImage = "JAP.png" },
                    new { CountryID = "ger", Name = "Germany", GameID = "so", CategoryID = "i", LogoImage = "GER.png" },
                    new { CountryID = "chi", Name = "China", GameID = "so", CategoryID = "i", LogoImage = "CHI.png" },
                    new { CountryID = "mex", Name = "Mexico", GameID = "so", CategoryID = "i", LogoImage = "MEX.png" },
                    new { CountryID = "bra", Name = "Brazil", GameID = "so", CategoryID = "o", LogoImage = "BRA.png" },
                    new { CountryID = "net", Name = "Netherlands", GameID = "so", CategoryID = "o", LogoImage = "NET.png" },
                    new { CountryID = "usa", Name = "USA", GameID = "so", CategoryID = "o", LogoImage = "USA.png" },
                    new { CountryID = "tha", Name = "Thailand", GameID = "po", CategoryID = "i", LogoImage = "THA.png" },
                    new { CountryID = "uru", Name = "Uruguay", GameID = "po", CategoryID = "i", LogoImage = "URU.png" },
                    new { CountryID = "ukr", Name = "Ukraine", GameID = "po", CategoryID = "i", LogoImage = "UKR.png" },
                    new { CountryID = "aus", Name = "Austria", GameID = "po", CategoryID = "o", LogoImage = "AUS.png" },
                    new { CountryID = "pak", Name = "Pakistan", GameID = "po", CategoryID = "o", LogoImage = "PAK.png" },
                    new { CountryID = "zim", Name = "Zimbabwe", GameID = "po", CategoryID = "o", LogoImage = "ZIM.png" },
                    new { CountryID = "fra", Name = "France", GameID = "yo", CategoryID = "i", LogoImage = "FRA.png" },
                    new { CountryID = "cyp", Name = "Cyprus", GameID = "yo", CategoryID = "i", LogoImage = "CYP.png" },
                    new { CountryID = "rus", Name = "Russia", GameID = "yo", CategoryID = "i", LogoImage = "RUS.png" },
                    new { CountryID = "fin", Name = "Finland", GameID = "yo", CategoryID = "o", LogoImage = "FIN.png" },
                    new { CountryID = "slo", Name = "Slovakia", GameID = "yo", CategoryID = "o", LogoImage = "SLO.png" },
                    new { CountryID = "por", Name = "Portugal", GameID = "yo", CategoryID = "o", LogoImage = "POR.png" }
                );

        }

    }
}
