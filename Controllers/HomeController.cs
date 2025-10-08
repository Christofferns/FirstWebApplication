using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebApplication.Models;
using FirstWebApplication.Data;
using Dapper;

namespace FirstWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DapperContext _context;

    public HomeController(ILogger<HomeController> logger, DapperContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Viser startsiden og tester DB-tilkobling
    public async Task<IActionResult> Index()
    {
        try
        {
            using var conn = _context.CreateConnection();
            await conn.OpenAsync();

            // Test en enkel spørring
            var result = await conn.ExecuteScalarAsync<int>("SELECT 1;");
            ViewBag.Message = result == 1
                ? "Kobling til MariaDB OK 🎉"
                : "Kobling til MariaDB feilet 😕";

            await conn.CloseAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Feil ved DB-kobling");
            ViewBag.Message = $"Feil ved DB-kobling: {ex.Message}";
        }

        return View();
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
}
