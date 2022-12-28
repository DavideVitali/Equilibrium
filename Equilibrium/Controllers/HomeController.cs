﻿using Equilibrium.Models;
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
            if (m != "davide")
            {
                throw new UnauthorizedAccessException("Password errata.");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}