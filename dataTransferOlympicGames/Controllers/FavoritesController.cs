using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dataTransferOlympicGames.Models;

namespace dataTransferOlympicGames.Controllers
{
    public class FavoritesController : Controller
    {

        private CountryContext context;

        public FavoritesController(CountryContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index()
        {

            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View(model);

        }

        [HttpPost]
        public RedirectToActionResult Add(Country country)
        {
            country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Category)
                .Where(t => t.CountryID == country.CountryID)
                .FirstOrDefault() ?? new Country();

            var session = new OlympicSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{country.Name} added to your favorites";

            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            });

        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {

            var session = new OlympicSession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            });

        }

    }
}
