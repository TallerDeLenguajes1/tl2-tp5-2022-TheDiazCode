using CadeteriaWeb.Models;
using CadeteriaWeb.servicios;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IRepositorioCliente repositorioCliente;

        public ClienteController(ILogger<ClienteController> logger, IRepositorioCliente repositorioCliente)
        {
            _logger = logger;
            this.repositorioCliente = repositorioCliente;
        }
        public IActionResult Index()
        {
            List<ClienteDTO> clientes = repositorioCliente.listar();
            var modelo = new HomeIndexViewModel()
            {
                ClienteDTOs = clientes
            };
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ClienteDTO clienteDTO)
        {
            repositorioCliente.RegistrarCliente(clienteDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int idCliente)
        {
            var cliente = repositorioCliente.ObtenerID(idCliente);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Editar(ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var accion = repositorioCliente.Editar(cliente);
            if (accion)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idCliente)
        {
            var cliente = repositorioCliente.ObtenerID(idCliente);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Eliminar(ClienteDTO cliente)
        {
           
            var accion = repositorioCliente.Eliminar(cliente.Id);
            if (accion)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
