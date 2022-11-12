using CadeteriaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CadeteriaWeb.servicios;

namespace CadeteriaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioCliente repositorioCliente;

        public HomeController(ILogger<HomeController> logger, IRepositorioCliente repositorioCliente)
        {
            _logger = logger;
            this.repositorioCliente = repositorioCliente;
        }

        public IActionResult Index()
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