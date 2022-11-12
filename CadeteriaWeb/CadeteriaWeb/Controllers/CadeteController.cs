using CadeteriaWeb.Models;
using CadeteriaWeb.servicios;
using Microsoft.AspNetCore.Mvc;

namespace CadeteriaWeb.Controllers
{
    public class CadeteController : Controller
    {
        private readonly IRepositorioCadete repositorioCadete;

        public CadeteController(IRepositorioCadete repositorioCadete)
        {
            this.repositorioCadete = repositorioCadete;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cadete()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Cadete(CadeteDTO cadeteDTO)
        {
            repositorioCadete.RegistrarCadete(cadeteDTO);
            return RedirectToAction("_Gracias");
        }
        public IActionResult _Gracias()
        {
            return View();
        }
    }
}
