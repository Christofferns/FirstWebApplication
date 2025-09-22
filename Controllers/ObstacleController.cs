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
        [ValidateAntiForgeryToken]
        public IActionResult DataForm(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
                return View(obstacleData);

            // Ferdig utfylt -> vis Overview
            return View("Overview", obstacleData);
        }

        // ----- EDIT -----

        // Åpne Edit ved å POSTe hele modellen fra Overview (enkelt uten database)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ObstacleData obstacleData)
        {
            return View("Edit", obstacleData);
        }

        // Lagre endringer fra Edit-skjemaet og vis Overview igjen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSave(ObstacleData obstacleData)
        {
            if (!ModelState.IsValid)
                return View("Edit", obstacleData);

            return View("Overview", obstacleData);
        }
    }
}
