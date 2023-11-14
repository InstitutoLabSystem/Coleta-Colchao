using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BancoContext _bancoContext;
        private readonly ColchaoContext _context;

        public HomeController(ILogger<HomeController> logger, BancoContext bancoContext, ColchaoContext context)
        {
            _logger = logger;
            _bancoContext = bancoContext;
            _context = context;
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acess");
        }
        public IActionResult Index(string os, string orcamento)
        {
            if (os != null)
            {
                var dados = (from p in _bancoContext.programacao_lab_ensaios
                             join c in _bancoContext.ordemservicocotacaoitem_hc_copylab
                             on new { Orcamento = p.Orcamento, Item = p.Item } equals new { Orcamento = c.orcamento, Item = c.Item.ToString() }
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
                                 ProdEnsaiado = c.ProdEnsaiado

                             }).ToList();

                if (dados.Count != 0)
                {
                    ViewBag.os = os;
                    ViewBag.orcamento = dados.First().orcamento;
                    return View(dados);
                }
                else
                {
                    TempData["Mensagem"] = "Orçamento Não Encontrado.";
                    return View("Index");
                }
            }
            else
            {
                return View();
            }
        }


        public async Task<IActionResult> BuscarOrcamento(string os)
        {
            try
            {
                var dados = (from p in _bancoContext.programacao_lab_ensaios
                             join c in _bancoContext.ordemservicocotacaoitem_hc_copylab
                             on new { Orcamento = p.Orcamento, Item = p.Item } equals new { Orcamento = c.orcamento, Item = c.Item.ToString() }
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
                                 ProdEnsaiado = c.ProdEnsaiado

                             }).ToList();

                var buscarOs = _context.regtro_colchao.Where(x => x.os == os).FirstOrDefault();
                if (buscarOs == null)
                {
                    if (dados.Count != 0)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        return RedirectToAction(nameof(Index), "Coleta", new { os, ViewBag.orcamento });
                    }
                    else
                    {
                        TempData["Mensagem"] = "Orçamento Não Encontrado.";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.os = os;
                    ViewBag.orcamento = dados.First().orcamento;
                    return View("Index", dados);
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