using Microsoft.AspNetCore.Mvc;

namespace Geno_API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
