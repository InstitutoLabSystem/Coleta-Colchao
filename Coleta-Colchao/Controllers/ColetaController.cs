using Microsoft.AspNetCore.Mvc;

namespace Coleta_Colchao.Controllers
{
    public class ColetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
