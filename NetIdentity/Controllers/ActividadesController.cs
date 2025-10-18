using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetIdentity.Controllers
{
    
    public class ActividadesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize(Policy = "menoresEdad")]
        public IActionResult Deportes()
        {
            return View();
        }

        [Authorize]
        public IActionResult Tareas()
        {
            return View();
        }
        
        [Authorize(Policy = "GeneroMasculino")]
        public IActionResult ActividadesMasculinas()
        {
            return View();
        }
        
        [Authorize(Policy = "GeneroFemenino")]
        public IActionResult ActividadesFemeninas()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [Authorize(Policy = "GeneroOtro")]
        public IActionResult ActividadesAdmin()
        {
            return View();
        }
    }

}
