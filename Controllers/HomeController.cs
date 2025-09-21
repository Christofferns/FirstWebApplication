using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using FirstWebApplication.Models;

namespace FirstWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MySqlConnection _conn;

    public HomeController(ILogger<HomeController> logger, MySqlConnection conn)
    {
        _logger = logger;
        _conn = conn;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            await _conn.OpenAsync();
            await _conn.CloseAsync();
            ViewBag.Message = "Kobling til MariaDB OK 🎉";
        }
        catch (Exception ex)
        {
            ViewBag.Message = $"Feil ved DB-kobling: {ex.Message}";
        }
        return View();
    }

    [HttpGet]
    public IActionResult DataForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DataForm(ObstacleData obstacleData)
    {
        if (ModelState.IsValid)
        {
            return View("Overview", obstacleData);
        }
        return View(obstacleData);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
