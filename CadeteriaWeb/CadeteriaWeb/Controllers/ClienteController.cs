using CadeteriaWeb.Models;
using CadeteriaWeb.servicios;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioCliente repositorioCliente;

        public ClienteController(ILogger<HomeController> logger, IRepositorioCliente repositorioCliente)
        {
            _logger = logger;
            this.repositorioCliente = repositorioCliente;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
