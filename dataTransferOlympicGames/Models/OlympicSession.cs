namespace dataTransferOlympicGames.Models
{
    public class OlympicSession
    {

        private const string CountryKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string CatKey = "cat";
        private const string NameKey = "name";

        private ISession session { get; set; }

        public OlympicSession(ISession session) => this.session = session;

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountryKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountryKey) ?? new List<Country>();

        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetActiveGame(string activeGame) =>
            session.SetString(GameKey, activeGame);

        public string GetActiveGame() =>
            session.GetString(GameKey) ?? string.Empty;

        public void SetActiveCat(string activeCat) =>
            session.SetString(CatKey, activeCat);

        public string GetActiveCat() =>
            session.GetString(CatKey) ?? string.Empty;

        public void SetName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                session.Remove(NameKey);
            }
            else
            {
                session.SetString(NameKey, userName);
            }
        }

        public string GetName() => session.GetString(NameKey) ?? string.Empty;

        public void RemoveMyCountries()
        {
            session.Remove(CountryKey);
            session.Remove(CountKey);
        }

    }
}
