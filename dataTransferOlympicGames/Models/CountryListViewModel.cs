namespace dataTransferOlympicGames.Models
{
    public class CountryListViewModel
    {

        public List<Country> Countries { get; set; }
        public string ActiveGame { get; set; }
        public string ActiveCat { get; set; }

        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = value;
                games.Insert(0, new Game { GameID = "all", Name = "all" });
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                categories.Insert(0, new Category { CategoryID = "all", Name = "all" });
            }
        }

        public string CheckActiveGame(string g) => g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveCat(string c) => c.ToLower() == ActiveCat.ToLower() ? "active" : "";

    }
}
