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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using static Coleta_Colchao.Models.ColetaModel;

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

        //função de pegar usuario.
        public string Usuario()
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            return user;
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

                var buscarOs = _context.regtro_colchao.Where(x => x.os == os).OrderByDescending(x => x.Id).FirstOrDefault();
                var buscarEspumaOs = _context.regtro_colchao_espuma.Where(x => x.os == os).OrderByDescending(x => x.Id).FirstOrDefault();
                var buscarLamina = _context.regtro_colchao_lamina.Where(x => x.os == os).OrderByDescending(x => x.Id).FirstOrDefault();
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
                        else if (dados.Any(x => x.codigo == "FTCCCH002000001") || dados.Any(x => x.codigo == "DNSCCH002000001") || dados.Any(x => x.codigo == "IDTCCH001000001"))
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
                        ViewBag.user = Usuario();
                        ViewBag.rev = buscarOs.rev;
                        ViewBag.PercorrerRegstro = _context.regtro_colchao.Where(x => x.os == os).OrderByDescending(x => x.Id).ToList();
                        ViewBag.ensaio = "Molas";
                        ViewBag.bloqueada = buscarOs.Bloqueada;

                        return View("Index", dados);
                    }

                    if (buscarEspumaOs != null)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        ViewBag.rev = buscarEspumaOs.rev;
                        ViewBag.PercorrerRegstro = _context.regtro_colchao_espuma.Where(x => x.os == os).OrderByDescending(x => x.Id).ToList();
                        ViewBag.user = Usuario();
                        ViewBag.ensaio = "Espuma";
                        ViewBag.bloqueada = buscarEspumaOs.Bloqueada;
                        return View("Index", dados);
                    }

                    if (buscarLamina != null)
                    {
                        ViewBag.os = os;
                        ViewBag.orcamento = dados.First().orcamento;
                        ViewBag.rev = buscarLamina.rev;
                        ViewBag.PercorrerRegstro = _context.regtro_colchao_lamina.Where(x => x.os == os).OrderByDescending(x => x.Id).ToList();
                        ViewBag.user = Usuario();
                        ViewBag.ensaio = "Laminas";
                        ViewBag.bloqueada = buscarLamina.Bloqueada;
                        ViewBag.status = "andamento";

                        //codigos dos ensaios do colchao, para trazer todas os referente ao ensaio de colchao.
                        var codigosLaminas = new List<string> { "DNSCCH002000001", "DPCCCH002000001", "FDGCCH002000001", "FTCCCH002000001", "IDTCCH001000001", "QUICCH002000001", "RSLCCH002000001" };

                        ViewBag.ContemOs = (from p in _bancoContext.programacao_lab_ensaios
                                            join c in _bancoContext.ordemservicocotacaoitem_hc_copylab
                                            on new { Orcamento = p.Orcamento, Item = p.Item } equals new { Orcamento = c.orcamento, Item = c.Item.ToString() }
                                            join hc in _bancoContext.Wmoddetprod
                                            on c.CodigoEnsaio equals hc.codmaster
                                            join lb in _bancoContext.ordemservico_laboratorio
                                            on new { Numero = c.Numero.ToString(), Mes = c.Mes, Ano = c.Ano } equals new { Numero = lb.seqorc, Mes = lb.mesorc, Ano = lb.anoorc }
                                            where lb.orcamento == dados.First().orcamento && codigosLaminas.Contains(hc.codigo) && lb.Andamento != "ENVIADO"
                                            orderby lb.OS
                                            select new
                                            {
                                                lb.OS,
                                                hc.codigo,
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

        //gerar revisao da coleta.
        public async Task<IActionResult> GerarRevisao(string os, string orcamento, string ensaio, int revisao, string nota, string motivo)
        {
            //somando a revisao para salvar no log.
            revisao = revisao + 1;

            //esses ensaios pode ter para todos os tipo de colchao.
            var EnsaioBaseEstrutural = _context.ensaio_base_durabilidade_estrutural.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
            if (EnsaioBaseEstrutural != null)
            {
                var Novo_EnsaioBaseEstrutural = EnsaioBaseEstrutural.Clone();

                Novo_EnsaioBaseEstrutural.Id = 0;
                Novo_EnsaioBaseEstrutural.rev = Novo_EnsaioBaseEstrutural.rev + 1;

                _context.ensaio_base_durabilidade_estrutural.Add(Novo_EnsaioBaseEstrutural);
            }

            var EnsaioImpacto = _context.ensaio_base_impacto_vertical.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
            if (EnsaioImpacto != null)
            {
                var novoEnsaioImpcato = EnsaioImpacto.Clone();

                novoEnsaioImpcato.Id = 0;
                novoEnsaioImpcato.rev = novoEnsaioImpcato.rev + 1;

                _context.ensaio_base_impacto_vertical.Add(novoEnsaioImpcato);
            }

            var EnsaioDurabilidade = _context.ensaio_base_durabilidade.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
            if (EnsaioDurabilidade != null)
            {
                var novoEnsaioDurabilidade = EnsaioDurabilidade.Clone();

                novoEnsaioDurabilidade.Id = 0;
                novoEnsaioDurabilidade.rev = novoEnsaioDurabilidade.rev + 1;

                _context.ensaio_base_durabilidade.Add(novoEnsaioDurabilidade);
            }

            var EnsaioBaseCargaEstatica = _context.ensaio_base_carga_estatica.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
            if (EnsaioBaseCargaEstatica != null)
            {
                var novo_EnsaioBaseCargaEstatica = EnsaioBaseCargaEstatica.Clone();

                novo_EnsaioBaseCargaEstatica.Id = 0;
                novo_EnsaioBaseCargaEstatica.rev = novo_EnsaioBaseCargaEstatica.rev + 1;

                _context.ensaio_base_carga_estatica.Add(novo_EnsaioBaseCargaEstatica);
            }
            var Condicionamento = _context.condicionamento.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();

            if (Condicionamento != null)
            {
                var novo_Condicionamento = Condicionamento.Clone();

                novo_Condicionamento.Id = 0;
                novo_Condicionamento.rev = novo_Condicionamento.rev + 1;
                _context.Add(novo_Condicionamento);
            }
            //fim.

            //verificando qual ensaio é, molas,espuma,Laminas
            if (ensaio == "Molas")
            {
                //pegando registro geral de molas.
                var RegtroMolas = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();

                if (RegtroMolas != null)
                {
                    var novo_RegtroMolas = RegtroMolas.Clone();

                    novo_RegtroMolas.Id = 0;
                    novo_RegtroMolas.rev = novo_RegtroMolas.rev + 1;
                    _context.Add(novo_RegtroMolas);
                }

                //pegando todas as tabelas de molas e verifando se existe valores e insertando a nova revisao.
                var Ensaio_molas_4_3 = _context.ensaio_molas_item4_3.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_4_3 != null)
                {
                    var novo_Ensaio_molas_4_3 = Ensaio_molas_4_3.Clone();

                    novo_Ensaio_molas_4_3.Id = 0;
                    novo_Ensaio_molas_4_3.rev = novo_Ensaio_molas_4_3.rev + 1;

                    _context.ensaio_molas_item4_3.Add(novo_Ensaio_molas_4_3);
                }

                var Ensaio_molas_7_1 = _context.ensaio_molas_item7_1.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_1 != null)
                {
                    var novo_ensaio_molas_7_1 = Ensaio_molas_7_1.Clone();

                    novo_ensaio_molas_7_1.Id = 0;
                    novo_ensaio_molas_7_1.rev = novo_ensaio_molas_7_1.rev + 1;
                    _context.ensaio_molas_item7_1.Add(novo_ensaio_molas_7_1);
                }

                var Ensaio_molas_7_2 = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_2 != null)
                {
                    var novo_Ensaio_molas7_2 = Ensaio_molas_7_2.Clone();

                    novo_Ensaio_molas7_2.Id = 0;
                    novo_Ensaio_molas7_2.rev = novo_Ensaio_molas7_2.rev + 1;
                    _context.ensaio_molas_item7_2.Add(novo_Ensaio_molas7_2);
                }

                var Ensaio_molas_7_3 = _context.ensaio_molas_item7_3.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_3 != null)
                {
                    var novo_molas_7_3 = Ensaio_molas_7_3.Clone();

                    novo_molas_7_3.Id = 0;
                    novo_molas_7_3.rev = novo_molas_7_3.rev + 1;
                    _context.ensaio_molas_item7_3.Add(novo_molas_7_3);
                }

                var Ensaio_molas_7_5 = _context.ensaio_molas_item7_5.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_5 != null)
                {
                    var novo_ensaio_molas7_5 = Ensaio_molas_7_5.Clone();

                    novo_ensaio_molas7_5.Id = 0;
                    novo_ensaio_molas7_5.rev = novo_ensaio_molas7_5.rev + 1;
                    _context.ensaio_molas_item7_5.Add(novo_ensaio_molas7_5);
                }

                var Ensaio_molas_7_6 = _context.ensaio_molas_item7_6.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_6 != null)
                {
                    var novo_ensaio_molas7_6 = Ensaio_molas_7_6.Clone();

                    novo_ensaio_molas7_6.Id = 0;
                    novo_ensaio_molas7_6.rev = novo_ensaio_molas7_6.rev + 1;
                    _context.ensaio_molas_item7_6.Add(novo_ensaio_molas7_6);
                }

                var Ensaio_molas_7_7 = _context.ensaio_molas_item7_7.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_7 != null)
                {
                    var novo_ensaio_molas7_7 = Ensaio_molas_7_7.Clone();

                    novo_ensaio_molas7_7.Id = 0;
                    novo_ensaio_molas7_7.rev = novo_ensaio_molas7_7.rev + 1;
                    _context.ensaio_molas_item7_7.Add(novo_ensaio_molas7_7);
                }

                var Ensaio_molas_7_8 = _context.ensaio_molas_item7_8.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Ensaio_molas_7_8 != null)
                {
                    var novo_ensaio_molas7_8 = Ensaio_molas_7_8.Clone();

                    novo_ensaio_molas7_8.Id = 0;
                    novo_ensaio_molas7_8.rev = novo_ensaio_molas7_8.rev + 1;
                    _context.ensaio_molas_item7_8.Add(novo_ensaio_molas7_8);
                }

                var Identificacao_Embalagem = _context.ensaio_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (Identificacao_Embalagem != null)
                {
                    var Novo_Identificacao_Embalagem = Identificacao_Embalagem.Clone();

                    Novo_Identificacao_Embalagem.Id = 0;
                    Novo_Identificacao_Embalagem.rev = Novo_Identificacao_Embalagem.rev + 1;

                    _context.ensaio_identificacao_embalagem.Add(Novo_Identificacao_Embalagem);
                }
            }
            //fim verificação se ensaio é de molas.

            //inicio de laminas
            if (ensaio == "Laminas")
            {
                var registro_Laminas = _context.regtro_colchao_lamina.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();

                if (registro_Laminas != null)
                {
                    var novo_registro_Laminas = registro_Laminas.Clone();

                    novo_registro_Laminas.Id = 0;
                    novo_registro_Laminas.rev = novo_registro_Laminas.rev + 1;

                    _context.regtro_colchao_lamina.Add(novo_registro_Laminas);
                }

                var LaminaDeterminicaoDensidade = _context.lamina_determinacao_densidade.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminaDeterminicaoDensidade != null)
                {
                    var novo_LaminaDeterminicaoDensidade = LaminaDeterminicaoDensidade.Clone();

                    novo_LaminaDeterminicaoDensidade.Id = 0;
                    novo_LaminaDeterminicaoDensidade.rev = novo_LaminaDeterminicaoDensidade.rev + 1;

                    _context.lamina_determinacao_densidade.Add(novo_LaminaDeterminicaoDensidade);
                }

                var LaminaDpc = _context.lamina_dpc.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminaDpc != null)
                {
                    var novo_LaminaDpc = LaminaDpc.Clone();

                    novo_LaminaDpc.Id = 0;
                    novo_LaminaDpc.rev = novo_LaminaDpc.rev + 1;

                    _context.lamina_dpc.Add(novo_LaminaDpc);
                }

                var LaminasFI = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminasFI != null)
                {
                    var novo_LaminasFI = LaminasFI.Clone();

                    novo_LaminasFI.Id = 0;
                    novo_LaminasFI.rev = novo_LaminasFI.rev + 1;

                    _context.lamina_fi.Add(novo_LaminasFI);
                }

                var LaminaFadiga = _context.lamina_fadiga_dinamica.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminaFadiga != null)
                {
                    var novo_LaminaFadiga = LaminaFadiga.Clone();

                    novo_LaminaFadiga.Id = 0;
                    novo_LaminaFadiga.rev = novo_LaminaFadiga.rev + 1;

                    _context.lamina_fadiga_dinamica.Add(novo_LaminaFadiga);
                }

                var LaminaPFI = _context.lamina_pfi.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminaPFI != null)
                {
                    var novo_LaminaPFI = LaminaPFI.Clone();

                    novo_LaminaPFI.Id = 0;
                    novo_LaminaPFI.rev = novo_LaminaPFI.rev + 1;

                    _context.lamina_pfi.Add(novo_LaminaPFI);
                }

                var LaminaDetResiliencia = _context.lamina_resiliencia.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (LaminaDetResiliencia != null)
                {
                    var novo_LaminaDetResiliencia = LaminaDetResiliencia.Clone();

                    novo_LaminaDetResiliencia.Id = 0;
                    novo_LaminaDetResiliencia.rev = novo_LaminaDetResiliencia.rev + 1;

                    _context.lamina_resiliencia.Add(novo_LaminaDetResiliencia);
                }
            }
            //fim de laminas

            //Inicio Espuma
            if (ensaio == "Espuma")
            {
                var registro_Espuma = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();

                if (registro_Espuma != null)
                {
                    var novo_registro_Espuma = registro_Espuma.Clone();

                    novo_registro_Espuma.Id = 0;
                    novo_registro_Espuma.rev = novo_registro_Espuma.rev + 1;

                    _context.regtro_colchao_espuma.Add(novo_registro_Espuma);
                }

                var EnsaioEspuma4_1 = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (EnsaioEspuma4_1 != null)
                {
                    var novo_EnsaioEspuma4_1 = EnsaioEspuma4_1.Clone();

                    novo_EnsaioEspuma4_1.Id = 0;
                    novo_EnsaioEspuma4_1.rev = novo_EnsaioEspuma4_1.rev + 1;

                    _context.ensaio_espuma4_1.Add(novo_EnsaioEspuma4_1);
                }

                var EnsaioEspuma4_3 = _context.ensaio_espuma4_3.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (EnsaioEspuma4_3 != null)
                {
                    var novo_EnsaioEspuma4_3 = EnsaioEspuma4_3.Clone();

                    novo_EnsaioEspuma4_3.Id = 0;
                    novo_EnsaioEspuma4_3.rev = novo_EnsaioEspuma4_3.rev + 1;

                    _context.ensaio_espuma4_3.Add(novo_EnsaioEspuma4_3);
                }

                var EnsaioEspuma4_4 = _context.ensaio_espuma_item_4_4.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (EnsaioEspuma4_4 != null)
                {
                    var novo_EnsaioEspuma4_4 = EnsaioEspuma4_4.Clone();

                    novo_EnsaioEspuma4_4.Id = 0;
                    novo_EnsaioEspuma4_4.rev = novo_EnsaioEspuma4_4.rev + 1;

                    _context.ensaio_espuma_item_4_4.Add(novo_EnsaioEspuma4_4);
                }

                var EspumaIdentificacaoEmbalagem = _context.espuma_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).OrderByDescending(x => x.Id).FirstOrDefault();
                if (EspumaIdentificacaoEmbalagem != null)
                {
                    var novo_EspumaIdentificacaoEmbalagem = EspumaIdentificacaoEmbalagem.Clone();

                    novo_EspumaIdentificacaoEmbalagem.Id = 0;
                    novo_EspumaIdentificacaoEmbalagem.rev = novo_EspumaIdentificacaoEmbalagem.rev + 1;

                    _context.espuma_identificacao_embalagem.Add(novo_EspumaIdentificacaoEmbalagem);
                }
            }
            // fim espuma.

            //salvando no log as informações
            var salvarLog = new LogRevisao
            {
                os = os,
                orcamento = orcamento,
                rev = revisao,
                motivo = motivo,
                nota = nota,
                ensaio = ensaio,
                usuario = Usuario()
            };
            _context.log_colchao.Add(salvarLog);

            //SALVANDO NO BANCO DE DADOS AS ALTERAÇÕES DE NOVA REV.
            await _context.SaveChangesAsync();

            //retornando para minha função direto.
            return RedirectToAction(nameof(BuscarOrcamento), new { os });
        }

        //bloquear Coleta.
        [HttpPost]
        public async Task<IActionResult> BloquearColeta(string os, string orcamento, string ensaio, string motivo)
        {
            try
            {
                // verificando qual tipo de ensaio é para poder editar na tabela para bloquar coleta.
                if (ensaio == "Espuma")
                {
                    //buscando a os para saber se esta bloqueada ou não
                    var buscarDados = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).ToList();

                    //salvar no log se caso o usuario for desbloquear a coleta.
                    if (buscarDados[0].Bloqueada == "Sim")
                    {
                        var salvarLog = new LogRevisao
                        {
                            os = os,
                            orcamento = orcamento,
                            motivo = motivo,
                            nota = "Desbloqueio de coleta",
                            ensaio = ensaio,
                            usuario = Usuario()
                        };
                        _context.log_colchao.Add(salvarLog);
                    }

                    //começar a verificação se é para bloquear ou desbloquear 
                    for (int i = 0; i < buscarDados.Count; i++)
                    {
                        if (buscarDados[i].Bloqueada == null || buscarDados[i].Bloqueada == "Não")
                        {
                            buscarDados[i].Bloqueada = "Sim";
                        }
                        else
                        {
                            buscarDados[i].Bloqueada = "Não";
                        }

                        _context.regtro_colchao_espuma.Update(buscarDados[i]);
                    }
                }
                else if (ensaio == "Molas")
                {
                    //buscando a os para saber se esta bloqueada ou não
                    var buscarDados = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).ToList();

                    //salvar no log se caso o usuario for desbloquear a coleta.
                    if (buscarDados[0].Bloqueada == "Sim")
                    {
                        var salvarLog = new LogRevisao
                        {
                            os = os,
                            orcamento = orcamento,
                            motivo = motivo,
                            nota = "Desbloqueio de coleta",
                            ensaio = ensaio,
                            usuario = Usuario()
                        };
                        _context.log_colchao.Add(salvarLog);
                    }

                    //começar a verificação se é para bloquear ou desbloquear 
                    for (int i = 0; i < buscarDados.Count; i++)
                    {
                        if (buscarDados[i].Bloqueada == null || buscarDados[i].Bloqueada == "Não")
                        {
                            buscarDados[i].Bloqueada = "Sim";
                        }
                        else
                        {
                            buscarDados[i].Bloqueada = "Não";
                        }
                        _context.regtro_colchao.Update(buscarDados[i]);
                    }
                }
                else
                {
                    //buscando a os para saber se esta bloqueada ou não
                    var buscarDados = _context.regtro_colchao_lamina.Where(x => x.os == os && x.orcamento == orcamento).ToList();

                    //salvar no log se caso o usuario for desbloquear a coleta.
                    if (buscarDados[0].Bloqueada == "Sim")
                    {
                        var salvarLog = new LogRevisao
                        {
                            os = os,
                            orcamento = orcamento,
                            motivo = motivo,
                            nota = "Desbloqueio de coleta",
                            ensaio = ensaio,
                            usuario = Usuario()
                        };
                        _context.log_colchao.Add(salvarLog);
                    }

                    //começar a verificação se é para bloquear ou desbloquear 
                    for (int i = 0; i < buscarDados.Count; i++)
                    {
                        if (buscarDados[i].Bloqueada == null || buscarDados[i].Bloqueada == "Não")
                        {
                            buscarDados[i].Bloqueada = "Sim";
                        }
                        else
                        {
                            buscarDados[i].Bloqueada = "Não";
                        }
                        _context.regtro_colchao_lamina.Update(buscarDados[i]);
                    }
                }

                TempData["Mensagem"] = "Sucesso!";
                await _context.SaveChangesAsync();
                //var buscarDados = _context.regtro_colchao_espuma

                return RedirectToAction(nameof(BuscarOrcamento), new { os });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }
    }
}