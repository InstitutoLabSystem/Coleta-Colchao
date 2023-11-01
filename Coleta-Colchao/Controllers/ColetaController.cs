using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class ColetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnsaioColchaoEspuma()
        {
            return View();
        }
<<<<<<< Updated upstream

        public IActionResult EnsaioBaseCargaEstetica()
        {
            return View();
        }
        public IActionResult EnsaioBaseEstruturaDurabi()
=======
        public IActionResult durabilidade()
>>>>>>> Stashed changes
        {
            return View();
        }
    }
}
