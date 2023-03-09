using dataTransferOlympicGames.Models;
using System.Text.Json.Serialization;

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

    public class User
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [JsonIgnore]
        public string FullName => FirstName + " " + LastName;

    }
}
