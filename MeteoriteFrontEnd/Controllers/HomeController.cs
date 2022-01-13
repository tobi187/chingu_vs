using MeteoriteFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult Index()
        {
            var data = DataAccess.getRequest();
            data.RunSynchronously();
            List<APIModel> models = data.Result.toList();
            return View();
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