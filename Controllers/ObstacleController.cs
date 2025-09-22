using Microsoft.AspNetCore.Mvc;
using FirstWebApplication.Models;

namespace FirstWebApplication.Controllers
{
    public class ObstacleController : Controller
    {
        [HttpGet]
        public IActionResult DataForm()
        {
            // Tom modell ved første visning
            return View(new ObstacleData());
        }

        [HttpPost]
        public IActionResult DataForm(ObstacleData obstacleData)
        {
            // Sjekker attributtene på modellen
            if (!ModelState.IsValid)
            {
                // Ugyldig -> vis skjemaet igjen med feilmeldinger
                return View(obstacleData);
            }

            // Her vil obstacleData.GeometryGeoJson inneholde en GeoJSON FeatureCollection (string)
            // Klar til å lagres i DB om du ønsker.

            // Gyldig -> gå til oversikt med data
            return View("Overview", obstacleData);
        }
    }
}
