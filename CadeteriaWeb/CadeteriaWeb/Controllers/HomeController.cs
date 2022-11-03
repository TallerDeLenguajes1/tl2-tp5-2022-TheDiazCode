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
            var clientes = repositorioCliente.ObtenerClientes();
            var modelo = new HomeIndexViewModel
            {
                ClienteDTOs = clientes
            };
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Cliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cliente(ClienteDTO clienteDTO)
        {
            repositorioCliente.RegistrarClientes(clienteDTO);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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