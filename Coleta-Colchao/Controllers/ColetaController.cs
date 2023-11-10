using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
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

        public IActionResult Index(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View();
        }
        public IActionResult IndexEspuma(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View();
        }
        public IActionResult EnsaioEspumaParte1()
        {
            return View("Espuma/EnsaioEspumaParte1");
        }
        public IActionResult EnsaioEspumaParte2()
        {
            return View("Espuma/EnsaioEspumaParte2");
        }
        public IActionResult EnsaioIdentificacao()
        {
            return View("Espuma/EnsaioIdentificacao");
        }
        public IActionResult IdentificacaoEmbalagem()
        {
            return View("Espuma/IdentificacaoEmbalagem");
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

        public IActionResult EnsaioMolasParte1(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolasParte1");
        }

        public IActionResult EnsaioMolasParte2(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolasParte2");
        }

        public IActionResult EnsaioMolasParte3(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
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
        public async Task<IActionResult> SalvarRegistro(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,tipo_ensaio,ensaio")] ColetaModel.Registro registro)
        {

            try
            {
                string lacre = registro.lacre;
                string realizacao_ensaios = registro.realizacao_ensaios;
                string quant_recebida = registro.quant_recebida;
                string quant_ensaiada = registro.quant_ensaiada;
                DateOnly data_realizacao_ini = registro.data_realizacao_ini;
                DateOnly data_realizacao_term = registro.data_realizacao_term;
                string tipo_ensaio = registro.tipo_ensaio;
                string ensaio = registro.ensaio;


                if (tipo_ensaio != "Escolha" || ensaio != "Escolha")
                {
                    var salvarRegistro = new ColetaModel.Registro
                    {
                        orcamento = orcamento,
                        os = os,
                        lacre = lacre,
                        realizacao_ensaios = realizacao_ensaios,
                        quant_recebida = quant_recebida,
                        quant_ensaiada = quant_ensaiada,
                        data_realizacao_ini = data_realizacao_ini,
                        data_realizacao_term = data_realizacao_term,
                        tipo_ensaio = tipo_ensaio,
                        ensaio = ensaio,
                    };

                    _context.Add(salvarRegistro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Iniciais gravados com Sucesso";
                    return RedirectToAction(nameof(Index), new { os, orcamento });
                }
                else
                {
                    TempData["Mensagem"] = "Você precisar passar o campo tipo de ensaio ou ensaio para salvar.";
                    return RedirectToAction(nameof(Index), new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarColetaMolas1()
        {
            TempData["Mensagem"] = "Entrou";
            return RedirectToAction("EnsaioMolasParte1");
        }
    }
}