using Microsoft.AspNetCore.Mvc;
using FirstWebApplication.Models;
using FirstWebApplication.Repositories;

namespace FirstWebApplication.Controllers
{
    public class ObstacleController : Controller
    {
        private readonly ObstacleRepository _repo;
        public ObstacleController(ObstacleRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult DataForm() => View(new ObstacleData());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DataForm(ObstacleData model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var rows = await _repo.CreateAsync(model);
                if (rows == 0)
                {
                    ModelState.AddModelError(string.Empty, "Ingenting ble lagret (0 rader).");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Feil ved lagring: " + ex.Message);
                return View(model);
            }

            // ✅ Viser samme side som før (ikke Admin)
            ViewBag.Saved = true; // valgfritt – for “lagret”-melding
            return View("Overview", model);
        }

        // Mulighet for å vise Overview direkte, om du ønsker å lenke dit
        [HttpGet]
        public IActionResult Overview(ObstacleData model)
        {
            return View(model);
        }
    }
}
