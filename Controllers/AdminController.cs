using Microsoft.AspNetCore.Mvc;
using FirstWebApplication.Repositories;

namespace FirstWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly ObstacleRepository _repo;
        public AdminController(ObstacleRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Obstacles()
        {
            var all = await _repo.GetAllAsync();
            return View(all);
        }
    }
}
