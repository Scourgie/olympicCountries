using dataTransferOlympicGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace dataTransferOlympicGames.Controllers
{
    public class HomeController : Controller
    {

        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeGame = "all", string activeCat = "all")
        {

            ViewBag.ActiveGame = activeGame;
            ViewBag.ActiveCat = activeCat;

            List<Game> games = context.Games.ToList();
            List<Category> categories = context.Categories.ToList();

            games.Insert(0, new Game { GameID = "all", Name = "All" });
            categories.Insert(0, new Category { CategoryID = "all", Name = "All" });

            ViewBag.Games = games;
            ViewBag.Categories = categories;

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
            {
                query = query.Where( t => t.Game.GameID.ToLower() == activeGame.ToLower() );
            }
            if (activeCat != "all")
            {
                query = query.Where( t => t.Category.CategoryID.ToLower() == activeCat.ToLower() );
            }

            var countries = query.ToList();
            return View(countries);

        }

    }
}
