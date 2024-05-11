using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class NuevoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
