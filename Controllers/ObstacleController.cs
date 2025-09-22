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
            if (!ModelState.IsValid)
                return View(obstacleData);

            // Ferdig utfylt -> vis Overview
            return View("Overview", obstacleData);
        }

        // ----- EDIT -----

        // Vi laster Edit-skjemaet ved å POSTe hele modellen fra Overview (skåner oss for for lang querystring).
        [HttpPost]
        public IActionResult Edit(ObstacleData obstacleData)
        {
            // Viser Edit-skjema med eksisterende verdier (inkl. GeoJSON)
            return View("Edit", obstacleData);
        }

        // Lagre endringer fra Edit-skjemaet og vis Overview igjen
        [HttpPost]
        public IActionResult EditSave(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
                return View("Edit", obstacleData);

            // Tilbake til Overview med oppdatert modell
            return View("Overview", obstacleData);
        }
    }
}
