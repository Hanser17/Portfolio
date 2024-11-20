using Microsoft.AspNetCore.Mvc;
using Portafolio.Interfaces;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProyecto _repositoryProyectos;
        private readonly IEmailSendGrip _emailSendGrip;

        public HomeController(ILogger<HomeController> logger, IRepositoryProyecto repositoryProyectos, IEmailSendGrip emailSendGrip)
        {
            _logger = logger;
            _repositoryProyectos = repositoryProyectos;
            _emailSendGrip = emailSendGrip;
        }

        public IActionResult Index()
        {
           
            var proyectos = _repositoryProyectos.ObtenerProyecto().Take(3).ToList();
            var modelo = new HomeIndexModels { Proyectos = proyectos };


            return View(modelo);
        }
 
     public IActionResult Proyectos()
        {
            var proyectos = _repositoryProyectos.ObtenerProyecto();
            var modelo = new HomeIndexModels { Proyectos = proyectos };
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await _emailSendGrip.Enviar(contactoViewModel);
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
