using dataTransferOlympicGames.Models;

namespace dataTransferOlympicGames.Models
{
    public class Country
    {

        public string? CountryID { get; set; }
        public string? Name { get; set; }
        public Game Game { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public string? LogoImage { get; set; }

    }
}
