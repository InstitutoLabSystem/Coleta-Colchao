using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Authorization;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BancoContext _bancoContext;

        public HomeController(ILogger<HomeController> logger, BancoContext bancoContext)
        {
            _logger = logger;
            _bancoContext = bancoContext;

        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acess");
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscarOrcamento(string orcamento)
        {
            try
            {
                var dados = (from p in _bancoContext.ordemservico_laboratorio
                             join c in _bancoContext.ordemservicocotacao_hc_copylab
                             on (p.orcamento) equals (c.codigo + c.mes + c.ano)
                             where p.orcamento == orcamento & p.Laboratorio == "Colchão"
                             orderby p.OS
                             select new HomeModel.Resposta
                             {
                                 orcamento = p.orcamento,
                                 OS = p.OS,
                                 Solicitante = c.Solicitante
                             }).ToList();

                if (dados.Count != 0)
                {
                    return View("Index", dados);
                }
                else
                {
                    TempData["Mensagem"] = "Orçamento Não Encontrado.";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }
    }
}