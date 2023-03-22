using dataTransferOlympicGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dataTransferOlympicGames.Controllers
{
    public class HomeController : Controller
    {

        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(CountryListViewModel model)
        {

            model.Games = context.Games.ToList();
            model.Categories = context.Categories.ToList();

            IQueryable<Country> query = context.Countries;
            if (model.ActiveGame != "all")
            {
                query = query.Where(t => t.Game.GameID.ToLower() == model.ActiveGame.ToLower());
            }
            if (model.ActiveCat != "all")
            {
                query = query.Where(t => t.Category.CategoryID.ToLower() == model.ActiveCat.ToLower());
            }
            model.Countries = query.ToList();

            return View(model);

        }

        public ViewResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryID == id) ?? new Country(),
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            };
            return View(model);
        }

    }
}
