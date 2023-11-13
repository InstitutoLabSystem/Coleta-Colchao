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

        public async Task<IActionResult> BuscarOrcamento(string os)
        {
            try
            {
                var dados = (from p in _bancoContext.programacao_lab_ensaios
                             join c in _bancoContext.ordemservicocotacaoitem_hc_copylab
                             on new { Orcamento = p.Orcamento, Item = p.Item }  equals new { Orcamento = c.orcamento, Item = c.Item.ToString()}
                             join hc in _bancoContext.Wmoddetprod
                             on c.CodigoEnsaio equals hc.codmaster
                             where p.OS == os
                             orderby hc.codigo
                             select new HomeModel.Resposta
                             {
                                 orcamento = p.Orcamento,
                                 OS = p.OS,
                                 codmaster = hc.codmaster,
                                 codigo = hc.codigo,
                                 descricao = hc.descricao,
                             }).ToList();

                if (dados != null)
                {
                    return View("Index",dados);
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