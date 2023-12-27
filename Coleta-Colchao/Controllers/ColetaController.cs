using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using static Coleta_Colchao.Models.ColetaModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
    //[Route("Coleta")]
    public class ColetaController : Controller
    {
        //conexao..
        private readonly ILogger<ColetaController> _logger;
        private readonly ColchaoContext _context;
        private readonly BancoContext _bancoContext;
        public ColetaController(ILogger<ColetaController> logger, ColchaoContext colchaoContex, BancoContext bancoContext)
        {
            _logger = logger;
            _context = colchaoContex;
            _bancoContext = bancoContext;
        }


        public IActionResult Index(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View();
        }


        public IActionResult IndexMolas(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/IndexMolas");
        }
        public IActionResult IndexEspuma(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Espuma/IndexEspuma");
        }

        public IActionResult EditarIndexEspuma(string os, string orcamento)
        {
            var dados = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Espuma/IndexEspuma", dados);
        }

        //[Route("Molas/teste")]
        //public IActionResult teste(string os)
        //{
        //    var dados = _context.teste.Where(x => x.os == os).FirstOrDefault();
        //    return View(dados);
        //}

        public IActionResult EditarRegistroMolas(string os, string orcamento)
        {
            var dados = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).ToList();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EditarRegistroMolas", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View();
            }

        }

        public IActionResult EnsaioEspuma4_1(string os, string orcamento)
        {
            var dados = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var RegistroEspuma = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.quantidadeLaminas = RegistroEspuma.quant_laminas;
                ViewBag.tipoColchao = RegistroEspuma.tipo_colchao;
                return View("Espuma/EnsaioEspuma4_1", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.quantidadeLaminas = RegistroEspuma.quant_laminas;
                ViewBag.tipoColchao = RegistroEspuma.tipo_colchao;
                return View("Espuma/EnsaioEspuma4_1");
            }

        }

        public IActionResult Espuma4_4(string os, string orcamento)
        {
            var dados = _context.ensaio_espuma_item_4_4.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/Espuma4_4");

            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/Espuma4_4", dados);
            }
        }


        public IActionResult EnsaioEspuma4_3(string os, string orcamento)
        {
            var dados = _context.ensaio_espuma4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/EnsaioEspuma4_3", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/EnsaioEspuma4_3");
            }
        }
        public IActionResult IdentificacaoEmbalagem(string os, string orcamento)
        {
            var visualizarDados = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var dados = _context.espuma_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.outrosMateriais = visualizarDados.outros_materia;
                return View("Espuma/IdentificacaoEmbalagem", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.outrosMateriais = visualizarDados.outros_materia;
                return View("Espuma/IdentificacaoEmbalagem");
            }
        }
        public IActionResult EnsaioBaseCargaEstatica(string os, string orcamento)
        {
            var dados = _context.ensaio_base_carga_estatica.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View();
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View(dados);
            }

        }
        public IActionResult EnsaioBaseEstruturaDurabi(string os, string orcamento)
        {

            var dados = _context.ensaio_base_durabilidade_estrutural.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View(dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View();
            }
        }

        public IActionResult EnsaioDurabilidade(string os, string orcamento)
        {
            var dados = _context.ensaio_base_durabilidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var trazerEnsaio7_2 = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (trazerEnsaio7_2 == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.ensaio = "Molas";
                TempData["Mensagem"] = "Lembre-se voce nao ensaio o item 7_2 ";
                return View();

            }

            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.ensaio = "Molas";
                return View(dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;

                //manipulando a variavel para mostrar na tela quando n tiver ensaio.
                ViewBag.comprimento = (trazerEnsaio7_2.comp_espe * 10) / 2;
                ViewBag.largura = (trazerEnsaio7_2.larg_espe * 10) / 2;
                ViewBag.ensaio = "Molas";

                return View();
            }

        }
        public IActionResult EnsaioDurabilidadeEspuma(string os, string orcamento)
        {
            var dados = _context.ensaio_base_durabilidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.ensaio = "Espuma";
                return View(dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.ensaio = "Espuma";
                return View();
            }
        }

        public IActionResult EnsaioImpacto(string os, string orcamento)
        {
            var dados = _context.ensaio_base_impacto_vertical.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            //buscar valor preenchido no ensaio.
            var buscarEnsaio7_2 = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.comprimento = buscarEnsaio7_2.comp_espe * 10;
                ViewBag.largura = buscarEnsaio7_2.larg_espe * 10;
                return View();
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;

                return View(dados);
            }
        }
        public IActionResult EnsaioImpactoEspuma(string os, string orcamento)
        {
            var dados = _context.ensaio_base_impacto_vertical.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();


            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View();
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View(dados);
            }
        }
        public IActionResult EnsaioMolas7_1(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_1");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_1", dados);
            }


        }
        public IActionResult EnsaioMolas7_2(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_2");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_2", dados);
            }

        }
        public IActionResult EnsaioMolas7_6(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_6.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_6");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_6", dados);
            }
        }

        public IActionResult EnsaioMolas7_3(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_3");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_3", dados);
            }
        }
        public IActionResult EnsaioMolas7_7(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_7.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                //pegando o valor que o usuario  colocou no ensaio, para manipular da tela do usuario.
                var trazerEnsaio = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                ViewBag.tipo = trazerEnsaio.nome_molejo_dois;
                ViewBag.tipo2 = trazerEnsaio.nome_molejo_um;

                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_7");
            }
            else
            {
                //pegando o valor que o usuario  colocou no ensaio, para manipular da tela do usuario.
                var trazerEnsaio = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                ViewBag.tipo = trazerEnsaio.nome_molejo_dois;
                ViewBag.tipo2 = trazerEnsaio.nome_molejo_um;

                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_7", dados);
            }
        }
        public IActionResult EnsaioMolas7_5(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_5.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_5");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_5", dados);
            }
        }
        public IActionResult EnsaioMolas7_8(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item7_8.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_8");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_8", dados);
            }
        }
        public IActionResult EnsaioMolas4_3(string os, string orcamento)
        {
            var dados = _context.ensaio_molas_item4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas4_3");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas4_3", dados);
            }

        }



        public IActionResult IdentificacaoEmbalagemMolas(string os, string orcamento)
        {
            var dados = _context.ensaio_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            //trazendo os dados para manipular no ensaio realizado.
            var trazerDadosSalvos = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.latex = trazerDadosSalvos.latex;
                ViewBag.napa = trazerDadosSalvos.napa_cou_plas;
                ViewBag.manual = trazerDadosSalvos.manual;

                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/IdentificacaoEmbalagemMolas");
            }
            else
            {
                ViewBag.latex = trazerDadosSalvos.latex;
                ViewBag.napa = trazerDadosSalvos.napa_cou_plas;
                ViewBag.manual = trazerDadosSalvos.manual;

                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/IdentificacaoEmbalagemMolas", dados);
            }
        }
        public IActionResult IdentificacaoEmbalagem2()
        {
            return View("Molas/IdentificacaoEmbalagem2");
        }

        //INICIO DAS FUNÇÕES PARA SALVAR OS DADOS,

        //[HttpPost]
        //public async Task<IActionResult> SalvarRegistro(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,num_proc,cod_ref,tipo_cert,modelo_cert,tipo_proc,produto,estrutura,tipo_molejo,quant_molejo,fornecedor_um,fornecedor_dois,nome_molejo_um,nome_molejo_dois,quant_media_um,quant_media_dois,bitola_arame_um,bitola_arame_dois,borda_peri,isolante,latex,napa_cou_plas,manual")] ColetaModel.Registro registro)
        //{
        //    try
        //    {
        //        string lacre = registro.lacre;
        //        string realizacao_ensaios = registro.realizacao_ensaios;
        //        string quant_recebida = registro.quant_recebida;
        //        string quant_ensaiada = registro.quant_ensaiada;
        //        DateOnly data_realizacao_ini = registro.data_realizacao_ini;
        //        DateOnly data_realizacao_term = registro.data_realizacao_term;
        //        string num_proc = registro.num_proc;
        //        string cod_ref = registro.cod_ref;
        //        string tipo_cert = registro.tipo_cert;
        //        string modelo_cert = registro.modelo_cert;
        //        string tipo_proc = registro.tipo_proc;
        //        string produto = registro.produto;
        //        string estrutura = registro.estrutura;
        //        string tipo_molejo = registro.tipo_molejo;
        //        string quant_molejo = registro.quant_molejo;
        //        string fornecedor_um = registro.fornecedor_um;
        //        string fornecedor_dois = registro.fornecedor_dois;
        //        string nome_molejo_um = registro.nome_molejo_um;
        //        string nome_molejo_dois = registro.nome_molejo_dois;
        //        string quant_media_um = registro.quant_media_um;
        //        string quant_media_dois = registro.quant_media_dois;
        //        string bitola_arame_um = registro.bitola_arame_um;
        //        string bitola_arame_dois = registro.bitola_arame_dois;
        //        string borda_peri = registro.borda_peri;
        //        string isolante = registro.isolante;
        //        string latex = registro.latex;
        //        string napa_cou_plas = registro.napa_cou_plas;
        //        string manual = registro.manual;


        //        var salvarRegistro = new ColetaModel.Registro
        //        {
        //            orcamento = orcamento,
        //            os = os,
        //            lacre = lacre,
        //            realizacao_ensaios = realizacao_ensaios,
        //            quant_recebida = quant_recebida,
        //            quant_ensaiada = quant_ensaiada,
        //            data_realizacao_ini = data_realizacao_ini,
        //            data_realizacao_term = data_realizacao_term,
        //            num_proc = num_proc,
        //            cod_ref = cod_ref,
        //            tipo_cert = tipo_cert,
        //            modelo_cert = modelo_cert,
        //            tipo_proc = tipo_proc,
        //            produto = produto,
        //            estrutura = estrutura,
        //            tipo_molejo = tipo_molejo,
        //            quant_molejo = quant_molejo,
        //            fornecedor_um = fornecedor_um,
        //            fornecedor_dois = fornecedor_dois,
        //            nome_molejo_um = nome_molejo_um,
        //            nome_molejo_dois = nome_molejo_dois,
        //            quant_media_um = quant_media_um,
        //            quant_media_dois = quant_media_dois,
        //            bitola_arame_um = bitola_arame_um,
        //            bitola_arame_dois = bitola_arame_dois,
        //            borda_peri = borda_peri,
        //            isolante = isolante,
        //            latex = latex,
        //            napa_cou_plas = napa_cou_plas,
        //            manual = manual,

        //        };

        //        _context.Add(salvarRegistro);
        //        await _context.SaveChangesAsync();
        //        TempData["Mensagem"] = "Dados Iniciais gravados com Sucesso";
        //        return RedirectToAction(nameof(Index), "Home", new { os, orcamento });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error", ex.Message);
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> SalvarRegistroMolas(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,num_proc,cod_ref,tipo_cert,modelo_cert,tipo_proc,produto,estrutura,tipo_molejo,quant_molejo,fornecedor_um,fornecedor_dois,nome_molejo_um,nome_molejo_dois,quant_media_um,quant_media_dois,bitola_arame_um,bitola_arame_dois,borda_peri,isolante,latex,napa_cou_plas,manual")] ColetaModel.Registro registro)
        {
            try
            {
                string lacre = registro.lacre;
                string realizacao_ensaios = registro.realizacao_ensaios;
                string quant_recebida = registro.quant_recebida;
                string quant_ensaiada = registro.quant_ensaiada;
                DateOnly data_realizacao_ini = registro.data_realizacao_ini;
                DateOnly data_realizacao_term = registro.data_realizacao_term;
                string num_proc = registro.num_proc;
                string cod_ref = registro.cod_ref;
                string tipo_cert = registro.tipo_cert;
                string modelo_cert = registro.modelo_cert;
                string tipo_proc = registro.tipo_proc;
                string produto = registro.produto;
                string estrutura = registro.estrutura;
                string tipo_molejo = registro.tipo_molejo;
                string quant_molejo = registro.quant_molejo;
                string fornecedor_um = registro.fornecedor_um;
                string fornecedor_dois = registro.fornecedor_dois;
                string nome_molejo_um = registro.nome_molejo_um;
                string nome_molejo_dois = registro.nome_molejo_dois;
                string quant_media_um = registro.quant_media_um;
                string quant_media_dois = registro.quant_media_dois;
                string bitola_arame_um = registro.bitola_arame_um;
                string bitola_arame_dois = registro.bitola_arame_dois;
                string borda_peri = registro.borda_peri;
                string isolante = registro.isolante;
                string latex = registro.latex;
                string napa_cou_plas = registro.napa_cou_plas;
                string manual = registro.manual;


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
                    num_proc = num_proc,
                    cod_ref = cod_ref,
                    tipo_cert = tipo_cert,
                    modelo_cert = modelo_cert,
                    tipo_proc = tipo_proc,
                    produto = produto,
                    estrutura = estrutura,
                    tipo_molejo = tipo_molejo,
                    quant_molejo = quant_molejo,
                    fornecedor_um = fornecedor_um,
                    fornecedor_dois = fornecedor_dois,
                    nome_molejo_um = nome_molejo_um,
                    nome_molejo_dois = nome_molejo_dois,
                    quant_media_um = quant_media_um,
                    quant_media_dois = quant_media_dois,
                    bitola_arame_um = bitola_arame_um,
                    bitola_arame_dois = bitola_arame_dois,
                    borda_peri = borda_peri,
                    isolante = isolante,
                    latex = latex,
                    napa_cou_plas = napa_cou_plas,
                    manual = manual,

                };

                _context.Add(salvarRegistro);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Dados Iniciais gravados com Sucesso";
                return RedirectToAction(nameof(Index), "Home", new { os, orcamento });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarRegistroEspuma(string os, string orcamento, ColetaModel.RegistroEspuma salvarDados)
        {
            try
            {
                string lacre = salvarDados.lacre;
                string realizacao_ensaios = salvarDados.realizacao_ensaios;
                string quant_recebida = salvarDados.quant_recebida;
                string quant_ensaiada = salvarDados.quant_ensaiada;
                DateOnly data_realizacao_ini = salvarDados.data_realizacao_ini;
                DateOnly data_realizacao_term = salvarDados.data_realizacao_term;
                string num_proc = salvarDados.num_proc;
                string cod_ref = salvarDados.cod_ref;
                string tipo_cert = salvarDados.tipo_cert;
                string modelo_cert = salvarDados.modelo_cert;
                string tipo_proc = salvarDados.tipo_proc;
                string produto = salvarDados.produto;
                string clasi_produto = salvarDados.clasi_produto;
                string tipo_colchao = salvarDados.tipo_colchao;
                string uso = salvarDados.uso;
                int quant_laminas = salvarDados.quant_laminas;
                string densidade_1 = salvarDados.densidade_1;
                string densidade_2 = salvarDados.densidade_1;
                string densidade_3 = salvarDados.densidade_1;
                string densidade_4 = salvarDados.densidade_1;
                string densidade_5 = salvarDados.densidade_1;
                string revestimento = salvarDados.revestimento;
                string outros_materia = salvarDados.outros_materia;

                _context.regtro_colchao_espuma.Add(salvarDados);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                return RedirectToAction(nameof(Index), "Home", new { os, orcamento });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditarRegistroEspuma(string os, string orcamento, ColetaModel.RegistroEspuma salvarDados)
        {
            try
            {
                var editarDados = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados != null)
                {
                    editarDados.lacre = salvarDados.lacre;
                    editarDados.realizacao_ensaios = salvarDados.realizacao_ensaios;
                    editarDados.quant_recebida = salvarDados.quant_recebida;
                    editarDados.quant_ensaiada = salvarDados.quant_ensaiada;
                    editarDados.data_realizacao_ini = salvarDados.data_realizacao_ini;
                    editarDados.data_realizacao_term = salvarDados.data_realizacao_term;
                    editarDados.num_proc = salvarDados.num_proc;
                    editarDados.cod_ref = salvarDados.cod_ref;
                    editarDados.tipo_cert = salvarDados.tipo_cert;
                    editarDados.modelo_cert = salvarDados.modelo_cert;
                    editarDados.produto = salvarDados.produto;
                    editarDados.clasi_produto = salvarDados.clasi_produto;
                    editarDados.tipo_colchao = salvarDados.tipo_colchao;
                    editarDados.uso = salvarDados.uso;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;
                    editarDados.quant_laminas = salvarDados.quant_laminas;
                    editarDados.densidade_1 = salvarDados.densidade_1;
                    editarDados.densidade_2 = salvarDados.densidade_2;
                    editarDados.densidade_3 = salvarDados.densidade_3;
                    editarDados.densidade_4 = salvarDados.densidade_4;
                    editarDados.densidade_5 = salvarDados.densidade_5;
                    editarDados.revestimento = salvarDados.revestimento;
                    editarDados.outros_materia = salvarDados.outros_materia;

                    _context.regtro_colchao_espuma.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com Sucesso.";
                    return RedirectToAction(nameof(Index), "Home", new { os, orcamento });
                }
                else
                {
                    TempData["Mensagem"] = "Não foi possivel editar os dados.";
                    return RedirectToAction(nameof(Index), "Home", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditarRegistroMolas(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,num_proc,cod_ref,tipo_cert,modelo_cert,tipo_proc,produto,estrutura,tipo_molejo,quant_molejo,fornecedor_um,fornecedor_dois,nome_molejo_um,nome_molejo_dois,quant_media_um,quant_media_dois,bitola_arame_um,bitola_arame_dois,borda_peri,isolante,latex,napa_cou_plas,manual")] ColetaModel.Registro EditarRegistros)
        {
            var editarValores = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            try
            {
                if (editarValores != null)
                {
                    editarValores.lacre = EditarRegistros.lacre;
                    editarValores.realizacao_ensaios = EditarRegistros.realizacao_ensaios;
                    editarValores.quant_recebida = EditarRegistros.quant_recebida;
                    editarValores.quant_ensaiada = EditarRegistros.quant_ensaiada;
                    editarValores.data_realizacao_ini = EditarRegistros.data_realizacao_ini;
                    editarValores.data_realizacao_term = EditarRegistros.data_realizacao_term;
                    editarValores.num_proc = EditarRegistros.num_proc;
                    editarValores.cod_ref = EditarRegistros.cod_ref;
                    editarValores.tipo_cert = EditarRegistros.tipo_cert;
                    editarValores.modelo_cert = EditarRegistros.modelo_cert;
                    editarValores.tipo_proc = EditarRegistros.tipo_proc;
                    editarValores.produto = EditarRegistros.produto;
                    editarValores.estrutura = EditarRegistros.estrutura;
                    editarValores.tipo_molejo = EditarRegistros.tipo_molejo;
                    editarValores.quant_molejo = EditarRegistros.quant_molejo;
                    editarValores.fornecedor_um = EditarRegistros.fornecedor_um;
                    editarValores.fornecedor_dois = EditarRegistros.fornecedor_dois;
                    editarValores.nome_molejo_um = EditarRegistros.nome_molejo_um;
                    editarValores.quant_media_um = EditarRegistros.quant_media_um;
                    editarValores.quant_media_dois = EditarRegistros.quant_media_dois;
                    editarValores.bitola_arame_um = EditarRegistros.bitola_arame_um;
                    editarValores.bitola_arame_dois = EditarRegistros.bitola_arame_dois;
                    editarValores.borda_peri = EditarRegistros.borda_peri;
                    editarValores.isolante = EditarRegistros.isolante;
                    editarValores.latex = EditarRegistros.latex;
                    editarValores.napa_cou_plas = EditarRegistros.napa_cou_plas;
                    editarValores.manual = EditarRegistros.manual;


                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EditarRegistroMolas), "Coleta", new { os, orcamento });
                }
                else
                {
                    TempData["Mensagem"] = "Não Foi possivel Editar os dados";
                    return View("EditarRegistro");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio4_3(string os, string orcamento, [Bind("borda_aco,borda_espuma,borda_aco_molejo,borda_espuma_molejo,data_ini,data_term,valor_enc_aco,valor_enc_espuma,valor_enc_aco_molejo,valor_enc_espuma_molejo,man_parale_aco,man_parale_espuma,man_parale_aco_molejo,man_parale_espuma_molejo")] ColetaModel.Ensaio4_3 salvarDados)
        {
            try
            {
                var dados = _context.ensaio_molas_item4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (dados == null)
                {
                    string borda_aco = salvarDados.borda_aco;
                    string borda_aco_molejo = salvarDados.borda_aco_molejo;
                    string borda_espuma = salvarDados.borda_espuma;
                    string borda_espuma_molejo = salvarDados.borda_espuma_molejo;
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float valor_enc_aco = salvarDados.valor_enc_aco;
                    float valor_enc_aco_molejo = salvarDados.valor_enc_aco_molejo;
                    float valor_enc_espuma = salvarDados.valor_enc_espuma;
                    float valor_enc_espuma_molejo = salvarDados.valor_enc_espuma_molejo;
                    string man_parale_aco = salvarDados.man_parale_aco;
                    string man_parale_aco_molejo = salvarDados.man_parale_aco_molejo;
                    string man_parale_espuma_molejo = salvarDados.man_parale_espuma_molejo;
                    string man_parale_espuma = salvarDados.man_parale_espuma;
                    int contem_molejo;

                    if (borda_aco_molejo == "X" || borda_espuma_molejo == "X")
                    {
                        contem_molejo = 1;
                    }
                    else
                    {
                        contem_molejo = 0;
                    }
                    var registro = new ColetaModel.Ensaio4_3
                    {
                        os = os,
                        orcamento = orcamento,
                        borda_aco = borda_aco,
                        borda_aco_molejo = borda_aco_molejo,
                        borda_espuma = borda_espuma,
                        borda_espuma_molejo = borda_espuma_molejo,
                        data_ini = data_ini,
                        data_term = data_term,
                        valor_enc_aco = valor_enc_aco,
                        valor_enc_aco_molejo = valor_enc_aco_molejo,
                        valor_enc_espuma = valor_enc_espuma,
                        valor_enc_espuma_molejo = valor_enc_espuma_molejo,
                        man_parale_aco = man_parale_aco,
                        man_parale_aco_molejo = man_parale_aco_molejo,
                        man_parale_espuma_molejo = man_parale_espuma_molejo,
                        man_parale_espuma = man_parale_espuma,
                        contem_molejo = contem_molejo
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return View("Molas/EnsaioMolas4_3");
                }
                else
                {
                    dados.borda_aco = salvarDados.borda_aco;
                    dados.borda_aco_molejo = salvarDados.borda_aco_molejo;
                    dados.borda_espuma = salvarDados.borda_espuma;
                    dados.borda_espuma_molejo = salvarDados.borda_espuma_molejo;
                    dados.data_ini = salvarDados.data_ini;
                    dados.data_term = salvarDados.data_term;
                    dados.valor_enc_aco = salvarDados.valor_enc_aco;
                    dados.valor_enc_aco_molejo = salvarDados.valor_enc_aco_molejo;
                    dados.valor_enc_espuma = salvarDados.valor_enc_espuma;
                    dados.valor_enc_espuma_molejo = salvarDados.valor_enc_espuma_molejo;
                    dados.man_parale_aco = salvarDados.man_parale_aco;
                    dados.man_parale_aco_molejo = salvarDados.man_parale_aco_molejo;
                    dados.man_parale_espuma_molejo = salvarDados.man_parale_espuma_molejo;
                    dados.man_parale_espuma = salvarDados.man_parale_espuma;
                    int contem_molejo;

                    if (dados.borda_aco_molejo == "X" || dados.borda_espuma_molejo == "X")
                    {
                        contem_molejo = 1;
                    }
                    else
                    {
                        contem_molejo = 0;
                    }

                    _context.Update(dados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas4_3), "coleta", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_5(string os, string orcamento, [Bind("data_ini,data_term,temp_ensaio,faces,qtd_face,med_face_1,med_face_2,executor,auxiliar")] ColetaModel.Ensaio7_5 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_5.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                //verificando se foi realizado o ensaio 7.2
                var ensaio7_2 = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (ensaio7_2 == null)
                {
                    TempData["Mensagem"] = "Para realizar esse ensaio é necessario realizar o ensaio 7.2 de molas primeiro.";
                    return RedirectToAction(nameof(EnsaioMolas7_5), "Coleta", new { os, orcamento });
                }

                if (editarDados == null)
                {

                    // declarando as variaveis vazias para poder manipular elas.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    string temp_ensaio = salvarDados.temp_ensaio;
                    int qtd_face = salvarDados.qtd_face;
                    string faces = salvarDados.faces;
                    float esp_face_1 = ensaio7_2.alt_media;
                    float med_face_1 = salvarDados.med_face_1;
                    float acom_esp_face_1 = 0f;
                    float esp_face_2 = ensaio7_2.alt_media;
                    float med_face_2 = salvarDados.med_face_2;
                    float acom_esp_face_2 = 0f;
                    float acomodacao_encontrada_1 = 0f;
                    float acomodacao_encontrada_2 = 0f;
                    string conforme = string.Empty;

                    //realizando logica para 1 face.
                    if (qtd_face == 1)
                    {
                        if (ensaio7_2.alt_media >= 12 && ensaio7_2.alt_media <= 22)
                        {
                            acom_esp_face_1 = 6;
                        }
                        else if (ensaio7_2.alt_media >= 23 && ensaio7_2.alt_media <= 30)
                        {
                            acom_esp_face_1 = 8;
                        }
                        else
                        {
                            acom_esp_face_1 = 10;
                        }
                        acomodacao_encontrada_1 = (med_face_1 / esp_face_1) * 100;
                        string conv_acomodacao_encontrada_1 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_1 = float.Parse(conv_acomodacao_encontrada_1);

                        if (acomodacao_encontrada_1 <= acom_esp_face_1)
                        {
                            conforme = "C";
                        }
                        else
                        {
                            conforme = "NC";
                        }
                    }
                    else
                    {
                        if (ensaio7_2.alt_media >= 12 && ensaio7_2.alt_media <= 22)
                        {
                            acom_esp_face_1 = 6;
                            acom_esp_face_2 = 6;
                        }
                        else if (ensaio7_2.alt_media >= 23 && ensaio7_2.alt_media <= 30)
                        {
                            acom_esp_face_1 = 8;
                            acom_esp_face_2 = 8;
                        }
                        else
                        {
                            acom_esp_face_1 = 10;
                            acom_esp_face_2 = 10;
                        }


                        acomodacao_encontrada_1 = (med_face_1 / esp_face_1) * 100;
                        string conv_acomodacao_encontrada_1 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_1 = float.Parse(conv_acomodacao_encontrada_1);

                        acomodacao_encontrada_2 = (med_face_2 / esp_face_2) * 100;
                        string conv_acomodacao_encontrada_2 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_2 = float.Parse(conv_acomodacao_encontrada_2);

                        float media = (acomodacao_encontrada_1 + acomodacao_encontrada_2) / 2;

                        if (media <= acom_esp_face_2)
                        {
                            conforme = "C";
                        }
                        else
                        {
                            conforme = "NC";

                        }
                    }

                    var registro = new ColetaModel.Ensaio7_5
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ensaio = temp_ensaio,
                        esp_face_1 = esp_face_1,
                        faces = faces,
                        qtd_face = qtd_face,
                        med_face_1 = med_face_1,
                        acom_esp_face_1 = acom_esp_face_1,
                        acom_enc_face_1 = acomodacao_encontrada_1,
                        esp_face_2 = esp_face_2,
                        med_face_2 = med_face_2,
                        acom_esp_face_2 = acom_esp_face_2,
                        acom_enc_face_2 = acomodacao_encontrada_2,
                        conforme = conforme,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_5), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os dados, primeiro criando as variaveis que precisa.

                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.temp_ensaio = salvarDados.temp_ensaio;
                    editarDados.qtd_face = salvarDados.qtd_face;
                    editarDados.faces = salvarDados.faces;
                    editarDados.esp_face_1 = ensaio7_2.alt_media;
                    editarDados.med_face_1 = salvarDados.med_face_1;
                    editarDados.acom_esp_face_1 = 0f;
                    editarDados.esp_face_2 = ensaio7_2.alt_media;
                    editarDados.med_face_2 = salvarDados.med_face_2;
                    editarDados.acom_esp_face_2 = 0f;
                    float acomodacao_encontrada_1 = 0f;
                    float acomodacao_encontrada_2 = 0f;


                    if (editarDados.qtd_face == 1)
                    {
                        if (ensaio7_2.alt_media >= 12 && ensaio7_2.alt_media <= 22)
                        {
                            editarDados.acom_esp_face_1 = 6;
                        }
                        else if (ensaio7_2.alt_media >= 23 && ensaio7_2.alt_media <= 30)
                        {
                            editarDados.acom_esp_face_1 = 8;
                        }
                        else
                        {
                            editarDados.acom_esp_face_1 = 10;
                        }
                        acomodacao_encontrada_1 = (editarDados.med_face_1 / editarDados.esp_face_1) * 100;
                        string conv_acomodacao_encontrada_1 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_1 = float.Parse(conv_acomodacao_encontrada_1);

                        if (acomodacao_encontrada_1 <= editarDados.acom_esp_face_1)
                        {
                            editarDados.conforme = "C";
                        }
                        else
                        {
                            editarDados.conforme = "NC";
                        }

                    }
                    else
                    {
                        if (ensaio7_2.alt_media >= 12 && ensaio7_2.alt_media <= 22)
                        {
                            editarDados.acom_esp_face_1 = 6;
                            editarDados.acom_esp_face_2 = 6;
                        }
                        else if (ensaio7_2.alt_media >= 23 && ensaio7_2.alt_media <= 30)
                        {
                            editarDados.acom_esp_face_1 = 8;
                            editarDados.acom_esp_face_2 = 8;
                        }
                        else
                        {
                            editarDados.acom_esp_face_1 = 10;
                            editarDados.acom_esp_face_2 = 10;
                        }


                        acomodacao_encontrada_1 = (editarDados.med_face_1 / editarDados.esp_face_1) * 100;
                        string conv_acomodacao_encontrada_1 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_1 = float.Parse(conv_acomodacao_encontrada_1);

                        acomodacao_encontrada_2 = (editarDados.med_face_2 / editarDados.esp_face_2) * 100;
                        string conv_acomodacao_encontrada_2 = acomodacao_encontrada_1.ToString("N1");
                        acomodacao_encontrada_2 = float.Parse(conv_acomodacao_encontrada_2);

                        float media = (acomodacao_encontrada_1 + acomodacao_encontrada_2) / 2;

                        if (media <= editarDados.acom_esp_face_2)
                        {
                            editarDados.conforme = "C";
                        }
                        else
                        {
                            editarDados.conforme = "NC";
                        }
                    }

                    editarDados.acom_enc_face_1 = acomodacao_encontrada_1;
                    editarDados.acom_enc_face_2 = acomodacao_encontrada_2;


                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_5), "Coleta", new { os, orcamento });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_1(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_term,quant_face,velo_face_1,quant_face_1,velo_face_2,quant_face_2,executor,auxiliar")] ColetaModel.Ensaio7_1 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (editarDados == null)
                {
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float temp_ini = salvarDados.temp_ini;
                    float temp_term = salvarDados.temp_term;
                    int quant_face = salvarDados.quant_face;
                    int velo_face_1 = salvarDados.velo_face_1;
                    int quant_face_1 = salvarDados.quant_face_1;
                    int velo_face_2 = salvarDados.velo_face_2;
                    int quant_face_2 = salvarDados.quant_face_2;
                    string executor = salvarDados.executor;
                    string auxiliar = salvarDados.auxiliar;

                    var registro = new ColetaModel.Ensaio7_1
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ini = temp_ini,
                        temp_term = temp_term,
                        quant_face = quant_face,
                        velo_face_1 = velo_face_1,
                        quant_face_1 = quant_face_1,
                        velo_face_2 = velo_face_2,
                        quant_face_2 = quant_face_2,
                        executor = executor,
                        auxiliar = auxiliar,
                    };
                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_1), "Coleta", new { os, orcamento });
                }
                else
                {
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.temp_ini = salvarDados.temp_ini;
                    editarDados.temp_term = salvarDados.temp_term;
                    editarDados.quant_face = salvarDados.quant_face;
                    editarDados.velo_face_1 = salvarDados.velo_face_1;
                    editarDados.quant_face_1 = salvarDados.quant_face_1;
                    editarDados.velo_face_2 = salvarDados.velo_face_2;
                    editarDados.quant_face_2 = salvarDados.quant_face_2;
                    editarDados.executor = salvarDados.executor;
                    editarDados.auxiliar = salvarDados.auxiliar;

                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_1), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_2(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_term,comp_med_1,comp_med_2,comp_med_3,comp_espe,larg_med_1,larg_med_2,larg_med_3,larg_espe,alt_med_1,alt_med_2,alt_med_3,alt_espe,executor,auxiliar")] ColetaModel.Ensaio7_2 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_2.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo os valores e armazenando nas variaveis.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float temp_ini = salvarDados.temp_ini;
                    float temp_term = salvarDados.temp_term;
                    float comp_med_1 = salvarDados.comp_med_1;
                    float comp_med_2 = salvarDados.comp_med_2;
                    float comp_med_3 = salvarDados.comp_med_3;
                    float comp_espe = salvarDados.comp_espe;
                    float larg_med_1 = salvarDados.larg_med_1;
                    float larg_med_2 = salvarDados.larg_med_2;
                    float larg_med_3 = salvarDados.larg_med_3;
                    float larg_espe = salvarDados.larg_espe;
                    float alt_med_1 = salvarDados.alt_med_1;
                    float alt_med_2 = salvarDados.alt_med_2;
                    float alt_med_3 = salvarDados.alt_med_3;
                    float alt_espe = salvarDados.alt_espe;
                    string conforme_comprimento = string.Empty;
                    string conform_largura = string.Empty;
                    string conform_altura = string.Empty;

                    //calculando a media dos resultados.
                    float media_comprimeto = (comp_med_1 + comp_med_2 + comp_med_3) / 3;
                    string conv_media_comprimeto = media_comprimeto.ToString("N1");
                    media_comprimeto = float.Parse(conv_media_comprimeto);

                    float media_largura = (larg_med_1 + larg_med_2 + larg_med_3) / 3;
                    string conv_media_largura = media_largura.ToString("N1");
                    media_largura = float.Parse(conv_media_largura);

                    float media_altura = (alt_med_1 + alt_med_2 + alt_med_3) / 3;
                    string conv_media_altura = media_altura.ToString("N1");
                    media_altura = float.Parse(conv_media_altura);

                    //REALIZANDO CALCULO DE CONFORME OU NAO CONFORME comprimento.
                    float valor_min_comprimento = comp_espe - 1.5f;
                    float valor_max_comprimento = comp_espe + 1.5f;


                    if (media_comprimeto >= valor_min_comprimento && media_comprimeto <= valor_max_comprimento)
                    {
                        conforme_comprimento = "C";
                    }
                    else
                    {
                        conforme_comprimento = "NC";
                    }

                    //calculo de incerteza de largura.
                    float valor_min_largura = larg_espe - 1.5f;
                    float valor_max_largura = larg_espe + 1.5f;

                    if (media_largura >= valor_min_largura && media_largura <= valor_max_largura)
                    {
                        conform_largura = "C";
                    }
                    else
                    {
                        conform_largura = "NC";
                    }

                    //calculo de incerteza de altura.
                    float valor_min_altura = alt_espe - 1.5f;
                    float valor_max_altura = alt_espe + 1.5f;

                    if (media_altura >= valor_min_altura && media_altura <= valor_max_altura)
                    {
                        conform_altura = "C";
                    }
                    else
                    {
                        conform_altura = "NC";
                    }

                    //armazenando no banco.
                    var registro = new ColetaModel.Ensaio7_2
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ini = temp_ini,
                        temp_term = temp_term,
                        comp_med_1 = comp_med_1,
                        comp_med_2 = comp_med_2,
                        comp_med_3 = comp_med_3,
                        comp_espe = comp_espe,
                        com_media = media_comprimeto,
                        larg_med_1 = larg_med_1,
                        larg_med_2 = larg_med_2,
                        larg_med_3 = larg_med_3,
                        larg_espe = larg_espe,
                        larg_media = media_largura,
                        alt_med_1 = alt_med_1,
                        alt_med_2 = alt_med_2,
                        alt_med_3 = alt_med_3,
                        alt_espe = alt_espe,
                        alt_media = media_altura,
                        conforme_comprimento = conforme_comprimento,
                        conforme_largura = conform_largura,
                        conforme_altura = conform_altura,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_2), "Coleta", new { os, orcamento });

                }
                else
                {
                    //editando os valores.
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.temp_ini = salvarDados.temp_ini;
                    editarDados.temp_term = salvarDados.temp_term;
                    editarDados.comp_med_1 = salvarDados.comp_med_1;
                    editarDados.comp_med_2 = salvarDados.comp_med_2;
                    editarDados.comp_med_3 = salvarDados.comp_med_3;
                    editarDados.comp_espe = salvarDados.comp_espe;
                    editarDados.larg_med_1 = salvarDados.larg_med_1;
                    editarDados.larg_med_2 = salvarDados.larg_med_2;
                    editarDados.larg_med_3 = salvarDados.larg_med_3;
                    editarDados.larg_espe = salvarDados.larg_espe;
                    editarDados.alt_med_1 = salvarDados.alt_med_1;
                    editarDados.alt_med_2 = salvarDados.alt_med_2;
                    editarDados.alt_med_3 = salvarDados.alt_med_3;
                    editarDados.alt_espe = salvarDados.alt_espe;



                    //pegando a media dos valores
                    float media_comprimeto = (editarDados.comp_med_1 + editarDados.comp_med_2 + editarDados.comp_med_3) / 3;
                    string conv_media_comprimeto = media_comprimeto.ToString("N1");
                    media_comprimeto = float.Parse(conv_media_comprimeto);

                    float media_largura = (editarDados.larg_med_1 + editarDados.larg_med_2 + editarDados.larg_med_3) / 3;
                    string conv_media_largura = media_largura.ToString("N1");
                    media_largura = float.Parse(conv_media_largura);

                    float media_altura = (editarDados.alt_med_1 + editarDados.alt_med_2 + editarDados.alt_med_3) / 3;
                    string conv_media_altura = media_altura.ToString("N1");
                    media_altura = float.Parse(conv_media_altura);

                    //realizando calculos para editar conforme ou nao conforme
                    string conforme_comprimento = string.Empty;
                    string conform_largura = string.Empty;
                    string conform_altura = string.Empty;
                    float valor_min_comprimento = editarDados.comp_espe - 1.5f;
                    float valor_max_comprimento = editarDados.comp_espe + 1.5f;


                    if (media_comprimeto >= valor_min_comprimento && media_comprimeto <= valor_max_comprimento)
                    {
                        conforme_comprimento = "C";
                    }
                    else
                    {
                        conforme_comprimento = "NC";
                    }

                    //calculo de incerteza de largura.
                    float valor_min_largura = editarDados.larg_espe - 1.5f;
                    float valor_max_largura = editarDados.larg_espe + 1.5f;

                    if (media_largura >= valor_min_largura && media_largura <= valor_max_largura)
                    {
                        conform_largura = "C";
                    }
                    else
                    {
                        conform_largura = "NC";
                    }

                    //calculo de incerteza de altura.
                    float valor_min_altura = editarDados.alt_espe - 1.5f;
                    float valor_max_altura = editarDados.alt_espe + 1.5f;

                    if (media_altura >= valor_min_altura && media_altura <= valor_max_altura)
                    {
                        conform_altura = "C";
                    }
                    else
                    {
                        conform_altura = "NC";
                    }

                    editarDados.conforme_comprimento = conforme_comprimento;
                    editarDados.conforme_largura = conform_largura;
                    editarDados.conforme_altura = conform_altura;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_2), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEspumaUm(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_fim,dimensao_temp,comprimento_result,comprimento_um,comprimento_esp,comprimento_dois," +
          "comprimento_tres,comprimento_media,largura_result,largura_um,largura_esp,largura_dois,largura_tres,largura_media,altura_result,altura_um,altura_esp,altura_dois,altura_tres,altura_media,lamina_um,lamina_comp_um," +
          "lamina_esp_um,lamina_comp_dois,lamina_comp_tres,lamina_media_um,lamina_tipo_um,lamina_min_um,lamina_max_um,lamina_resul_um,lamina_dois,lamina_comp_quat,lamina_esp_dois, lamina_comp_cinco,lamina_comp_seis,lamina_media_dois,lamina_tipo_dois," +
          "lamina_min_dois,lamina_max_dois,lamina_resul_dois,lamina_tres,lamina_comp_sete,lamina_esp_tres,lamina_comp_oito,lamina_comp_nove,lamina_media_tres,lamina_tipo_tres,lamina_min_tres,lamina_max_tres,lamina_resul_tres,lamina_quat,lamina_comp_dez,lamina_esp_quat," +
          "lamina_comp_onze,lamina_comp_doze,lamina_media_quat,lamina_tipo_quat,lamina_min_quat,lamina_max_quat,lamina_resul_quat,lamina_cinco,lamina_comp_treze,lamina_esp_cinco,lamina_comp_quatorze,lamina_comp_quinze,lamina_media_cinco,lamina_tipo_cinco," +
          "lamina_min_cinco,lamina_max_cinco,lamina_resul_cinco,esp_tipo_um,esp_lamina_um,esp_especificado_um,esp_mm_um,esp_cm_um,esp_tipo_dois,esp_lamina_dois,esp_especificado_dois,esp_mm_dois,esp_cm_dois,col_tipo_um,col_especificado_um,col_encontrado_um,col_resul_um," +
          "col_tipo_dois,col_lamina_dois,col_especificado_dois,col_resul_dois,reves_tipo_um,reves_lamina_um,reves_especificado_um,reves_mm_um,reves_cm_um,reves_tipo_dois,reves_lamina_dois,reves_especificado_dois,reves_mm_dois,reves_cm_dois,temp_repouso,lamina_media_um")] ColetaModel.EspumaUm salvar)
        {
            try
            {

                var editarDados = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (editarDados == null)
                {

                    //recebendo os valores do html.
                    DateOnly data_ini = salvar.data_ini;
                    DateOnly data_term = salvar.data_term;
                    string temp_ini = salvar.temp_ini;
                    string temp_fim = salvar.temp_fim;
                    string dimensao_temp = salvar.dimensao_temp;
                    string comprimento_result = string.Empty;
                    float comprimento_um = salvar.comprimento_um;
                    float comprimento_esp = salvar.comprimento_esp;
                    float comprimento_dois = salvar.comprimento_dois;
                    float comprimento_tres = salvar.comprimento_tres;
                    string temp_repouso = salvar.temp_repouso;
                    float comprimento_media = ((comprimento_um + comprimento_dois + comprimento_tres) / 3);
                    float valor_min_comprimento = comprimento_esp - 1.5f;
                    float valor_max_comprimento = comprimento_esp + 1.5f;

                    if (comprimento_media >= valor_min_comprimento && comprimento_media <= valor_max_comprimento)
                    {
                        comprimento_result = "C";
                    }
                    else
                    {
                        comprimento_result = "NC";
                    }


                    string largura_result = string.Empty;
                    float largura_um = salvar.largura_um;
                    float largura_esp = salvar.largura_esp;
                    float largura_dois = salvar.largura_dois;
                    float largura_tres = salvar.largura_tres;
                    float largura_media = ((largura_um + largura_dois + largura_tres) / 3);
                    float largura_valor_min_comprimento = largura_esp - 1.5f;
                    float largura_valor_max_comprimento = largura_esp + 1.5f;

                    if (largura_media >= largura_valor_min_comprimento && largura_media <= largura_valor_max_comprimento)
                    {
                        largura_result = "C";
                    }
                    else
                    {
                        largura_result = "NC";
                    }


                    string altura_result = string.Empty;
                    float altura_um = salvar.altura_um;
                    float altura_esp = salvar.altura_esp;
                    float altura_dois = salvar.altura_dois;
                    float altura_tres = salvar.altura_tres;
                    float altura_media = ((altura_um + altura_dois + altura_tres) / 3);
                    float altura_valor_min_comprimento = altura_esp - 1.5f;
                    float altura_valor_max_comprimento = altura_esp + 1.5f;
                    if (altura_media >= altura_valor_min_comprimento && altura_media <= altura_valor_max_comprimento)
                    {
                        altura_result = "C";
                    }
                    else
                    {
                        altura_result = "NC";
                    }

                    string lamina_um = salvar.lamina_um;
                    float lamina_comp_um = salvar.lamina_comp_um;
                    float lamina_esp_um = salvar.lamina_esp_um;
                    float lamina_comp_dois = salvar.lamina_comp_dois;
                    float lamina_comp_tres = salvar.lamina_comp_tres;
                    float lamina_media_um = ((lamina_comp_um + lamina_comp_dois + lamina_comp_tres) / 3);
                    string lamina_tipo_um = salvar.lamina_tipo_um;
                    float lamina_min_um = salvar.lamina_min_um;
                    float lamina_max_um = salvar.lamina_max_um;
                    string lamina_resul_um = string.Empty;

                    if (lamina_media_um >= lamina_min_um && lamina_media_um <= lamina_max_um)
                    {
                        lamina_resul_um = "C";
                    }
                    else
                    {
                        lamina_resul_um = "NC";
                    }


                    string lamina_dois = salvar.lamina_dois;
                    float lamina_comp_quat = salvar.lamina_comp_quat;
                    float lamina_esp_dois = salvar.lamina_esp_dois;
                    float lamina_comp_cinco = salvar.lamina_comp_cinco;
                    float lamina_comp_seis = salvar.lamina_comp_seis;

                    float lamina_media_dois = ((lamina_comp_quat + lamina_comp_cinco + lamina_comp_seis) / 3);

                    string lamina_tipo_dois = salvar.lamina_tipo_dois;
                    float lamina_min_dois = salvar.lamina_min_dois;
                    float lamina_max_dois = salvar.lamina_max_dois;
                    string lamina_resul_dois = string.Empty;

                    if (lamina_media_dois >= lamina_min_dois && lamina_media_dois <= lamina_max_dois)
                    {
                        lamina_resul_dois = "C";
                    }
                    else
                    {
                        lamina_resul_dois = "NC";
                    }


                    string lamina_tres = salvar.lamina_tres;
                    float lamina_comp_sete = salvar.lamina_comp_sete;
                    float lamina_esp_tres = salvar.lamina_esp_tres;
                    float lamina_comp_oito = salvar.lamina_comp_oito;
                    float lamina_comp_nove = salvar.lamina_comp_nove;
                    float lamina_media_tres = ((lamina_comp_sete + lamina_comp_oito + lamina_comp_nove) / 3);

                    string lamina_tipo_tres = salvar.lamina_tipo_tres;
                    float lamina_min_tres = salvar.lamina_min_tres;
                    float lamina_max_tres = salvar.lamina_max_tres;
                    string lamina_resul_tres = string.Empty;

                    if (lamina_media_tres >= lamina_min_tres && lamina_media_tres <= lamina_max_tres)
                    {
                        lamina_resul_tres = "C";
                    }
                    else
                    {
                        lamina_resul_tres = "NC";
                    }

                    string lamina_quat = salvar.lamina_quat;
                    float lamina_comp_dez = salvar.lamina_comp_dez;
                    float lamina_esp_quat = salvar.lamina_esp_quat;
                    float lamina_comp_onze = salvar.lamina_comp_onze;
                    float lamina_comp_doze = salvar.lamina_comp_doze;
                    float lamina_media_quat = ((lamina_comp_dez + lamina_comp_onze + lamina_comp_doze) / 3);

                    string lamina_tipo_quat = salvar.lamina_tipo_quat;
                    float lamina_min_quat = salvar.lamina_min_quat;
                    float lamina_max_quat = salvar.lamina_max_quat;
                    string lamina_resul_quat = string.Empty;
                    string lamina_cinco = salvar.lamina_cinco;
                    float lamina_comp_treze = salvar.lamina_comp_treze;
                    float lamina_esp_cinco = salvar.lamina_esp_cinco;
                    float lamina_comp_quatorze = salvar.lamina_comp_quatorze;
                    float lamina_comp_quinze = salvar.lamina_comp_quinze;

                    if (lamina_media_quat >= lamina_min_quat && lamina_media_quat <= lamina_max_quat)
                    {
                        lamina_resul_quat = "C";
                    }
                    else
                    {
                        lamina_resul_quat = "NC";
                    }

                    float lamina_media_cinco = ((lamina_comp_treze + lamina_comp_quatorze + lamina_comp_quinze) / 3);
                    string lamina_tipo_cinco = salvar.lamina_tipo_cinco;
                    float lamina_min_cinco = salvar.lamina_min_cinco;
                    float lamina_max_cinco = salvar.lamina_max_cinco;
                    string lamina_resul_cinco = string.Empty;

                    if (lamina_media_cinco >= lamina_min_cinco && lamina_media_cinco <= lamina_max_cinco)
                    {
                        lamina_resul_cinco = "C";
                    }
                    else
                    {
                        lamina_resul_cinco = "NC";
                    }


                    string esp_tipo_um = salvar.esp_tipo_um;
                    float esp_lamina_um = salvar.esp_lamina_um;
                    float esp_especificado_um = salvar.esp_especificado_um;
                    float esp_mm_um = salvar.esp_mm_um;
                    float esp_cm_um = esp_mm_um / 10;

                    string esp_tipo_dois = salvar.esp_tipo_dois;

                    float esp_lamina_dois = salvar.esp_lamina_dois;
                    float esp_especificado_dois = salvar.esp_especificado_dois;
                    float esp_mm_dois = salvar.esp_mm_dois;
                    float esp_cm_dois = esp_mm_dois / 10;

                    string col_tipo_um = salvar.col_tipo_um;
                    float col_especificado_um = salvar.col_especificado_um;
                    float col_encontrado_um = salvar.col_encontrado_um;
                    string col_resul_um = salvar.col_resul_um;


                    string col_tipo_dois = salvar.col_tipo_dois;
                    float col_lamina_dois = salvar.col_lamina_dois;
                    float col_especificado_dois = salvar.col_especificado_dois;
                    float col_resul_dois = salvar.col_resul_dois;

                    string reves_tipo_um = salvar.reves_tipo_um;
                    float reves_lamina_um = salvar.reves_lamina_um;
                    float reves_especificado_um = salvar.reves_especificado_um;
                    float reves_mm_um = salvar.reves_mm_um;

                    float reves_cm_um = reves_mm_um / 10;

                    string reves_tipo_dois = salvar.reves_tipo_dois;

                    float reves_lamina_dois = salvar.reves_lamina_dois;
                    float reves_especificado_dois = salvar.reves_especificado_dois;
                    float reves_mm_dois = salvar.reves_mm_dois;

                    float reves_cm_dois = reves_mm_dois / 10;

                    //salvando os valores
                    var salvarEspuma = new ColetaModel.EspumaUm
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ini = temp_ini,
                        temp_fim = temp_fim,
                        dimensao_temp = dimensao_temp,
                        comprimento_um = comprimento_um,
                        comprimento_dois = comprimento_um,
                        comprimento_tres = comprimento_tres,
                        comprimento_esp = comprimento_esp,
                        comprimento_media = comprimento_media,
                        comprimento_result = comprimento_result,
                        largura_um = largura_um,
                        largura_dois = largura_dois,
                        largura_tres = largura_tres,
                        largura_esp = largura_esp,
                        largura_media = largura_media,
                        largura_result = largura_result,
                        altura_um = altura_um,
                        altura_dois = altura_dois,
                        altura_tres = altura_tres,
                        altura_esp = altura_esp,
                        altura_media = altura_media,
                        altura_result = altura_result,
                        temp_repouso = temp_repouso,
                        //lamina_tempo = lamina_tempo,
                        lamina_um = lamina_um,
                        lamina_comp_um = lamina_comp_um,
                        lamina_comp_dois = lamina_comp_dois,
                        lamina_comp_tres = lamina_comp_tres,
                        lamina_esp_um = lamina_esp_um,
                        lamina_media_um = lamina_media_um,
                        lamina_tipo_um = lamina_tipo_um,
                        lamina_min_um = lamina_min_um,
                        lamina_max_um = lamina_max_um,
                        lamina_resul_um = lamina_resul_um,
                        lamina_dois = lamina_dois,
                        lamina_comp_quat = lamina_comp_quat,
                        lamina_comp_cinco = lamina_comp_cinco,
                        lamina_comp_seis = lamina_comp_seis,
                        lamina_esp_dois = lamina_esp_dois,
                        lamina_media_dois = lamina_media_dois,
                        lamina_tipo_dois = lamina_tipo_dois,
                        lamina_min_dois = lamina_min_dois,
                        lamina_max_dois = lamina_max_dois,
                        lamina_resul_dois = lamina_resul_dois,
                        lamina_tres = lamina_tres,
                        lamina_comp_sete = lamina_comp_sete,
                        lamina_comp_oito = lamina_comp_oito,
                        lamina_comp_nove = lamina_comp_nove,
                        lamina_esp_tres = lamina_esp_tres,
                        lamina_media_tres = lamina_media_tres,
                        lamina_tipo_tres = lamina_tipo_tres,
                        lamina_min_tres = lamina_min_tres,
                        lamina_max_tres = lamina_max_tres,
                        lamina_resul_tres = lamina_resul_tres,
                        lamina_quat = lamina_quat,
                        lamina_comp_dez = lamina_comp_dez,
                        lamina_comp_onze = lamina_comp_onze,
                        lamina_comp_doze = lamina_comp_doze,
                        lamina_esp_quat = lamina_esp_quat,
                        lamina_media_quat = lamina_media_quat,
                        lamina_tipo_quat = lamina_tipo_quat,
                        lamina_min_quat = lamina_min_quat,
                        lamina_max_quat = lamina_max_quat,
                        lamina_resul_quat = lamina_resul_quat,
                        lamina_cinco = lamina_cinco,
                        lamina_comp_treze = lamina_comp_treze,
                        lamina_comp_quatorze = lamina_comp_quatorze,
                        lamina_comp_quinze = lamina_comp_quinze,
                        lamina_esp_cinco = lamina_esp_cinco,
                        lamina_media_cinco = lamina_media_cinco,
                        lamina_tipo_cinco = lamina_tipo_cinco,
                        lamina_min_cinco = lamina_min_cinco,
                        lamina_max_cinco = lamina_max_cinco,
                        lamina_resul_cinco = lamina_resul_cinco,
                        esp_tipo_um = esp_tipo_um,
                        esp_lamina_um = esp_lamina_um,
                        esp_especificado_um = esp_especificado_um,
                        esp_mm_um = esp_mm_um,
                        esp_cm_um = esp_cm_um,
                        esp_tipo_dois = esp_tipo_dois,
                        esp_lamina_dois = esp_lamina_dois,
                        esp_especificado_dois = esp_especificado_dois,
                        esp_mm_dois = esp_mm_dois,
                        esp_cm_dois = esp_cm_dois,
                        col_tipo_um = col_tipo_um,
                        col_especificado_um = col_especificado_um,
                        col_encontrado_um = col_encontrado_um,
                        col_resul_um = col_resul_um,
                        col_tipo_dois = col_tipo_dois,
                        col_lamina_dois = col_lamina_dois,
                        col_especificado_dois = col_especificado_dois,
                        col_resul_dois = col_resul_dois,
                        reves_tipo_um = reves_tipo_um,
                        reves_lamina_um = reves_lamina_um,
                        reves_especificado_um = reves_especificado_um,
                        reves_mm_um = reves_mm_um,
                        reves_cm_um = reves_cm_um,
                        reves_tipo_dois = reves_tipo_dois,
                        reves_lamina_dois = reves_lamina_dois,
                        reves_especificado_dois = reves_especificado_dois,
                        reves_mm_dois = reves_mm_dois,
                        reves_cm_dois = reves_cm_dois,

                    };

                    _context.Add(salvarEspuma);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioEspuma4_1), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores.
                    editarDados.data_ini = salvar.data_ini;
                    editarDados.data_term = salvar.data_term;
                    editarDados.temp_ini = salvar.temp_ini;
                    editarDados.temp_fim = salvar.temp_fim;
                    editarDados.dimensao_temp = salvar.dimensao_temp;
                    editarDados.comprimento_result = salvar.comprimento_result;
                    editarDados.comprimento_um = salvar.comprimento_um;
                    editarDados.comprimento_esp = salvar.comprimento_esp;
                    editarDados.comprimento_dois = salvar.comprimento_dois;
                    editarDados.comprimento_tres = salvar.comprimento_tres;
                    editarDados.temp_repouso = salvar.temp_repouso;

                    editarDados.comprimento_media = ((editarDados.comprimento_um + editarDados.comprimento_dois + editarDados.comprimento_tres) / 3);

                    float valor_min_comprimento = editarDados.comprimento_esp - 1.5f;
                    float valor_max_comprimento = editarDados.comprimento_esp + 1.5f;

                    if (editarDados.comprimento_media >= valor_min_comprimento && editarDados.comprimento_media <= valor_max_comprimento)
                    {
                        editarDados.comprimento_result = "C";
                    }
                    else
                    {
                        editarDados.comprimento_result = "NC";
                    }


                    editarDados.largura_result = salvar.largura_result;
                    editarDados.largura_um = salvar.largura_um;
                    editarDados.largura_esp = salvar.largura_esp;
                    editarDados.largura_dois = salvar.largura_dois;
                    editarDados.largura_tres = salvar.largura_tres;

                    editarDados.largura_media = ((editarDados.largura_um + editarDados.largura_dois + editarDados.largura_tres) / 3);


                    float largura_valor_min_comprimento = editarDados.largura_esp - 1.5f;
                    float largura_valor_max_comprimento = editarDados.largura_esp + 1.5f;

                    if (editarDados.largura_media >= largura_valor_min_comprimento && editarDados.largura_media <= largura_valor_max_comprimento)
                    {
                        editarDados.largura_result = "C";
                    }
                    else
                    {
                        editarDados.largura_result = "NC";
                    }


                    editarDados.altura_result = salvar.altura_result;
                    editarDados.altura_um = salvar.altura_um;
                    editarDados.altura_esp = salvar.altura_esp;
                    editarDados.altura_dois = salvar.altura_dois;
                    editarDados.altura_tres = salvar.altura_tres;

                    editarDados.altura_media = ((editarDados.altura_um + editarDados.altura_dois + editarDados.altura_tres) / 3);

                    float altura_valor_min_comprimento = editarDados.comprimento_esp - 1.5f;
                    float altura_valor_max_comprimento = editarDados.comprimento_esp + 1.5f;

                    if (editarDados.altura_media >= altura_valor_min_comprimento && editarDados.altura_media <= altura_valor_max_comprimento)
                    {
                        editarDados.altura_result = "C";
                    }
                    else
                    {
                        editarDados.altura_result = "NC";
                    }


                    editarDados.lamina_um = salvar.lamina_um;
                    editarDados.lamina_comp_um = salvar.lamina_comp_um;
                    editarDados.lamina_esp_um = salvar.lamina_esp_um;
                    editarDados.lamina_comp_dois = salvar.lamina_comp_dois;
                    editarDados.lamina_comp_tres = salvar.lamina_comp_tres;
                    editarDados.lamina_media_um = ((editarDados.lamina_comp_um + editarDados.lamina_comp_dois + editarDados.lamina_comp_tres) / 3);
                    editarDados.lamina_tipo_um = salvar.lamina_tipo_um;
                    editarDados.lamina_min_um = salvar.lamina_min_um;
                    editarDados.lamina_max_um = salvar.lamina_max_um;

                    if (editarDados.lamina_media_um >= editarDados.lamina_min_um && editarDados.lamina_media_um <= editarDados.lamina_max_um)
                    {
                        editarDados.lamina_resul_um = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_um = "NC";
                    }

                    editarDados.lamina_dois = salvar.lamina_dois;
                    editarDados.lamina_comp_quat = salvar.lamina_comp_quat;
                    editarDados.lamina_esp_dois = salvar.lamina_esp_dois;
                    editarDados.lamina_comp_cinco = salvar.lamina_comp_cinco;
                    editarDados.lamina_comp_seis = salvar.lamina_comp_seis;


                    editarDados.lamina_media_dois = ((editarDados.lamina_comp_quat + editarDados.lamina_comp_cinco + editarDados.lamina_comp_seis) / 3);
                    editarDados.lamina_tipo_dois = salvar.lamina_tipo_dois;
                    editarDados.lamina_min_dois = salvar.lamina_min_dois;
                    editarDados.lamina_max_dois = salvar.lamina_max_dois;
                    if (editarDados.lamina_media_dois >= editarDados.lamina_min_dois && editarDados.lamina_media_dois <= editarDados.lamina_max_dois)
                    {
                        editarDados.lamina_resul_dois = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_dois = "NC";
                    }


                    editarDados.lamina_tres = salvar.lamina_tres;
                    editarDados.lamina_comp_sete = salvar.lamina_comp_sete;
                    editarDados.lamina_esp_tres = salvar.lamina_esp_tres;
                    editarDados.lamina_comp_oito = salvar.lamina_comp_oito;
                    editarDados.lamina_comp_nove = salvar.lamina_comp_nove;
                    editarDados.lamina_media_tres = ((editarDados.lamina_comp_sete + editarDados.lamina_comp_oito + editarDados.lamina_comp_nove) / 3);
                    editarDados.lamina_tipo_tres = salvar.lamina_tipo_tres;
                    editarDados.lamina_min_tres = salvar.lamina_min_tres;
                    editarDados.lamina_max_tres = salvar.lamina_max_tres;
                    if (editarDados.lamina_media_tres >= editarDados.lamina_min_tres && editarDados.lamina_media_tres <= editarDados.lamina_max_tres)
                    {
                        editarDados.lamina_resul_tres = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_tres = "NC";
                    }



                    editarDados.lamina_quat = salvar.lamina_quat;
                    editarDados.lamina_comp_dez = salvar.lamina_comp_dez;
                    editarDados.lamina_esp_quat = salvar.lamina_esp_quat;
                    editarDados.lamina_comp_onze = salvar.lamina_comp_onze;
                    editarDados.lamina_comp_doze = salvar.lamina_comp_doze;
                    editarDados.lamina_media_quat = ((editarDados.lamina_comp_dez + editarDados.lamina_comp_onze + editarDados.lamina_comp_doze) / 3);
                    editarDados.lamina_tipo_quat = salvar.lamina_tipo_quat;
                    editarDados.lamina_min_quat = salvar.lamina_min_quat;
                    editarDados.lamina_max_quat = salvar.lamina_max_quat;

                    if (editarDados.lamina_media_quat >= editarDados.lamina_min_quat && editarDados.lamina_media_quat <= editarDados.lamina_max_quat)
                    {
                        editarDados.lamina_resul_quat = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_quat = "NC";
                    }


                    editarDados.lamina_cinco = salvar.lamina_cinco;
                    editarDados.lamina_comp_treze = salvar.lamina_comp_treze;
                    editarDados.lamina_esp_cinco = salvar.lamina_esp_cinco;
                    editarDados.lamina_comp_quatorze = salvar.lamina_comp_quatorze;
                    editarDados.lamina_comp_quinze = salvar.lamina_comp_quinze;
                    editarDados.lamina_media_cinco = ((editarDados.lamina_comp_treze + editarDados.lamina_comp_quatorze + editarDados.lamina_comp_quinze) / 3);
                    editarDados.lamina_tipo_cinco = salvar.lamina_tipo_cinco;
                    editarDados.lamina_min_cinco = salvar.lamina_min_cinco;
                    editarDados.lamina_max_cinco = salvar.lamina_max_cinco;
                    if (editarDados.lamina_media_um >= editarDados.lamina_min_cinco && editarDados.lamina_media_cinco <= editarDados.lamina_max_cinco)
                    {
                        editarDados.lamina_resul_cinco = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_cinco = "NC";
                    }



                    editarDados.esp_tipo_um = salvar.esp_tipo_um;
                    editarDados.esp_lamina_um = salvar.esp_lamina_um;
                    editarDados.esp_especificado_um = salvar.esp_especificado_um;
                    editarDados.esp_mm_um = salvar.esp_mm_um;

                    editarDados.esp_cm_um = (editarDados.esp_mm_um / 10);
                    editarDados.esp_tipo_dois = salvar.esp_tipo_dois;
                    editarDados.esp_lamina_dois = salvar.esp_lamina_dois;
                    editarDados.esp_especificado_dois = salvar.esp_especificado_dois;
                    editarDados.esp_mm_dois = salvar.esp_mm_dois;
                    editarDados.esp_cm_dois = (editarDados.esp_mm_dois / 10);
                    editarDados.col_tipo_um = salvar.col_tipo_um;
                    editarDados.col_especificado_um = salvar.col_especificado_um;
                    editarDados.col_encontrado_um = salvar.col_encontrado_um;
                    editarDados.col_resul_um = salvar.col_resul_um;
                    editarDados.col_tipo_dois = salvar.col_tipo_dois;
                    editarDados.col_lamina_dois = salvar.col_lamina_dois;
                    editarDados.col_especificado_dois = salvar.col_especificado_dois;
                    editarDados.col_resul_dois = salvar.col_resul_dois;
                    editarDados.reves_tipo_um = salvar.reves_tipo_um;
                    editarDados.reves_lamina_um = salvar.reves_lamina_um;
                    editarDados.reves_especificado_um = salvar.reves_especificado_um;
                    editarDados.reves_mm_um = salvar.reves_mm_um;

                    editarDados.reves_cm_um = (editarDados.reves_mm_um / 10);

                    editarDados.reves_tipo_dois = salvar.reves_tipo_dois;
                    editarDados.reves_lamina_dois = salvar.reves_lamina_dois;
                    editarDados.reves_especificado_dois = salvar.reves_especificado_dois;
                    editarDados.reves_mm_dois = salvar.reves_mm_dois;

                    editarDados.reves_cm_dois = (editarDados.reves_mm_dois / 10);

                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioEspuma4_1), "Coleta", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_8(string os, string orcamento, [Bind("tipo_material,data_ini,data_term,copos_prov_1,copos_prov_2,copos_prov_3,copos_prov_4,copos_prov_5,copos_prov_6,copos_prov_7,copos_prov_8,copos_prov_9,copos_prov_10,area_corpo_1,area_corpo_2,dim_corpo_1,dim_corpo_2,trincas,rompimentos")] ColetaModel.Ensaio7_8 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_8.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (editarDados == null)
                {
                    //recebendo os valores do html..
                    string tipo_material = salvarDados.tipo_material;
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float copos_prov_1 = salvarDados.copos_prov_1;
                    float copos_prov_2 = salvarDados.copos_prov_2;
                    float copos_prov_3 = salvarDados.copos_prov_3;
                    float copos_prov_4 = salvarDados.copos_prov_4;
                    float copos_prov_5 = salvarDados.copos_prov_5;
                    float copos_prov_6 = salvarDados.copos_prov_6;
                    float copos_prov_7 = salvarDados.copos_prov_7;
                    float copos_prov_8 = salvarDados.copos_prov_8;
                    float copos_prov_9 = salvarDados.copos_prov_9;
                    float copos_prov_10 = salvarDados.copos_prov_10;
                    int area_corpo_1 = salvarDados.area_corpo_1;
                    int area_corpo_2 = salvarDados.area_corpo_2;
                    float dim_corpo_1 = salvarDados.dim_corpo_1;
                    float dim_corpo_2 = salvarDados.dim_corpo_2;
                    string trincas = salvarDados.trincas;
                    string rompimentos = salvarDados.rompimentos;
                    string conforme_gramas = string.Empty;
                    string conforme = string.Empty;

                    //realizando calculos.
                    float media_copos = (copos_prov_1 + copos_prov_2 + copos_prov_3 + copos_prov_4 + copos_prov_5 + copos_prov_6 + copos_prov_7 + copos_prov_8 + copos_prov_9 + copos_prov_10) / 10;
                    string conv_media_copos = media_copos.ToString("N4");
                    media_copos = float.Parse(conv_media_copos);

                    float gramatura = (media_copos / (area_corpo_1 * area_corpo_2 / 100) * 10000);

                    //verificando conformidade dos ensaios.
                    if (media_copos >= 100.0f)
                    {
                        conforme_gramas = "C";
                    }
                    else
                    {
                        conforme_gramas = "NC";
                    }

                    if (trincas == "Não" && rompimentos == "Não")
                    {
                        conforme = "C";
                    }
                    else
                    {
                        conforme = "NC";
                    }

                    var registro = new ColetaModel.Ensaio7_8
                    {
                        os = os,
                        orcamento = orcamento,
                        tipo_material = tipo_material,
                        data_ini = data_ini,
                        data_term = data_term,
                        copos_prov_1 = copos_prov_1,
                        copos_prov_2 = copos_prov_2,
                        copos_prov_3 = copos_prov_3,
                        copos_prov_4 = copos_prov_4,
                        copos_prov_5 = copos_prov_5,
                        copos_prov_6 = copos_prov_6,
                        copos_prov_7 = copos_prov_7,
                        copos_prov_8 = copos_prov_8,
                        copos_prov_9 = copos_prov_9,
                        copos_prov_10 = copos_prov_10,
                        copos_media = media_copos,
                        area_corpo_1 = area_corpo_1,
                        area_corpo_2 = area_corpo_2,
                        gramatura = gramatura,
                        dim_corpo_1 = dim_corpo_1,
                        dim_corpo_2 = dim_corpo_2,
                        trincas = trincas,
                        rompimentos = rompimentos,
                        conforme_gramas = conforme_gramas,
                        conforme = conforme,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_8), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores do html..
                    editarDados.tipo_material = salvarDados.tipo_material;
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.copos_prov_1 = salvarDados.copos_prov_1;
                    editarDados.copos_prov_2 = salvarDados.copos_prov_2;
                    editarDados.copos_prov_3 = salvarDados.copos_prov_3;
                    editarDados.copos_prov_4 = salvarDados.copos_prov_4;
                    editarDados.copos_prov_5 = salvarDados.copos_prov_5;
                    editarDados.copos_prov_6 = salvarDados.copos_prov_6;
                    editarDados.copos_prov_7 = salvarDados.copos_prov_7;
                    editarDados.copos_prov_8 = salvarDados.copos_prov_8;
                    editarDados.copos_prov_9 = salvarDados.copos_prov_9;
                    editarDados.copos_prov_10 = salvarDados.copos_prov_10;
                    editarDados.area_corpo_1 = salvarDados.area_corpo_1;
                    editarDados.area_corpo_2 = salvarDados.area_corpo_2;
                    editarDados.dim_corpo_1 = salvarDados.dim_corpo_1;
                    editarDados.dim_corpo_2 = salvarDados.dim_corpo_2;
                    editarDados.trincas = salvarDados.trincas;
                    editarDados.rompimentos = salvarDados.rompimentos;
                    string conforme_gramas = string.Empty;
                    string conforme = string.Empty;

                    //realizando contas.
                    float media_copos = (editarDados.copos_prov_1 + editarDados.copos_prov_2 + editarDados.copos_prov_3 + editarDados.copos_prov_4 + editarDados.copos_prov_5 + editarDados.copos_prov_6 + editarDados.copos_prov_7 + editarDados.copos_prov_8 + editarDados.copos_prov_9 + editarDados.copos_prov_10) / 10;
                    string conv_media_copos = media_copos.ToString("N4");
                    media_copos = float.Parse(conv_media_copos);

                    float gramatura = (media_copos / (editarDados.area_corpo_1 * editarDados.area_corpo_2 / 100) * 10000);

                    //verificando conformidade dos ensaios.
                    if (media_copos >= 100.0f)
                    {
                        editarDados.conforme_gramas = "C";
                    }
                    else
                    {
                        editarDados.conforme_gramas = "NC";
                    }

                    if (editarDados.trincas == "Não" && editarDados.rompimentos == "Não")
                    {
                        editarDados.conforme = "C";
                    }
                    else
                    {
                        editarDados.conforme = "NC";
                    }

                    //editando os valores das contas, caso precise.
                    editarDados.copos_media = media_copos;
                    editarDados.gramatura = gramatura;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_8), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_6(string os, string orcamento, [Bind("data_ini,data_term,faces,alterar_queda,rep_1,rep_2,rep_3,alt_queda_det,rep_det_1,rep_det_2,rep_det_3,temp_ens_rolagem")] ColetaModel.Ensaio7_6 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_6.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo valores do html.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    string faces = salvarDados.faces;
                    float alterar_queda = salvarDados.alterar_queda;
                    float rep_1 = salvarDados.rep_1;
                    float rep_2 = salvarDados.rep_2;
                    float rep_3 = salvarDados.rep_3;
                    float alt_queda_det = salvarDados.alt_queda_det;
                    float rep_det_1 = salvarDados.rep_det_1;
                    float rep_det_2 = salvarDados.rep_det_2;
                    float rep_det_3 = salvarDados.rep_det_3;
                    int temp_ens_rolagem = salvarDados.temp_ens_rolagem;
                    string conforme = string.Empty;

                    //realizando calculos necessarios.
                    float media_3 = (rep_1 + rep_2 + rep_3) / 3;
                    float media_det = (rep_det_1 + rep_det_2 + rep_det_3) / 3;

                    //calculando porcentual e passando para possitivo.
                    float perda_porcentual = ((((media_det - media_3) / media_3) * 100) * -1);
                    string conv_perda_porcentual = perda_porcentual.ToString("N2");
                    perda_porcentual = float.Parse(conv_perda_porcentual);

                    //verificando se esta conforme ou nao conforme
                    if (perda_porcentual >= 25)
                    {
                        conforme = "NC";
                    }
                    else
                    {
                        conforme = "C";
                    }

                    var registro = new ColetaModel.Ensaio7_6
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        faces = faces,
                        alterar_queda = alterar_queda,
                        rep_1 = rep_1,
                        rep_2 = rep_2,
                        rep_3 = rep_3,
                        media_rep = media_3,
                        alt_queda_det = alt_queda_det,
                        rep_det_1 = rep_det_1,
                        rep_det_2 = rep_det_2,
                        rep_det_3 = rep_det_3,
                        media_det = media_det,
                        temp_ens_rolagem = temp_ens_rolagem,
                        perda_porc = perda_porcentual,
                        conforme = conforme
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_6), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores que esta no html.
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.faces = salvarDados.faces;
                    editarDados.alterar_queda = salvarDados.alterar_queda;
                    editarDados.rep_1 = salvarDados.rep_1;
                    editarDados.rep_2 = salvarDados.rep_2;
                    editarDados.rep_3 = salvarDados.rep_3;
                    editarDados.alt_queda_det = salvarDados.alt_queda_det;
                    editarDados.rep_det_1 = salvarDados.rep_det_1;
                    editarDados.rep_det_2 = salvarDados.rep_det_2;
                    editarDados.rep_det_3 = salvarDados.rep_det_3;
                    editarDados.temp_ens_rolagem = salvarDados.temp_ens_rolagem;

                    float media_3 = (editarDados.rep_1 + editarDados.rep_2 + editarDados.rep_3) / 3;
                    float media_det = (editarDados.rep_det_1 + editarDados.rep_det_2 + editarDados.rep_det_3) / 3;

                    //calculando porcentual e passando para possitivo.
                    float perda_porcentual = ((((media_det - media_3) / media_3) * 100) * -1);
                    string conv_perda_porcentual = perda_porcentual.ToString("N2");
                    perda_porcentual = float.Parse(conv_perda_porcentual);
                    //realizando calculos necessarios.

                    //verificando se esta conforme ou nao conforme
                    if (perda_porcentual >= 25)
                    {
                        editarDados.conforme = "NC";
                    }
                    else
                    {
                        editarDados.conforme = "C";
                    }

                    editarDados.media_rep = media_3;
                    editarDados.media_det = media_det;
                    editarDados.perda_porc = perda_porcentual;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Edita Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_6), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_7(string os, string orcamento, [Bind("data_ini,data_term,rasgo,quebra,contem_bonell,contem_mola,contem_lkf,contem_vericoil,contem_fio_continuo_1,contem_fio_continuo_2,contem_offset,minim_bitola_1,minim_bitola_2,mini_molas_1,mini_molas_2,mini_molas_3,mini_molas_4,mini_molas_5,mini_molas_6,mini_molas_7,mini_molas_8,calc_molas_1,calc_molas_2,calc_molas_3,calc_molas_duplicado,calc_molas_duplicado_2,calc_molas_duplicado_3")] ColetaModel.Ensaio7_7 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_7.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo os valores de html.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    string rasgo = salvarDados.rasgo;
                    string quebra = salvarDados.quebra;
                    string contem_bonell = salvarDados.contem_bonell;
                    string contem_mola = salvarDados.contem_mola;
                    string contem_lkf = salvarDados.contem_lkf;
                    string contem_vericoil = salvarDados.contem_vericoil;
                    string contem_fio_continuo_1 = salvarDados.contem_fio_continuo_1;
                    string contem_fio_continuo_2 = salvarDados.contem_fio_continuo_2;
                    string contem_offset = salvarDados.contem_offset;
                    //string contem_tipo_8 = salvarDados.contem_tipo_8;
                    string minim_bitola_1 = salvarDados.minim_bitola_1;
                    string minim_bitola_2 = salvarDados.minim_bitola_2;
                    float mini_molas_1 = salvarDados.mini_molas_1;
                    float mini_molas_2 = salvarDados.mini_molas_2;
                    float mini_molas_3 = salvarDados.mini_molas_3;
                    float mini_molas_4 = salvarDados.mini_molas_4;
                    float mini_molas_5 = salvarDados.mini_molas_5;
                    float mini_molas_6 = salvarDados.mini_molas_6;
                    float mini_molas_7 = salvarDados.mini_molas_7;
                    float mini_molas_8 = salvarDados.mini_molas_8;
                    float calc_molas_1 = salvarDados.calc_molas_1;
                    float calc_molas_2 = salvarDados.calc_molas_2;
                    float calc_molas_3 = salvarDados.calc_molas_3;
                    float calc_molas_duplicado = (float)salvarDados.calc_molas_duplicado;
                    float calc_molas_duplicado_2 = (float)salvarDados.calc_molas_duplicado_2;
                    float calc_molas_duplicado_3 = (float)salvarDados.calc_molas_duplicado_3;
                    float resultado_calculo_duplicado = 0f;

                    //calculando resultado necassario.
                    float resultado_calc = (calc_molas_1 / (calc_molas_2 * calc_molas_3) * 10000);
                    string conv_resultado_calc = resultado_calc.ToString("N2");
                    resultado_calc = float.Parse(conv_resultado_calc);

                    if (calc_molas_duplicado != 0 && calc_molas_duplicado_2 != 0 && calc_molas_duplicado_2 != 0)
                    {
                        resultado_calculo_duplicado = (calc_molas_duplicado / (calc_molas_duplicado_2 * calc_molas_duplicado_3) * 10000);
                        string conv_resultado_calculo_duplicado = resultado_calculo_duplicado.ToString("N2");
                        resultado_calculo_duplicado = float.Parse(conv_resultado_calculo_duplicado);
                    }


                    var registro = new ColetaModel.Ensaio7_7
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        rasgo = rasgo,
                        quebra = quebra,
                        contem_bonell = contem_bonell,
                        contem_mola = contem_mola,
                        contem_lkf = contem_lkf,
                        contem_vericoil = contem_vericoil,
                        contem_fio_continuo_1 = contem_fio_continuo_1,
                        contem_fio_continuo_2 = contem_fio_continuo_2,
                        contem_offset = contem_offset,
                        //contem_tipo_8 = contem_tipo_8,
                        minim_bitola_1 = minim_bitola_1,
                        minim_bitola_2 = minim_bitola_2,
                        mini_molas_1 = mini_molas_1,
                        mini_molas_2 = mini_molas_2,
                        mini_molas_3 = mini_molas_3,
                        mini_molas_4 = mini_molas_4,
                        mini_molas_5 = mini_molas_5,
                        mini_molas_6 = mini_molas_6,
                        mini_molas_7 = mini_molas_7,
                        mini_molas_8 = mini_molas_8,
                        calc_molas_1 = calc_molas_1,
                        calc_molas_2 = calc_molas_2,
                        calc_molas_3 = calc_molas_3,
                        resultado_calc = resultado_calc,
                        calc_molas_duplicado = calc_molas_duplicado,
                        calc_molas_duplicado_2 = calc_molas_duplicado_2,
                        calc_molas_duplicado_3 = calc_molas_duplicado_3,
                        resultado_calc_duplicado = resultado_calculo_duplicado,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_7), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores recebido do html..
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.rasgo = salvarDados.rasgo;
                    editarDados.quebra = salvarDados.quebra;
                    editarDados.contem_bonell = salvarDados.contem_bonell;
                    editarDados.contem_mola = salvarDados.contem_mola;
                    editarDados.contem_lkf = salvarDados.contem_lkf;
                    editarDados.contem_vericoil = salvarDados.contem_vericoil;
                    editarDados.contem_fio_continuo_1 = salvarDados.contem_fio_continuo_1;
                    editarDados.contem_fio_continuo_2 = salvarDados.contem_fio_continuo_2;
                    editarDados.contem_offset = salvarDados.contem_offset;
                    editarDados.minim_bitola_1 = salvarDados.minim_bitola_1;
                    editarDados.minim_bitola_2 = salvarDados.minim_bitola_2;
                    editarDados.mini_molas_1 = salvarDados.mini_molas_1;
                    editarDados.mini_molas_2 = salvarDados.mini_molas_2;
                    editarDados.mini_molas_3 = salvarDados.mini_molas_3;
                    editarDados.mini_molas_4 = salvarDados.mini_molas_4;
                    editarDados.mini_molas_5 = salvarDados.mini_molas_5;
                    editarDados.mini_molas_6 = salvarDados.mini_molas_6;
                    editarDados.mini_molas_7 = salvarDados.mini_molas_7;
                    editarDados.mini_molas_8 = salvarDados.mini_molas_8;
                    editarDados.calc_molas_1 = salvarDados.calc_molas_1;
                    editarDados.calc_molas_2 = salvarDados.calc_molas_2;
                    editarDados.calc_molas_3 = salvarDados.calc_molas_3;
                    editarDados.calc_molas_duplicado = salvarDados.calc_molas_duplicado;
                    editarDados.calc_molas_duplicado_2 = salvarDados.calc_molas_duplicado_2;
                    editarDados.calc_molas_duplicado_3 = salvarDados.calc_molas_duplicado_3;


                    //calculando resultado necassario.
                    editarDados.resultado_calc = (editarDados.calc_molas_1 / (editarDados.calc_molas_2 * editarDados.calc_molas_3) * 10000);
                    string conv_resultado_calc = editarDados.resultado_calc.ToString("N2");
                    editarDados.resultado_calc = float.Parse(conv_resultado_calc);

                    if (editarDados.calc_molas_duplicado != 0 && editarDados.calc_molas_duplicado_2 != 0 && editarDados.calc_molas_duplicado_3 != 0)
                    {
                        editarDados.resultado_calc_duplicado = (editarDados.calc_molas_duplicado / (editarDados.calc_molas_duplicado_2 * editarDados.calc_molas_duplicado_3) * 10000);
                        string conv_resultado_calculo_duplicado = editarDados.resultado_calc_duplicado.ToString("N2");
                        editarDados.resultado_calc_duplicado = float.Parse(conv_resultado_calculo_duplicado);
                    }

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_7), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEnsaio7_3(string os, string orcamento, [Bind("data_ini,data_term,bordas,faces_utilizadas,rasgo,quebra")] ColetaModel.Ensaio7_3 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo os valores recebidos do html..
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float bordas = salvarDados.bordas;
                    string faces_utilizadas = salvarDados.faces_utilizadas;
                    string rasgo = salvarDados.rasgo;
                    string quebra = salvarDados.quebra;
                    string conforme = string.Empty;

                    //verificando a conformidade.
                    if (rasgo == "Não" || quebra == "Não")
                    {
                        conforme = "C";
                    }
                    else
                    {
                        conforme = "NC";
                    }

                    var registro = new ColetaModel.Ensaio7_3
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        bordas = bordas,
                        faces_utilizadas = faces_utilizadas,
                        rasgo = rasgo,
                        quebra = quebra,
                        conforme = conforme,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_3), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores recebidos do html
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.bordas = salvarDados.bordas;
                    editarDados.faces_utilizadas = salvarDados.faces_utilizadas;
                    editarDados.rasgo = salvarDados.rasgo;
                    editarDados.quebra = salvarDados.quebra;

                    //verificando a conformidade.
                    if (editarDados.rasgo == "Não" || editarDados.quebra == "Não")
                    {
                        editarDados.conforme = "C";
                    }
                    else
                    {
                        editarDados.conforme = "NC";
                    }

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioMolas7_3), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }



        [HttpPost]
        public async Task<IActionResult> SalvarEspuma4_3(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_fim,lamina_central,quant_colagens,colagens_densidade,espessura_nominal,espessura_central,porcentagem_enc,lamina_menor_esp,quant_colagens_dois," +
            "distancia_um,distancia_dois,colagens_comp,espuma,esp_lamina_um,esp_lamina_dois,esp_lamina_tres,esp_lamina_quat,esp_lamina_cinco,esp_lamina_seis,esp_lamina_sete,esp_lamina_oito,quant_colagens_tres,distancia_tres,distancia_quat,colchao_casal,colagem_comp,espuma_conv,espuma_densidade," +
            "colagem_largura,quant_colagens_quat,localidade,quant_colagens_cinco,espessura_lamina,adesivo,cascas_superiores,cascas_inferiores,observacoes,executador_um,executador_dois,executador_tres,executador_quat")] ColetaModel.Espuma4_3 salvar)
        {
            try
            {
                var editarDados = _context.ensaio_espuma4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {

                    //recebendo os valores recebidos do html..
                    DateOnly data_ini = salvar.data_ini;
                    DateOnly data_term = salvar.data_term;
                    var temp_ini = salvar.temp_ini;
                    var temp_fim = salvar.temp_fim;
                    var lamina_central = salvar.lamina_central;
                    var quant_colagens = salvar.quant_colagens;
                    var colagens_densidade = salvar.colagens_densidade;
                    var espessura_nominal = salvar.espessura_nominal;
                    var espessura_central = salvar.espessura_central;
                    var porcentagem_enc = salvar.porcentagem_enc;
                    var lamina_menor_esp = salvar.lamina_menor_esp;
                    var quant_colagens_dois = salvar.quant_colagens_dois;
                    var distancia_um = salvar.distancia_um;
                    var distancia_dois = salvar.distancia_dois;
                    var colagens_comp = salvar.colagens_comp;
                    var espuma = salvar.espuma;
                    var esp_lamina_um = salvar.esp_lamina_um;
                    var esp_lamina_dois = salvar.esp_lamina_dois;
                    var esp_lamina_tres = salvar.esp_lamina_tres;
                    var esp_lamina_quat = salvar.esp_lamina_quat;
                    var esp_lamina_cinco = salvar.esp_lamina_cinco;
                    var esp_lamina_seis = salvar.esp_lamina_seis;
                    var esp_lamina_sete = salvar.esp_lamina_sete;
                    var esp_lamina_oito = salvar.esp_lamina_oito;
                    var quant_colagens_tres = salvar.quant_colagens_tres;
                    var distancia_tres = salvar.distancia_tres;
                    var distancia_quat = salvar.distancia_quat;
                    var colchao_casal = salvar.colchao_casal;
                    var colagem_comp = salvar.colagem_comp;
                    var espuma_conv = salvar.espuma_conv;
                    var espuma_densidade = salvar.espuma_densidade;
                    var colagem_largura = salvar.colagem_largura;
                    var quant_colagens_quat = salvar.quant_colagens_quat;
                    var localidade = salvar.localidade;
                    var quant_colagens_cinco = salvar.quant_colagens_cinco;
                    var espessura_lamina = salvar.espessura_lamina;
                    var adesivo = salvar.adesivo;
                    var cascas_superiores = salvar.cascas_superiores;
                    var cascas_inferiores = salvar.cascas_inferiores;
                    var observacoes = salvar.observacoes;
                    var executador_um = salvar.executador_um;
                    var executador_dois = salvar.executador_dois;
                    var executador_tres = salvar.executador_tres;
                    var executador_quat = salvar.executador_quat;

                    var salvardados = new ColetaModel.Espuma4_3
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ini = temp_ini,
                        temp_fim = temp_fim,
                        lamina_central = lamina_central,
                        quant_colagens = quant_colagens,
                        colagens_densidade = colagens_densidade,
                        espessura_nominal = espessura_nominal,
                        espessura_central = espessura_central,
                        porcentagem_enc = porcentagem_enc,
                        lamina_menor_esp = lamina_menor_esp,
                        quant_colagens_dois = quant_colagens_dois,
                        distancia_um = distancia_um,
                        distancia_dois = distancia_dois,
                        colagens_comp = colagens_comp,
                        espuma = espuma,
                        esp_lamina_um = esp_lamina_um,
                        esp_lamina_dois = esp_lamina_dois,
                        esp_lamina_tres = esp_lamina_tres,
                        esp_lamina_quat = esp_lamina_quat,
                        esp_lamina_cinco = esp_lamina_cinco,
                        esp_lamina_seis = esp_lamina_seis,
                        esp_lamina_sete = esp_lamina_sete,
                        esp_lamina_oito = esp_lamina_oito,
                        quant_colagens_tres = quant_colagens_tres,
                        distancia_tres = distancia_tres,
                        distancia_quat = distancia_quat,
                        colchao_casal = colchao_casal,
                        colagem_comp = colagem_comp,
                        espuma_conv = espuma_conv,
                        espuma_densidade = espuma_densidade,
                        colagem_largura = colagem_largura,
                        quant_colagens_quat = quant_colagens_quat,
                        localidade = localidade,
                        quant_colagens_cinco = quant_colagens_cinco,
                        espessura_lamina = espessura_lamina,
                        adesivo = adesivo,
                        cascas_superiores = cascas_superiores,
                        cascas_inferiores = cascas_inferiores,
                        observacoes = observacoes,
                        executador_um = executador_um,
                        executador_dois = executador_dois,
                        executador_tres = executador_tres,
                        executador_quat = executador_quat,

                    };
                    _context.Add(salvardados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(EnsaioEspuma4_3), "Coleta", new { os, orcamento });
                }
                else
                {
                    editarDados.data_ini = salvar.data_ini;
                    editarDados.data_term = salvar.data_term;
                    editarDados.temp_ini = salvar.temp_ini;
                    editarDados.temp_fim = salvar.temp_fim;
                    editarDados.lamina_central = salvar.lamina_central;
                    editarDados.quant_colagens = salvar.quant_colagens;
                    editarDados.colagens_densidade = salvar.colagens_densidade;
                    editarDados.espessura_nominal = salvar.espessura_nominal;
                    editarDados.espessura_central = salvar.espessura_central;
                    editarDados.porcentagem_enc = salvar.porcentagem_enc;
                    editarDados.lamina_menor_esp = salvar.lamina_menor_esp;
                    editarDados.quant_colagens_dois = salvar.quant_colagens_dois;
                    editarDados.distancia_um = salvar.distancia_um;
                    editarDados.distancia_dois = salvar.distancia_dois;
                    editarDados.colagens_comp = salvar.colagens_comp;
                    editarDados.espuma = salvar.espuma;
                    editarDados.esp_lamina_um = salvar.esp_lamina_um;
                    editarDados.esp_lamina_dois = salvar.esp_lamina_dois;
                    editarDados.esp_lamina_tres = salvar.esp_lamina_tres;
                    editarDados.esp_lamina_quat = salvar.esp_lamina_quat;
                    editarDados.esp_lamina_cinco = salvar.esp_lamina_cinco;
                    editarDados.esp_lamina_seis = salvar.esp_lamina_seis;
                    editarDados.esp_lamina_sete = salvar.esp_lamina_sete;
                    editarDados.esp_lamina_oito = salvar.esp_lamina_oito;
                    editarDados.quant_colagens_tres = salvar.quant_colagens_tres;
                    editarDados.distancia_tres = salvar.distancia_tres;
                    editarDados.distancia_quat = salvar.distancia_quat;
                    editarDados.colchao_casal = salvar.colchao_casal;
                    editarDados.colagem_comp = salvar.colagem_comp;
                    editarDados.espuma_conv = salvar.espuma_conv;
                    editarDados.espuma_densidade = salvar.espuma_densidade;
                    editarDados.colagem_largura = salvar.colagem_largura;
                    editarDados.quant_colagens_quat = salvar.quant_colagens_quat;
                    editarDados.localidade = salvar.localidade;
                    editarDados.quant_colagens_cinco = salvar.quant_colagens_cinco;
                    editarDados.espessura_lamina = salvar.espessura_lamina;
                    editarDados.adesivo = salvar.adesivo;
                    editarDados.cascas_superiores = salvar.cascas_superiores;
                    editarDados.cascas_inferiores = salvar.cascas_inferiores;
                    editarDados.observacoes = salvar.observacoes;
                    editarDados.executador_um = salvar.executador_um;
                    editarDados.executador_dois = salvar.executador_dois;
                    editarDados.executador_tres = salvar.executador_tres;
                    editarDados.executador_quat = salvar.executador_quat;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(EnsaioEspuma4_3), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEmbalagensMolas(string os, string orcamento, [Bind("data_ini,data_term,etiqueta_ident,revest_permanente,etiqueta_duravel_indele,face_superior,visualizacao,lingua_portuguesa,area_etiqueta_1,area_etiqueta_2,cnpj_cpf,marca_modelo,dimensoes_prod,informada_altura,composicoes,tipo_molejo,contem_borda,densidade_espuma,composi_revestimento,data_fabricacao,ident_lote,pais_origem,codigo_barras,cuidado_minimos,aviso_esclarecimento,possui_mais_laminas,contem_advertencia,altura_letra,negrito,caixa_alta,contem_advertencia_mat,altura_letra_mat,negrito_mat,caixa_alta_mat,contem_instru_uso,orientacoes,alerta_consumidor,desenho_esquematico,contem_advertencia_6_2,altura_letra_6_2,negrito6_2,caixa_alta_6_2,embalagem_unitaria,embalagem_garante")] ColetaModel.EnsaioIdentificacaoEmbalagem salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo os valores do html
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    string etiqueta_ident = salvarDados.etiqueta_ident;
                    string revest_permanente = salvarDados.revest_permanente;
                    string etiqueta_duravel_indele = salvarDados.etiqueta_duravel_indele;
                    string face_superior = salvarDados.face_superior;
                    string visualizacao = salvarDados.visualizacao;
                    string lingua_portuguesa = salvarDados.lingua_portuguesa;
                    float area_etiqueta_1 = salvarDados.area_etiqueta_1;
                    float area_etiqueta_2 = salvarDados.area_etiqueta_2;
                    string cnpj_cpf = salvarDados.cnpj_cpf;
                    string marca_modelo = salvarDados.marca_modelo;
                    string dimensoes_prod = salvarDados.dimensoes_prod;
                    string informada_altura = salvarDados.informada_altura;
                    string composicoes = salvarDados.composicoes;
                    string tipo_molejo = salvarDados.tipo_molejo;
                    string contem_borda = salvarDados.contem_borda;
                    string densidade_espuma = salvarDados.densidade_espuma;
                    string composi_revestimento = salvarDados.composi_revestimento;
                    string data_fabricacao = salvarDados.data_fabricacao;
                    string ident_lote = salvarDados.ident_lote;
                    string pais_origem = salvarDados.pais_origem;
                    string codigo_barras = salvarDados.codigo_barras;
                    string cuidado_minimos = salvarDados.cuidado_minimos;
                    string aviso_esclarecimento = salvarDados.aviso_esclarecimento;
                    string possui_mais_laminas = salvarDados.possui_mais_laminas;
                    string contem_advertencia = salvarDados.contem_advertencia;
                    string altura_letra = salvarDados.altura_letra;
                    string negrito = salvarDados.negrito;
                    string caixa_alta = salvarDados.caixa_alta;
                    string contem_advertencia_mat = salvarDados.contem_advertencia_mat;
                    string altura_letra_mat = salvarDados.altura_letra_mat;
                    string negrito_mat = salvarDados.negrito_mat;
                    string caixa_alta_mat = salvarDados.caixa_alta_mat;
                    string contem_instru_uso = salvarDados.contem_instru_uso;
                    string orientacoes = salvarDados.orientacoes;
                    string alerta_consumidor = salvarDados.alerta_consumidor;
                    string desenho_esquematico = salvarDados.desenho_esquematico;
                    string contem_advertencia_6_2 = salvarDados.contem_advertencia_6_2;
                    string altura_letra_6_2 = salvarDados.altura_letra_6_2;
                    string negrito6_2 = salvarDados.negrito6_2;
                    string caixa_alta_6_2 = salvarDados.caixa_alta_6_2;
                    string embalagem_unitaria = salvarDados.embalagem_unitaria;
                    string embalagem_garante = salvarDados.embalagem_garante;
                    string conforme_requisitos = string.Empty;
                    string conforme_requisitos_2 = string.Empty;
                    string conforme_requisitos_3 = string.Empty;
                    string conforme_requisitos_4 = string.Empty;
                    string conforme_6_1 = string.Empty;
                    string conforme_embalagem = string.Empty;

                    // realizando calculo necessario.
                    float calc_media = area_etiqueta_1 * area_etiqueta_2;

                    //VERIFICANDO SE COLETA ESTA CONFORME OU NC DE CADA CAMPO
                    if (etiqueta_ident == "Não" || revest_permanente == "Não" || etiqueta_duravel_indele == "Não" || face_superior == "Não" || visualizacao == "Não" || lingua_portuguesa == "Não")
                    {
                        conforme_requisitos = "NC";
                    }
                    else
                    {
                        conforme_requisitos = "C";
                    }

                    if (cnpj_cpf == "Não" || marca_modelo == "Não" || dimensoes_prod == "Não")
                    {
                        conforme_requisitos_2 = "NC";
                    }
                    else
                    {
                        conforme_requisitos_2 = "C";

                    }

                    if (informada_altura == "Não" || composicoes == "Não" || contem_borda == "Não" || densidade_espuma == "Não" || composi_revestimento == "Não" || data_fabricacao == "Não" || ident_lote == "Não" || pais_origem == "Não" || codigo_barras == "Não" || cuidado_minimos == "Não")
                    {
                        conforme_requisitos_3 = "NC";
                    }
                    else
                    {
                        conforme_requisitos_3 = "C";
                    }

                    if (aviso_esclarecimento == "Não" || possui_mais_laminas == "Não" || contem_advertencia == "Não" || negrito == "Não" || caixa_alta == "Não" || contem_advertencia_mat == "Não" || negrito_mat == "Não")
                    {
                        conforme_requisitos_4 = "NC";
                    }
                    else
                    {
                        conforme_requisitos_4 = "C";
                    }

                    if (contem_instru_uso == "Não" || orientacoes == "Não" || alerta_consumidor == "Não" || desenho_esquematico == "Não" || contem_advertencia_6_2 == "Não" || altura_letra_6_2 == "Não" || negrito6_2 == "Não" || caixa_alta_6_2 == "Não")
                    {
                        conforme_6_1 = "NC";
                    }
                    else
                    {
                        conforme_6_1 = "C";
                    }

                    if (embalagem_garante == "Não" || embalagem_unitaria == "Não")
                    {
                        conforme_embalagem = "NC";
                    }
                    else
                    {
                        conforme_embalagem = "C";
                    }
                    //termino das verificações de conformidade.


                    var registro = new ColetaModel.EnsaioIdentificacaoEmbalagem
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        etiqueta_ident = etiqueta_ident,
                        revest_permanente = revest_permanente,
                        etiqueta_duravel_indele = etiqueta_duravel_indele,
                        face_superior = face_superior,
                        visualizacao = visualizacao,
                        lingua_portuguesa = lingua_portuguesa,
                        area_etiqueta_1 = area_etiqueta_1,
                        area_etiqueta_2 = area_etiqueta_2,
                        area_etiqueta_media = calc_media,
                        cnpj_cpf = cnpj_cpf,
                        marca_modelo = marca_modelo,
                        dimensoes_prod = salvarDados.dimensoes_prod,
                        informada_altura = informada_altura,
                        composicoes = composicoes,
                        tipo_molejo = tipo_molejo,
                        contem_borda = contem_borda,
                        densidade_espuma = densidade_espuma,
                        composi_revestimento = composi_revestimento,
                        data_fabricacao = data_fabricacao,
                        ident_lote = ident_lote,
                        pais_origem = pais_origem,
                        codigo_barras = codigo_barras,
                        cuidado_minimos = cuidado_minimos,
                        aviso_esclarecimento = aviso_esclarecimento,
                        possui_mais_laminas = possui_mais_laminas,
                        contem_advertencia = contem_advertencia,
                        altura_letra = altura_letra,
                        negrito = negrito,
                        caixa_alta = caixa_alta,
                        contem_advertencia_mat = contem_advertencia_mat,
                        altura_letra_mat = altura_letra_mat,
                        negrito_mat = negrito_mat,
                        caixa_alta_mat = caixa_alta_mat,
                        contem_instru_uso = contem_instru_uso,
                        orientacoes = orientacoes,
                        alerta_consumidor = alerta_consumidor,
                        desenho_esquematico = desenho_esquematico,
                        contem_advertencia_6_2 = contem_advertencia_6_2,
                        altura_letra_6_2 = altura_letra_6_2,
                        negrito6_2 = negrito6_2,
                        caixa_alta_6_2 = caixa_alta_6_2,
                        embalagem_unitaria = embalagem_unitaria,
                        embalagem_garante = embalagem_garante,
                        conforme_requisitos = conforme_requisitos,
                        conforme_requisitos_2 = conforme_requisitos_2,
                        conforme_requisitos_3 = conforme_requisitos_3,
                        conforme_requisitos_4 = conforme_requisitos_4,
                        conforme_6_1 = conforme_6_1,
                        conforme_embalagem = conforme_embalagem,
                    };

                    //salvando no banco
                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(IdentificacaoEmbalagemMolas), "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores no html..
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.etiqueta_ident = salvarDados.etiqueta_ident;
                    editarDados.revest_permanente = salvarDados.revest_permanente;
                    editarDados.etiqueta_duravel_indele = salvarDados.etiqueta_duravel_indele;
                    editarDados.face_superior = salvarDados.face_superior;
                    editarDados.visualizacao = salvarDados.visualizacao;
                    editarDados.lingua_portuguesa = salvarDados.lingua_portuguesa;
                    editarDados.area_etiqueta_1 = salvarDados.area_etiqueta_1;
                    editarDados.area_etiqueta_2 = salvarDados.area_etiqueta_2;
                    editarDados.cnpj_cpf = salvarDados.cnpj_cpf;
                    editarDados.marca_modelo = salvarDados.marca_modelo;
                    editarDados.dimensoes_prod = salvarDados.dimensoes_prod;
                    editarDados.informada_altura = salvarDados.informada_altura;
                    editarDados.composicoes = salvarDados.composicoes;
                    editarDados.tipo_molejo = salvarDados.tipo_molejo;
                    editarDados.contem_borda = salvarDados.contem_borda;
                    editarDados.densidade_espuma = salvarDados.densidade_espuma;
                    editarDados.composi_revestimento = salvarDados.composi_revestimento;
                    editarDados.data_fabricacao = salvarDados.data_fabricacao;
                    editarDados.ident_lote = salvarDados.ident_lote;
                    editarDados.pais_origem = salvarDados.pais_origem;
                    editarDados.codigo_barras = salvarDados.codigo_barras;
                    editarDados.cuidado_minimos = salvarDados.cuidado_minimos;
                    editarDados.aviso_esclarecimento = salvarDados.aviso_esclarecimento;
                    editarDados.possui_mais_laminas = salvarDados.possui_mais_laminas;
                    editarDados.contem_advertencia = salvarDados.contem_advertencia;
                    editarDados.altura_letra = salvarDados.altura_letra;
                    editarDados.negrito = salvarDados.negrito;
                    editarDados.caixa_alta = salvarDados.caixa_alta;
                    editarDados.contem_advertencia_mat = salvarDados.contem_advertencia_mat;
                    editarDados.altura_letra_mat = salvarDados.altura_letra_mat;
                    editarDados.negrito_mat = salvarDados.negrito_mat;
                    editarDados.caixa_alta_mat = salvarDados.caixa_alta_mat;
                    editarDados.contem_instru_uso = salvarDados.contem_instru_uso;
                    editarDados.orientacoes = salvarDados.orientacoes;
                    editarDados.alerta_consumidor = salvarDados.alerta_consumidor;
                    editarDados.desenho_esquematico = salvarDados.desenho_esquematico;
                    editarDados.contem_advertencia_6_2 = salvarDados.contem_advertencia_6_2;
                    editarDados.altura_letra_6_2 = salvarDados.altura_letra_6_2;
                    editarDados.negrito6_2 = salvarDados.negrito6_2;
                    editarDados.caixa_alta_6_2 = salvarDados.caixa_alta_6_2;
                    editarDados.embalagem_unitaria = salvarDados.embalagem_unitaria;
                    editarDados.embalagem_garante = salvarDados.embalagem_garante;

                    //realizando contas necessarias.
                    float calc_media = editarDados.area_etiqueta_1 * editarDados.area_etiqueta_2;

                    //VERIFICANDO SE COLETA ESTA CONFORME OU NC DE CADA CAMPO
                    if (editarDados.etiqueta_ident == "Não" || editarDados.revest_permanente == "Não" || editarDados.etiqueta_duravel_indele == "Não" || editarDados.face_superior == "Não" || editarDados.visualizacao == "Não" || editarDados.lingua_portuguesa == "Não")
                    {
                        editarDados.conforme_requisitos = "NC";
                    }
                    else
                    {
                        editarDados.conforme_requisitos = "C";
                    }

                    if (editarDados.cnpj_cpf == "Não" || editarDados.marca_modelo == "Não" || editarDados.dimensoes_prod == "Não")
                    {
                        editarDados.conforme_requisitos_2 = "NC";
                    }
                    else
                    {
                        editarDados.conforme_requisitos_2 = "C";

                    }

                    if (editarDados.informada_altura == "Não" || editarDados.composicoes == "Não" || editarDados.contem_borda == "Não" || editarDados.densidade_espuma == "Não" || editarDados.composi_revestimento == "Não" || editarDados.data_fabricacao == "Não" || editarDados.ident_lote == "Não" || editarDados.pais_origem == "Não" || editarDados.codigo_barras == "Não" || editarDados.cuidado_minimos == "Não")
                    {
                        editarDados.conforme_requisitos_3 = "NC";
                    }
                    else
                    {
                        editarDados.conforme_requisitos_3 = "C";
                    }

                    if (editarDados.aviso_esclarecimento == "Não" || editarDados.possui_mais_laminas == "Não" || editarDados.contem_advertencia == "Não" || editarDados.negrito == "Não" || editarDados.caixa_alta == "Não" || editarDados.contem_advertencia_mat == "Não" || editarDados.negrito_mat == "Não")
                    {
                        editarDados.conforme_requisitos_4 = "NC";
                    }
                    else
                    {
                        editarDados.conforme_requisitos_4 = "C";
                    }

                    if (editarDados.contem_instru_uso == "Não" || editarDados.orientacoes == "Não" || editarDados.alerta_consumidor == "Não" || editarDados.desenho_esquematico == "Não" || editarDados.contem_advertencia_6_2 == "Não" || editarDados.altura_letra_6_2 == "Não" || editarDados.negrito6_2 == "Não" || editarDados.caixa_alta_6_2 == "Não")
                    {
                        editarDados.conforme_6_1 = "NC";
                    }
                    else
                    {
                        editarDados.conforme_6_1 = "C";
                    }

                    if (editarDados.embalagem_garante == "Não" || editarDados.embalagem_unitaria == "Não")
                    {
                        editarDados.conforme_embalagem = "NC";
                    }
                    else
                    {
                        editarDados.conforme_embalagem = "C";
                    }
                    //termino das verificações de conformidade.


                    //recebendo valor depois do calculo.
                    editarDados.area_etiqueta_media = calc_media;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(IdentificacaoEmbalagemMolas), "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }



        [HttpPost]
        public async Task<IActionResult> EspumaIdentificacaoEmbalagem(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_fim,etiquieta_um,etiquieta_um,fixacao,material,area_um,area_dois,area_result,etiquieta_dois,marca,dimensoes,info_altura,medidas,colchoes,tipo_colchao," +
            "letras,altura_letra_um,negrito_um,caixa_alta_um,coloracao_um,classificacao,uso,composicao,tipo_espuma,densidade_nominal,espessura_mad,comp_revestimento,data_fabricacao,pais_fabricacao,cuidados,aviso_um,altura_letra_dois,negrito_dois,caixa_alta_dois,coloracao_dois,esclarecimento_um," +
            "altura_letra_tres,negrito_tres,caixa_alta_tres,coloracao_eti,esclarecimento_dois,altura_letra_quat,negrito_quat,caixa_alta_quat,coloracao_quat,colchao_infantil,embalagem_colchao,aviso_embalagem_um,altura_letra_cinco,negrito_cinco,caixa_alta_cinco,coloracao_cinco,aviso_odor,aviso_embalagem_dois,altura_letra_seis,negrito_seis," +
            "caixa_alta_seis,coloracao_seis,dec_voluntaria,texto_negrito,identificacao,identificacao_dois,desc_lamina,latex,embalagem_uni,embalagem_protecao,observacao,executador_um,executador_dois,executador_tres,executador_quat")] ColetaModel.Espuma_identificacao_embalagem salvar)
        {

            try
            {
                var editarDados = _context.espuma_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {

                    //recebendo os valores do html
                    DateOnly data_ini = salvar.data_ini;
                    DateOnly data_term = salvar.data_term;
                    string temp_ini = salvar.temp_ini;
                    string temp_fim = salvar.temp_fim;
                    string etiquieta_um = salvar.etiquieta_um;
                    string fixacao = salvar.fixacao;
                    string material = salvar.material;
                    string area_um = salvar.area_um;
                    string area_dois = salvar.area_dois;

                    double areaum = double.Parse(area_um);
                    double areadois = double.Parse(area_dois);
                    double calculo_area_result  = areaum * areadois;
                    string area_result = calculo_area_result.ToString();

                    string etiquieta_dois = salvar.etiquieta_dois;
                    string marca = salvar.marca;
                    string dimensoes = salvar.dimensoes;
                    string info_altura = salvar.info_altura;
                    string medidas = salvar.medidas;
                    string colchoes = salvar.colchoes;
                    string tipo_colchao = salvar.tipo_colchao;
                    string letras = salvar.letras;
                    string altura_letra_um = salvar.altura_letra_um;
                    string negrito_um = salvar.negrito_um;
                    string caixa_alta_um = salvar.caixa_alta_um;
                    string coloracao_um = salvar.coloracao_um;
                    string classificacao = salvar.classificacao;
                    string uso = salvar.uso;
                    string composicao = salvar.composicao;
                    string tipo_espuma = salvar.tipo_espuma;
                    string densidade_nominal = salvar.densidade_nominal;
                    string espessura_mad = salvar.espessura_mad;
                    string comp_revestimento = salvar.comp_revestimento;
                    string data_fabricacao = salvar.data_fabricacao;
                    string pais_fabricacao = salvar.pais_fabricacao;
                    string cuidados = salvar.cuidados;
                    string aviso_um = salvar.aviso_um;
                    string altura_letra_dois = salvar.altura_letra_dois;
                    string negrito_dois = salvar.negrito_dois;
                    string caixa_alta_dois = salvar.caixa_alta_dois;
                    string coloracao_dois = salvar.coloracao_dois;
                    string esclarecimento_um = salvar.esclarecimento_um;
                    string altura_letra_tres = salvar.altura_letra_tres;
                    string negrito_tres = salvar.negrito_tres;
                    string caixa_alta_tres = salvar.caixa_alta_tres;
                    string coloracao_eti = salvar.coloracao_eti;
                    string esclarecimento_dois = salvar.esclarecimento_dois;
                    string altura_letra_quat = salvar.altura_letra_quat;
                    string negrito_quat = salvar.negrito_quat;
                    string caixa_alta_quat = salvar.caixa_alta_quat;
                    string coloracao_quat = salvar.coloracao_quat;
                    string colchao_infantil = salvar.colchao_infantil;
                    string embalagem_colchao = salvar.embalagem_colchao;
                    string aviso_embalagem_um = salvar.aviso_embalagem_um;
                    string altura_letra_cinco = salvar.altura_letra_cinco;
                    string negrito_cinco = salvar.negrito_cinco;
                    string caixa_alta_cinco = salvar.caixa_alta_cinco;
                    string coloracao_cinco = salvar.coloracao_cinco;
                    string aviso_odor = salvar.aviso_odor;
                    string aviso_embalagem_dois = salvar.aviso_embalagem_dois;
                    string altura_letra_seis = salvar.altura_letra_seis;
                    string negrito_seis = salvar.negrito_seis;
                    string caixa_alta_seis = salvar.caixa_alta_seis;
                    string coloracao_seis = salvar.coloracao_seis;
                    string dec_voluntaria = salvar.dec_voluntaria;
                    string texto_negrito = salvar.texto_negrito;
                    string identificacao = salvar.identificacao;
                    string identificacao_dois = salvar.identificacao_dois;
                    string desc_lamina = salvar.desc_lamina;
                    string latex = salvar.latex;
                    string embalagem_uni = salvar.embalagem_uni;
                    string embalagem_protecao = salvar.embalagem_protecao;
                    string observacao = salvar.observacao;
                    string executador_um = salvar.executador_um;
                    string executador_dois = salvar.executador_dois;
                    string executador_tres = salvar.executador_tres;
                    string executador_quat = salvar.executador_quat;


                    var registro = new ColetaModel.Espuma_identificacao_embalagem
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ini = temp_ini,
                        temp_fim = temp_fim,
                        etiquieta_um = etiquieta_um,
                        fixacao = fixacao,
                        material = material,
                        area_um = area_um,
                        area_dois = area_dois,
                        area_result = area_result,
                        etiquieta_dois = etiquieta_dois,
                        marca = marca,
                        dimensoes = dimensoes,
                        info_altura = info_altura,
                        medidas = medidas,
                        colchoes = colchoes,
                        tipo_colchao = tipo_colchao,
                        letras = letras,
                        altura_letra_um = altura_letra_um,
                        negrito_um = negrito_um,
                        caixa_alta_um = caixa_alta_um,
                        coloracao_um = coloracao_um,
                        classificacao = classificacao,
                        uso = uso,
                        composicao = composicao,
                        tipo_espuma = tipo_espuma,
                        densidade_nominal = densidade_nominal,
                        espessura_mad = espessura_mad,
                        comp_revestimento = comp_revestimento,
                        data_fabricacao = data_fabricacao,
                        pais_fabricacao = pais_fabricacao,
                        cuidados = cuidados,
                        aviso_um = aviso_um,
                        altura_letra_dois = altura_letra_dois,
                        negrito_dois = negrito_dois,
                        caixa_alta_dois = caixa_alta_dois,
                        coloracao_dois = coloracao_dois,
                        esclarecimento_um = esclarecimento_um,
                        altura_letra_tres = altura_letra_tres,
                        negrito_tres = negrito_tres,
                        caixa_alta_tres = caixa_alta_tres,
                        coloracao_eti = coloracao_eti,
                        esclarecimento_dois = esclarecimento_dois,
                        altura_letra_quat = altura_letra_quat,
                        negrito_quat = negrito_quat,
                        caixa_alta_quat = caixa_alta_quat,
                        coloracao_quat = coloracao_quat,
                        colchao_infantil = colchao_infantil,
                        embalagem_colchao = embalagem_colchao,
                        aviso_embalagem_um = aviso_embalagem_um,
                        altura_letra_cinco = altura_letra_cinco,
                        negrito_cinco = negrito_cinco,
                        caixa_alta_cinco = caixa_alta_cinco,
                        coloracao_cinco = coloracao_cinco,
                        aviso_odor = aviso_odor,
                        aviso_embalagem_dois = aviso_embalagem_dois,
                        altura_letra_seis = altura_letra_seis,
                        negrito_seis = negrito_seis,
                        caixa_alta_seis = caixa_alta_seis,
                        coloracao_seis = coloracao_seis,
                        dec_voluntaria = dec_voluntaria,
                        texto_negrito = texto_negrito,
                        identificacao = identificacao,
                        identificacao_dois = identificacao_dois,
                        desc_lamina = desc_lamina,
                        latex = latex,
                        embalagem_uni = embalagem_uni,
                        embalagem_protecao = embalagem_protecao,
                        observacao = observacao,
                        executador_um = executador_um,
                        executador_dois = executador_dois,
                        executador_tres = executador_tres,
                        executador_quat = executador_quat,
                    };

                    //salvando no banco
                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return RedirectToAction(nameof(IdentificacaoEmbalagem), "Coleta", new { os, orcamento });

                }
                else
                {

                    editarDados.data_ini = salvar.data_ini;
                    editarDados.data_term = salvar.data_term;
                    editarDados.temp_ini = salvar.temp_ini;
                    editarDados.temp_fim = salvar.temp_fim;
                    editarDados.etiquieta_um = salvar.etiquieta_um;
                    editarDados.fixacao = salvar.fixacao;
                    editarDados.material = salvar.material;
                    editarDados.area_um = salvar.area_um;
                    editarDados.area_dois = salvar.area_dois;

                    double areaum = double.Parse(editarDados.area_um);
                    double areadois = double.Parse(editarDados.area_dois);
                    editarDados.area_result = (areaum * areadois).ToString();

                    editarDados.etiquieta_dois = salvar.etiquieta_dois;
                    editarDados.marca = salvar.marca;
                    editarDados.dimensoes = salvar.dimensoes;
                    editarDados.info_altura = salvar.info_altura;
                    editarDados.medidas = salvar.medidas;
                    editarDados.colchoes = salvar.colchoes;
                    editarDados.tipo_colchao = salvar.tipo_colchao;
                    editarDados.letras = salvar.letras;
                    editarDados.altura_letra_um = salvar.altura_letra_um;
                    editarDados.negrito_um = salvar.negrito_um;
                    editarDados.caixa_alta_um = salvar.caixa_alta_um;
                    editarDados.coloracao_um = salvar.coloracao_um;
                    editarDados.classificacao = salvar.classificacao;
                    editarDados.uso = salvar.uso;
                    editarDados.composicao = salvar.composicao;
                    editarDados.tipo_espuma = salvar.tipo_espuma;
                    editarDados.densidade_nominal = salvar.densidade_nominal;
                    editarDados.espessura_mad = salvar.espessura_mad;
                    editarDados.comp_revestimento = salvar.comp_revestimento;
                    editarDados.data_fabricacao = salvar.data_fabricacao;
                    editarDados.pais_fabricacao = salvar.pais_fabricacao;
                    editarDados.cuidados = salvar.cuidados;
                    editarDados.aviso_um = salvar.aviso_um;
                    editarDados.altura_letra_dois = salvar.altura_letra_dois;
                    editarDados.negrito_dois = salvar.negrito_dois;
                    editarDados.caixa_alta_dois = salvar.caixa_alta_dois;
                    editarDados.coloracao_dois = salvar.coloracao_dois;
                    editarDados.esclarecimento_um = salvar.esclarecimento_um;
                    editarDados.altura_letra_tres = salvar.altura_letra_tres;
                    editarDados.negrito_tres = salvar.negrito_tres;
                    editarDados.caixa_alta_tres = salvar.caixa_alta_tres;
                    editarDados.coloracao_eti = salvar.coloracao_eti;
                    editarDados.esclarecimento_dois = salvar.esclarecimento_dois;
                    editarDados.altura_letra_quat = salvar.altura_letra_quat;
                    editarDados.negrito_quat = salvar.negrito_quat;
                    editarDados.caixa_alta_quat = salvar.caixa_alta_quat;
                    editarDados.coloracao_quat = salvar.coloracao_quat;
                    editarDados.colchao_infantil = salvar.colchao_infantil;
                    editarDados.embalagem_colchao = salvar.embalagem_colchao;
                    editarDados.aviso_embalagem_um = salvar.aviso_embalagem_um;
                    editarDados.altura_letra_cinco = salvar.altura_letra_cinco;
                    editarDados.negrito_cinco = salvar.negrito_cinco;
                    editarDados.caixa_alta_cinco = salvar.caixa_alta_cinco;
                    editarDados.coloracao_cinco = salvar.coloracao_cinco;
                    editarDados.aviso_odor = salvar.aviso_odor;
                    editarDados.aviso_embalagem_dois = salvar.aviso_embalagem_dois;
                    editarDados.altura_letra_seis = salvar.altura_letra_seis;
                    editarDados.negrito_seis = salvar.negrito_seis;
                    editarDados.caixa_alta_seis = salvar.caixa_alta_seis;
                    editarDados.coloracao_seis = salvar.coloracao_seis;
                    editarDados.dec_voluntaria = salvar.dec_voluntaria;
                    editarDados.texto_negrito = salvar.texto_negrito;
                    editarDados.identificacao = salvar.identificacao;
                    editarDados.identificacao_dois = salvar.identificacao_dois;
                    editarDados.desc_lamina = salvar.desc_lamina;
                    editarDados.latex = salvar.latex;
                    editarDados.embalagem_uni = salvar.embalagem_uni;
                    editarDados.embalagem_protecao = salvar.embalagem_protecao;
                    editarDados.observacao = salvar.observacao;
                    editarDados.executador_um = salvar.executador_um;
                    editarDados.executador_dois = salvar.executador_dois;
                    editarDados.executador_tres = salvar.executador_tres;
                    editarDados.executador_quat = salvar.executador_quat;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
                    return RedirectToAction(nameof(IdentificacaoEmbalagem), "Coleta", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> salvarBaseDurabilidade(string os, string orcamento, ColetaModel.EnsaioBaseDurabilidade dados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_durabilidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    //recebendo os valors do html para as variaveis
                    DateOnly data_inicio = dados.data_inicio;
                    DateOnly data_termi = dados.data_termi;
                    TimeOnly hora_inicio = dados.hora_inicio;
                    TimeOnly hora_term = dados.hora_term;
                    string temp_min = dados.temp_min;
                    string temp_max = dados.temp_max;
                    string base_cama = dados.base_cama;
                    string angulo_encontrado = dados.angulo_encontrado;
                    int distancia_ponto_a = dados.distancia_ponto_a;
                    int largura_encontrad = dados.largura_ponto_a;
                    string suportou_ponto_a = dados.suportou_ponto_a;
                    string ruptura_ponto_a = dados.ruptura_ponto_a;
                    string afundamento_ponto_a = dados.afundamento_ponto_a;
                    string rasgo_ponto_a = dados.rasgo_ponto_a;
                    string rompimento_ponto_a = dados.rompimento_ponto_a;
                    string prejudique_ponto_a = dados.prejudique_ponto_a;
                    string suportou_ponto_b = dados.suportou_ponto_b;
                    string ruptura_ponto_b = dados.ruptura_ponto_b;
                    string afundamento_ponto_b = dados.afundamento_ponto_b;
                    string rasgo_ponto_b = dados.rasgo_ponto_b;
                    string rompimento_ponto_b = dados.rompimento_ponto_b;
                    string prejudique_ponto_b = dados.prejudique_ponto_b;
                    string suportou_ponto_c = dados.suportou_ponto_c;
                    string ruptura_ponto_c = dados.ruptura_ponto_c;
                    string afundamento_ponto_c = dados.afundamento_ponto_c;
                    string rasgo_ponto_c = dados.rasgo_ponto_c;
                    string rompimento_ponto_c = dados.rompimento_ponto_c;
                    string prejudique_ponto_c = dados.prejudique_ponto_c;


                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_a == "Não" && afundamento_ponto_a == "Não" && rasgo_ponto_a == "Não" && rompimento_ponto_a == "Não" && prejudique_ponto_a == "Não")
                    {
                        dados.conforme_a = "C";
                    }
                    else
                    {
                        dados.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_b == "Não" && afundamento_ponto_b == "Não" && rasgo_ponto_b == "Não" && rompimento_ponto_b == "Não" && prejudique_ponto_b == "Não")
                    {
                        dados.conforme_b = "C";
                    }
                    else
                    {
                        dados.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_c == "Não" && afundamento_ponto_c == "Não" && rasgo_ponto_c == "Não" && rompimento_ponto_c == "Não" && prejudique_ponto_c == "Não")
                    {
                        dados.conforme_c = "C";
                    }
                    else
                    {
                        dados.conforme_c = "NC";
                    }



                    _context.Add(dados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados salvo com sucesso.";

                    if (ViewBag.ensaio == "Molas")
                    {
                        return RedirectToAction("EnsaioDurabilidade", new { os, orcamento });
                    }
                    else
                    {
                        return RedirectToAction("EnsaioDurabilidadeEspuma", new { os, orcamento });
                    }
                }
                else
                {
                    //recebendo os valores para editar no banco.
                    editarRegistro.data_inicio = dados.data_inicio;
                    editarRegistro.data_termi = dados.data_termi;
                    editarRegistro.hora_inicio = dados.hora_inicio;
                    editarRegistro.hora_term = dados.hora_term;
                    editarRegistro.temp_min = dados.temp_min;
                    editarRegistro.temp_max = dados.temp_max;
                    editarRegistro.base_cama = dados.base_cama;
                    editarRegistro.angulo_encontrado = dados.angulo_encontrado;
                    editarRegistro.distancia_ponto_a = dados.distancia_ponto_a;
                    editarRegistro.suportou_ponto_a = dados.suportou_ponto_a;
                    editarRegistro.ruptura_ponto_a = dados.ruptura_ponto_a;
                    editarRegistro.afundamento_ponto_a = dados.afundamento_ponto_a;
                    editarRegistro.rasgo_ponto_a = dados.rasgo_ponto_a;
                    editarRegistro.rompimento_ponto_a = dados.rompimento_ponto_a;
                    editarRegistro.prejudique_ponto_a = dados.prejudique_ponto_a;
                    editarRegistro.suportou_ponto_b = dados.suportou_ponto_b;
                    editarRegistro.ruptura_ponto_b = dados.ruptura_ponto_b;
                    editarRegistro.afundamento_ponto_b = dados.afundamento_ponto_b;
                    editarRegistro.rasgo_ponto_b = dados.rasgo_ponto_b;
                    editarRegistro.rompimento_ponto_b = dados.rompimento_ponto_b;
                    editarRegistro.prejudique_ponto_b = dados.prejudique_ponto_b;
                    editarRegistro.suportou_ponto_c = dados.suportou_ponto_c;
                    editarRegistro.ruptura_ponto_c = dados.ruptura_ponto_c;
                    editarRegistro.afundamento_ponto_c = dados.afundamento_ponto_c;
                    editarRegistro.rasgo_ponto_c = dados.rasgo_ponto_c;
                    editarRegistro.rompimento_ponto_c = dados.rompimento_ponto_c;
                    editarRegistro.prejudique_ponto_c = dados.prejudique_ponto_c;

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_a == "Não" && editarRegistro.afundamento_ponto_a == "Não" && editarRegistro.rasgo_ponto_a == "Não" && editarRegistro.rompimento_ponto_a == "Não" && editarRegistro.prejudique_ponto_a == "Não")
                    {
                        editarRegistro.conforme_a = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_b == "Não" && editarRegistro.afundamento_ponto_b == "Não" && editarRegistro.rasgo_ponto_b == "Não" && editarRegistro.rompimento_ponto_b == "Não" && editarRegistro.prejudique_ponto_b == "Não")
                    {
                        editarRegistro.conforme_b = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_c == "Não" && editarRegistro.afundamento_ponto_c == "Não" && editarRegistro.rasgo_ponto_c == "Não" && editarRegistro.rompimento_ponto_c == "Não" && editarRegistro.prejudique_ponto_c == "Não")
                    {
                        editarRegistro.conforme_c = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_c = "NC";
                    }
                    _context.Update(editarRegistro);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioDurabilidade", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> salvarBaseDurabilidadeEspuma(string os, string orcamento, ColetaModel.EnsaioBaseDurabilidade dados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_durabilidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    //recebendo os valors do html para as variaveis
                    DateOnly data_inicio = dados.data_inicio;
                    DateOnly data_termi = dados.data_termi;
                    TimeOnly hora_inicio = dados.hora_inicio;
                    TimeOnly hora_term = dados.hora_term;
                    string temp_min = dados.temp_min;
                    string temp_max = dados.temp_max;
                    string base_cama = dados.base_cama;
                    string angulo_encontrado = dados.angulo_encontrado;
                    int distancia_ponto_a = dados.distancia_ponto_a;
                    int largura_encontrad = dados.largura_ponto_a;
                    string suportou_ponto_a = dados.suportou_ponto_a;
                    string ruptura_ponto_a = dados.ruptura_ponto_a;
                    string afundamento_ponto_a = dados.afundamento_ponto_a;
                    string rasgo_ponto_a = dados.rasgo_ponto_a;
                    string rompimento_ponto_a = dados.rompimento_ponto_a;
                    string prejudique_ponto_a = dados.prejudique_ponto_a;
                    string suportou_ponto_b = dados.suportou_ponto_b;
                    string ruptura_ponto_b = dados.ruptura_ponto_b;
                    string afundamento_ponto_b = dados.afundamento_ponto_b;
                    string rasgo_ponto_b = dados.rasgo_ponto_b;
                    string rompimento_ponto_b = dados.rompimento_ponto_b;
                    string prejudique_ponto_b = dados.prejudique_ponto_b;
                    string suportou_ponto_c = dados.suportou_ponto_c;
                    string ruptura_ponto_c = dados.ruptura_ponto_c;
                    string afundamento_ponto_c = dados.afundamento_ponto_c;
                    string rasgo_ponto_c = dados.rasgo_ponto_c;
                    string rompimento_ponto_c = dados.rompimento_ponto_c;
                    string prejudique_ponto_c = dados.prejudique_ponto_c;


                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_a == "Não" && afundamento_ponto_a == "Não" && rasgo_ponto_a == "Não" && rompimento_ponto_a == "Não" && prejudique_ponto_a == "Não")
                    {
                        dados.conforme_a = "C";
                    }
                    else
                    {
                        dados.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_b == "Não" && afundamento_ponto_b == "Não" && rasgo_ponto_b == "Não" && rompimento_ponto_b == "Não" && prejudique_ponto_b == "Não")
                    {
                        dados.conforme_b = "C";
                    }
                    else
                    {
                        dados.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (ruptura_ponto_c == "Não" && afundamento_ponto_c == "Não" && rasgo_ponto_c == "Não" && rompimento_ponto_c == "Não" && prejudique_ponto_c == "Não")
                    {
                        dados.conforme_c = "C";
                    }
                    else
                    {
                        dados.conforme_c = "NC";
                    }



                    _context.Add(dados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados salvo com sucesso.";
                    return RedirectToAction("EnsaioDurabilidadeEspuma", new { os, orcamento });

                }
                else
                {
                    //recebendo os valores para editar no banco.
                    editarRegistro.data_inicio = dados.data_inicio;
                    editarRegistro.data_termi = dados.data_termi;
                    editarRegistro.hora_inicio = dados.hora_inicio;
                    editarRegistro.hora_term = dados.hora_term;
                    editarRegistro.temp_min = dados.temp_min;
                    editarRegistro.temp_max = dados.temp_max;
                    editarRegistro.base_cama = dados.base_cama;
                    editarRegistro.angulo_encontrado = dados.angulo_encontrado;
                    editarRegistro.distancia_ponto_a = dados.distancia_ponto_a;
                    editarRegistro.suportou_ponto_a = dados.suportou_ponto_a;
                    editarRegistro.ruptura_ponto_a = dados.ruptura_ponto_a;
                    editarRegistro.afundamento_ponto_a = dados.afundamento_ponto_a;
                    editarRegistro.rasgo_ponto_a = dados.rasgo_ponto_a;
                    editarRegistro.rompimento_ponto_a = dados.rompimento_ponto_a;
                    editarRegistro.prejudique_ponto_a = dados.prejudique_ponto_a;
                    editarRegistro.suportou_ponto_b = dados.suportou_ponto_b;
                    editarRegistro.ruptura_ponto_b = dados.ruptura_ponto_b;
                    editarRegistro.afundamento_ponto_b = dados.afundamento_ponto_b;
                    editarRegistro.rasgo_ponto_b = dados.rasgo_ponto_b;
                    editarRegistro.rompimento_ponto_b = dados.rompimento_ponto_b;
                    editarRegistro.prejudique_ponto_b = dados.prejudique_ponto_b;
                    editarRegistro.suportou_ponto_c = dados.suportou_ponto_c;
                    editarRegistro.ruptura_ponto_c = dados.ruptura_ponto_c;
                    editarRegistro.afundamento_ponto_c = dados.afundamento_ponto_c;
                    editarRegistro.rasgo_ponto_c = dados.rasgo_ponto_c;
                    editarRegistro.rompimento_ponto_c = dados.rompimento_ponto_c;
                    editarRegistro.prejudique_ponto_c = dados.prejudique_ponto_c;

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_a == "Não" && editarRegistro.afundamento_ponto_a == "Não" && editarRegistro.rasgo_ponto_a == "Não" && editarRegistro.rompimento_ponto_a == "Não" && editarRegistro.prejudique_ponto_a == "Não")
                    {
                        editarRegistro.conforme_a = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_b == "Não" && editarRegistro.afundamento_ponto_b == "Não" && editarRegistro.rasgo_ponto_b == "Não" && editarRegistro.rompimento_ponto_b == "Não" && editarRegistro.prejudique_ponto_b == "Não")
                    {
                        editarRegistro.conforme_b = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.ruptura_ponto_c == "Não" && editarRegistro.afundamento_ponto_c == "Não" && editarRegistro.rasgo_ponto_c == "Não" && editarRegistro.rompimento_ponto_c == "Não" && editarRegistro.prejudique_ponto_c == "Não")
                    {
                        editarRegistro.conforme_c = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_c = "NC";
                    }
                    _context.Update(editarRegistro);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioDurabilidadeEspuma", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> salvarEnsaioImpactioVertical(string os, string orcamento, ColetaModel.EnsaioBaseImpactoVertical salvarDados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_impacto_vertical.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    //recebendo os valores do html.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    DateOnly data_ini_ens = salvarDados.data_ini_ens;
                    DateOnly data_term_ens = salvarDados.data_term_ens;
                    TimeOnly hora_inic = salvarDados.hora_inic;
                    TimeOnly hora_term = salvarDados.hora_term;
                    string tem_min = salvarDados.tem_min;
                    string tem_max = salvarDados.tem_max;
                    int comp_base = salvarDados.comp_base;
                    int larg_base = salvarDados.larg_base;
                    string impac_um_a = salvarDados.impac_um_a;
                    string impac_um_b = salvarDados.impac_um_b;
                    string impac_um_c = salvarDados.impac_um_c;
                    string impac_um_d = salvarDados.impac_um_d;
                    string impac_um_g = salvarDados.impac_um_g;
                    string impac_um_i = salvarDados.impac_um_i;
                    string impac_um_j = salvarDados.impac_um_j;
                    string ruptura_um = salvarDados.ruptura_um;
                    string afundamento_um = salvarDados.afundamento_um;
                    string rasgo_um = salvarDados.rasgo_um;
                    string rompimento_um = salvarDados.rompimento_um;
                    string prejudique_um = salvarDados.prejudique_um;
                    string impac_dois_a = salvarDados.impac_dois_a;
                    string impac_dois_b = salvarDados.impac_dois_b;
                    string impac_dois_c = salvarDados.impac_dois_c;
                    string impac_dois_d = salvarDados.impac_dois_d;
                    string impac_dois_g = salvarDados.impac_dois_g;
                    string impac_dois_i = salvarDados.impac_dois_i;
                    string impac_dois_j = salvarDados.impac_dois_j;
                    string ruptura_dois = salvarDados.ruptura_dois;
                    string afundamento_dois = salvarDados.afundamento_dois;
                    string rasgo_dois = salvarDados.rasgo_dois;
                    string rompimento_dois = salvarDados.rompimento_dois;
                    string prejudique_dois = salvarDados.prejudique_dois;

                    //realizando conforme e nao conforme
                    if (impac_um_a == "Sim" && impac_um_b == "Sim" && impac_um_c == "Sim" && impac_um_d == "Sim" && impac_um_g == "Sim" && impac_um_i == "Sim" && impac_um_j == "Sim")
                    {
                        salvarDados.confome_ponto_a = "C";
                    }
                    else
                    {
                        salvarDados.confome_ponto_a = "NC";
                    }

                    if (ruptura_um == "Não" && prejudique_um == "Não" && rompimento_um == "Não" && rasgo_um == "Não" && afundamento_um == "Não")
                    {
                        salvarDados.conforme_um = "C";
                    }
                    else
                    {
                        salvarDados.conforme_um = "NC";
                    }

                    if (ruptura_dois == "Não" && prejudique_dois == "Não" && rompimento_dois == "Não" && rasgo_dois == "Não" && afundamento_dois == "Não")
                    {
                        salvarDados.conforme_dois = "C";
                    }
                    else
                    {
                        salvarDados.conforme_dois = "NC";
                    }



                    if (impac_dois_a == "Sim" && impac_dois_b == "Sim" && impac_dois_c == "Sim" && impac_dois_d == "Sim" && impac_dois_g == "Sim" && impac_dois_i == "Sim" && impac_dois_j == "Sim")
                    {
                        salvarDados.confome_ponto_b = "C";
                    }
                    else
                    {
                        salvarDados.confome_ponto_b = "NC";
                    }
                    //fim dos resultados de conforme ou nao conforme..


                    _context.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("EnsaioImpacto", new { os, orcamento });
                }
                else
                {
                    //editando os valores no html
                    editarRegistro.data_ini = salvarDados.data_ini;
                    editarRegistro.data_term = salvarDados.data_term;
                    editarRegistro.data_ini_ens = salvarDados.data_ini_ens;
                    editarRegistro.data_term_ens = salvarDados.data_term_ens;
                    editarRegistro.hora_inic = salvarDados.hora_inic;
                    editarRegistro.hora_term = salvarDados.hora_term;
                    editarRegistro.tem_min = salvarDados.tem_min;
                    editarRegistro.tem_max = salvarDados.tem_max;
                    editarRegistro.comp_base = salvarDados.comp_base;
                    editarRegistro.larg_base = salvarDados.larg_base;
                    editarRegistro.impac_um_a = salvarDados.impac_um_a;
                    editarRegistro.impac_um_b = salvarDados.impac_um_b;
                    editarRegistro.impac_um_c = salvarDados.impac_um_c;
                    editarRegistro.impac_um_d = salvarDados.impac_um_d;
                    editarRegistro.impac_um_g = salvarDados.impac_um_g;
                    editarRegistro.impac_um_i = salvarDados.impac_um_i;
                    editarRegistro.impac_um_j = salvarDados.impac_um_j;
                    editarRegistro.ruptura_um = salvarDados.ruptura_um;
                    editarRegistro.afundamento_um = salvarDados.afundamento_um;
                    editarRegistro.rasgo_um = salvarDados.rasgo_um;
                    editarRegistro.rompimento_um = salvarDados.rompimento_um;
                    editarRegistro.prejudique_um = salvarDados.prejudique_um;
                    editarRegistro.impac_dois_a = salvarDados.impac_dois_a;
                    editarRegistro.impac_dois_b = salvarDados.impac_dois_b;
                    editarRegistro.impac_dois_c = salvarDados.impac_dois_c;
                    editarRegistro.impac_dois_d = salvarDados.impac_dois_d;
                    editarRegistro.impac_dois_g = salvarDados.impac_dois_g;
                    editarRegistro.impac_dois_i = salvarDados.impac_dois_i;
                    editarRegistro.impac_dois_j = salvarDados.impac_dois_j;
                    editarRegistro.ruptura_dois = salvarDados.ruptura_dois;
                    editarRegistro.afundamento_dois = salvarDados.afundamento_dois;
                    editarRegistro.rasgo_dois = salvarDados.rasgo_dois;
                    editarRegistro.rompimento_dois = salvarDados.rompimento_dois;
                    editarRegistro.prejudique_dois = salvarDados.prejudique_dois;

                    //realizando conforme e nao conforme
                    if (editarRegistro.impac_um_a == "Sim" && editarRegistro.impac_um_b == "Sim" && editarRegistro.impac_um_c == "Sim" && editarRegistro.impac_um_d == "Sim" && editarRegistro.impac_um_g == "Sim" && editarRegistro.impac_um_i == "Sim" && editarRegistro.impac_um_j == "Sim")
                    {
                        editarRegistro.confome_ponto_a = "C";
                    }
                    else
                    {
                        editarRegistro.confome_ponto_a = "NC";
                    }


                    if (editarRegistro.ruptura_um == "Não" && editarRegistro.prejudique_um == "Não" && editarRegistro.rompimento_um == "Não" && editarRegistro.rasgo_um == "Não" && editarRegistro.afundamento_um == "Não")
                    {
                        editarRegistro.conforme_um = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_um = "NC";
                    }

                    if (editarRegistro.ruptura_dois == "Não" && editarRegistro.prejudique_dois == "Não" && editarRegistro.rompimento_dois == "Não" && editarRegistro.rasgo_dois == "Não" && editarRegistro.afundamento_dois == "Não")
                    {
                        editarRegistro.conforme_dois = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_dois = "NC";
                    }

                    if (editarRegistro.impac_dois_a == "Sim" && editarRegistro.impac_dois_b == "Sim" && editarRegistro.impac_dois_c == "Sim" && editarRegistro.impac_dois_d == "Sim" && editarRegistro.impac_dois_g == "Sim" && editarRegistro.impac_dois_i == "Sim" && editarRegistro.impac_dois_j == "Sim")
                    {
                        editarRegistro.confome_ponto_b = "C";
                    }
                    else
                    {
                        editarRegistro.confome_ponto_b = "NC";
                    }
                    //fim dos resultados de conforme ou nao conforme..

                    _context.Update(editarRegistro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioImpacto", new { os, orcamento });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> salvarEnsaioImpactioVerticalEspuma(string os, string orcamento, ColetaModel.EnsaioBaseImpactoVertical salvarDados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_impacto_vertical.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    //recebendo os valores do html.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    DateOnly data_ini_ens = salvarDados.data_ini_ens;
                    DateOnly data_term_ens = salvarDados.data_term_ens;
                    TimeOnly hora_inic = salvarDados.hora_inic;
                    TimeOnly hora_term = salvarDados.hora_term;
                    string tem_min = salvarDados.tem_min;
                    string tem_max = salvarDados.tem_max;
                    int comp_base = salvarDados.comp_base;
                    int larg_base = salvarDados.larg_base;
                    string impac_um_a = salvarDados.impac_um_a;
                    string impac_um_b = salvarDados.impac_um_b;
                    string impac_um_c = salvarDados.impac_um_c;
                    string impac_um_d = salvarDados.impac_um_d;
                    string impac_um_g = salvarDados.impac_um_g;
                    string impac_um_i = salvarDados.impac_um_i;
                    string impac_um_j = salvarDados.impac_um_j;
                    string ruptura_um = salvarDados.ruptura_um;
                    string afundamento_um = salvarDados.afundamento_um;
                    string rasgo_um = salvarDados.rasgo_um;
                    string rompimento_um = salvarDados.rompimento_um;
                    string prejudique_um = salvarDados.prejudique_um;
                    string impac_dois_a = salvarDados.impac_dois_a;
                    string impac_dois_b = salvarDados.impac_dois_b;
                    string impac_dois_c = salvarDados.impac_dois_c;
                    string impac_dois_d = salvarDados.impac_dois_d;
                    string impac_dois_g = salvarDados.impac_dois_g;
                    string impac_dois_i = salvarDados.impac_dois_i;
                    string impac_dois_j = salvarDados.impac_dois_j;
                    string ruptura_dois = salvarDados.ruptura_dois;
                    string afundamento_dois = salvarDados.afundamento_dois;
                    string rasgo_dois = salvarDados.rasgo_dois;
                    string rompimento_dois = salvarDados.rompimento_dois;
                    string prejudique_dois = salvarDados.prejudique_dois;

                    //realizando conforme e nao conforme
                    if (impac_um_a == "Sim" && impac_um_b == "Sim" && impac_um_c == "Sim" && impac_um_d == "Sim" && impac_um_g == "Sim" && impac_um_i == "Sim" && impac_um_j == "Sim")
                    {
                        salvarDados.confome_ponto_a = "C";
                    }
                    else
                    {
                        salvarDados.confome_ponto_a = "NC";
                    }

                    if (ruptura_um == "Não" && prejudique_um == "Não" && rompimento_um == "Não" && rasgo_um == "Não" && afundamento_um == "Não")
                    {
                        salvarDados.conforme_um = "C";
                    }
                    else
                    {
                        salvarDados.conforme_um = "NC";
                    }

                    if (ruptura_dois == "Não" && prejudique_dois == "Não" && rompimento_dois == "Não" && rasgo_dois == "Não" && afundamento_dois == "Não")
                    {
                        salvarDados.conforme_dois = "C";
                    }
                    else
                    {
                        salvarDados.conforme_dois = "NC";
                    }



                    if (impac_dois_a == "Sim" && impac_dois_b == "Sim" && impac_dois_c == "Sim" && impac_dois_d == "Sim" && impac_dois_g == "Sim" && impac_dois_i == "Sim" && impac_dois_j == "Sim")
                    {
                        salvarDados.confome_ponto_b = "C";
                    }
                    else
                    {
                        salvarDados.confome_ponto_b = "NC";
                    }
                    //fim dos resultados de conforme ou nao conforme..


                    _context.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("EnsaioImpactoEspuma", new { os, orcamento });
                }
                else
                {
                    //editando os valores no html
                    editarRegistro.data_ini = salvarDados.data_ini;
                    editarRegistro.data_term = salvarDados.data_term;
                    editarRegistro.data_ini_ens = salvarDados.data_ini_ens;
                    editarRegistro.data_term_ens = salvarDados.data_term_ens;
                    editarRegistro.hora_inic = salvarDados.hora_inic;
                    editarRegistro.hora_term = salvarDados.hora_term;
                    editarRegistro.tem_min = salvarDados.tem_min;
                    editarRegistro.tem_max = salvarDados.tem_max;
                    editarRegistro.comp_base = salvarDados.comp_base;
                    editarRegistro.larg_base = salvarDados.larg_base;
                    editarRegistro.impac_um_a = salvarDados.impac_um_a;
                    editarRegistro.impac_um_b = salvarDados.impac_um_b;
                    editarRegistro.impac_um_c = salvarDados.impac_um_c;
                    editarRegistro.impac_um_d = salvarDados.impac_um_d;
                    editarRegistro.impac_um_g = salvarDados.impac_um_g;
                    editarRegistro.impac_um_i = salvarDados.impac_um_i;
                    editarRegistro.impac_um_j = salvarDados.impac_um_j;
                    editarRegistro.ruptura_um = salvarDados.ruptura_um;
                    editarRegistro.afundamento_um = salvarDados.afundamento_um;
                    editarRegistro.rasgo_um = salvarDados.rasgo_um;
                    editarRegistro.rompimento_um = salvarDados.rompimento_um;
                    editarRegistro.prejudique_um = salvarDados.prejudique_um;
                    editarRegistro.impac_dois_a = salvarDados.impac_dois_a;
                    editarRegistro.impac_dois_b = salvarDados.impac_dois_b;
                    editarRegistro.impac_dois_c = salvarDados.impac_dois_c;
                    editarRegistro.impac_dois_d = salvarDados.impac_dois_d;
                    editarRegistro.impac_dois_g = salvarDados.impac_dois_g;
                    editarRegistro.impac_dois_i = salvarDados.impac_dois_i;
                    editarRegistro.impac_dois_j = salvarDados.impac_dois_j;
                    editarRegistro.ruptura_dois = salvarDados.ruptura_dois;
                    editarRegistro.afundamento_dois = salvarDados.afundamento_dois;
                    editarRegistro.rasgo_dois = salvarDados.rasgo_dois;
                    editarRegistro.rompimento_dois = salvarDados.rompimento_dois;
                    editarRegistro.prejudique_dois = salvarDados.prejudique_dois;

                    //realizando conforme e nao conforme
                    if (editarRegistro.impac_um_a == "Sim" && editarRegistro.impac_um_b == "Sim" && editarRegistro.impac_um_c == "Sim" && editarRegistro.impac_um_d == "Sim" && editarRegistro.impac_um_g == "Sim" && editarRegistro.impac_um_i == "Sim" && editarRegistro.impac_um_j == "Sim")
                    {
                        editarRegistro.confome_ponto_a = "C";
                    }
                    else
                    {
                        editarRegistro.confome_ponto_a = "NC";
                    }


                    if (editarRegistro.ruptura_um == "Não" && editarRegistro.prejudique_um == "Não" && editarRegistro.rompimento_um == "Não" && editarRegistro.rasgo_um == "Não" && editarRegistro.afundamento_um == "Não")
                    {
                        editarRegistro.conforme_um = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_um = "NC";
                    }

                    if (editarRegistro.ruptura_dois == "Não" && editarRegistro.prejudique_dois == "Não" && editarRegistro.rompimento_dois == "Não" && editarRegistro.rasgo_dois == "Não" && editarRegistro.afundamento_dois == "Não")
                    {
                        editarRegistro.conforme_dois = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_dois = "NC";
                    }

                    if (editarRegistro.impac_dois_a == "Sim" && editarRegistro.impac_dois_b == "Sim" && editarRegistro.impac_dois_c == "Sim" && editarRegistro.impac_dois_d == "Sim" && editarRegistro.impac_dois_g == "Sim" && editarRegistro.impac_dois_i == "Sim" && editarRegistro.impac_dois_j == "Sim")
                    {
                        editarRegistro.confome_ponto_b = "C";
                    }
                    else
                    {
                        editarRegistro.confome_ponto_b = "NC";
                    }
                    //fim dos resultados de conforme ou nao conforme..

                    _context.Update(editarRegistro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioImpactoEspuma", new { os, orcamento });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarBaseDurabilidadeEstrutural(string os, string orcamento, ColetaModel.EnsaioBaseDurabilidadeEstrutural salvarDados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_durabilidade_estrutural.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    //recebendo os valores do html.
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    DateOnly data_ini_ens = salvarDados.data_ini_ens;
                    DateOnly data_term_ens = salvarDados.data_term_ens;
                    TimeOnly hora_ini = salvarDados.hora_ini;
                    TimeOnly hora_term = salvarDados.hora_term;
                    string temp_max = salvarDados.temp_max;
                    string temp_min = salvarDados.temp_min;
                    string suportou = salvarDados.suportou;
                    string ruptura = salvarDados.ruptura;
                    string quebra = salvarDados.quebra;
                    string prejudicou = salvarDados.prejudicou;

                    if (ruptura == "Não" && quebra == "Não" && prejudicou == "Não")
                    {
                        salvarDados.conforme = "C";
                    }
                    else
                    {
                        salvarDados.conforme = "NC";
                    }


                    _context.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("EnsaioBaseEstruturaDurabi", new { os, orcamento });
                }
                else
                {
                    editarRegistro.data_ini = salvarDados.data_ini;
                    editarRegistro.data_term = salvarDados.data_term;
                    editarRegistro.data_ini_ens = salvarDados.data_ini_ens;
                    editarRegistro.data_term_ens = salvarDados.data_term_ens;
                    editarRegistro.hora_ini = salvarDados.hora_ini;
                    editarRegistro.hora_term = salvarDados.hora_term;
                    editarRegistro.temp_max = salvarDados.temp_max;
                    editarRegistro.temp_min = salvarDados.temp_min;
                    editarRegistro.suportou = salvarDados.suportou;
                    editarRegistro.ruptura = salvarDados.ruptura;
                    editarRegistro.quebra = salvarDados.quebra;
                    editarRegistro.prejudicou = salvarDados.prejudicou;

                    if (editarRegistro.ruptura == "Não" && editarRegistro.quebra == "Não" && editarRegistro.prejudicou == "Não")
                    {
                        editarRegistro.conforme = "C";
                    }
                    else
                    {
                        editarRegistro.conforme = "NC";
                    }


                    _context.Update(editarRegistro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioBaseEstruturaDurabi", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> SalvarEspuma4_4(string os, string orcamento, ColetaModel.EnsaioEspuma4_4 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_espuma_item_4_4.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    _context.ensaio_espuma_item_4_4.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction(nameof(Espuma4_4), "Coleta", new { os, orcamento });
                }
                else
                {
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.superior_horizontal = salvarDados.superior_horizontal;
                    editarDados.inferior_horizontal = salvarDados.inferior_horizontal;

                    _context.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction(nameof(Espuma4_4), "Coleta", new { os, orcamento });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarCargaEstatica(string os, string orcamento, ColetaModel.CargasEstatica salvarDados)
        {
            try
            {
                var editarRegistro = _context.ensaio_base_carga_estatica.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarRegistro == null)
                {
                    _context.ensaio_base_carga_estatica.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("EnsaioBaseCargaEstatica", new { os, orcamento });
                }
                else
                {
                    //editando os dados recebido do html
                    editarRegistro.data_ini = salvarDados.data_ini;
                    editarRegistro.data_term = salvarDados.data_term;
                    editarRegistro.data_ini_ens = salvarDados.data_ini_ens;
                    editarRegistro.data_term_ens = salvarDados.data_term_ens;
                    editarRegistro.hora_ensaio = salvarDados.hora_ensaio;
                    editarRegistro.term_ensaio = salvarDados.term_ensaio;
                    editarRegistro.temp_min = salvarDados.temp_min;
                    editarRegistro.temp_max = salvarDados.temp_max;
                    editarRegistro.local_aplicado = salvarDados.local_aplicado;
                    editarRegistro.forca_aplicada = salvarDados.forca_aplicada;
                    editarRegistro.aplicacao_carga = salvarDados.aplicacao_carga;
                    editarRegistro.suportou_aplicacao = salvarDados.suportou_aplicacao;
                    editarRegistro.ruptura = salvarDados.ruptura;
                    editarRegistro.afundamento = salvarDados.afundamento;
                    editarRegistro.rasgo = salvarDados.rasgo;
                    editarRegistro.rompimento = salvarDados.rompimento;
                    editarRegistro.prejudique = salvarDados.prejudique;

                    _context.ensaio_base_carga_estatica.Update(editarRegistro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("EnsaioBaseCargaEstatica", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        //[Route("Molas/teste")]
        //[HttpPost]
        //public IActionResult editar(Teste testee)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(testee);
        //        _context.SaveChanges();
        //        TempData["Mensagem"] = "Dados editado Com Sucesso";
        //        return RedirectToAction("teste");

        //    }
        //    return View("teste");
        //}
    }
}
