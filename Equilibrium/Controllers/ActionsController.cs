using Microsoft.AspNetCore.Mvc;

namespace Equilibrium.Controllers
{
    public class ActionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
