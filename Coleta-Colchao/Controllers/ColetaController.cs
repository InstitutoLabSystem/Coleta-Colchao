using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class ColetaController : Controller
    {
        //conexao..
        private readonly ILogger<ColetaController> _logger;
        private readonly ColchaoContext _context;
        public ColetaController(ILogger<ColetaController> logger, ColchaoContext colchaoContex)
        {
            _logger = logger;
            _context = colchaoContex;
        }

        public IActionResult IndexMolas()
        {
            return View();
        }

        public IActionResult EnsaioColchaoEspuma()
        {
            return View();
        }

        public IActionResult EnsaioBaseCargaEstetica()
        {
            return View();
        }
        public IActionResult EnsaioBaseEstruturaDurabi()
        {
            return View();
        }

        public IActionResult EnsaioDurabilidade()
        {
            return View();
        }

        public IActionResult EnsaioImpacto()
        {
            return View();
        }

        public IActionResult EnsaioMolasParte1()
        {
            return View("Molas/EnsaioMolasParte1");
        }

        public IActionResult EnsaioMolasParte2()
        {
            return View("Molas/EnsaioMolasParte2");
        }

        public IActionResult EnsaioMolasParte3()
        {
            return View("Molas/EnsaioMolasParte3");

        }

        public IActionResult IdentificacaoEmbalagem1()
        {
            return View("Molas/IdentificacaoEmbalagem1");
        }
        public IActionResult IdentificacaoEmbalagem2()
        {
            return View("Molas/IdentificacaoEmbalagem2");
        }

        //INICIO DAS FUNÇÕES PARA SALVAR OS DADOS,
        [HttpPost]
        public async Task<IActionResult> SalvarColetaMolas1()
        {
           TempData["Mensagem"] = "Entrou";
            return RedirectToAction("EnsaioMolasParte1");
        }
    }
}