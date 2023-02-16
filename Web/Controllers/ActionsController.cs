using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ActionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
