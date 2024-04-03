using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;
using System.Security.Claims;
using System.Linq;

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

        [Route("Home")]
        public IActionResult Index(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View();
        }



        [Route("Home/Index")]
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
                             orderby hc.descricao
                             select new HomeModel.Resposta
                             {
                                 orcamento = p.Orcamento,
                                 OS = p.OS,
                                 codmaster = hc.codmaster,
                                 codigo = hc.codigo,
                                 descricao = hc.descricao,
                                 ProdEnsaiado = c.ProdEnsaiado,

                             }).ToList();

                var buscarOs = _context.regtro_colchao.Where(x => x.os == os).FirstOrDefault();
                var buscarEspumaOs = _context.regtro_colchao_espuma.Where(x => x.os == os).FirstOrDefault();
                var buscarLamina = _context.regtro_colchao_lamina.Where(x => x.os == os).FirstOrDefault();
                if (buscarOs == null && buscarEspumaOs == null && buscarLamina == null)
                {
                    if (dados.Count != 0)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;

                        if (dados.Any(x => x.codigo == "PRLCCH001000001"))
                        {
                            return RedirectToAction("IndexMolas", "Coleta", new { os, ViewBag.orcamento });
                        }
                        else if (dados.Any(x => x.codigo == "DIMCCH001000001"))
                        {
                            return RedirectToAction("IndexEspuma", "Coleta", new { os, ViewBag.orcamento });
                        }
                        else if (dados.Any(x => x.codigo == "FTCCCH002000001") || dados.Any(x => x.codigo == "DNSCCH002000001"))
                        {
                            return RedirectToAction("IndexLamina", "Coleta", new { os, ViewBag.orcamento });
                        }
                        else
                        {
                            TempData["Mensagem"] = "Nenhum codigo encontrado.";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "Orçamento Não Encontrado.";
                        return View("Index");
                    }
                }
                else
                {
                    if (buscarOs != null)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        ViewBag.estrutura = buscarOs.estrutura;
                        ViewBag.ensaio = "Molas";

                        return View("Index", dados);
                    }

                    if (buscarEspumaOs != null)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        ViewBag.ensaio = "Espuma";
                        return View("Index", dados);
                    }

                    if (buscarLamina != null)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        ViewBag.ensaio = "Laminas";

                        //codigos dos ensaios do colchao, para trazer todas os referente ao ensaio de colchao.
                        var codigosLaminas = new List<string> { "DNSCCH002000001", "DPCCCH002000001", "FDGCCH002000001", "FTCCCH002000001", "IDTCCH001000001", "QUICCH002000001", "RSLCCH002000001" };

                        ViewBag.ContemOs = (from p in _bancoContext.programacao_lab_ensaios
                                            join c in _bancoContext.ordemservicocotacaoitem_hc_copylab
                                            on new { Orcamento = p.Orcamento, Item = p.Item } equals new { Orcamento = c.orcamento, Item = c.Item.ToString() }
                                            join hc in _bancoContext.Wmoddetprod
                                            on c.CodigoEnsaio equals hc.codmaster
                                            where p.Orcamento == dados.First().orcamento && codigosLaminas.Contains(hc.codigo)
                                            orderby hc.descricao
                                            select new
                                            {
                                                hc.codigo,
                                                p.OS,
                                            }).ToList().Distinct();

                        return View("Index", dados);
                    }
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