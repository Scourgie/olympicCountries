using Microsoft.AspNetCore.Mvc;
using dataTransferOlympicGames.Models;

namespace dataTransferOlympicGames.Controllers
{
    public class NameController : Controller
    {

        public ViewResult Index()
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
        public RedirectToActionResult Change(CountryListViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetName(model.UserName);

            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            });
        }

    }
}
