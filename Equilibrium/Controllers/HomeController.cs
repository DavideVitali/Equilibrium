using Equilibrium.Components;
using Equilibrium.Components.OperationResult;
using Equilibrium.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Equilibrium.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string m)
        {
            if (string.IsNullOrEmpty(m))
            {
                return OperationResult.Failure($"{nameof(m)} is not valid.");
            }

            return OperationResult.Success(m);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}