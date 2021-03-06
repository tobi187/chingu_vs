using MeteoriteFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using DataAction;
using MeteroiteBackEnd.MeteoriteApiModel;

namespace MeteoriteFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = DataAccess.getRequest();
            await data.ConfigureAwait(continueOnCapturedContext: false);
            List<APIModel> models = data.Result.ToList();
            if (!models.Any())
            {
                return View("Error");
            }
            return View(models);
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            var data = DataAccess.searchUser(searchTerm ?? "");
            List<APIModel> models = data.ToList();
            if (!models.Any())
            {
                return View("Error");
            }
            return View(models);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}