using CadeteriaWeb.Models;
using CadeteriaWeb.servicios;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaWeb.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IRepositorioCadete repositorioCadete;

        public CadeteController(ILogger<CadeteController> logger, IRepositorioCadete repositorioCadete)
        {
            _logger = logger;
            this.repositorioCadete = repositorioCadete;
        }
        public IActionResult Index()
        {
            List<CadeteDTO> cadetes = repositorioCadete.listar();
            var modelo = new HomeIndexViewModel()
            {
                CadeteDTOs = cadetes
            };
            return View(modelo);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(CadeteDTO cadeteDTO)
        {
            repositorioCadete.RegistrarCadete(cadeteDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int idCadete)
        {
            var cadete = repositorioCadete.ObtenerId(idCadete);
            return View(cadete);
        }

        [HttpPost]
        public IActionResult Editar(CadeteDTO cadete)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var accion = repositorioCadete.Editar(cadete);
            if (accion)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        public IActionResult Eliminar(int idCadete)
        {
            var cadete = repositorioCadete.ObtenerId(idCadete);
            return View(cadete);
        }
        [HttpPost]
        public IActionResult Eliminar(CadeteDTO cadete)
        {
            var accion = repositorioCadete.Eliminar(cadete.Id);
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
