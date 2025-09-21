using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    public class FormController : Controller
    {
        // GET: /Form
        public IActionResult Index()
        {
            return View();
        }
    }
}
