﻿using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using NuGet.Versioning;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
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
        public IActionResult IndexLamina(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Laminas/IndexLamina");
        }
        public IActionResult EditarLamina(string os, string orcamento)
        {
            var dados = _context.regtro_colchao_lamina.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Laminas/EditarLamina", dados);
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
            return View("Espuma/EditarIndexEspuma", dados);
        }

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
            var Inicial = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var dados = _context.ensaio_espuma4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.infantil = Inicial.tipo_colchao;
                return View("Espuma/EnsaioEspuma4_3", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.infantil = Inicial.tipo_colchao;
                return View("Espuma/EnsaioEspuma4_3");
            }
        }
        public IActionResult IdentificacaoEmbalagem(string os, string orcamento)
        {
            var visualizarDados = _context.regtro_colchao_espuma.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var EnsaioEspuma4_1 = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (EnsaioEspuma4_1 == null)
            {
                TempData["Mensagem"] = "É necessario gravar o ensaio de espuma 4.1 para gravar esse ensaio.";
                return View("Espuma/IdentificacaoEmbalagem");
            }

            var dados = _context.espuma_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.outrosMateriais = visualizarDados.outros_materia;
                ViewBag.antiReflexo = visualizarDados.anti_reflexo;
                ViewBag.tipoColchao = visualizarDados.tipo_colchao;
                ViewBag.tipLamina = EnsaioEspuma4_1.lamina_um;
                return View("Espuma/IdentificacaoEmbalagem", dados);
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.outrosMateriais = visualizarDados.outros_materia;
                ViewBag.antiReflexo = visualizarDados.anti_reflexo;
                ViewBag.tipoColchao = visualizarDados.tipo_colchao;
                ViewBag.tipLamina = EnsaioEspuma4_1.lamina_um;
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
            var buscarInformacao = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

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
                ViewBag.comprimento = (buscarInformacao.comprimento_esp * 10) / 2;
                ViewBag.largura = (buscarInformacao.largura_esp * 10) / 2;
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
            var buscarInformacao = _context.ensaio_espuma4_1.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                ViewBag.comprimento = buscarInformacao.comprimento_esp * 10;
                ViewBag.largura = buscarInformacao.largura_esp * 10;
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

        public IActionResult LaminaDeterminacaoDensidade(string os, string orcamento)
        {
            var dados = _context.lamina_determinacao_densidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaDeterminacaoDensidade");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaDeterminacaoDensidade", dados);
            }

        }

        public IActionResult LamindaDeterminacaoResiliencia(string os, string orcamento)
        {
            var dados = _context.lamina_resiliencia.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LamindaDeterminacaoResiliencia");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LamindaDeterminacaoResiliencia", dados);
            }

        }
        public IActionResult LaminaDPC(string os, string orcamento)
        {
            var dados = _context.lamina_dpc.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaDPC");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaDPC", dados);
            }
        }

        public IActionResult LaminaFadiga(string os, string orcamento)
        {
            var dados = _context.lamina_fadiga_dinamica.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            //buscar resultados para inserir na tabela do ensaio atraves da view bag.
            var buscarFI = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

            if (buscarFI == null)
            {
                TempData["Mensagem"] = "ATENÇÃO!! REALIZE O ENSAIO DE F.I PRIMEIRO PARA REALIZAR O ENSAIO DE FADIGA, ESTAMOS TE REDIRICIONANDO PARA A PAGINA.";
                return RedirectToAction(nameof(LaminaF_I),"Coleta", new { os, orcamento });
            }

            if (dados == null)
            {
                //viewbags para buscar os dados da tabela.
                //largura.
                ViewBag.lar_amostra_um_um = buscarFI.lar_amostra_um_um;
                ViewBag.lar_amostra_um_dois = buscarFI.lar_amostra_um_dois;
                ViewBag.lar_amostra_um_tres = buscarFI.lar_amostra_um_tres;
                ViewBag.lar_amostra_um_quatro = buscarFI.lar_amostra_um_quatro;

                ViewBag.lar_amostra_dois_um = buscarFI.lar_amostra_dois_um;
                ViewBag.lar_amostra_dois_dois = buscarFI.lar_amostra_dois_dois;
                ViewBag.lar_amostra_dois_tres = buscarFI.lar_amostra_dois_tres;
                ViewBag.lar_amostra_dois_quatro = buscarFI.lar_amostra_dois_quatro;

                ViewBag.lar_amostra_tres_um = buscarFI.lar_amostra_um_tres;
                ViewBag.lar_amostra_tres_dois = buscarFI.lar_amostra_tres_dois;
                ViewBag.lar_amostra_tres_tres = buscarFI.lar_amostra_tres_tres;
                ViewBag.lar_amostra_tres_quatro = buscarFI.lar_amostra_tres_quatro;

                ViewBag.lar_media_um = buscarFI.lar_media_um;
                ViewBag.lar_media_dois = buscarFI.lar_media_dois;
                ViewBag.lar_media_tres = buscarFI.lar_media_tres;
                //comprimento.
                ViewBag.comp_amostra_um_um = buscarFI.comp_amostra_um_um;
                ViewBag.comp_amostra_um_dois = buscarFI.comp_amostra_um_dois;
                ViewBag.comp_amostra_um_tres = buscarFI.comp_amostra_um_tres;
                ViewBag.comp_amostra_um_quatro = buscarFI.comp_amostra_um_quatro;

                ViewBag.comp_amostra_dois_um = buscarFI.comp_amostra_dois_um;
                ViewBag.comp_amostra_dois_dois = buscarFI.comp_amostra_dois_dois;
                ViewBag.comp_amostra_dois_tres = buscarFI.comp_amostra_dois_tres;
                ViewBag.comp_amostra_dois_quatro = buscarFI.comp_amostra_dois_quatro;

                ViewBag.comp_amostra_tres_um = buscarFI.comp_amostra_tres_um;
                ViewBag.comp_amostra_tres_dois = buscarFI.comp_amostra_tres_dois;
                ViewBag.comp_amostra_tres_tres = buscarFI.comp_amostra_tres_tres;
                ViewBag.comp_amostra_tres_quatro = buscarFI.comp_amostra_tres_quatro;

                ViewBag.comp_media_um = buscarFI.comp_media_um;
                ViewBag.comp_media_dois = buscarFI.comp_media_dois;
                ViewBag.comp_media_tres = buscarFI.comp_media_tres;
                //espessura inicial
                ViewBag.esp_ini_amostra_um_um = buscarFI.esp_ini_amostra_um_um;
                ViewBag.esp_ini_amostra_um_dois = buscarFI.esp_ini_amostra_um_dois;
                ViewBag.esp_ini_amostra_um_tres = buscarFI.esp_ini_amostra_um_tres;
                ViewBag.esp_ini_amostra_um_quatro = buscarFI.esp_ini_amostra_um_quatro;
                ViewBag.esp_ini_amostra_um_cinco = buscarFI.esp_ini_amostra_um_cinco;
                ViewBag.esp_ini_amostra_um_seis = buscarFI.esp_ini_amostra_um_seis;
                ViewBag.esp_ini_amostra_um_sete = buscarFI.esp_ini_amostra_um_sete;
                ViewBag.esp_ini_amostra_um_oito = buscarFI.esp_ini_amostra_um_oito;

                ViewBag.esp_ini_amostra_dois_um = buscarFI.esp_ini_amostra_dois_um;
                ViewBag.esp_ini_amostra_dois_dois = buscarFI.esp_ini_amostra_dois_dois;
                ViewBag.esp_ini_amostra_dois_tres = buscarFI.esp_ini_amostra_dois_tres;
                ViewBag.esp_ini_amostra_dois_quatro = buscarFI.esp_ini_amostra_dois_quatro;
                ViewBag.esp_ini_amostra_dois_cinco = buscarFI.esp_ini_amostra_dois_cinco;
                ViewBag.esp_ini_amostra_dois_seis = buscarFI.esp_ini_amostra_dois_seis;
                ViewBag.esp_ini_amostra_dois_sete = buscarFI.esp_ini_amostra_dois_sete;
                ViewBag.esp_ini_amostra_dois_oito = buscarFI.esp_ini_amostra_dois_oito;

                ViewBag.esp_ini_amostra_dois_um = buscarFI.esp_ini_amostra_dois_um;
                ViewBag.esp_ini_amostra_dois_dois = buscarFI.esp_ini_amostra_dois_dois;
                ViewBag.esp_ini_amostra_dois_tres = buscarFI.esp_ini_amostra_dois_tres;
                ViewBag.esp_ini_amostra_dois_quatro = buscarFI.esp_ini_amostra_dois_quatro;
                ViewBag.esp_ini_amostra_dois_cinco = buscarFI.esp_ini_amostra_dois_cinco;
                ViewBag.esp_ini_amostra_dois_seis = buscarFI.esp_ini_amostra_dois_seis;
                ViewBag.esp_ini_amostra_dois_sete = buscarFI.esp_ini_amostra_dois_sete;
                ViewBag.esp_ini_amostra_dois_oito = buscarFI.esp_ini_amostra_dois_oito;

                ViewBag.esp_ini_amostra_tres_um = buscarFI.esp_ini_amostra_tres_um;
                ViewBag.esp_ini_amostra_tres_dois = buscarFI.esp_ini_amostra_tres_dois;
                ViewBag.esp_ini_amostra_tres_tres = buscarFI.esp_ini_amostra_tres_tres;
                ViewBag.esp_ini_amostra_tres_quatro = buscarFI.esp_ini_amostra_tres_quatro;
                ViewBag.esp_ini_amostra_tres_cinco = buscarFI.esp_ini_amostra_tres_cinco;
                ViewBag.esp_ini_amostra_tres_seis = buscarFI.esp_ini_amostra_tres_seis;
                ViewBag.esp_ini_amostra_tres_sete = buscarFI.esp_ini_amostra_tres_sete;
                ViewBag.esp_ini_amostra_tres_oito = buscarFI.esp_ini_amostra_tres_oito;

                ViewBag.esp_media_um = buscarFI.esp_media_um;
                ViewBag.esp_media_dois = buscarFI.esp_media_dois;
                ViewBag.esp_media_tres = buscarFI.esp_media_tres;
                //media espessura
                ViewBag.media_espessura_um = buscarFI.media_espessura_um;
                ViewBag.media_espessura_dois = buscarFI.media_espessura_dois;
                ViewBag.media_espessura_tres = buscarFI.media_espessura_tres;


                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaFadiga");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaFadiga", dados);
            }

        }
        public IActionResult LaminaPFI(string os, string orcamento)
        {
            var buscarFi = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            var buscarFadiga = _context.lamina_fadiga_dinamica.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (buscarFi == null)
            {
                TempData["Mensagem"] = "ATENÇÃO!! REALIZE O ENSAIO DE F.I PRIMEIRO PARA REALIZAR O ENSAIO DE FADIGA, ESTAMOS TE REDIRICIONANDO PARA A PAGINA.";
                return RedirectToAction(nameof(LaminaF_I), "Coleta", new { os, orcamento });
            }

            if (buscarFadiga == null)
            {
                TempData["Mensagem"] = "ATENÇÃO!! REALIZE O ENSAIO DE FADIGA PRIMEIRO PARA REALIZAR O ENSAIO DE FADIGA, ESTAMOS TE REDIRICIONANDO PARA A PAGINA.";
                return RedirectToAction(nameof(LaminaFadiga), "Coleta", new { os, orcamento });
            }

            var dados = _context.lamina_pfi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                //recebendo os valores para mostrar na tela quando for nullo, 
                //largura.
                ViewBag.lar_amostra_um_um = buscarFi.lar_amostra_um_um;
                ViewBag.lar_amostra_um_dois = buscarFi.lar_amostra_um_dois;
                ViewBag.lar_amostra_um_tres = buscarFi.lar_amostra_um_tres;
                ViewBag.lar_amostra_um_quatro = buscarFi.lar_amostra_um_quatro;

                ViewBag.lar_amostra_dois_um = buscarFi.lar_amostra_dois_um;
                ViewBag.lar_amostra_dois_dois = buscarFi.lar_amostra_dois_dois;
                ViewBag.lar_amostra_dois_tres = buscarFi.lar_amostra_dois_tres;
                ViewBag.lar_amostra_dois_quatro = buscarFi.lar_amostra_dois_quatro;

                ViewBag.lar_amostra_tres_um = buscarFi.lar_amostra_um_tres;
                ViewBag.lar_amostra_tres_dois = buscarFi.lar_amostra_tres_dois;
                ViewBag.lar_amostra_tres_tres = buscarFi.lar_amostra_tres_tres;
                ViewBag.lar_amostra_tres_quatro = buscarFi.lar_amostra_tres_quatro;

                ViewBag.lar_media_um = buscarFi.lar_media_um;
                ViewBag.lar_media_dois = buscarFi.lar_media_dois;
                ViewBag.lar_media_tres = buscarFi.lar_media_tres;
                //comprimento.
                ViewBag.comp_amostra_um_um = buscarFi.comp_amostra_um_um;
                ViewBag.comp_amostra_um_dois = buscarFi.comp_amostra_um_dois;
                ViewBag.comp_amostra_um_tres = buscarFi.comp_amostra_um_tres;
                ViewBag.comp_amostra_um_quatro = buscarFi.comp_amostra_um_quatro;

                ViewBag.comp_amostra_dois_um = buscarFi.comp_amostra_dois_um;
                ViewBag.comp_amostra_dois_dois = buscarFi.comp_amostra_dois_dois;
                ViewBag.comp_amostra_dois_tres = buscarFi.comp_amostra_dois_tres;
                ViewBag.comp_amostra_dois_quatro = buscarFi.comp_amostra_dois_quatro;

                ViewBag.comp_amostra_tres_um = buscarFi.comp_amostra_tres_um;
                ViewBag.comp_amostra_tres_dois = buscarFi.comp_amostra_tres_dois;
                ViewBag.comp_amostra_tres_tres = buscarFi.comp_amostra_tres_tres;
                ViewBag.comp_amostra_tres_quatro = buscarFi.comp_amostra_tres_quatro;

                ViewBag.comp_media_um = buscarFi.comp_media_um;
                ViewBag.comp_media_dois = buscarFi.comp_media_dois;
                ViewBag.comp_media_tres = buscarFi.comp_media_tres;
                //espessura final para jogar na tabela.

                ViewBag.esp_final_amostra_um_um = buscarFadiga.esp_final_amostra_um_um;
                ViewBag.esp_final_amostra_um_dois = buscarFadiga.esp_final_amostra_um_dois;
                ViewBag.esp_final_amostra_um_tres = buscarFadiga.esp_final_amostra_um_tres;
                ViewBag.esp_final_amostra_um_quatro = buscarFadiga.esp_final_amostra_um_quatro;
                ViewBag.esp_final_amostra_um_cinco = buscarFadiga.esp_final_amostra_um_cinco;
                ViewBag.esp_final_amostra_um_seis = buscarFadiga.esp_final_amostra_um_seis;
                ViewBag.esp_final_amostra_um_sete = buscarFadiga.esp_final_amostra_um_sete;
                ViewBag.esp_final_amostra_um_oito = buscarFadiga.esp_final_amostra_um_oito;

                ViewBag.esp_final_amostra_dois_um = buscarFadiga.esp_final_amostra_dois_um;
                ViewBag.esp_final_amostra_dois_dois = buscarFadiga.esp_final_amostra_dois_dois;
                ViewBag.esp_final_amostra_dois_tres = buscarFadiga.esp_final_amostra_dois_tres;
                ViewBag.esp_final_amostra_dois_quatro = buscarFadiga.esp_final_amostra_dois_quatro;
                ViewBag.esp_final_amostra_dois_cinco = buscarFadiga.esp_final_amostra_dois_cinco;
                ViewBag.esp_final_amostra_dois_seis = buscarFadiga.esp_final_amostra_dois_seis;
                ViewBag.esp_final_amostra_dois_sete = buscarFadiga.esp_final_amostra_dois_sete;
                ViewBag.esp_final_amostra_dois_oito = buscarFadiga.esp_final_amostra_dois_oito;

                ViewBag.esp_final_amostra_tres_um = buscarFadiga.esp_final_amostra_tres_um;
                ViewBag.esp_final_amostra_tres_dois = buscarFadiga.esp_final_amostra_tres_dois;
                ViewBag.esp_final_amostra_tres_tres = buscarFadiga.esp_final_amostra_tres_tres;
                ViewBag.esp_final_amostra_tres_quatro = buscarFadiga.esp_final_amostra_tres_quatro;
                ViewBag.esp_final_amostra_tres_cinco = buscarFadiga.esp_final_amostra_tres_cinco;
                ViewBag.esp_final_amostra_tres_seis = buscarFadiga.esp_final_amostra_tres_seis;
                ViewBag.esp_final_amostra_tres_sete = buscarFadiga.esp_final_amostra_tres_sete;
                ViewBag.esp_final_amostra_tres_oito = buscarFadiga.esp_final_amostra_tres_oito;

                ViewBag.media_esp_fin_um = buscarFadiga.media_esp_fin_um;
                ViewBag.media_esp_fin_dois = buscarFadiga.media_esp_fin_dois;
                ViewBag.media_esp_fin_tres = buscarFadiga.media_esp_fin_tres;



                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaPFI");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaPFI", dados);
            }

        }
        public IActionResult LaminaF_I(string os, string orcamento)
        {
            var dados = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
            if (dados == null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaF_I");
            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Laminas/LaminaF_I", dados);
            }
        }

        public IActionResult EnviarFotos(string os, string orcamento)
        {
            int novaOs = int.Parse(os);
            var dados = _context.colchao_anexos.Where(x => x.rae == novaOs && x.orcamento == orcamento).ToList();

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


        //INICIO DAS FUNÇÕES PARA SALVAR OS DADOS,
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
                    andamento = "Andamento"

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
        public async Task<IActionResult> salvarLamina(string os, string orcamento, ColetaModel.RegistroLamina salvar)
        {
            try
            {
                salvar.andamento = "Andamento";
                _context.regtro_colchao_lamina.Add(salvar);
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
        public async Task<IActionResult> editarLamina(string os, string orcamento, ColetaModel.RegistroLamina dados)
        {
            try
            {
                var Editardados = _context.regtro_colchao_lamina.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (Editardados != null)
                {
                    //atualizando valores mudados entre dados e editar dados
                    Editardados.quant_recebida = dados.quant_recebida;
                    Editardados.quant_ensaiada = dados.quant_ensaiada;
                    Editardados.data_realizacao_ini = dados.data_realizacao_ini;
                    Editardados.data_realizacao_term = dados.data_realizacao_term;
                    Editardados.num_proc = dados.num_proc;
                    Editardados.cod_ref = dados.cod_ref;
                    Editardados.tipo_cert = dados.tipo_cert;
                    Editardados.modelo_cert = dados.modelo_cert;
                    Editardados.tipo_proc = dados.tipo_proc;



                    _context.regtro_colchao_lamina.Update(dados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados editado Com Sucesso";
                    return RedirectToAction(nameof(Index), "Home", new { os, orcamento });
                }
                else
                {
                    TempData["Mensagem"] = "ERRO AO EDITAR";
                    return RedirectToAction(nameof(EditarLamina), "Coleta", new { os, orcamento });
                }

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
                salvarDados.andamento = "Andamento";


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
                    editarDados.tipo_espuma_2 = salvarDados.tipo_espuma_2;
                    editarDados.tipo_espuma_3 = salvarDados.tipo_espuma_3;
                    editarDados.tipo_espuma_4 = salvarDados.tipo_espuma_4;
                    editarDados.tipo_espuma_5 = salvarDados.tipo_espuma_5;
                    editarDados.quant_laminas = salvarDados.quant_laminas;
                    editarDados.densidade_1 = salvarDados.densidade_1;
                    editarDados.densidade_2 = salvarDados.densidade_2;
                    editarDados.densidade_3 = salvarDados.densidade_3;
                    editarDados.densidade_4 = salvarDados.densidade_4;
                    editarDados.densidade_5 = salvarDados.densidade_5;
                    editarDados.revestimento = salvarDados.revestimento;
                    editarDados.outros_materia = salvarDados.outros_materia;
                    editarDados.anti_reflexo = salvarDados.anti_reflexo;

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
                    editarValores.nome_molejo_dois = EditarRegistros.nome_molejo_dois;
                    editarValores.quant_media_um = EditarRegistros.quant_media_um;
                    editarValores.quant_media_dois = EditarRegistros.quant_media_dois;
                    editarValores.bitola_arame_um = EditarRegistros.bitola_arame_um;
                    editarValores.bitola_arame_dois = EditarRegistros.bitola_arame_dois;
                    editarValores.borda_peri = EditarRegistros.borda_peri;
                    editarValores.isolante = EditarRegistros.isolante;
                    editarValores.latex = EditarRegistros.latex;
                    editarValores.napa_cou_plas = EditarRegistros.napa_cou_plas;
                    editarValores.manual = EditarRegistros.manual;


                    _context.Update(editarValores);
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
                    return RedirectToAction(nameof(EnsaioMolas4_3), "coleta", new { os, orcamento });
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
        public async Task<IActionResult> SalvarEnsaio7_2(string os, string orcamento, [Bind("data_ini,data_term,temp_ini,temp_term,comp_med_1,comp_med_2,comp_med_3,comp_espe,larg_med_1,larg_med_2,larg_med_3,larg_espe,alt_med_1,alt_med_2,alt_med_3,alt_espe,tipo_espuma_1,tipo_espuma_2,tipo_espuma_3,tipo_espuma_4,tipo_espuma_5,tipo_espuma_6,tipo_espuma_7,tipo_espuma_8,tipo_espuma_9,tipo_espuma_10,esp_tipo_esp_1,esp_tipo_esp_2,esp_tipo_esp_3,esp_tipo_esp_4,esp_tipo_esp_5,esp_tipo_esp_6,esp_tipo_esp_7,esp_tipo_esp_8,esp_tipo_esp_9,esp_tipo_esp_10,tem_metalasse,total_metalasse,mate_tipo_espuma_1,mata_esp_tipo_esp_1,mate_tipo_espuma_2,mata_esp_tipo_esp_2,executor,auxiliar")] ColetaModel.Ensaio7_2 salvarDados)
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
                    string tipo_espuma_1 = salvarDados.tipo_espuma_1;
                    string tipo_espuma_2 = salvarDados.tipo_espuma_2;
                    string tipo_espuma_3 = salvarDados.tipo_espuma_3;
                    string tipo_espuma_4 = salvarDados.tipo_espuma_4;
                    string tipo_espuma_5 = salvarDados.tipo_espuma_5;
                    string tipo_espuma_6 = salvarDados.tipo_espuma_6;
                    string tipo_espuma_7 = salvarDados.tipo_espuma_7;
                    string tipo_espuma_8 = salvarDados.tipo_espuma_8;
                    string tipo_espuma_9 = salvarDados.tipo_espuma_9;
                    string tipo_espuma_10 = salvarDados.tipo_espuma_10;
                    float esp_tipo_esp_1 = salvarDados.esp_tipo_esp_1;
                    float esp_tipo_esp_2 = salvarDados.esp_tipo_esp_2;
                    float esp_tipo_esp_3 = salvarDados.esp_tipo_esp_3;
                    float esp_tipo_esp_4 = salvarDados.esp_tipo_esp_4;
                    float esp_tipo_esp_5 = salvarDados.esp_tipo_esp_5;
                    float esp_tipo_esp_6 = salvarDados.esp_tipo_esp_6;
                    float esp_tipo_esp_7 = salvarDados.esp_tipo_esp_7;
                    float esp_tipo_esp_8 = salvarDados.esp_tipo_esp_8;
                    float esp_tipo_esp_9 = salvarDados.esp_tipo_esp_9;
                    float esp_tipo_esp_10 = salvarDados.esp_tipo_esp_10;
                    string tem_metalasse = salvarDados.tem_metalasse;
                    string total_metalasse = salvarDados.total_metalasse;
                    string mate_tipo_espuma_1 = salvarDados.mate_tipo_espuma_1;
                    float mata_esp_tipo_esp_1 = salvarDados.mata_esp_tipo_esp_1;
                    string mate_tipo_espuma_2 = salvarDados.mate_tipo_espuma_2;
                    float mata_esp_tipo_esp_2 = salvarDados.mata_esp_tipo_esp_2;
                    string conformidade = string.Empty;
                    string conformidade_mat = string.Empty;



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

                    //conforme ou nao conform,estofamento.

                    if (esp_tipo_esp_1 != 0 && esp_tipo_esp_1 <= 19 || esp_tipo_esp_2 != 0 && esp_tipo_esp_2 <= 19 || esp_tipo_esp_3 != 0 && esp_tipo_esp_3 <= 19 || esp_tipo_esp_4 != 0 && esp_tipo_esp_4 <= 19 || esp_tipo_esp_5 != 0 && esp_tipo_esp_5 <= 19 || esp_tipo_esp_6 != 0 && esp_tipo_esp_6 <= 20 || esp_tipo_esp_7 != 0 && esp_tipo_esp_7 <= 19 || esp_tipo_esp_8 != 0 && esp_tipo_esp_8 <= 19 || esp_tipo_esp_9 != 0 && esp_tipo_esp_9 <= 19)
                    {
                        conformidade = "NC";
                    }
                    else
                    {
                        conformidade = "C";
                    }
                    //conforme ou nao conform,metalasse.
                    if (mata_esp_tipo_esp_1 != 0 && mata_esp_tipo_esp_1 > 9 || mata_esp_tipo_esp_2 != 0 && mata_esp_tipo_esp_2 > 9)
                    {
                        conformidade_mat = "C";
                    }
                    else
                    {
                        conformidade_mat = "NC";
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
                        tipo_espuma_1 = tipo_espuma_1,
                        tipo_espuma_2 = tipo_espuma_2,
                        tipo_espuma_3 = tipo_espuma_3,
                        tipo_espuma_4 = tipo_espuma_4,
                        tipo_espuma_5 = tipo_espuma_5,
                        tipo_espuma_6 = tipo_espuma_6,
                        tipo_espuma_7 = tipo_espuma_7,
                        tipo_espuma_8 = tipo_espuma_8,
                        tipo_espuma_9 = tipo_espuma_9,
                        tipo_espuma_10 = tipo_espuma_10,
                        esp_tipo_esp_1 = esp_tipo_esp_1,
                        esp_tipo_esp_2 = esp_tipo_esp_2,
                        esp_tipo_esp_3 = esp_tipo_esp_3,
                        esp_tipo_esp_4 = esp_tipo_esp_4,
                        esp_tipo_esp_5 = esp_tipo_esp_5,
                        esp_tipo_esp_6 = esp_tipo_esp_6,
                        esp_tipo_esp_7 = esp_tipo_esp_7,
                        esp_tipo_esp_8 = esp_tipo_esp_8,
                        esp_tipo_esp_9 = esp_tipo_esp_9,
                        esp_tipo_esp_10 = esp_tipo_esp_10,
                        tem_metalasse = tem_metalasse,
                        total_metalasse = total_metalasse,
                        mate_tipo_espuma_1 = mate_tipo_espuma_1,
                        mata_esp_tipo_esp_1 = mata_esp_tipo_esp_1,
                        mate_tipo_espuma_2 = mate_tipo_espuma_2,
                        mata_esp_tipo_esp_2 = mata_esp_tipo_esp_2,
                        conformidade = conformidade,
                        conformidade_mat = conformidade_mat
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
                    editarDados.tipo_espuma_1 = salvarDados.tipo_espuma_1;
                    editarDados.tipo_espuma_2 = salvarDados.tipo_espuma_2;
                    editarDados.tipo_espuma_3 = salvarDados.tipo_espuma_3;
                    editarDados.tipo_espuma_4 = salvarDados.tipo_espuma_4;
                    editarDados.tipo_espuma_5 = salvarDados.tipo_espuma_5;
                    editarDados.tipo_espuma_6 = salvarDados.tipo_espuma_6;
                    editarDados.tipo_espuma_7 = salvarDados.tipo_espuma_7;
                    editarDados.tipo_espuma_8 = salvarDados.tipo_espuma_8;
                    editarDados.tipo_espuma_9 = salvarDados.tipo_espuma_9;
                    editarDados.tipo_espuma_10 = salvarDados.tipo_espuma_10;
                    editarDados.esp_tipo_esp_1 = salvarDados.esp_tipo_esp_1;
                    editarDados.esp_tipo_esp_2 = salvarDados.esp_tipo_esp_2;
                    editarDados.esp_tipo_esp_3 = salvarDados.esp_tipo_esp_3;
                    editarDados.esp_tipo_esp_4 = salvarDados.esp_tipo_esp_4;
                    editarDados.esp_tipo_esp_5 = salvarDados.esp_tipo_esp_5;
                    editarDados.esp_tipo_esp_6 = salvarDados.esp_tipo_esp_6;
                    editarDados.esp_tipo_esp_7 = salvarDados.esp_tipo_esp_7;
                    editarDados.esp_tipo_esp_8 = salvarDados.esp_tipo_esp_8;
                    editarDados.esp_tipo_esp_9 = salvarDados.esp_tipo_esp_9;
                    editarDados.esp_tipo_esp_10 = salvarDados.esp_tipo_esp_10;
                    editarDados.tem_metalasse = salvarDados.tem_metalasse;
                    editarDados.total_metalasse = salvarDados.total_metalasse;
                    editarDados.mate_tipo_espuma_1 = salvarDados.mate_tipo_espuma_1;
                    editarDados.mata_esp_tipo_esp_1 = salvarDados.mata_esp_tipo_esp_1;
                    editarDados.mate_tipo_espuma_2 = salvarDados.mate_tipo_espuma_2;
                    editarDados.mata_esp_tipo_esp_2 = salvarDados.mata_esp_tipo_esp_2;



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

                    //conforme ou nao conform,estofamento.

                    if (editarDados.esp_tipo_esp_1 != 0 && editarDados.esp_tipo_esp_1 <= 19 || editarDados.esp_tipo_esp_2 != 0 && editarDados.esp_tipo_esp_2 <= 19 || editarDados.esp_tipo_esp_3 != 0 && editarDados.esp_tipo_esp_3 <= 19 || editarDados.esp_tipo_esp_4 != 0 && editarDados.esp_tipo_esp_4 <= 19 || editarDados.esp_tipo_esp_5 != 0 && editarDados.esp_tipo_esp_5 <= 19 || editarDados.esp_tipo_esp_6 != 0 && editarDados.esp_tipo_esp_6 <= 19 || editarDados.esp_tipo_esp_7 != 0 && editarDados.esp_tipo_esp_7 <= 19 || editarDados.esp_tipo_esp_8 != 0 && editarDados.esp_tipo_esp_8 <= 19 || editarDados.esp_tipo_esp_9 != 0 && editarDados.esp_tipo_esp_9 <= 19)
                    {
                        editarDados.conformidade = "NC";
                    }
                    else
                    {
                        editarDados.conformidade = "C";
                    }
                    //conforme ou nao conform,metalasse.
                    if (editarDados.mata_esp_tipo_esp_1 != 0 && editarDados.mata_esp_tipo_esp_1 <= 9 || editarDados.mata_esp_tipo_esp_2 != 0 && editarDados.mata_esp_tipo_esp_2 <= 9)
                    {
                        editarDados.conformidade_mat = "NC";
                    }
                    else
                    {
                        editarDados.conformidade_mat = "C";
                    }

                    editarDados.conforme_comprimento = conforme_comprimento;
                    editarDados.conforme_largura = conform_largura;
                    editarDados.conforme_altura = conform_altura;
                    editarDados.alt_media = media_altura;
                    editarDados.com_media = media_comprimeto;
                    editarDados.larg_media = media_largura;



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
          "lamina_min_cinco,lamina_max_cinco,lamina_resul_cinco,esp_tipo_um,esp_mm_um,esp_cm_um,esp_tipo_dois,esp_mm_dois,esp_cm_dois,col_tipo_um,col_especificado_um,col_encontrado_um,col_resul_um," +
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

                    if (lamina_media_um >= lamina_min_um)
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

                    if (lamina_media_dois >= lamina_min_dois)
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

                    if (lamina_media_tres >= lamina_min_tres)
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

                    if (lamina_media_quat >= lamina_min_quat)
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
                    //realizando calculo do lamina um
                    esp_lamina_um = altura_media;
                    esp_especificado_um = (float)Math.Round(esp_lamina_um / 3, 2);

                    string esp_tipo_dois = salvar.esp_tipo_dois;

                    float esp_lamina_dois = salvar.esp_lamina_dois;
                    float esp_especificado_dois = salvar.esp_especificado_dois;
                    float esp_mm_dois = salvar.esp_mm_dois;
                    float esp_cm_dois = esp_mm_dois / 10;

                    //ralizando calculo do lamina dois
                    esp_lamina_dois = altura_media;
                    esp_especificado_dois = (float)Math.Round(esp_lamina_dois / 3, 2);

                    string col_tipo_um = salvar.col_tipo_um;
                    float col_especificado_um = salvar.col_especificado_um;
                    float col_encontrado_um = salvar.col_encontrado_um;
                    string col_resul_um = salvar.col_resul_um;


                    string col_tipo_dois = salvar.col_tipo_dois;
                    float col_lamina_dois = salvar.col_lamina_dois;
                    float col_especificado_dois = salvar.col_especificado_dois;
                    string col_resul_dois = salvar.col_resul_dois;

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

                    if (editarDados.lamina_media_um >= editarDados.lamina_min_um)
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
                    if (editarDados.lamina_media_dois >= editarDados.lamina_min_dois)
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
                    if (editarDados.lamina_media_tres >= editarDados.lamina_min_tres)
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

                    if (editarDados.lamina_media_quat >= editarDados.lamina_min_quat)
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
                    if (editarDados.lamina_media_um >= editarDados.lamina_min_cinco)
                    {
                        editarDados.lamina_resul_cinco = "C";
                    }
                    else
                    {
                        editarDados.lamina_resul_cinco = "NC";
                    }



                    editarDados.esp_tipo_um = salvar.esp_tipo_um;

                    //realizando calculo do lamina um
                    editarDados.esp_lamina_um = editarDados.altura_media;
                    editarDados.esp_especificado_um = (float)Math.Round(editarDados.esp_lamina_um / 3, 2);

                    editarDados.esp_mm_um = salvar.esp_mm_um;

                    editarDados.esp_cm_um = (editarDados.esp_mm_um / 10);
                    editarDados.esp_tipo_dois = salvar.esp_tipo_dois;

                    //realizando calculo do lamina dois
                    editarDados.esp_lamina_dois = editarDados.altura_media;
                    editarDados.esp_especificado_dois = (float)Math.Round(editarDados.esp_lamina_dois / 3, 2);

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

                    float gramatura = ((media_copos / (area_corpo_1 * area_corpo_2 / 100)) * 10000);



                    //verificando conformidade dos ensaios.
                    if (media_copos >= 100.0f)
                    {
                        conforme_gramas = "C";
                    }
                    else
                    {
                        conforme_gramas = "NC";
                    }

                    if (trincas == "NC" && rompimentos == "NC")
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

                    if (editarDados.trincas == "NC" && editarDados.rompimentos == "NC")
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
                    string conforme = string.Empty;

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

                    if (rasgo == "Sim" || quebra == "Sim")
                    {
                        conforme = "NC";
                    }
                    else
                    {
                        conforme = "C";
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
                        conforme = conforme
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

                    if (editarDados.rasgo == "Sim" || editarDados.quebra == "Sim")
                    {
                        editarDados.conforme = "NC";
                    }
                    else
                    {
                        editarDados.conforme = "C";
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
                    if (rasgo == "Não" && quebra == "Não")
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
                    if (editarDados.rasgo == "Não" && editarDados.quebra == "Não")
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
            "colagem_largura,quant_colagens_quat,localidade,quant_colagens_cinco,espessura_lamina,adesivo,tipo_ensaio")] ColetaModel.Espuma4_3 salvar)
        {
            try
            {
                var editarDados = _context.ensaio_espuma4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {

                    //recebendo os valores recebidos do html..
                    DateOnly data_ini = salvar.data_ini;
                    DateOnly data_term = salvar.data_term;
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
                    string tipo_ensaio = salvar.tipo_ensaio;



                    var salvardados = new ColetaModel.Espuma4_3
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
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
                        tipo_ensaio = tipo_ensaio


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
                    editarDados.tipo_ensaio = salvar.tipo_ensaio;



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
        public async Task<IActionResult> SalvarEmbalagensMolas(string os, string orcamento, [Bind("data_ini,data_term,etiqueta_ident,revest_permanente,etiqueta_duravel_indele,face_superior,visualizacao,lingua_portuguesa,area_etiqueta_1,area_etiqueta_2,cnpj_cpf,cnpj_cpf_2,marca_modelo,dimensoes_prod,informada_altura,composicoes,tipo_molejo,contem_borda,densidade_espuma,composi_revestimento,data_fabricacao,ident_lote,pais_origem,codigo_barras,cuidado_minimos,aviso_esclarecimento,possui_mais_laminas,conforme_r,contem_advertencia,altura_letra,negrito,conforme_s,caixa_alta,contem_advertencia_mat,altura_letra_mat,negrito_mat,caixa_alta_mat,contem_instru_uso,orientacoes,alerta_consumidor,desenho_esquematico,contem_advertencia_6_2,altura_letra_6_2,negrito6_2,caixa_alta_6_2,embalagem_unitaria,embalagem_garante,colchao_disponivel,fixada,conforme_6_2")] ColetaModel.EnsaioIdentificacaoEmbalagem salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //recebendo os valores do html
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    string lingua_portuguesa = salvarDados.lingua_portuguesa;
                    float area_etiqueta_1 = salvarDados.area_etiqueta_1;
                    float area_etiqueta_2 = salvarDados.area_etiqueta_2;
                    string cnpj_cpf = salvarDados.cnpj_cpf;
                    string cnpj_cpf_2 = salvarDados.cnpj_cpf_2;
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
                    string conforme_r = salvarDados.conforme_r;
                    string altura_letra = salvarDados.altura_letra;
                    string negrito = salvarDados.negrito;
                    string conforme_s = salvarDados.conforme_s;
                    string altura_letra_mat = salvarDados.altura_letra_mat;
                    string caixa_alta_mat = salvarDados.caixa_alta_mat;
                    string contem_instru_uso = salvarDados.contem_instru_uso;
                    string orientacoes = salvarDados.orientacoes;
                    string alerta_consumidor = salvarDados.alerta_consumidor;
                    string desenho_esquematico = salvarDados.desenho_esquematico;
                    string altura_letra_6_2 = salvarDados.altura_letra_6_2;
                    string caixa_alta_6_2 = salvarDados.caixa_alta_6_2;
                    string embalagem_unitaria = salvarDados.embalagem_unitaria;
                    string colchao_disponivel = salvarDados.colchao_disponivel;
                    string fixada = salvarDados.fixada;
                    string conforme6_2 = salvarDados.conforme_6_2;

                    // realizando calculo necessario.
                    float calc_media = area_etiqueta_1 * area_etiqueta_2;

                    //VERIFICANDO SE COLETA ESTA CONFORME OU NC DE CADA CAMPO
                    //if (etiqueta_ident == "NC" || revest_permanente == "NC" || etiqueta_duravel_indele == "NC" || face_superior == "NC" || visualizacao == "NC" || lingua_portuguesa == "NC")
                    //{

                    //    if (calc_media >= 150)
                    //    {
                    //        conforme_requisitos = "NC";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos = "C";
                    //    }
                    //}
                    //else
                    //{
                    //    if (calc_media <= 150)
                    //    {
                    //        conforme_requisitos = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos = "NC";
                    //    }
                    //}

                    //if (cnpj_cpf == "NC" || marca_modelo == "NC" || dimensoes_prod == "NC")
                    //{
                    //    conforme_requisitos_2 = "NC";
                    //}
                    //else
                    //{
                    //    conforme_requisitos_2 = "C";

                    //}

                    //if (informada_altura == "NC" || composicoes == "NC" || contem_borda == "NC" || densidade_espuma == "NC" || composi_revestimento == "NC" || data_fabricacao == "NC" || ident_lote == "NC" || pais_origem == "NC" || codigo_barras == "NC" || cuidado_minimos == "NC")
                    //{
                    //    conforme_requisitos_3 = "NC";
                    //}
                    //else
                    //{
                    //    conforme_requisitos_3 = "C";
                    //}

                    //if (aviso_esclarecimento == "NC" || possui_mais_laminas == "NC" || contem_advertencia == "NC" || negrito == "NC" || caixa_alta == "NC" || contem_advertencia_mat == "NC" || negrito_mat == "NC")
                    //{
                    //    if (altura_letra == null)
                    //    {
                    //        altura_letra = "0";
                    //    }
                    //    float conv_altura_letra = float.Parse(altura_letra);

                    //    if (conv_altura_letra >= 2.5)
                    //    {
                    //        conforme_requisitos_4 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos_4 = "NC";
                    //    }
                    //}
                    //else
                    //{
                    //    if (altura_letra == null)
                    //    {
                    //        altura_letra = "0";
                    //    }
                    //    float conv_altura_letra = float.Parse(altura_letra);

                    //    if (conv_altura_letra >= 2.5)
                    //    {
                    //        conforme_requisitos_4 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos_4 = "NC";
                    //    }



                    //}
                    //if (contem_advertencia_mat == "C" || negrito_mat == "C" || caixa_alta_mat == "C")
                    //{
                    //    if (altura_letra_mat == null)
                    //    {
                    //        altura_letra_mat = "0";
                    //    }

                    //    float conv_altura_letra_mat = float.Parse(altura_letra_mat);
                    //    if (conv_altura_letra_mat >= 5)
                    //    {
                    //        conforme_requisitos_5 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos_5 = "NC";
                    //    }
                    //}
                    //else
                    //{
                    //    if (altura_letra_mat == null)
                    //    {
                    //        altura_letra_mat = "0";
                    //    }
                    //    float conv_altura_letra_mat = float.Parse(altura_letra_mat);
                    //    if (conv_altura_letra_mat >= 5)
                    //    {
                    //        conforme_requisitos_5 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_requisitos_5 = "NC";
                    //    }
                    //}


                    //if (contem_advertencia_6_2 == "C" || negrito6_2 == "C" || caixa_alta_6_2 == "C")
                    //{
                    //    if (altura_letra_6_2 == null)
                    //    {
                    //        altura_letra_6_2 = "0";
                    //    }
                    //    float conv_altura_letra_6_2 = float.Parse(altura_letra_6_2);
                    //    if (conv_altura_letra_6_2 >= 5)
                    //    {
                    //        conforme_6_2 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_6_2 = "NC";
                    //    }
                    //}
                    //else
                    //{
                    //    if (altura_letra_6_2 == null)
                    //    {
                    //        altura_letra_6_2 = "0";
                    //    }
                    //    float conv_altura_letra_6_2 = float.Parse(altura_letra_6_2);

                    //    if (conv_altura_letra_6_2 >= 5)
                    //    {
                    //        conforme_6_2 = "C";
                    //    }
                    //    else
                    //    {
                    //        conforme_6_2 = "NC";
                    //    }

                    //}


                    //if (contem_instru_uso == "NC" || orientacoes == "NC" || alerta_consumidor == "NC" || desenho_esquematico == "NC" || contem_advertencia_6_2 == "NC" || altura_letra_6_2 == "NC" || negrito6_2 == "NC" || caixa_alta_6_2 == "NC")
                    //{
                    //    conforme_6_1 = "NC";
                    //}
                    //else
                    //{
                    //    conforme_6_1 = "C";
                    //}

                    //if (embalagem_garante == "NC" || embalagem_unitaria == "NC")
                    //{
                    //    conforme_embalagem = "NC";
                    //}
                    //else
                    //{
                    //    conforme_embalagem = "C";
                    //}
                    //termino das verificações de conformidade.


                    var registro = new ColetaModel.EnsaioIdentificacaoEmbalagem
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        lingua_portuguesa = lingua_portuguesa,
                        area_etiqueta_1 = area_etiqueta_1,
                        area_etiqueta_2 = area_etiqueta_2,
                        area_etiqueta_media = calc_media,
                        cnpj_cpf = cnpj_cpf,
                        cnpj_cpf_2 = cnpj_cpf_2,
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
                        conforme_r = conforme_r,
                        altura_letra = altura_letra,
                        negrito = negrito,
                        conforme_s = conforme_s,
                        altura_letra_mat = altura_letra_mat,
                        caixa_alta_mat = caixa_alta_mat,
                        contem_instru_uso = contem_instru_uso,
                        orientacoes = orientacoes,
                        alerta_consumidor = alerta_consumidor,
                        desenho_esquematico = desenho_esquematico,
                        altura_letra_6_2 = altura_letra_6_2,
                        caixa_alta_6_2 = caixa_alta_6_2,
                        embalagem_unitaria = embalagem_unitaria,
                        colchao_disponivel = colchao_disponivel,
                        fixada = fixada,
                        conforme_6_2 = conforme6_2

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
                    editarDados.altura_letra = salvarDados.altura_letra;
                    editarDados.negrito = salvarDados.negrito;
                    editarDados.altura_letra_mat = salvarDados.altura_letra_mat;
                    editarDados.caixa_alta_mat = salvarDados.caixa_alta_mat;
                    editarDados.contem_instru_uso = salvarDados.contem_instru_uso;
                    editarDados.orientacoes = salvarDados.orientacoes;
                    editarDados.alerta_consumidor = salvarDados.alerta_consumidor;
                    editarDados.desenho_esquematico = salvarDados.desenho_esquematico;
                    editarDados.altura_letra_6_2 = salvarDados.altura_letra_6_2;
                    editarDados.caixa_alta_6_2 = salvarDados.caixa_alta_6_2;


                    //realizando contas necessarias.
                    float calc_media = editarDados.area_etiqueta_1 * editarDados.area_etiqueta_2;

                    //VERIFICANDO SE COLETA ESTA CONFORME OU NC DE CADA CAMPO
                    //if (editarDados.etiqueta_ident == "NC" || editarDados.revest_permanente == "NC" || editarDados.etiqueta_duravel_indele == "NC" || editarDados.face_superior == "NC" || editarDados.visualizacao == "NC" || editarDados.lingua_portuguesa == "NC")
                    //{
                    //    if (calc_media <= 150)
                    //    {
                    //        editarDados.conforme_requisitos = "NC";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos = "C";
                    //    }
                    //}
                    //else
                    //{
                    //    if (calc_media <= 150)
                    //    {
                    //        editarDados.conforme_requisitos = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos = "NC";
                    //    }
                    //}

                    //if (editarDados.cnpj_cpf == "NC" || editarDados.marca_modelo == "NC" || editarDados.dimensoes_prod == "NC")
                    //{
                    //    editarDados.conforme_requisitos_2 = "NC";
                    //}
                    //else
                    //{
                    //    editarDados.conforme_requisitos_2 = "C";

                    //}

                    //if (editarDados.informada_altura == "NC" || editarDados.composicoes == "NC" || editarDados.contem_borda == "NC" || editarDados.densidade_espuma == "NC" || editarDados.composi_revestimento == "NC" || editarDados.data_fabricacao == "NC" || editarDados.ident_lote == "NC" || editarDados.pais_origem == "NC" || editarDados.codigo_barras == "NC" || editarDados.cuidado_minimos == "NC")
                    //{
                    //    editarDados.conforme_requisitos_3 = "NC";
                    //}
                    //else
                    //{
                    //    editarDados.conforme_requisitos_3 = "C";
                    //}

                    //if (editarDados.aviso_esclarecimento == "NC" || editarDados.possui_mais_laminas == "NC" || editarDados.contem_advertencia == "NC" || editarDados.negrito == "NC" || editarDados.caixa_alta == "NC" || editarDados.contem_advertencia_mat == "NC" || editarDados.negrito_mat == "NC")
                    //{

                    //    float conv_altura_letra = float.Parse(editarDados.altura_letra);
                    //    if (conv_altura_letra <= 2.5)
                    //    {
                    //        editarDados.conforme_requisitos_4 = "NC";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos_4 = "C";
                    //    }
                    //}
                    //else
                    //{
                    //    float conv_altura_letra = float.Parse(editarDados.altura_letra);
                    //    if (conv_altura_letra >= 2.5)
                    //    {
                    //        editarDados.conforme_requisitos_4 = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos_4 = "NC";
                    //    }
                    //}

                    //if (editarDados.contem_advertencia_mat == "C" || editarDados.negrito_mat == "C" || editarDados.caixa_alta_mat == "C")
                    //{

                    //    float conv_altura_letra_mat = float.Parse(editarDados.altura_letra_mat);
                    //    if (conv_altura_letra_mat >= 5)
                    //    {
                    //        editarDados.conforme_requisitos_5 = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos_5 = "NC";
                    //    }
                    //}
                    //else
                    //{
                    //    float conv_altura_letra_mat = float.Parse(editarDados.altura_letra_mat);
                    //    if (conv_altura_letra_mat >= 5)
                    //    {
                    //        editarDados.conforme_requisitos_5 = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_requisitos_5 = "NC";
                    //    }
                    //}

                    //if (editarDados.contem_instru_uso == "NC" || editarDados.orientacoes == "NC" || editarDados.alerta_consumidor == "NC" || editarDados.desenho_esquematico == "NC" || editarDados.contem_advertencia_6_2 == "NC" || editarDados.altura_letra_6_2 == "NC" || editarDados.negrito6_2 == "NC" || editarDados.caixa_alta_6_2 == "NC")
                    //{
                    //    editarDados.conforme_6_1 = "NC";
                    //}
                    //else
                    //{
                    //    editarDados.conforme_6_1 = "C";
                    //}

                    //if (editarDados.contem_advertencia_6_2 == "C" || editarDados.negrito6_2 == "C" || editarDados.caixa_alta_6_2 == "C")
                    //{
                    //    float conv_altura_letra_6_2 = float.Parse(editarDados.altura_letra_6_2);
                    //    if (conv_altura_letra_6_2 >= 5)
                    //    {
                    //        editarDados.conforme_6_2 = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_6_2 = "NC";
                    //    }
                    //}
                    //else
                    //{
                    //    float conv_altura_letra_6_2 = float.Parse(editarDados.altura_letra_6_2);
                    //    if (conv_altura_letra_6_2 >= 5)
                    //    {
                    //        editarDados.conforme_6_2 = "C";
                    //    }
                    //    else
                    //    {
                    //        editarDados.conforme_6_2 = "NC";
                    //    }
                    //}

                    //if (editarDados.embalagem_garante == "NC" || editarDados.embalagem_unitaria == "NC")
                    //{
                    //    editarDados.conforme_embalagem = "NC";
                    //}
                    //else
                    //{
                    //    editarDados.conforme_embalagem = "C";
                    //}
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
            "caixa_alta_seis,coloracao_seis,dec_voluntaria,texto_negrito,identificacao,identificacao_dois,desc_lamina,latex,embalagem_uni,embalagem_protecao,observacao,visualizacao,lingua_portuguesa,executador_um,executador_dois,executador_tres,executador_quat")] ColetaModel.Espuma_identificacao_embalagem salvar)
        {

            try
            {
                var editarDados = _context.espuma_identificacao_embalagem.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {

                    //recebendo os valores do html
                    DateOnly data_ini = salvar.data_ini;
                    DateOnly data_term = salvar.data_term;
                    string etiquieta_um = salvar.etiquieta_um;
                    string fixacao = salvar.fixacao;
                    string material = salvar.material;
                    string area_um = salvar.area_um;
                    string area_dois = salvar.area_dois;

                    //realizando calculo.
                    double areaum = double.Parse(area_um);
                    double areadois = double.Parse(area_dois);
                    double calculo_area_result = areaum * areadois;
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
                    string visualizacao = salvar.visualizacao;
                    string lingua_portuguesa = salvar.lingua_portuguesa;
                    string executador_um = salvar.executador_um;
                    string executador_dois = salvar.executador_dois;
                    string executador_tres = salvar.executador_tres;
                    string executador_quat = salvar.executador_quat;


                    //verificação de conformidade dos ensaios.
                    string conforme_inicial = string.Empty;
                    string conforme_letras = string.Empty;
                    string conforme_letras_dois = string.Empty;
                    string conforme_infantil = string.Empty;
                    string conforme2_14_2 = string.Empty;
                    string conforme2_14_3 = string.Empty;
                    string conforme6_2 = string.Empty;

                    if (etiquieta_um == "Sim" && fixacao == "Sim" && material == "Sim" && visualizacao == "Sim" && lingua_portuguesa == "Sim")
                    {
                        if (calculo_area_result > 150)
                        {
                            conforme_inicial = "C";
                        }
                        else
                        {
                            conforme_inicial = "NC";
                        }
                    }
                    else
                    {
                        conforme_inicial = "NC";
                    }

                    //conformidade das perguntas de A ate G
                    if (etiquieta_dois == "Sim" && marca == "Sim" && dimensoes == "Sim" && medidas == "Sim" && tipo_colchao == "Sim" && colchoes == "Sim" && letras == "Sim" && negrito_um == "Sim" && caixa_alta_um == "Sim" && coloracao_um == "Sim" && classificacao == "Sim" && uso == "Sim" && composicao == "Sim" && info_altura == null || info_altura == "Sim" && colchoes == "Sim" || colchoes == null)
                    {
                        conforme_letras = "C";
                    }
                    else
                    {
                        conforme_letras = "NC";
                    }

                    //conformidade dos restante das perguntas..
                    if (tipo_espuma == "Sim" && densidade_nominal == "Sim" && comp_revestimento == "Sim" && data_fabricacao == "Sim" && pais_fabricacao == "Sim" && cuidados == "Sim" && negrito_dois == "Sim" && caixa_alta_dois == "Sim" && negrito_tres == "Sim" && caixa_alta_tres == "Sim" && coloracao_eti == "Sim" && negrito_quat == "Sim" && caixa_alta_quat == "Sim" && coloracao_quat == "Sim" && espessura_mad == "Sim" || espessura_mad == null && aviso_um == "Sim" || aviso_um == null && negrito_dois == "Sim" || negrito_dois == null && caixa_alta_dois == "Sim" || caixa_alta_dois == null && esclarecimento_um == "Sim" || esclarecimento_um == null && negrito_tres == "Sim" || negrito_tres == null && caixa_alta_tres == "Sim" || caixa_alta_tres == null && coloracao_eti == "Sim" || coloracao_eti == null && esclarecimento_dois == "Sim" || esclarecimento_dois == null)
                    {
                        if (int.Parse(altura_letra_dois) >= 3 && int.Parse(altura_letra_tres) >= 3 && int.Parse(altura_letra_quat) >= 3)
                        {
                            conforme_letras_dois = "C";
                        }
                        else
                        {
                            conforme_letras_dois = "NC";
                        }
                    }
                    else
                    {
                        conforme_letras_dois = "NC";
                    }

                    //conformidade colchao infantil.
                    if (ViewBag.tipLamina == "Colchão infantil")
                    {
                        if (colchao_infantil == "Sim" && embalagem_colchao == "Sim" && aviso_embalagem_um == "Sim" && negrito_cinco == "Sim" && caixa_alta_cinco == "Sim" && coloracao_cinco == "Sim" && aviso_embalagem_dois == "Sim" && negrito_seis == "Sim" && caixa_alta_seis == "Sim" && coloracao_seis == "Sim" && dec_voluntaria == "Sim" && texto_negrito == "Sim" && identificacao == "Sim" && identificacao_dois == "Sim")
                        {
                            if (int.Parse(altura_letra_cinco) >= 3 && int.Parse(altura_letra_seis) >= 3)
                            {
                                conforme_infantil = "C";
                            }
                            else
                            {
                                conforme_infantil = "NC";
                            }
                        }
                        else
                        {
                            conforme_infantil = "NC";
                        }
                    }
                    else
                    {
                        conforme_infantil = null;
                    }

                    //conformidade  item 2.14.2 
                    if (ViewBag.tipLamina == "Colchão misto" || ViewBag.tipLamina == "Composto")
                    {
                        if (desc_lamina == "Sim")
                        {
                            conforme2_14_2 = "C";
                        }
                        else
                        {
                            conforme2_14_2 = "NC";
                        }
                    }
                    else
                    {
                        conforme2_14_2 = null;
                    }

                    //confome item 2_14_3
                    if (ViewBag.outrosMateriais == "Lâmina  Latex")
                    {
                        if (latex == "Sim")
                        {
                            conforme2_14_3 = "C";
                        }
                        else
                        {
                            conforme2_14_3 = "NC";
                        }
                    }
                    else
                    {
                        conforme2_14_3 = null;
                    }

                    //conforme item 6.2              
                    if (embalagem_uni == "Sim" && embalagem_protecao == "Sim")
                    {
                        conforme6_2 = "C";
                    }
                    else
                    {
                        conforme6_2 = "NC";
                    }




                    var registro = new ColetaModel.Espuma_identificacao_embalagem
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
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
                        visualizacao = visualizacao,
                        lingua_portuguesa = lingua_portuguesa,
                        conforme_inicial = conforme_inicial,
                        conforme_letras = conforme_letras,
                        conforme_letras_dois = conforme_letras_dois,
                        conforme_infantil = conforme_infantil,
                        conforme_2_14_2 = conforme2_14_2,
                        conforme_2_14_3 = conforme2_14_3,
                        conforme6_2 = conforme6_2,
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
                    editarDados.etiquieta_um = salvar.etiquieta_um;
                    editarDados.fixacao = salvar.fixacao;
                    editarDados.material = salvar.material;
                    editarDados.area_um = salvar.area_um;
                    editarDados.area_dois = salvar.area_dois;

                    double areaum = double.Parse(editarDados.area_um);
                    double areadois = double.Parse(editarDados.area_dois);
                    editarDados.area_result = (areaum * areadois).ToString();


                    //editando os valores par conforme e nao conforme.
                    string conforme_inicial = string.Empty;
                    string conforme_letras = string.Empty;
                    string conforme_letras_dois = string.Empty;
                    string conforme_infantil = string.Empty;
                    string conforme2_14_2 = string.Empty;
                    string conforme2_14_3 = string.Empty;
                    string conforme6_2 = string.Empty;

                    if (editarDados.etiquieta_um == "Sim" && editarDados.fixacao == "Sim" && editarDados.material == "Sim" && editarDados.visualizacao == "Sim" && editarDados.lingua_portuguesa == "Sim")
                    {
                        if (float.Parse(editarDados.area_result) > 150)
                        {
                            conforme_inicial = "C";
                        }
                        else
                        {
                            conforme_inicial = "NC";
                        }
                    }
                    else
                    {
                        conforme_inicial = "NC";
                    }

                    //conformidade das perguntas de A ate G
                    if (editarDados.etiquieta_dois == "Sim" && editarDados.marca == "Sim" && editarDados.dimensoes == "Sim" && editarDados.medidas == "Sim" && editarDados.tipo_colchao == "Sim" && editarDados.colchoes == "Sim" && editarDados.letras == "Sim" && editarDados.negrito_um == "Sim" && editarDados.caixa_alta_um == "Sim" && editarDados.coloracao_um == "Sim" && editarDados.classificacao == "Sim" && editarDados.uso == "Sim" && editarDados.composicao == null && editarDados.info_altura == null || editarDados.info_altura == "Sim" && editarDados.colchoes == "Sim" || editarDados.colchoes == null)
                    {
                        conforme_letras = "C";
                    }
                    else
                    {
                        conforme_letras = "NC";
                    }

                    //conformidade dos restante das perguntas..
                    if (editarDados.tipo_espuma == "Sim" && editarDados.densidade_nominal == "Sim" && editarDados.comp_revestimento == "Sim" && editarDados.data_fabricacao == "Sim" && editarDados.pais_fabricacao == "Sim" && editarDados.cuidados == "Sim" && editarDados.negrito_dois == "Sim" && editarDados.caixa_alta_dois == "Sim" && editarDados.negrito_tres == "Sim" && editarDados.caixa_alta_tres == "Sim" && editarDados.coloracao_eti == "Sim" && editarDados.negrito_quat == "Sim" && editarDados.caixa_alta_quat == "Sim" && editarDados.coloracao_quat == "Sim" && editarDados.espessura_mad == "Sim" || editarDados.espessura_mad == null && editarDados.aviso_um == "Sim" || editarDados.aviso_um == "---" && editarDados.negrito_dois == "Sim" || editarDados.negrito_dois == null && editarDados.caixa_alta_dois == "Sim" || editarDados.caixa_alta_dois == null && editarDados.esclarecimento_um == "Sim" || editarDados.esclarecimento_um == null && editarDados.negrito_tres == "Sim" || editarDados.negrito_tres == null && editarDados.caixa_alta_tres == "Sim" || editarDados.caixa_alta_tres == null && editarDados.coloracao_eti == "Sim" || editarDados.coloracao_eti == null && editarDados.esclarecimento_dois == "Sim" || editarDados.esclarecimento_dois == null)
                    {
                        if (editarDados.altura_letra_dois == null || editarDados.altura_letra_tres == null || editarDados.altura_letra_quat == null)
                        {
                            conforme_letras_dois = "C";
                        }
                        else
                        {
                            conforme_letras_dois = "NC";
                        }
                        //if (int.Parse(editarDados.altura_letra_dois) >= 3 && int.Parse(editarDados.altura_letra_tres) >= 3  && int.Parse(editarDados.altura_letra_quat) >= 3)
                        //{
                        //    conforme_letras_dois = "C";
                        //}

                    }
                    else
                    {
                        conforme_letras_dois = "NC";
                    }

                    //conformidade colchao infantil.
                    if (ViewBag.tipLamina == "Colchão infantil")
                    {
                        if (editarDados.colchao_infantil == "Sim" && editarDados.embalagem_colchao == "Sim" && editarDados.aviso_embalagem_um == "Sim" && editarDados.negrito_cinco == "Sim" && editarDados.caixa_alta_cinco == "Sim" && editarDados.coloracao_cinco == "Sim" && editarDados.aviso_embalagem_dois == "Sim" && editarDados.negrito_seis == "Sim" && editarDados.caixa_alta_seis == "Sim" && editarDados.coloracao_seis == "Sim" && editarDados.dec_voluntaria == "Sim" && editarDados.texto_negrito == "Sim" && editarDados.identificacao == "Sim" && editarDados.identificacao_dois == "Sim")
                        {
                            if (int.Parse(editarDados.altura_letra_cinco) >= 3 && int.Parse(editarDados.altura_letra_seis) >= 3)
                            {
                                conforme_infantil = "C";
                            }
                            else
                            {
                                conforme_infantil = "NC";
                            }
                        }
                        else
                        {
                            conforme_infantil = "NC";
                        }
                    }
                    else
                    {
                        conforme_infantil = null;
                    }

                    //conformidade  item 2.14.2 
                    if (ViewBag.tipLamina == "Colchão misto" || ViewBag.tipLamina == "Composto")
                    {
                        if (editarDados.desc_lamina == "Sim")
                        {
                            conforme2_14_2 = "C";
                        }
                        else
                        {
                            conforme2_14_2 = "NC";
                        }
                    }
                    else
                    {
                        conforme2_14_2 = null;
                    }

                    if (ViewBag.outrosMateriais == "Lâmina  Latex")
                    {
                        if (editarDados.latex == "Sim")
                        {
                            conforme2_14_3 = "C";
                        }
                        else
                        {
                            conforme2_14_3 = "NC";
                        }
                    }
                    else
                    {
                        conforme2_14_3 = null;
                    }

                    //conforme item 6.2              
                    if (editarDados.embalagem_uni == "Sim" && editarDados.embalagem_protecao == "Sim")
                    {
                        conforme6_2 = "C";
                    }
                    else
                    {
                        conforme6_2 = "NC";
                    }


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
                    editarDados.visualizacao = salvar.visualizacao;
                    editarDados.lingua_portuguesa = salvar.lingua_portuguesa;
                    editarDados.executador_um = salvar.executador_um;
                    editarDados.conforme_inicial = conforme_inicial;
                    editarDados.conforme_letras = conforme_letras;
                    editarDados.conforme_letras_dois = conforme_letras_dois;
                    editarDados.conforme_infantil = conforme_infantil;
                    editarDados.conforme_2_14_2 = conforme2_14_2;
                    editarDados.conforme_2_14_3 = conforme2_14_3;
                    editarDados.conforme6_2 = conforme6_2;
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
                    string temp_ini = dados.temp_ini;
                    string temp_term = dados.temp_term;


                    //realizando se esta conforme ou nao conforme
                    if (suportou_ponto_a == "C" && ruptura_ponto_a == "NC" && afundamento_ponto_a == "NC" && rasgo_ponto_a == "NC" && rompimento_ponto_a == "NC" && prejudique_ponto_a == "NC")
                    {
                        dados.conforme_a = "C";
                    }
                    else
                    {
                        dados.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (suportou_ponto_b == "C" && ruptura_ponto_b == "NC" && afundamento_ponto_b == "NC" && rasgo_ponto_b == "NC" && rompimento_ponto_b == "NC" && prejudique_ponto_b == "NC")
                    {
                        dados.conforme_b = "C";
                    }
                    else
                    {
                        dados.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (suportou_ponto_c == "C" && ruptura_ponto_c == "NC" && afundamento_ponto_c == "NC" && rasgo_ponto_c == "NC" && rompimento_ponto_c == "NC" && prejudique_ponto_c == "NC")
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
                    editarRegistro.temp_ini = dados.temp_ini;
                    editarRegistro.temp_term = dados.temp_term;

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.suportou_ponto_a == "C" && editarRegistro.ruptura_ponto_a == "NC" && editarRegistro.afundamento_ponto_a == "NC" && editarRegistro.rasgo_ponto_a == "NC" && editarRegistro.rompimento_ponto_a == "NC" && editarRegistro.prejudique_ponto_a == "NC")
                    {
                        editarRegistro.conforme_a = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_a = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.suportou_ponto_b == "C" && editarRegistro.ruptura_ponto_b == "NC" && editarRegistro.afundamento_ponto_b == "NC" && editarRegistro.rasgo_ponto_b == "NC" && editarRegistro.rompimento_ponto_b == "NC" && editarRegistro.prejudique_ponto_b == "NC")
                    {
                        editarRegistro.conforme_b = "C";
                    }
                    else
                    {
                        editarRegistro.conforme_b = "NC";
                    }

                    //realizando se esta conforme ou nao conforme
                    if (editarRegistro.suportou_ponto_c == "C" && editarRegistro.ruptura_ponto_c == "NC" && editarRegistro.afundamento_ponto_c == "NC" && editarRegistro.rasgo_ponto_c == "NC" && editarRegistro.rompimento_ponto_c == "NC" && editarRegistro.prejudique_ponto_c == "NC")
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
                    string impac_dois_e = salvarDados.impac_dois_e;
                    string impac_dois_i = salvarDados.impac_dois_i;
                    string impac_dois_j = salvarDados.impac_dois_j;
                    string ruptura_dois = salvarDados.ruptura_dois;
                    string afundamento_dois = salvarDados.afundamento_dois;
                    string rasgo_dois = salvarDados.rasgo_dois;
                    string rompimento_dois = salvarDados.rompimento_dois;
                    string prejudique_dois = salvarDados.prejudique_dois;
                    string temp_ini = salvarDados.temp_ini;
                    string temp_term = salvarDados.temp_term;

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
                    editarRegistro.impac_dois_e = salvarDados.impac_dois_e;
                    editarRegistro.impac_dois_i = salvarDados.impac_dois_i;
                    editarRegistro.impac_dois_j = salvarDados.impac_dois_j;
                    editarRegistro.ruptura_dois = salvarDados.ruptura_dois;
                    editarRegistro.afundamento_dois = salvarDados.afundamento_dois;
                    editarRegistro.rasgo_dois = salvarDados.rasgo_dois;
                    editarRegistro.rompimento_dois = salvarDados.rompimento_dois;
                    editarRegistro.prejudique_dois = salvarDados.prejudique_dois;
                    editarRegistro.temp_ini = salvarDados.temp_ini;
                    editarRegistro.temp_term = salvarDados.temp_term;


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
                    TimeOnly hora_ini = salvarDados.hora_ini;
                    TimeOnly hora_term = salvarDados.hora_term;
                    string temp_max = salvarDados.temp_max;
                    string temp_min = salvarDados.temp_min;
                    string suportou = salvarDados.suportou;
                    string ruptura = salvarDados.ruptura;
                    string quebra = salvarDados.quebra;
                    string prejudicou = salvarDados.prejudicou;
                    string temp_ini = salvarDados.temp_ini;
                    string temp_term = salvarDados.temp_term;

                    if (ruptura == "NC" && quebra == "NC" && prejudicou == "NC")
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
                    editarRegistro.hora_ini = salvarDados.hora_ini;
                    editarRegistro.hora_term = salvarDados.hora_term;
                    editarRegistro.temp_max = salvarDados.temp_max;
                    editarRegistro.temp_min = salvarDados.temp_min;
                    editarRegistro.suportou = salvarDados.suportou;
                    editarRegistro.ruptura = salvarDados.ruptura;
                    editarRegistro.quebra = salvarDados.quebra;
                    editarRegistro.prejudicou = salvarDados.prejudicou;
                    editarRegistro.temp_ini = salvarDados.temp_ini;
                    editarRegistro.temp_term = salvarDados.temp_term;

                    if (editarRegistro.ruptura == "NC" && editarRegistro.quebra == "NC" && editarRegistro.prejudicou == "NC")
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
                    if (salvarDados.superior_horizontal == "Não" && salvarDados.inferior_horizontal == "Não")
                    {
                        salvarDados.conforme = "C";
                    }
                    else
                    {
                        salvarDados.conforme = "NC";
                    }

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

                    if (editarDados.superior_horizontal == "Não" && editarDados.inferior_horizontal == "Não")
                    {
                        editarDados.conforme = "C";
                    }
                    else
                    {
                        editarDados.conforme = "NC";
                    }

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

        [HttpPost]
        public async Task<IActionResult> SalvarDeterminacaoDensidade(string os, string orcamento, ColetaModel.SalvarLaminaDeterminacaoDensidade salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_determinacao_densidade.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //realizando calculo da media das amostras..
                    float media_amostra_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.lar_media_um = media_amostra_um;

                    float media_amostra_dois = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.lar_media_dois = media_amostra_dois;

                    float media_amostra_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.lar_media_tres = media_amostra_tres;

                    float media_comp_um = ((salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_um) / 4);
                    salvarDados.comp_media_um = media_comp_um;

                    float media_comp_dois = ((salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_um) / 4);
                    salvarDados.comp_media_dois = media_comp_dois;

                    float media_comp_tres = ((salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_um) / 4);
                    salvarDados.comp_media_tres = media_comp_tres;

                    float media_esp_um = ((salvarDados.esp_amostra_um_um + salvarDados.esp_amostra_um_dois + salvarDados.esp_amostra_um_tres + salvarDados.esp_amostra_um_quat + salvarDados.esp_amostra_um_cinco + salvarDados.esp_amostra_um_seis + salvarDados.esp_amostra_um_sete + salvarDados.esp_amostra_um_oito) / 8);
                    salvarDados.esp_media_um = media_esp_um;

                    float media_esp_dois = ((salvarDados.esp_amostra_dois_um + salvarDados.esp_amostra_dois_dois + salvarDados.esp_amostra_dois_tres + salvarDados.esp_amostra_dois_quat + salvarDados.esp_amostra_dois_cinco + salvarDados.esp_amostra_dois_seis + salvarDados.esp_amostra_dois_sete + salvarDados.esp_amostra_dois_oito) / 8);
                    salvarDados.esp_media_dois = media_esp_dois;

                    float media_esp_tres = ((salvarDados.esp_amostra_tres_um + salvarDados.esp_amostra_tres_dois + salvarDados.esp_amostra_tres_tres + salvarDados.esp_amostra_tres_quat + salvarDados.esp_amostra_tres_cinco + salvarDados.esp_amostra_tres_seis + salvarDados.esp_amostra_tres_sete + salvarDados.esp_amostra_tres_oito) / 8);
                    salvarDados.esp_media_tres = media_esp_tres;

                    // final do calculo da medias de largura, comprimento, e espessura.

                    //inicio calculo total..
                    float vol_calc_amostra_um = ((media_amostra_um * media_comp_um * media_esp_um) / 1000);
                    float vol_calc_amostra_dois = ((media_amostra_dois * media_comp_dois * media_esp_dois) / 1000);
                    float vol_calc_amostra_tres = ((media_amostra_tres * media_comp_tres * media_esp_tres) / 1000);
                    salvarDados.calc_amostra_um = vol_calc_amostra_um;
                    salvarDados.calc_amostra_dois = vol_calc_amostra_dois;
                    salvarDados.calc_amostra_tres = vol_calc_amostra_tres;
                    //final do calculo..

                    //inicio calculo dr..
                    salvarDados.dr_um_um = salvarDados.massa_um;
                    salvarDados.dr_um_dois = vol_calc_amostra_um;
                    salvarDados.dr_resul_um = ((salvarDados.dr_um_um / salvarDados.dr_um_dois) * 1000);

                    salvarDados.dr_dois_um = salvarDados.massa_dois;
                    salvarDados.dr_dois_dois = vol_calc_amostra_dois;
                    salvarDados.dr_resul_dois = ((salvarDados.dr_dois_um / salvarDados.dr_dois_dois) * 1000);

                    salvarDados.dr_tres_um = salvarDados.massa_tres;
                    salvarDados.dr_tres_dois = vol_calc_amostra_tres;
                    salvarDados.dr_resul_tres = ((salvarDados.dr_tres_um / salvarDados.dr_tres_dois) * 1000);

                    salvarDados.dr_media = ((salvarDados.dr_resul_um + salvarDados.dr_resul_dois + salvarDados.dr_resul_tres) / 3);

                    //float inverter_densidade = (salvarDados.densidade * 10) / 100;
                    float densidade_resultado = ((salvarDados.densidade * 10) / 100) + salvarDados.densidade;
                    float densidade_resultado_dois = (((salvarDados.densidade * 10) / 100) - salvarDados.densidade) * -1;

                    if (salvarDados.dr_media >= densidade_resultado_dois && salvarDados.dr_media <= densidade_resultado)
                    {
                        salvarDados.conforme = "C";
                    }
                    else
                    {
                        salvarDados.conforme = "NC";
                    }
                    //salvando minimo e maximo da densidade.
                    salvarDados.maxima_densidade = densidade_resultado;
                    salvarDados.minima_densidade = densidade_resultado_dois;

                    _context.lamina_determinacao_densidade.Add(salvarDados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados salvo com sucesso.";
                    return RedirectToAction("LaminaDeterminacaoDensidade", "Coleta", new { os, orcamento });
                }
                else
                {
                    ////recebendo os valores para editar no html...
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;

                    ////largura
                    editarDados.lar_amostra_um_um = salvarDados.lar_amostra_um_um;
                    editarDados.lar_amostra_um_dois = salvarDados.lar_amostra_um_dois;
                    editarDados.lar_amostra_um_tres = salvarDados.lar_amostra_um_tres;
                    editarDados.lar_amostra_um_quatro = salvarDados.lar_amostra_um_quatro;
                    editarDados.lar_amostra_dois_um = salvarDados.lar_amostra_dois_um;
                    editarDados.lar_amostra_dois_dois = salvarDados.lar_amostra_dois_dois;
                    editarDados.lar_amostra_dois_tres = salvarDados.lar_amostra_dois_tres;
                    editarDados.lar_amostra_dois_quatro = salvarDados.lar_amostra_dois_quatro;
                    editarDados.lar_amostra_tres_um = salvarDados.lar_amostra_tres_um;
                    editarDados.lar_amostra_tres_dois = salvarDados.lar_amostra_tres_dois;
                    editarDados.lar_amostra_tres_tres = salvarDados.lar_amostra_tres_tres;
                    editarDados.lar_amostra_tres_quatro = salvarDados.lar_amostra_tres_quatro;
                    ////comprimento
                    editarDados.comp_amostra_um_um = salvarDados.comp_amostra_um_um;
                    editarDados.comp_amostra_um_dois = salvarDados.comp_amostra_um_dois;
                    editarDados.comp_amostra_um_tres = salvarDados.comp_amostra_um_tres;
                    editarDados.comp_amostra_um_quat = salvarDados.comp_amostra_um_quat;
                    editarDados.comp_amostra_dois_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_dois_dois = salvarDados.comp_amostra_dois_dois;
                    editarDados.comp_amostra_dois_tres = salvarDados.comp_amostra_dois_tres;
                    editarDados.comp_amostra_dois_quat = salvarDados.comp_amostra_dois_quat;
                    editarDados.comp_amostra_tres_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_tres_dois = salvarDados.comp_amostra_tres_dois;
                    editarDados.comp_amostra_tres_tres = salvarDados.comp_amostra_tres_tres;
                    editarDados.comp_amostra_tres_quat = salvarDados.comp_amostra_tres_quat;
                    ////espessura.
                    editarDados.esp_amostra_um_um = salvarDados.esp_amostra_um_um;
                    editarDados.esp_amostra_um_dois = salvarDados.esp_amostra_um_dois;
                    editarDados.esp_amostra_um_tres = salvarDados.esp_amostra_um_tres;
                    editarDados.esp_amostra_um_quat = salvarDados.esp_amostra_um_quat;
                    editarDados.esp_amostra_um_cinco = salvarDados.esp_amostra_um_cinco;
                    editarDados.esp_amostra_um_seis = salvarDados.esp_amostra_um_seis;
                    editarDados.esp_amostra_um_sete = salvarDados.esp_amostra_um_sete;
                    editarDados.esp_amostra_um_oito = salvarDados.esp_amostra_um_oito;
                    editarDados.esp_amostra_dois_um = salvarDados.esp_amostra_um_um;
                    editarDados.esp_amostra_dois_dois = salvarDados.esp_amostra_dois_dois;
                    editarDados.esp_amostra_dois_tres = salvarDados.esp_amostra_dois_tres;
                    editarDados.esp_amostra_dois_quat = salvarDados.esp_amostra_dois_quat;
                    editarDados.esp_amostra_dois_cinco = salvarDados.esp_amostra_dois_cinco;
                    editarDados.esp_amostra_dois_seis = salvarDados.esp_amostra_dois_seis;
                    editarDados.esp_amostra_dois_sete = salvarDados.esp_amostra_dois_sete;
                    editarDados.esp_amostra_dois_oito = salvarDados.esp_amostra_dois_oito;
                    editarDados.esp_amostra_tres_um = salvarDados.esp_amostra_tres_um;
                    editarDados.esp_amostra_tres_dois = salvarDados.esp_amostra_tres_dois;
                    editarDados.esp_amostra_tres_tres = salvarDados.esp_amostra_tres_tres;
                    editarDados.esp_amostra_tres_quat = salvarDados.esp_amostra_tres_quat;
                    editarDados.esp_amostra_tres_cinco = salvarDados.esp_amostra_tres_cinco;
                    editarDados.esp_amostra_tres_seis = salvarDados.esp_amostra_tres_seis;
                    editarDados.esp_amostra_tres_sete = salvarDados.esp_amostra_tres_sete;
                    editarDados.esp_amostra_tres_oito = salvarDados.esp_amostra_tres_oito;
                    editarDados.densidade = salvarDados.densidade;

                    //atualizando a media de cada valor, encontrado.
                    editarDados.lar_media_um = ((editarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + editarDados.lar_amostra_um_tres + editarDados.lar_amostra_um_quatro) / 4);
                    editarDados.lar_media_dois = ((editarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + editarDados.lar_amostra_dois_tres + editarDados.lar_amostra_dois_quatro) / 4);
                    editarDados.lar_media_tres = ((editarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + editarDados.lar_amostra_tres_tres + editarDados.lar_amostra_tres_quatro) / 4);

                    editarDados.comp_media_um = ((editarDados.comp_amostra_um_um + editarDados.comp_amostra_um_dois + editarDados.comp_amostra_um_tres + editarDados.comp_amostra_um_quat) / 4);
                    editarDados.comp_media_dois = ((editarDados.comp_amostra_dois_um + editarDados.comp_amostra_dois_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_dois_quat) / 4);
                    editarDados.comp_media_tres = ((editarDados.comp_amostra_tres_um + editarDados.comp_amostra_tres_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_tres_quat) / 4);

                    editarDados.esp_media_um = ((editarDados.esp_amostra_tres_um + editarDados.esp_amostra_tres_dois + editarDados.esp_amostra_tres_tres + editarDados.esp_amostra_tres_quat + editarDados.esp_amostra_tres_cinco + editarDados.esp_amostra_tres_seis + editarDados.esp_amostra_tres_sete + editarDados.esp_amostra_tres_oito) / 8);
                    editarDados.esp_media_dois = ((editarDados.esp_amostra_dois_um + editarDados.esp_amostra_dois_dois + editarDados.esp_amostra_dois_tres + editarDados.esp_amostra_dois_quat + editarDados.esp_amostra_dois_cinco + editarDados.esp_amostra_dois_seis + editarDados.esp_amostra_dois_sete + editarDados.esp_amostra_dois_oito) / 8);
                    editarDados.esp_media_tres = ((editarDados.esp_amostra_tres_um + editarDados.esp_amostra_tres_dois + editarDados.esp_amostra_tres_tres + editarDados.esp_amostra_tres_quat + editarDados.esp_amostra_tres_cinco + editarDados.esp_amostra_tres_seis + editarDados.esp_amostra_tres_sete + editarDados.esp_amostra_tres_oito) / 8);

                    editarDados.calc_amostra_um = ((editarDados.lar_media_um * editarDados.comp_media_um * editarDados.esp_media_um) / 1000);
                    editarDados.calc_amostra_dois = ((editarDados.lar_media_dois * editarDados.comp_media_dois * editarDados.esp_media_dois) / 1000);
                    editarDados.calc_amostra_tres = ((editarDados.lar_media_tres * editarDados.comp_media_tres * editarDados.esp_media_tres) / 1000);

                    //campo de massa.
                    editarDados.massa_um = salvarDados.massa_um;
                    editarDados.massa_dois = salvarDados.massa_dois;
                    editarDados.massa_tres = salvarDados.massa_tres;

                    //inicio DR
                    editarDados.dr_um_um = editarDados.massa_um;
                    editarDados.dr_um_dois = editarDados.calc_amostra_um;
                    editarDados.dr_resul_um = ((editarDados.dr_um_um / editarDados.dr_um_dois) * 1000);

                    editarDados.dr_dois_um = editarDados.massa_dois;
                    editarDados.dr_dois_dois = editarDados.calc_amostra_dois;
                    editarDados.dr_resul_dois = ((editarDados.dr_dois_um / editarDados.dr_dois_dois) * 1000);

                    editarDados.dr_tres_um = editarDados.massa_tres;
                    editarDados.dr_tres_dois = editarDados.calc_amostra_tres;
                    editarDados.dr_resul_tres = ((editarDados.dr_tres_um / editarDados.dr_tres_dois) * 1000);

                    editarDados.dr_media = ((editarDados.dr_resul_um + editarDados.dr_resul_dois + editarDados.dr_resul_tres) / 3);

                    //float inverter_densidade = (salvarDados.densidade * 10) / 100;
                    float densidade_resultado = ((editarDados.densidade * 10) / 100) + editarDados.densidade;
                    float densidade_resultado_dois = (((editarDados.densidade * 10) / 100) - editarDados.densidade) * -1;

                    if (editarDados.dr_media >= densidade_resultado_dois && editarDados.dr_media <= densidade_resultado)
                    {
                        editarDados.conforme = "C";
                    }
                    else
                    {
                        editarDados.conforme = "NC";

                    }

                    //salvando minimo e maximo da densidade.
                    editarDados.maxima_densidade = densidade_resultado;
                    editarDados.minima_densidade = densidade_resultado_dois;

                    _context.lamina_determinacao_densidade.Update(editarDados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("LaminaDeterminacaoDensidade", "Coleta", new { os, orcamento });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SalvarLaminaResiliencia(string os, string orcamento, ColetaModel.LaminaResiliencia salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_resiliencia.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (editarDados == null)
                {
                    //realizando calculos necessarios, convertendo direto para 2 casas decimais dps da virgula... convertendo para string e float a mesmo tempo.
                    salvarDados.varia_amostra_um_um = float.Parse((((salvarDados.resil_amostra_um_dois - salvarDados.resil_amostra_um_um) / salvarDados.resil_amostra_um_um) * 100).ToString("N2"));
                    salvarDados.varia_amostra_um_dois = float.Parse(((((salvarDados.resil_amostra_um_tres - salvarDados.resil_amostra_um_um) / salvarDados.resil_amostra_um_um) * 100) * -1).ToString("N2"));
                    salvarDados.media_res_um = ((salvarDados.resil_amostra_um_um + salvarDados.resil_amostra_um_dois + salvarDados.resil_amostra_um_tres) / 3);

                    salvarDados.varia_amostra_dois_um = float.Parse(((((salvarDados.resil_amostra_dois_dois - salvarDados.resil_amostra_dois_um) / salvarDados.resil_amostra_dois_um) * 100) * -1).ToString("N2"));
                    salvarDados.varia_amostra_dois_dois = float.Parse(((((salvarDados.resil_amostra_dois_tres - salvarDados.resil_amostra_dois_um) / salvarDados.resil_amostra_dois_um) * 100) * -1).ToString("N2"));
                    salvarDados.media_res_dois = float.Parse(((salvarDados.resil_amostra_dois_um + salvarDados.resil_amostra_dois_dois + salvarDados.resil_amostra_dois_tres) / 3).ToString("N2"));

                    salvarDados.varia_amostra_tres_um = (((salvarDados.resil_amostra_tres_dois - salvarDados.resil_amostra_tres_um) / salvarDados.resil_amostra_tres_um) * 100);
                    salvarDados.varia_amostra_tres_dois = (((salvarDados.resil_amostra_tres_tres - salvarDados.resil_amostra_tres_um) / salvarDados.resil_amostra_tres_um) * 100);
                    salvarDados.media_res_tres = ((salvarDados.resil_amostra_tres_um + salvarDados.resil_amostra_tres_dois + salvarDados.resil_amostra_tres_tres) / 3);

                    salvarDados.resiliencia_enc = ((salvarDados.media_res_um + salvarDados.media_res_dois + salvarDados.media_res_tres) / 3);

                    //conformes
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18 || salvarDados.densidade == 20)
                        {
                            //minimo 30
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 23 || salvarDados.densidade == 26 || salvarDados.densidade == 28 || salvarDados.densidade == 33)
                        {
                            //minimo  35
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //minimo  40 
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Hipermacia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24 || salvarDados.densidade == 29 || salvarDados.densidade >= 35)
                        {
                            //minimo 30 
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Macia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24)
                        {
                            //minimo 35
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade >= 35)
                        {
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Aglomerado")
                    {
                        if (salvarDados.densidade >= 65)
                        {
                            //minimo 25
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //minimo 55
                            if (salvarDados.resiliencia_enc >= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Visco elástica")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //maxima 15
                            if (salvarDados.resiliencia_enc <= salvarDados.resiliencia_esp)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        salvarDados.conforme = "C";
                    }

                    _context.lamina_resiliencia.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados gravado com sucesso.";
                    return RedirectToAction("LamindaDeterminacaoResiliencia", "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os valores do html.
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.densidade = salvarDados.densidade;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;
                    editarDados.resil_amostra_um_dois = salvarDados.resil_amostra_um_dois;
                    editarDados.resil_amostra_um_um = salvarDados.resil_amostra_um_um;
                    editarDados.resil_amostra_um_tres = salvarDados.resil_amostra_um_tres;
                    editarDados.resil_amostra_dois_um = salvarDados.resil_amostra_dois_um;
                    editarDados.resil_amostra_dois_dois = salvarDados.resil_amostra_dois_dois;
                    editarDados.resil_amostra_dois_tres = salvarDados.resil_amostra_dois_tres;
                    editarDados.resil_amostra_tres_um = salvarDados.resil_amostra_tres_um;
                    editarDados.resil_amostra_tres_dois = salvarDados.resil_amostra_tres_dois;
                    editarDados.resil_amostra_tres_tres = salvarDados.resil_amostra_tres_tres;
                    editarDados.resiliencia_esp = salvarDados.resiliencia_esp;

                    //realizando calculos necessarios, convertendo direto para 2 casas decimais dps da virgula... convertendo para string e float a mesmo tempo.
                    editarDados.varia_amostra_um_um = float.Parse((((editarDados.resil_amostra_um_dois - editarDados.resil_amostra_um_um) / editarDados.resil_amostra_um_um) * 100).ToString("N2"));
                    editarDados.varia_amostra_um_dois = float.Parse(((((editarDados.resil_amostra_um_tres - editarDados.resil_amostra_um_um) / editarDados.resil_amostra_um_um) * 100) * -1).ToString("N2"));
                    editarDados.media_res_um = ((editarDados.resil_amostra_um_um + editarDados.resil_amostra_um_dois + editarDados.resil_amostra_um_tres) / 3);

                    editarDados.varia_amostra_dois_um = float.Parse(((((editarDados.resil_amostra_dois_dois - editarDados.resil_amostra_dois_um) / editarDados.resil_amostra_dois_um) * 100) * -1).ToString("N2"));
                    editarDados.varia_amostra_dois_dois = float.Parse(((((editarDados.resil_amostra_dois_tres - editarDados.resil_amostra_dois_um) / editarDados.resil_amostra_dois_um) * 100) * -1).ToString("N2"));
                    editarDados.media_res_dois = float.Parse(((editarDados.resil_amostra_dois_um + editarDados.resil_amostra_dois_dois + editarDados.resil_amostra_dois_tres) / 3).ToString("N2"));

                    editarDados.varia_amostra_tres_um = (((editarDados.resil_amostra_tres_dois - editarDados.resil_amostra_tres_um) / editarDados.resil_amostra_tres_um) * 100);
                    editarDados.varia_amostra_tres_dois = (((editarDados.resil_amostra_tres_tres - editarDados.resil_amostra_tres_um) / editarDados.resil_amostra_tres_um) * 100);
                    editarDados.media_res_tres = ((editarDados.resil_amostra_tres_um + editarDados.resil_amostra_tres_dois + editarDados.resil_amostra_tres_tres) / 3);

                    editarDados.resiliencia_esp = salvarDados.resiliencia_esp;
                    editarDados.resiliencia_enc = ((editarDados.media_res_um + editarDados.media_res_dois + editarDados.media_res_tres) / 3);
                    editarDados.min_max = salvarDados.min_max;

                    //conformes
                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18 || editarDados.densidade == 20)
                        {
                            //minimo 30
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 23 || editarDados.densidade == 26 || editarDados.densidade == 28 || editarDados.densidade == 33)
                        {
                            //minimo  35
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 40 || editarDados.densidade == 45)
                        {
                            //minimo  40 
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Hipermacia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24 || editarDados.densidade == 29 || editarDados.densidade >= 35)
                        {
                            //minimo 30 
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Macia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24)
                        {
                            //minimo 35
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade >= 35)
                        {
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Aglomerado")
                    {
                        if (editarDados.densidade >= 65)
                        {
                            //minimo 25
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //minimo 55
                            if (editarDados.resiliencia_enc >= editarDados.resiliencia_esp)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Visco elástica")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //maxima 15
                            if (editarDados.resiliencia_enc <= editarDados.resiliencia_esp)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        editarDados.conforme = "C";
                    }

                    _context.lamina_resiliencia.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados editado com sucesso.";
                    return RedirectToAction("LamindaDeterminacaoResiliencia", "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> salvarDPC(string os, string orcamento, ColetaModel.LaminaDPC salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_dpc.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //realizando os calculos de media de largura, compri, e espessura inicial.
                    float lar_media_amostra_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.lar_media_um = lar_media_amostra_um;

                    float lar_media_amostra_dois = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.lar_media_dois = lar_media_amostra_dois;

                    float lar_media_amostra_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.lar_media_tres = lar_media_amostra_tres;

                    float comp_media_um = ((salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_dois + salvarDados.comp_amostra_um_tres + salvarDados.comp_amostra_um_quatro) / 4);
                    salvarDados.comp_media_um = comp_media_um;

                    float com_media_dois = ((salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_dois + salvarDados.comp_amostra_dois_tres + salvarDados.comp_amostra_dois_quatro) / 4);
                    salvarDados.comp_media_dois = com_media_dois;

                    float com_media_tres = ((salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_dois + salvarDados.comp_amostra_tres_tres + salvarDados.comp_amostra_tres_quatro) / 4);
                    salvarDados.comp_media_tres = com_media_tres;

                    float esp_ini_media_um = ((salvarDados.esp_ini_amostra_um_um + salvarDados.esp_ini_amostra_um_dois + salvarDados.esp_ini_amostra_um_tres + salvarDados.esp_ini_amostra_um_quatro + salvarDados.esp_ini_amostra_um_cinco + salvarDados.esp_ini_amostra_um_seis + salvarDados.esp_ini_amostra_um_sete + salvarDados.esp_ini_amostra_um_oito) / 8);
                    salvarDados.esp_media_um = esp_ini_media_um;

                    float esp_ini_media_dois = ((salvarDados.esp_ini_amostra_dois_um + salvarDados.esp_ini_amostra_dois_dois + salvarDados.esp_ini_amostra_dois_tres + salvarDados.esp_ini_amostra_dois_quatro + salvarDados.esp_ini_amostra_dois_cinco + salvarDados.esp_ini_amostra_dois_seis + salvarDados.esp_ini_amostra_dois_sete + salvarDados.esp_ini_amostra_dois_oito) / 8);
                    salvarDados.esp_media_dois = esp_ini_media_dois;

                    float esp_ini_media_tres = ((salvarDados.esp_ini_amostra_tres_um + salvarDados.esp_ini_amostra_tres_dois + salvarDados.esp_ini_amostra_tres_tres + salvarDados.esp_ini_amostra_tres_quatro + salvarDados.esp_ini_amostra_tres_cinco + salvarDados.esp_ini_amostra_tres_seis + salvarDados.esp_ini_amostra_tres_sete + salvarDados.esp_ini_amostra_tres_oito) / 8);
                    salvarDados.esp_media_tres = esp_ini_media_tres;

                    //media de espessura.
                    float espessura_um = esp_ini_media_um;
                    salvarDados.media_esp_amostra_um = espessura_um;

                    float espessura_dois = esp_ini_media_dois;
                    salvarDados.media_esp_amostra_dois = espessura_dois;

                    float espessura_tres = esp_ini_media_tres;
                    salvarDados.media_esp_amostra_tres = espessura_tres;

                    float media_espessura_total = ((espessura_um + espessura_dois + espessura_tres) / 3);
                    salvarDados.media_esp_total = media_espessura_total;

                    float reducao = salvarDados.reducao_porc;
                    float reducao_mm = ((media_espessura_total * reducao) / 100);

                    float media_esp_final_um = ((salvarDados.esp_fin_amostra_um_um + salvarDados.esp_fin_amostra_um_dois + salvarDados.esp_fin_amostra_um_tres + salvarDados.esp_fin_amostra_um_quatro + salvarDados.esp_fin_amostra_um_cinco + salvarDados.esp_fin_amostra_um_seis + salvarDados.esp_fin_amostra_um_sete + salvarDados.esp_fin_amostra_um_oito) / 8);
                    salvarDados.media_esp_fin_um = media_esp_final_um;

                    float media_esp_final_dois = ((salvarDados.esp_fin_amostra_dois_um + salvarDados.esp_fin_amostra_dois_dois + salvarDados.esp_fin_amostra_dois_tres + salvarDados.esp_fin_amostra_dois_quatro + salvarDados.esp_fin_amostra_dois_cinco + salvarDados.esp_fin_amostra_um_seis + salvarDados.esp_fin_amostra_dois_sete + salvarDados.esp_fin_amostra_dois_oito) / 8);
                    salvarDados.media_esp_fin_dois = media_esp_final_dois;

                    float media_esp_final_tres = ((salvarDados.esp_fin_amostra_tres_um + salvarDados.esp_fin_amostra_tres_dois + salvarDados.esp_fin_amostra_tres_tres + salvarDados.esp_fin_amostra_tres_quatro + salvarDados.esp_fin_amostra_tres_cinco + salvarDados.esp_fin_amostra_um_seis + salvarDados.esp_fin_amostra_tres_sete + salvarDados.esp_fin_amostra_tres_oito) / 8);
                    salvarDados.media_esp_fin_tres = media_esp_final_tres;

                    //inciial da conta de dpc 1
                    float dcp_amostra_um_um = espessura_um;
                    salvarDados.dpc_amostra_um_um = espessura_um;
                    float dpc_amostra_um_dois = media_esp_final_um;
                    salvarDados.dpc_amostra_um_dois = dpc_amostra_um_dois;
                    float dpc_amostra_um_tres = espessura_um;
                    salvarDados.dpc_amostra_um_tres = dpc_amostra_um_tres;
                    float media_dpc_um = (((dcp_amostra_um_um - dpc_amostra_um_dois) / dpc_amostra_um_tres) * 100);
                    salvarDados.med_dpc_amostra_um = media_dpc_um;

                    //inicial da conta de dpc 2..
                    float dpc_amostra_dois_um = espessura_dois;
                    salvarDados.dpc_amostra_dois_um = dpc_amostra_dois_um;
                    float dpc_amostra_dois_dois = media_esp_final_dois;
                    salvarDados.dpc_amostra_dois_dois = dpc_amostra_dois_dois;
                    float dpc_amostra_dois_tres = espessura_dois;
                    salvarDados.dpc_amostra_dois_tres = dpc_amostra_dois_tres;
                    float media_dpc_dois = (((dpc_amostra_dois_um - dpc_amostra_dois_dois) / dpc_amostra_dois_tres) * 100);
                    salvarDados.med_dpc_amostra_dois = media_dpc_dois;

                    //inicial da conta de dpc 3..
                    float dpc_amostra_tres_um = espessura_tres;
                    salvarDados.dpc_amostra_tres_um = dpc_amostra_tres_um;
                    float dpc_amostra_tres_dois = media_esp_final_tres;
                    salvarDados.dpc_amostra_tres_dois = dpc_amostra_tres_dois;
                    float dpc_amostra_tres_tres = espessura_tres;
                    salvarDados.dpc_amostra_tres_tres = dpc_amostra_tres_tres;
                    float media_dpc_tres = (((dpc_amostra_tres_um - dpc_amostra_tres_dois) / dpc_amostra_tres_tres) * 100);
                    salvarDados.med_dpc_amostra_tres = media_dpc_tres;

                    //inico de variacao...
                    float variacao_dois = (((media_dpc_dois - media_dpc_um) / media_dpc_um) * 100) * -1;
                    salvarDados.vari_amsotra_dois = float.Parse(variacao_dois.ToString("N2"));

                    float variacao_tres = (((media_dpc_tres - media_dpc_um) / media_dpc_um) * 100) * -1;
                    salvarDados.vari_amsotra_tres = float.Parse(variacao_tres.ToString("N2"));

                    float dpc_encntrado = ((media_dpc_um + media_dpc_tres + media_dpc_tres) / 3);
                    //salvarDados.encontrada = dpc_encntrado;

                    //conformidade.
                    //conformes
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18)
                        {
                            //maximo 12
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 23 || salvarDados.densidade == 26 || salvarDados.densidade == 23)
                        {
                            //maximo 10
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 28 || salvarDados.densidade == 33 || salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //maximo 8
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Hipermacia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24 || salvarDados.densidade == 29 || salvarDados.densidade >= 35)
                        {
                            //maximo 15
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Macia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24)
                        {
                            //maximo 12
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade >= 35)
                        {
                            //maximo 10
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "C";
                            }
                        }
                        else if (salvarDados.densidade == 29)
                        {
                            //maximo 10
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Aglomerado")
                    {
                        if (salvarDados.densidade >= 65)
                        {
                            //maximo 25
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //maximoo 10
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Visco elástica")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //maxima 10
                            if (salvarDados.encontrada <= salvarDados.especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        salvarDados.conforme = "C";
                    }

                    _context.lamina_dpc.Add(salvarDados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("LaminaDPC", "Coleta", new { os, orcamento });
                }
                else
                {
                    //inico de editar os dados.
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.date_term = salvarDados.date_term;
                    editarDados.densidade = salvarDados.densidade;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;

                    //recebendo os valores de cada tabela para guardar.
                    editarDados.lar_amostra_um_um = salvarDados.lar_amostra_um_um;
                    editarDados.lar_amostra_um_dois = salvarDados.lar_amostra_um_dois;
                    editarDados.lar_amostra_um_tres = salvarDados.lar_amostra_um_tres;
                    editarDados.lar_amostra_um_quatro = salvarDados.lar_amostra_um_quatro;
                    editarDados.lar_amostra_dois_um = salvarDados.lar_amostra_dois_um;
                    editarDados.lar_amostra_dois_dois = salvarDados.lar_amostra_dois_dois;
                    editarDados.lar_amostra_dois_tres = salvarDados.lar_amostra_dois_tres;
                    editarDados.lar_amostra_dois_quatro = salvarDados.lar_amostra_dois_quatro;
                    editarDados.lar_amostra_tres_um = salvarDados.lar_amostra_tres_um;
                    editarDados.lar_amostra_tres_dois = salvarDados.lar_amostra_tres_dois;
                    editarDados.lar_amostra_tres_tres = salvarDados.lar_amostra_tres_tres;
                    editarDados.lar_amostra_tres_quatro = salvarDados.lar_amostra_tres_quatro;
                    //dados do comprimento da tabela....
                    editarDados.comp_amostra_um_um = salvarDados.comp_amostra_um_um;
                    editarDados.comp_amostra_um_dois = salvarDados.comp_amostra_um_dois;
                    editarDados.comp_amostra_um_tres = salvarDados.comp_amostra_um_tres;
                    editarDados.comp_amostra_um_quatro = salvarDados.comp_amostra_um_quatro;
                    editarDados.comp_amostra_dois_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_dois_dois = salvarDados.comp_amostra_dois_dois;
                    editarDados.comp_amostra_dois_tres = salvarDados.comp_amostra_dois_tres;
                    editarDados.comp_amostra_dois_quatro = salvarDados.comp_amostra_dois_quatro;
                    editarDados.comp_amostra_tres_um = salvarDados.comp_amostra_tres_um;
                    editarDados.comp_amostra_tres_dois = salvarDados.comp_amostra_tres_dois;
                    editarDados.comp_amostra_tres_tres = salvarDados.comp_amostra_tres_tres;
                    editarDados.comp_amostra_tres_quatro = salvarDados.comp_amostra_tres_quatro;

                    //dados para editar esp inicial.
                    editarDados.esp_ini_amostra_um_um = salvarDados.esp_ini_amostra_um_um;
                    editarDados.esp_ini_amostra_um_dois = salvarDados.esp_ini_amostra_um_dois;
                    editarDados.esp_ini_amostra_um_tres = salvarDados.esp_ini_amostra_um_tres;
                    editarDados.esp_ini_amostra_um_quatro = salvarDados.esp_ini_amostra_um_quatro;
                    editarDados.esp_ini_amostra_um_cinco = salvarDados.esp_ini_amostra_um_cinco;
                    editarDados.esp_ini_amostra_um_seis = salvarDados.esp_ini_amostra_um_seis;
                    editarDados.esp_ini_amostra_um_sete = salvarDados.esp_ini_amostra_um_sete;
                    editarDados.esp_ini_amostra_um_oito = salvarDados.esp_ini_amostra_um_oito;
                    editarDados.esp_ini_amostra_dois_um = salvarDados.esp_ini_amostra_dois_um;
                    editarDados.esp_ini_amostra_dois_dois = salvarDados.esp_ini_amostra_dois_dois;
                    editarDados.esp_ini_amostra_dois_tres = salvarDados.esp_ini_amostra_dois_tres;
                    editarDados.esp_ini_amostra_dois_quatro = salvarDados.esp_ini_amostra_dois_quatro;
                    editarDados.esp_ini_amostra_dois_cinco = salvarDados.esp_ini_amostra_dois_cinco;
                    editarDados.esp_ini_amostra_dois_seis = salvarDados.esp_ini_amostra_dois_seis;
                    editarDados.esp_ini_amostra_dois_sete = salvarDados.esp_ini_amostra_dois_sete;
                    editarDados.esp_ini_amostra_dois_oito = salvarDados.esp_ini_amostra_dois_oito;
                    editarDados.esp_ini_amostra_tres_um = salvarDados.esp_ini_amostra_tres_um;
                    editarDados.esp_ini_amostra_tres_dois = salvarDados.esp_ini_amostra_tres_dois;
                    editarDados.esp_ini_amostra_tres_tres = salvarDados.esp_ini_amostra_tres_tres;
                    editarDados.esp_ini_amostra_tres_quatro = salvarDados.esp_ini_amostra_tres_quatro;
                    editarDados.esp_ini_amostra_tres_cinco = salvarDados.esp_ini_amostra_tres_cinco;
                    editarDados.esp_ini_amostra_tres_seis = salvarDados.esp_ini_amostra_tres_seis;
                    editarDados.esp_ini_amostra_tres_sete = salvarDados.esp_ini_amostra_tres_sete;
                    editarDados.esp_ini_amostra_tres_oito = salvarDados.esp_ini_amostra_tres_oito;

                    //realizando a media dos dados recebidos em cima
                    float lar_media_amostra_um = ((editarDados.lar_amostra_um_um + editarDados.lar_amostra_um_dois + editarDados.lar_amostra_um_tres + editarDados.lar_amostra_um_quatro) / 4);
                    editarDados.lar_media_um = lar_media_amostra_um;

                    float lar_media_amostra_dois = ((editarDados.lar_amostra_dois_um + editarDados.lar_amostra_dois_dois + editarDados.lar_amostra_dois_tres + editarDados.lar_amostra_dois_quatro) / 4);
                    editarDados.lar_media_dois = lar_media_amostra_dois;

                    float lar_media_amostra_tres = ((editarDados.lar_amostra_tres_um + editarDados.lar_amostra_tres_dois + editarDados.lar_amostra_tres_tres + editarDados.lar_amostra_tres_quatro) / 4);
                    editarDados.lar_media_tres = lar_media_amostra_tres;

                    float comp_media_um = ((editarDados.comp_amostra_um_um + editarDados.comp_amostra_um_dois + editarDados.comp_amostra_um_tres + editarDados.comp_amostra_um_quatro) / 4);
                    salvarDados.comp_media_um = comp_media_um;

                    float com_media_dois = ((editarDados.comp_amostra_dois_um + editarDados.comp_amostra_dois_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_dois_quatro) / 4);
                    editarDados.comp_media_dois = com_media_dois;

                    float com_media_tres = ((salvarDados.comp_amostra_tres_um + editarDados.comp_amostra_tres_dois + editarDados.comp_amostra_tres_tres + editarDados.comp_amostra_tres_quatro) / 4);
                    editarDados.comp_media_tres = com_media_tres;

                    float esp_ini_media_um = ((editarDados.esp_ini_amostra_um_um + editarDados.esp_ini_amostra_um_dois + editarDados.esp_ini_amostra_um_tres + editarDados.esp_ini_amostra_um_quatro + editarDados.esp_ini_amostra_um_cinco + editarDados.esp_ini_amostra_um_seis + editarDados.esp_ini_amostra_um_sete + editarDados.esp_ini_amostra_um_oito) / 8);
                    editarDados.esp_media_um = esp_ini_media_um;

                    float esp_ini_media_dois = ((editarDados.esp_ini_amostra_dois_um + editarDados.esp_ini_amostra_dois_dois + editarDados.esp_ini_amostra_dois_tres + editarDados.esp_ini_amostra_dois_quatro + editarDados.esp_ini_amostra_dois_cinco + editarDados.esp_ini_amostra_dois_seis + editarDados.esp_ini_amostra_dois_sete + editarDados.esp_ini_amostra_dois_oito) / 8);
                    editarDados.esp_media_dois = esp_ini_media_dois;

                    float esp_ini_media_tres = ((editarDados.esp_ini_amostra_tres_um + editarDados.esp_ini_amostra_tres_dois + editarDados.esp_ini_amostra_tres_tres + editarDados.esp_ini_amostra_tres_quatro + editarDados.esp_ini_amostra_tres_cinco + editarDados.esp_ini_amostra_tres_seis + editarDados.esp_ini_amostra_tres_sete + editarDados.esp_ini_amostra_tres_oito) / 8);
                    editarDados.esp_media_tres = esp_ini_media_tres;

                    //calculo de espessura.
                    float espessura_um = esp_ini_media_um;
                    editarDados.media_esp_amostra_um = espessura_um;

                    float espessura_dois = esp_ini_media_dois;
                    editarDados.media_esp_amostra_dois = espessura_dois;

                    float espessura_tres = esp_ini_media_tres;
                    editarDados.media_esp_amostra_tres = espessura_tres;

                    float media_espessura_total = ((espessura_um + espessura_dois + espessura_tres) / 3);
                    editarDados.media_esp_total = media_espessura_total;

                    //calculo de reducao
                    float reducao = salvarDados.reducao_porc;
                    float reducao_mm = ((media_espessura_total * reducao) / 100);

                    //atulizando valores data, hora, temp,umidade.
                    editarDados.ini_data = salvarDados.ini_data;
                    editarDados.term_data = salvarDados.term_data;
                    editarDados.ini_hora = salvarDados.ini_hora;
                    editarDados.term_hora = salvarDados.term_hora;
                    editarDados.temp_min = salvarDados.temp_min;
                    editarDados.temp_max = salvarDados.temp_max;
                    editarDados.umi_min = salvarDados.umi_min;
                    editarDados.umi_max = salvarDados.umi_max;

                    //recebendo os dados de esp final..
                    editarDados.esp_fin_amostra_um_um = salvarDados.esp_fin_amostra_um_um;
                    editarDados.esp_fin_amostra_um_dois = salvarDados.esp_fin_amostra_um_dois;
                    editarDados.esp_fin_amostra_um_tres = salvarDados.esp_fin_amostra_um_tres;
                    editarDados.esp_fin_amostra_um_quatro = salvarDados.esp_fin_amostra_um_quatro;
                    editarDados.esp_fin_amostra_um_cinco = salvarDados.esp_fin_amostra_um_cinco;
                    editarDados.esp_fin_amostra_um_seis = salvarDados.esp_fin_amostra_um_seis;
                    editarDados.esp_fin_amostra_um_sete = salvarDados.esp_fin_amostra_um_sete;
                    editarDados.esp_fin_amostra_um_oito = salvarDados.esp_fin_amostra_um_oito;
                    editarDados.esp_fin_amostra_dois_um = salvarDados.esp_fin_amostra_dois_um;
                    editarDados.esp_fin_amostra_dois_dois = salvarDados.esp_fin_amostra_dois_dois;
                    editarDados.esp_fin_amostra_dois_tres = salvarDados.esp_fin_amostra_dois_tres;
                    editarDados.esp_fin_amostra_dois_quatro = salvarDados.esp_fin_amostra_dois_quatro;
                    editarDados.esp_fin_amostra_dois_cinco = salvarDados.esp_fin_amostra_dois_cinco;
                    editarDados.esp_fin_amostra_dois_seis = salvarDados.esp_fin_amostra_dois_seis;
                    editarDados.esp_fin_amostra_dois_sete = salvarDados.esp_fin_amostra_dois_sete;
                    editarDados.esp_fin_amostra_dois_oito = salvarDados.esp_fin_amostra_dois_oito;
                    editarDados.esp_fin_amostra_tres_um = salvarDados.esp_fin_amostra_tres_um;
                    editarDados.esp_fin_amostra_tres_dois = salvarDados.esp_fin_amostra_tres_dois;
                    editarDados.esp_fin_amostra_tres_tres = salvarDados.esp_fin_amostra_tres_tres;
                    editarDados.esp_fin_amostra_tres_quatro = salvarDados.esp_fin_amostra_tres_quatro;
                    editarDados.esp_fin_amostra_tres_cinco = salvarDados.esp_fin_amostra_tres_cinco;
                    editarDados.esp_fin_amostra_tres_seis = salvarDados.esp_fin_amostra_tres_seis;
                    editarDados.esp_fin_amostra_tres_sete = salvarDados.esp_fin_amostra_tres_sete;
                    editarDados.esp_fin_amostra_tres_oito = salvarDados.esp_fin_amostra_tres_oito;

                    //realizando calculo de media da esp final.
                    float media_esp_final_um = ((editarDados.esp_fin_amostra_um_um + editarDados.esp_fin_amostra_um_dois + editarDados.esp_fin_amostra_um_tres + editarDados.esp_fin_amostra_um_quatro + editarDados.esp_fin_amostra_um_cinco + editarDados.esp_fin_amostra_um_seis + editarDados.esp_fin_amostra_um_sete + editarDados.esp_fin_amostra_um_oito) / 8);
                    editarDados.media_esp_fin_um = media_esp_final_um;

                    float media_esp_final_dois = ((editarDados.esp_fin_amostra_dois_um + editarDados.esp_fin_amostra_dois_dois + editarDados.esp_fin_amostra_dois_tres + editarDados.esp_fin_amostra_dois_quatro + editarDados.esp_fin_amostra_dois_cinco + editarDados.esp_fin_amostra_um_seis + editarDados.esp_fin_amostra_dois_sete + editarDados.esp_fin_amostra_dois_oito) / 8);
                    editarDados.media_esp_fin_dois = media_esp_final_dois;

                    float media_esp_final_tres = ((editarDados.esp_fin_amostra_tres_um + editarDados.esp_fin_amostra_tres_dois + editarDados.esp_fin_amostra_tres_tres + editarDados.esp_fin_amostra_tres_quatro + editarDados.esp_fin_amostra_tres_cinco + editarDados.esp_fin_amostra_um_seis + editarDados.esp_fin_amostra_tres_sete + editarDados.esp_fin_amostra_tres_oito) / 8);
                    editarDados.media_esp_fin_tres = media_esp_final_tres;

                    //inciial da conta de dpc 1
                    float dcp_amostra_um_um = espessura_um;
                    editarDados.dpc_amostra_um_um = espessura_um;
                    float dpc_amostra_um_dois = media_esp_final_um;
                    editarDados.dpc_amostra_um_dois = dpc_amostra_um_dois;
                    float dpc_amostra_um_tres = espessura_um;
                    editarDados.dpc_amostra_um_tres = dpc_amostra_um_tres;
                    float media_dpc_um = (((dcp_amostra_um_um - dpc_amostra_um_dois) / dpc_amostra_um_tres) * 100);
                    editarDados.med_dpc_amostra_um = media_dpc_um;

                    //inicial da conta de dpc 2..
                    float dpc_amostra_dois_um = espessura_dois;
                    editarDados.dpc_amostra_dois_um = dpc_amostra_dois_um;
                    float dpc_amostra_dois_dois = media_esp_final_dois;
                    editarDados.dpc_amostra_dois_dois = dpc_amostra_dois_dois;
                    float dpc_amostra_dois_tres = espessura_dois;
                    editarDados.dpc_amostra_dois_tres = dpc_amostra_dois_tres;
                    float media_dpc_dois = (((dpc_amostra_dois_um - dpc_amostra_dois_dois) / dpc_amostra_dois_tres) * 100);
                    editarDados.med_dpc_amostra_dois = media_dpc_dois;

                    //inicial da conta de dpc 3..
                    float dpc_amostra_tres_um = espessura_tres;
                    editarDados.dpc_amostra_tres_um = dpc_amostra_tres_um;
                    float dpc_amostra_tres_dois = media_esp_final_tres;
                    editarDados.dpc_amostra_tres_dois = dpc_amostra_tres_dois;
                    float dpc_amostra_tres_tres = espessura_tres;
                    editarDados.dpc_amostra_tres_tres = dpc_amostra_tres_tres;
                    float media_dpc_tres = (((dpc_amostra_tres_um - dpc_amostra_tres_dois) / dpc_amostra_tres_tres) * 100);
                    editarDados.med_dpc_amostra_tres = media_dpc_tres;

                    //inico de variacao...
                    float variacao_dois = (((media_dpc_dois - media_dpc_um) / media_dpc_um) * 100) * -1;
                    editarDados.vari_amsotra_dois = float.Parse(variacao_dois.ToString("N2"));

                    float variacao_tres = (((media_dpc_tres - media_dpc_um) / media_dpc_um) * 100) * -1;
                    editarDados.vari_amsotra_tres = float.Parse(variacao_tres.ToString("N2"));

                    //float dpc_encntrado = ((media_dpc_um + media_dpc_tres + media_dpc_tres) / 3);
                    //editarDados.encontrada = dpc_encntrado;
                    editarDados.encontrada = salvarDados.encontrada;
                    editarDados.especificada = salvarDados.especificada;

                    //conformes
                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18)
                        {
                            //maximo 12
                            if (editarDados.encontrada <= editarDados.especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 23 || editarDados.densidade == 26 || editarDados.densidade == 23)
                        {
                            //maximo 10
                            if (editarDados.encontrada <= editarDados.especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 28 || editarDados.densidade == 33 || editarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //maximo 8
                            if (editarDados.encontrada <= editarDados.especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Hipermacia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24 || editarDados.densidade == 29 || salvarDados.densidade >= 35)
                        {
                            //maximo 15
                            if (editarDados.encontrada <= editarDados.especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Macia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24)
                        {
                            //maximo 12
                            if (editarDados.encontrada <= editarDados.especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade >= 35)
                        {
                            //maximo 10
                            if (editarDados.encontrada <= editarDados.especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "C";
                            }
                        }
                        else if (editarDados.densidade == 29)
                        {
                            //maximo 10
                            if (editarDados.encontrada <= editarDados.especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Aglomerado")
                    {
                        if (editarDados.densidade >= 65)
                        {
                            //maximo 25
                            if (editarDados.encontrada <= editarDados.especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //maximoo 10
                            if (editarDados.encontrada <= editarDados.especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Visco elástica")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //maxima 10
                            if (editarDados.encontrada <= editarDados.especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        editarDados.conforme = "C";
                    }

                    _context.lamina_dpc.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("LaminaDPC", "Coleta", new { os, orcamento });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> salvarLaminaFI(string os, string orcamento, int item, ColetaModel.LaminaFI salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //realizando os calculos de media de largura, comp, e espessura...
                    float lar_media_um_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.lar_media_um = lar_media_um_um;

                    float lar_media_dois_um = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.lar_media_dois = lar_media_dois_um;

                    float lar_media_dois_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.lar_media_tres = lar_media_dois_tres;

                    //inico de comp.
                    float comp_media_um = ((salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_dois + salvarDados.comp_amostra_um_tres + salvarDados.comp_amostra_um_quatro) / 4);
                    salvarDados.comp_media_um = comp_media_um;

                    float comp_media_dois = ((salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_dois + salvarDados.comp_amostra_dois_tres + salvarDados.comp_amostra_dois_quatro) / 4);
                    salvarDados.comp_media_dois = comp_media_dois;

                    float comp_media_tres = ((salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_dois + salvarDados.comp_amostra_tres_tres + salvarDados.comp_amostra_tres_quatro) / 4);
                    salvarDados.comp_media_tres = comp_media_tres;

                    float esp_media_um = ((salvarDados.esp_ini_amostra_um_um + salvarDados.esp_ini_amostra_um_dois + salvarDados.esp_ini_amostra_um_tres + salvarDados.esp_ini_amostra_um_quatro + salvarDados.esp_ini_amostra_um_cinco + salvarDados.esp_ini_amostra_um_seis + salvarDados.esp_ini_amostra_um_sete + salvarDados.esp_ini_amostra_um_oito) / 8);
                    salvarDados.esp_media_um = esp_media_um;

                    float esp_media_dois = ((salvarDados.esp_ini_amostra_dois_um + salvarDados.esp_ini_amostra_dois_dois + salvarDados.esp_ini_amostra_dois_tres + salvarDados.esp_ini_amostra_dois_quatro + salvarDados.esp_ini_amostra_dois_cinco + salvarDados.esp_ini_amostra_dois_seis + salvarDados.esp_ini_amostra_dois_sete + salvarDados.esp_ini_amostra_dois_oito) / 8);
                    salvarDados.esp_media_dois = esp_media_dois;

                    float esp_media_tres = ((salvarDados.esp_ini_amostra_tres_um + salvarDados.esp_ini_amostra_dois_dois + salvarDados.esp_ini_amostra_tres_tres + salvarDados.esp_ini_amostra_tres_quatro + salvarDados.esp_ini_amostra_tres_cinco + salvarDados.esp_ini_amostra_tres_seis + salvarDados.esp_ini_amostra_tres_sete + salvarDados.esp_ini_amostra_tres_oito) / 8);
                    salvarDados.esp_media_tres = esp_media_tres;

                    //inico de calculo de media de espessura.
                    salvarDados.media_espessura_um = esp_media_um;
                    salvarDados.media_espessura_dois = esp_media_dois;
                    salvarDados.media_espessura_tres = esp_media_tres;

                    //calculo redução mm
                    salvarDados.reducao_um = ((salvarDados.esp_media_um * salvarDados.reducao_porc_um) / 100); salvarDados.reducao_um = ((salvarDados.esp_media_um * salvarDados.reducao_porc_um) / 100);
                    salvarDados.reducao_dois = ((salvarDados.esp_media_dois * salvarDados.reducao_porc_dois) / 100);
                    salvarDados.reducao_tres = ((salvarDados.esp_media_tres * salvarDados.reducao_porc_tres) / 100);

                    //calculnado reduçlão nas tabelas 25 
                    float reducao_25_um = ((salvarDados.comp_25_um * salvarDados.media_espessura_um) / 100);
                    salvarDados.reducao_25_um = reducao_25_um;

                    float reducao_25_dois = ((salvarDados.comp_25_dois * salvarDados.media_espessura_dois) / 100);
                    salvarDados.reducao_25_dois = reducao_25_um;

                    float reducao_25_tres = ((salvarDados.comp_25_tres * salvarDados.media_espessura_tres) / 100);
                    salvarDados.reducao_25_tres = reducao_25_tres;

                    float media_geral_25 = ((salvarDados.fi_25_um + salvarDados.fi_25_dois + salvarDados.fi_25_tres) / 3);
                    salvarDados.media_25 = media_geral_25;

                    //caluclo redução de 40%
                    float reducao_40_um = ((salvarDados.comp_40_um * salvarDados.media_espessura_um) / 100);
                    salvarDados.reducao_40_um = reducao_40_um;

                    float reducao_40_dois = ((salvarDados.comp_40_dois * salvarDados.media_espessura_dois) / 100);
                    salvarDados.reducao_40_dois = reducao_40_dois;

                    float reducao_40_tres = ((salvarDados.comp_40_tres * salvarDados.media_espessura_tres) / 100);
                    salvarDados.reducao_40_tres = reducao_40_tres;

                    float media_geral_40 = ((salvarDados.fi_40_um + salvarDados.fi_40_dois + salvarDados.fi_40_tres) / 3);
                    salvarDados.media_40 = media_geral_40;


                    //calulo redução 60%
                    float reducao_65_um = ((salvarDados.comp_65_um * salvarDados.media_espessura_um) / 100);
                    salvarDados.reducao_65_um = reducao_65_um;

                    float reducao_65_dois = ((salvarDados.comp_65_dois * salvarDados.media_espessura_dois) / 100);
                    salvarDados.reducao_65_dois = reducao_65_dois;

                    float reducao_65_tres = ((salvarDados.comp_65_tres * salvarDados.media_espessura_tres) / 100);
                    salvarDados.reducao_65_tres = reducao_65_tres;

                    float media_geral_65 = ((salvarDados.fi_65_um + salvarDados.fi_65_dois + salvarDados.fi_65_tres) / 3);
                    salvarDados.media_65 = media_geral_65;


                    //força identação encontrada...
                    salvarDados.fator_ind_65 = media_geral_65;
                    salvarDados.fator_ind_40 = media_geral_40;
                    salvarDados.fator_ind_25 = media_geral_25;

                    //fator conforto
                    salvarDados.conforto_65 = (int)salvarDados.media_65;
                    salvarDados.conforto_25 = (int)salvarDados.media_25;

                    salvarDados.media_conforto = (salvarDados.conforto_65 / salvarDados.conforto_25);

                    //realizando logica para saber se esta conforme ou nao conforme.
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18)
                        {
                            //minimo 80 aqui
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 20)
                        {
                            //minimo 95 aqui
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 23)
                        {
                            //minimo 110
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 26)
                        {
                            //minimo 130
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 28)
                        {
                            //minimo 145
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 33)
                        {
                            //minimo 165
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 40)
                        {
                            //minimo 185
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 45)
                        {
                            //minimo 200
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Hipermacia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24)
                        {
                            //maximo 50
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 29)
                        {
                            //maximo 50
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade >= 35)
                        {
                            //maximo 150
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Macia")
                    {
                        if (salvarDados.densidade == 20)
                        {
                            //maximo 95
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 24)
                        {
                            //maximo 130
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 20)
                        {
                            //maximo 165
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade >= 35)
                        {
                            //maximo 200
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Aglomerado")
                    {
                        if (salvarDados.densidade >= 65)
                        {
                            //maximo 35
                            if (salvarDados.fator_ind_40 <= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Visco elástica")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //minimo 25
                            if (salvarDados.fator_ind_40 >= salvarDados.forca_esp_40)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }

                    // conformidade fator conforto
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18 || salvarDados.densidade == 20)
                        {
                            //minimo 2,0
                            if (salvarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                salvarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                salvarDados.conforme_conforto = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 23 || salvarDados.densidade == 26)
                        {
                            //minimo  2,1
                            if (salvarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                salvarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                salvarDados.conforme_conforto = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 28 || salvarDados.densidade == 33 || salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //minimo  2,2
                            if (salvarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                salvarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                salvarDados.conforme_conforto = "NC";
                            }
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //minimo 2,3
                            if (salvarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                salvarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                salvarDados.conforme_conforto = "NC";
                            }
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Visco elástica")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //minimo 10
                            if (salvarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                salvarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                salvarDados.conforme_conforto = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme_conforto = "C";
                        }
                    }
                    else
                    {
                        salvarDados.conforme_conforto = "C";
                    }

                    _context.lamina_fi.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados salvo com sucesso.";
                    return RedirectToAction("LaminaF_I", "Coleta", new { os, orcamento, item });
                }
                else
                {
                    //editando os valores que estao sendo sobrescritos.
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;

                    //editando dados da tabela largura
                    editarDados.lar_amostra_um_um = salvarDados.lar_amostra_um_um;
                    editarDados.lar_amostra_um_dois = salvarDados.lar_amostra_um_dois;
                    editarDados.lar_amostra_um_tres = salvarDados.lar_amostra_um_tres;
                    editarDados.lar_amostra_um_quatro = salvarDados.lar_amostra_um_quatro;
                    editarDados.lar_amostra_dois_um = salvarDados.lar_amostra_dois_um;
                    editarDados.lar_amostra_dois_dois = salvarDados.lar_amostra_dois_dois;
                    editarDados.lar_amostra_dois_tres = salvarDados.lar_amostra_dois_tres;
                    editarDados.lar_amostra_dois_quatro = salvarDados.lar_amostra_dois_quatro;
                    editarDados.lar_amostra_tres_um = salvarDados.lar_amostra_tres_um;
                    editarDados.lar_amostra_tres_dois = salvarDados.lar_amostra_tres_dois;
                    editarDados.lar_amostra_tres_tres = salvarDados.lar_amostra_tres_tres;
                    editarDados.lar_amostra_tres_quatro = salvarDados.lar_amostra_tres_quatro;
                    //comprimento
                    editarDados.comp_amostra_um_um = salvarDados.comp_amostra_um_um;
                    editarDados.comp_amostra_um_dois = salvarDados.comp_amostra_um_dois;
                    editarDados.comp_amostra_um_tres = salvarDados.comp_amostra_um_tres;
                    editarDados.comp_amostra_um_quatro = salvarDados.comp_amostra_um_quatro;
                    editarDados.comp_amostra_dois_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_dois_dois = salvarDados.comp_amostra_dois_dois;
                    editarDados.comp_amostra_dois_tres = salvarDados.comp_amostra_dois_tres;
                    editarDados.comp_amostra_dois_quatro = salvarDados.comp_amostra_dois_quatro;
                    editarDados.comp_amostra_tres_um = salvarDados.comp_amostra_tres_um;
                    editarDados.comp_amostra_tres_dois = salvarDados.comp_amostra_tres_dois;
                    editarDados.comp_amostra_tres_tres = salvarDados.comp_amostra_tres_tres;
                    editarDados.comp_amostra_tres_quatro = salvarDados.comp_amostra_tres_quatro;
                    //espessura.
                    editarDados.esp_ini_amostra_um_um = salvarDados.esp_ini_amostra_um_um;
                    editarDados.esp_ini_amostra_um_dois = salvarDados.esp_ini_amostra_um_dois;
                    editarDados.esp_ini_amostra_um_tres = salvarDados.esp_ini_amostra_um_tres;
                    editarDados.esp_ini_amostra_um_quatro = salvarDados.esp_ini_amostra_um_quatro;
                    editarDados.esp_ini_amostra_um_cinco = salvarDados.esp_ini_amostra_um_cinco;
                    editarDados.esp_ini_amostra_um_seis = salvarDados.esp_ini_amostra_um_seis;
                    editarDados.esp_ini_amostra_um_sete = salvarDados.esp_ini_amostra_um_sete;
                    editarDados.esp_ini_amostra_um_oito = salvarDados.esp_ini_amostra_um_oito;
                    editarDados.esp_ini_amostra_dois_um = salvarDados.esp_ini_amostra_dois_um;
                    editarDados.esp_ini_amostra_dois_dois = salvarDados.esp_ini_amostra_dois_dois;
                    editarDados.esp_ini_amostra_dois_tres = salvarDados.esp_ini_amostra_dois_tres;
                    editarDados.esp_ini_amostra_dois_quatro = salvarDados.esp_ini_amostra_dois_quatro;
                    editarDados.esp_ini_amostra_dois_cinco = salvarDados.esp_ini_amostra_dois_cinco;
                    editarDados.esp_ini_amostra_dois_seis = salvarDados.esp_ini_amostra_dois_seis;
                    editarDados.esp_ini_amostra_dois_sete = salvarDados.esp_ini_amostra_dois_sete;
                    editarDados.esp_ini_amostra_dois_oito = salvarDados.esp_ini_amostra_dois_oito;
                    editarDados.esp_ini_amostra_tres_um = salvarDados.esp_ini_amostra_tres_um;
                    editarDados.esp_ini_amostra_tres_dois = salvarDados.esp_ini_amostra_tres_dois;
                    editarDados.esp_ini_amostra_tres_tres = salvarDados.esp_ini_amostra_tres_tres;
                    editarDados.esp_ini_amostra_tres_quatro = salvarDados.esp_ini_amostra_tres_quatro;
                    editarDados.esp_ini_amostra_tres_cinco = salvarDados.esp_ini_amostra_tres_cinco;
                    editarDados.esp_ini_amostra_tres_seis = salvarDados.esp_ini_amostra_tres_seis;
                    editarDados.esp_ini_amostra_tres_sete = salvarDados.esp_ini_amostra_tres_sete;
                    editarDados.esp_ini_amostra_tres_oito = salvarDados.esp_ini_amostra_tres_oito;

                    //realizando calculos para pegar a media de cada tabela. largura.
                    editarDados.lar_media_um = ((editarDados.lar_amostra_um_um + editarDados.lar_amostra_um_dois + editarDados.lar_amostra_um_tres + editarDados.lar_amostra_um_quatro) / 4);
                    editarDados.lar_media_dois = ((editarDados.lar_amostra_dois_um + editarDados.lar_amostra_dois_dois + editarDados.lar_amostra_dois_tres + editarDados.lar_amostra_dois_quatro) / 4);
                    editarDados.lar_media_tres = ((editarDados.lar_amostra_tres_um + editarDados.lar_amostra_tres_dois + editarDados.lar_amostra_tres_tres + editarDados.lar_amostra_tres_quatro) / 4);
                    //comprimento
                    editarDados.comp_media_um = ((editarDados.comp_amostra_um_um + editarDados.comp_amostra_um_dois + editarDados.comp_amostra_um_tres + editarDados.comp_amostra_um_quatro) / 4);
                    editarDados.comp_media_dois = ((editarDados.comp_amostra_dois_um + editarDados.comp_amostra_dois_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_dois_quatro) / 4);
                    editarDados.comp_media_tres = ((editarDados.comp_amostra_tres_um + editarDados.comp_amostra_tres_dois + editarDados.comp_amostra_tres_tres + editarDados.comp_amostra_tres_quatro) / 4);
                    //espessura
                    editarDados.esp_media_um = ((editarDados.esp_ini_amostra_um_um + editarDados.esp_ini_amostra_um_dois + editarDados.esp_ini_amostra_um_tres + editarDados.esp_ini_amostra_um_quatro + editarDados.esp_ini_amostra_um_cinco + editarDados.esp_ini_amostra_um_seis + editarDados.esp_ini_amostra_um_sete + editarDados.esp_ini_amostra_um_oito) / 8);
                    editarDados.esp_media_dois = ((editarDados.esp_ini_amostra_dois_um + editarDados.esp_ini_amostra_dois_dois + editarDados.esp_ini_amostra_dois_tres + editarDados.esp_ini_amostra_dois_quatro + editarDados.esp_ini_amostra_dois_cinco + editarDados.esp_ini_amostra_dois_seis + editarDados.esp_ini_amostra_dois_sete + editarDados.esp_ini_amostra_dois_oito) / 8);
                    editarDados.esp_media_tres = ((editarDados.esp_ini_amostra_tres_um + editarDados.esp_ini_amostra_tres_dois + editarDados.esp_ini_amostra_tres_tres + editarDados.esp_ini_amostra_tres_quatro + editarDados.esp_ini_amostra_tres_cinco + editarDados.esp_ini_amostra_tres_seis + editarDados.esp_ini_amostra_tres_sete + editarDados.esp_ini_amostra_tres_oito) / 8);

                    //media espessura.
                    //inico de calculo de media de espessura.
                    editarDados.media_espessura_um = editarDados.esp_media_um;
                    editarDados.media_espessura_dois = editarDados.esp_media_dois;
                    editarDados.media_espessura_tres = editarDados.esp_media_tres;

                    editarDados.pre_carga = salvarDados.pre_carga;
                    editarDados.tempo_espera = salvarDados.tempo_espera;
                    editarDados.espuma_vsiocoelastica = salvarDados.espuma_vsiocoelastica;

                    //calculo para  redução mm..
                    editarDados.reducao_porc_um = salvarDados.reducao_porc_um;
                    editarDados.reducao_porc_dois = salvarDados.reducao_porc_dois;
                    editarDados.reducao_porc_tres = salvarDados.reducao_porc_tres;

                    editarDados.reducao_um = ((editarDados.esp_media_um * editarDados.reducao_porc_um) / 100);
                    editarDados.reducao_dois = ((editarDados.esp_media_dois * editarDados.reducao_porc_dois) / 100);
                    editarDados.reducao_tres = ((editarDados.esp_media_tres * editarDados.reducao_porc_tres) / 100);

                    //editando tabela de compressao 25.
                    editarDados.comp_25_um = salvarDados.comp_25_um;
                    editarDados.temp_25_um = salvarDados.temp_25_um;
                    editarDados.fi_25_um = salvarDados.fi_25_um;
                    editarDados.reducao_25_um = ((editarDados.esp_media_um * editarDados.comp_25_um) / 100);


                    editarDados.comp_25_dois = salvarDados.comp_25_dois;
                    editarDados.temp_25_dois = salvarDados.temp_25_dois;
                    editarDados.fi_25_dois = salvarDados.fi_25_dois;
                    editarDados.reducao_25_dois = ((editarDados.esp_media_dois * editarDados.comp_25_dois) / 100);

                    editarDados.comp_25_tres = salvarDados.comp_25_tres;
                    editarDados.temp_25_tres = salvarDados.temp_25_tres;
                    editarDados.fi_25_tres = salvarDados.fi_25_tres;
                    editarDados.reducao_25_tres = ((editarDados.esp_media_tres * editarDados.comp_25_tres) / 100);

                    editarDados.media_25 = ((editarDados.fi_25_um + editarDados.fi_25_dois + editarDados.fi_25_tres) / 3);

                    //editando tabela compressao 40.
                    editarDados.comp_40_um = salvarDados.comp_40_um;
                    editarDados.temp_40_um = salvarDados.temp_40_um;
                    editarDados.fi_40_um = salvarDados.fi_40_um;
                    editarDados.reducao_40_um = ((editarDados.esp_media_um * editarDados.comp_40_um) / 100);

                    editarDados.comp_40_dois = salvarDados.comp_40_dois;
                    editarDados.temp_40_dois = salvarDados.temp_40_dois;
                    editarDados.fi_40_dois = salvarDados.fi_40_dois;
                    editarDados.reducao_40_dois = ((editarDados.esp_media_dois * editarDados.comp_40_dois) / 100);


                    editarDados.comp_40_tres = salvarDados.comp_40_tres;
                    editarDados.temp_40_tres = salvarDados.temp_40_tres;
                    editarDados.fi_40_tres = salvarDados.fi_40_tres;
                    editarDados.reducao_40_tres = ((editarDados.esp_media_tres * editarDados.comp_40_tres) / 100);

                    editarDados.media_40 = ((editarDados.fi_40_um + editarDados.fi_40_dois + editarDados.fi_40_tres) / 3);

                    //editando tabela compressao 65.
                    editarDados.comp_65_um = salvarDados.comp_65_um;
                    editarDados.temp_65_um = salvarDados.temp_65_um;
                    editarDados.fi_65_um = salvarDados.fi_65_um;
                    editarDados.reducao_65_um = ((editarDados.esp_media_um * editarDados.comp_65_um) / 100);

                    editarDados.comp_65_dois = salvarDados.comp_65_dois;
                    editarDados.temp_65_dois = salvarDados.temp_65_dois;
                    editarDados.fi_65_dois = salvarDados.fi_65_dois;
                    editarDados.reducao_65_dois = ((editarDados.esp_media_dois * editarDados.comp_65_dois) / 100);

                    editarDados.comp_65_tres = salvarDados.comp_65_tres;
                    editarDados.temp_65_tres = salvarDados.temp_65_tres;
                    editarDados.fi_65_tres = salvarDados.fi_65_tres;
                    editarDados.reducao_65_tres = ((editarDados.esp_media_tres * editarDados.comp_65_tres) / 100);

                    editarDados.media_65 = ((editarDados.fi_65_um + editarDados.fi_65_dois + editarDados.fi_65_tres) / 3);

                    //calculo de força encontrado
                    editarDados.forca_esp_25 = salvarDados.forca_esp_25;
                    editarDados.forca_esp_40 = salvarDados.forca_esp_40;
                    editarDados.forca_esp_65 = salvarDados.forca_esp_65;

                    editarDados.fator_ind_25 = editarDados.media_25;
                    editarDados.fator_ind_40 = editarDados.media_40;
                    editarDados.fator_ind_65 = editarDados.media_65;

                    //conforto
                    editarDados.conforto_65 = (int)salvarDados.media_65;
                    editarDados.conforto_25 = (int)salvarDados.media_25;

                    editarDados.media_conforto = (editarDados.conforto_65 / editarDados.conforto_25);

                    //realizando logica para saber se esta conforme ou nao conforme.
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;
                    editarDados.densidade = salvarDados.densidade;
                    editarDados.fc_especificado = salvarDados.fc_especificado;

                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18)
                        {
                            //minimo 80 aqui
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 20)
                        {
                            //minimo 95 aqui
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 23)
                        {
                            //minimo 110
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 26)
                        {
                            //minimo 130
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 28)
                        {
                            //minimo 145
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 33)
                        {
                            //minimo 165
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 40)
                        {
                            //minimo 185
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 45)
                        {
                            //minimo 200
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Hipermacia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24)
                        {
                            //maximo 50
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 29)
                        {
                            //maximo 50
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade >= 35)
                        {
                            //maximo 150
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Macia")
                    {
                        if (editarDados.densidade == 20)
                        {
                            //maximo 95
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 24)
                        {
                            //maximo 130
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 20)
                        {
                            //maximo 165
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade >= 35)
                        {
                            //maximo 200
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Aglomerado")
                    {
                        if (editarDados.densidade >= 65)
                        {
                            //maximo 35
                            if (editarDados.fator_ind_40 <= editarDados.forca_esp_40)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Visco elástica")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //minimo 25
                            if (editarDados.fator_ind_40 >= editarDados.forca_esp_40)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        editarDados.conforme = "C";
                    }

                    // conformidade fator conforto
                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18 || editarDados.densidade == 20)
                        {
                            //minimo 2,0
                            if (editarDados.media_conforto >= float.Parse(editarDados.fc_especificado))
                            {
                                editarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                editarDados.conforme_conforto = "NC";
                            }
                        }
                        else if (editarDados.densidade == 23 || editarDados.densidade == 26)
                        {
                            //minimo  2,1
                            if (editarDados.media_conforto >= float.Parse(editarDados.fc_especificado))
                            {
                                editarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                editarDados.conforme_conforto = "NC";
                            }
                        }
                        else if (editarDados.densidade == 28 || editarDados.densidade == 33 || editarDados.densidade == 40 || editarDados.densidade == 45)
                        {
                            //minimo  2,2
                            if (editarDados.media_conforto >= float.Parse(salvarDados.fc_especificado))
                            {
                                editarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                editarDados.conforme_conforto = "NC";
                            }
                        }
                    }
                    else if (editarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //minimo 2,3
                            if (editarDados.media_conforto >= float.Parse(editarDados.fc_especificado))
                            {
                                editarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                editarDados.conforme_conforto = "NC";
                            }
                        }
                    }
                    else if (editarDados.tipo_espuma == "Visco elástica")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //minimo 10
                            if (editarDados.media_conforto >= float.Parse(editarDados.fc_especificado))
                            {
                                editarDados.conforme_conforto = "C";
                            }
                            else
                            {
                                editarDados.conforme_conforto = "NC";
                            }
                        }
                        else
                        {
                            editarDados.conforme_conforto = "C";
                        }
                    }
                    else
                    {
                        editarDados.conforme_conforto = "C";
                    }


                    _context.lamina_fi.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("LaminaF_I", "Coleta", new { os, orcamento, item });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarLaminaFadiga(string os, string orcamento, ColetaModel.LaminaFadigaRotativa salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_fadiga_dinamica.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    //realizando o calculo de media...
                    float lar_media_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.lar_media_um = lar_media_um;

                    float lar_media_dois = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.lar_media_dois = lar_media_dois;

                    float lar_media_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.lar_media_tres = lar_media_tres;

                    float comp_media_um = ((salvarDados.comp_amostra_um_um + salvarDados.comp_amostra_um_dois + salvarDados.comp_amostra_um_tres + salvarDados.comp_amostra_um_quatro) / 4);
                    salvarDados.comp_media_um = comp_media_um;

                    float comp_media_dois = ((salvarDados.comp_amostra_dois_um + salvarDados.comp_amostra_dois_dois + salvarDados.comp_amostra_dois_tres + salvarDados.comp_amostra_dois_quatro) / 4);
                    salvarDados.comp_media_dois = comp_media_dois;

                    float comp_media_tres = ((salvarDados.comp_amostra_tres_um + salvarDados.comp_amostra_tres_dois + salvarDados.comp_amostra_tres_tres + salvarDados.comp_amostra_tres_quatro) / 4);
                    salvarDados.comp_media_tres = comp_media_tres;

                    float media_espi_ini_um = ((salvarDados.esp_ini_amostra_um_um + salvarDados.esp_ini_amostra_um_dois + salvarDados.esp_ini_amostra_um_tres + salvarDados.esp_ini_amostra_um_quatro + salvarDados.esp_ini_amostra_um_cinco + salvarDados.esp_ini_amostra_um_seis + salvarDados.esp_ini_amostra_um_sete + salvarDados.esp_ini_amostra_um_oito) / 8);
                    salvarDados.esp_ini_media_um = media_espi_ini_um;

                    float media_espi_ini_dois = ((salvarDados.esp_ini_amostra_dois_um + salvarDados.esp_ini_amostra_dois_dois + salvarDados.esp_ini_amostra_dois_tres + salvarDados.esp_ini_amostra_dois_quatro + salvarDados.esp_ini_amostra_dois_cinco + salvarDados.esp_ini_amostra_dois_seis + salvarDados.esp_ini_amostra_dois_sete + salvarDados.esp_ini_amostra_dois_oito) / 8);
                    salvarDados.esp_ini_media_dois = media_espi_ini_dois;

                    float media_espi_ini_tres = ((salvarDados.esp_ini_amostra_tres_um + salvarDados.esp_ini_amostra_tres_dois + salvarDados.esp_ini_amostra_tres_tres + salvarDados.esp_ini_amostra_tres_quatro + salvarDados.esp_ini_amostra_tres_cinco + salvarDados.esp_ini_amostra_tres_seis + salvarDados.esp_ini_amostra_tres_sete + salvarDados.esp_ini_amostra_tres_oito) / 8);
                    salvarDados.esp_ini_media_tres = media_espi_ini_tres;

                    //RECEBENDO OS VALORES DA MEDIA DA ESPESSURA....
                    salvarDados.media_espessura_um = salvarDados.esp_ini_media_um;
                    salvarDados.media_espessura_dois = salvarDados.esp_ini_media_dois;
                    salvarDados.media_espessura_tres = salvarDados.esp_ini_media_tres;
                    salvarDados.media_espessura_total = ((salvarDados.esp_ini_media_um + salvarDados.esp_ini_media_dois + salvarDados.esp_ini_media_tres) / 3);


                    //calculo de media esp final...
                    float media_esp_final_um = ((salvarDados.esp_final_amostra_um_um + salvarDados.esp_final_amostra_um_dois + salvarDados.esp_final_amostra_um_tres + salvarDados.esp_final_amostra_um_quatro + salvarDados.esp_final_amostra_um_cinco + salvarDados.esp_final_amostra_um_seis + salvarDados.esp_final_amostra_um_sete + salvarDados.esp_final_amostra_um_oito) / 8);
                    salvarDados.media_esp_fin_um = media_esp_final_um;

                    float media_esp_final_dois = ((salvarDados.esp_final_amostra_dois_um + salvarDados.esp_final_amostra_dois_dois + salvarDados.esp_final_amostra_dois_tres + salvarDados.esp_final_amostra_dois_quatro + salvarDados.esp_final_amostra_dois_cinco + salvarDados.esp_final_amostra_dois_seis + salvarDados.esp_final_amostra_dois_sete + salvarDados.esp_final_amostra_dois_oito) / 8);
                    salvarDados.media_esp_fin_dois = media_esp_final_dois;

                    float media_esp_final_tres = ((salvarDados.esp_final_amostra_tres_um + salvarDados.esp_final_amostra_tres_dois + salvarDados.esp_final_amostra_tres_tres + salvarDados.esp_final_amostra_tres_quatro + salvarDados.esp_final_amostra_tres_cinco + salvarDados.esp_final_amostra_tres_seis + salvarDados.esp_final_amostra_tres_sete + salvarDados.esp_final_amostra_tres_oito) / 8);
                    salvarDados.media_esp_fin_tres = media_esp_final_tres;


                    //CALCULO DE PERDA DE ESPESSURA.
                    salvarDados.pe_um_um = salvarDados.media_espessura_um;
                    salvarDados.pe_um_dois = salvarDados.media_esp_fin_um;
                    //salvarDados.pe_um_tres = salvarDados.media_esp_fin_um;
                    salvarDados.pe_media_um = (((salvarDados.pe_um_um - salvarDados.pe_um_dois) / salvarDados.pe_um_tres) * 100);

                    salvarDados.pe_dois_um = salvarDados.media_espessura_dois;
                    salvarDados.pe_dois_dois = salvarDados.media_esp_fin_dois;
                    //salvarDados.pe_dois_tres = salvarDados.media_esp_fin_dois;
                    salvarDados.pe_media_dois = (((salvarDados.pe_dois_um - salvarDados.pe_dois_dois) / salvarDados.pe_dois_tres) * 100);

                    salvarDados.pe_tres_um = salvarDados.media_espessura_tres;
                    salvarDados.pe_tres_dois = salvarDados.media_esp_fin_tres;
                    //salvarDados.pe_tres_tres = salvarDados.media_esp_fin_dois;
                    salvarDados.pe_media_tres = (((salvarDados.pe_tres_um - salvarDados.pe_tres_dois) / salvarDados.pe_tres_tres) * 100);

                    //pe_especificado resultado.
                    salvarDados.pe_encontrado = ((salvarDados.pe_media_um + salvarDados.pe_media_dois + salvarDados.pe_media_tres) / 3);

                    //realizando logica para saber se esta conforme ou nao conforme.
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18)
                        {
                            //maximo 8 aqui
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 20)
                        {
                            //maximo 6aqui
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 23 || salvarDados.densidade == 26 || salvarDados.densidade == 28)
                        {
                            //maximo 5
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade == 33 || salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //maximo 4
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Aglomerado")
                    {
                        if (salvarDados.densidade >= 65)
                        {
                            //maximo 10
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //minimo 5
                            if (salvarDados.pe_encontrado <= salvarDados.pe_especificado)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }

                    _context.lamina_fadiga_dinamica.Add(salvarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("LaminaFadiga", "Coleta", new { os, orcamento });
                }
                else
                {
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;
                    editarDados.densidade = salvarDados.densidade;
                    //editando os valores de largura.

                    editarDados.lar_amostra_um_um = salvarDados.lar_amostra_um_um;
                    editarDados.lar_amostra_um_dois = salvarDados.lar_amostra_um_dois;
                    editarDados.lar_amostra_um_tres = salvarDados.lar_amostra_um_tres;
                    editarDados.lar_amostra_um_quatro = salvarDados.lar_amostra_um_quatro;

                    editarDados.lar_amostra_dois_um = salvarDados.lar_amostra_dois_um;
                    editarDados.lar_amostra_dois_dois = salvarDados.lar_amostra_dois_dois;
                    editarDados.lar_amostra_dois_tres = salvarDados.lar_amostra_dois_tres;
                    editarDados.lar_amostra_dois_quatro = salvarDados.lar_amostra_dois_quatro;

                    editarDados.lar_amostra_tres_um = salvarDados.lar_amostra_tres_um;
                    editarDados.lar_amostra_tres_dois = salvarDados.lar_amostra_tres_dois;
                    editarDados.lar_amostra_tres_tres = salvarDados.lar_amostra_tres_tres;
                    editarDados.lar_amostra_tres_quatro = salvarDados.lar_amostra_tres_quatro;

                    //editando comp..
                    editarDados.comp_amostra_um_um = salvarDados.comp_amostra_um_um;
                    editarDados.comp_amostra_um_dois = salvarDados.comp_amostra_um_dois;
                    editarDados.comp_amostra_um_tres = salvarDados.comp_amostra_um_tres;
                    editarDados.comp_amostra_um_quatro = salvarDados.comp_amostra_um_quatro;

                    editarDados.comp_amostra_dois_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_dois_dois = salvarDados.comp_amostra_dois_dois;
                    editarDados.comp_amostra_dois_tres = salvarDados.comp_amostra_dois_tres;
                    editarDados.comp_amostra_dois_quatro = salvarDados.comp_amostra_dois_quatro;

                    editarDados.comp_amostra_tres_um = salvarDados.comp_amostra_tres_um;
                    editarDados.comp_amostra_tres_dois = salvarDados.comp_amostra_tres_dois;
                    editarDados.comp_amostra_tres_tres = salvarDados.comp_amostra_tres_tres;
                    editarDados.comp_amostra_tres_quatro = salvarDados.comp_amostra_tres_quatro;

                    //editando espessura inicial
                    editarDados.esp_ini_amostra_um_um = salvarDados.esp_ini_amostra_um_um;
                    editarDados.esp_ini_amostra_um_dois = salvarDados.esp_ini_amostra_um_dois;
                    editarDados.esp_ini_amostra_um_tres = salvarDados.esp_ini_amostra_um_tres;
                    editarDados.esp_ini_amostra_um_quatro = salvarDados.esp_ini_amostra_um_quatro;
                    editarDados.esp_ini_amostra_um_cinco = salvarDados.esp_ini_amostra_um_cinco;
                    editarDados.esp_ini_amostra_um_seis = salvarDados.esp_ini_amostra_um_seis;
                    editarDados.esp_ini_amostra_um_sete = salvarDados.esp_ini_amostra_um_sete;
                    editarDados.esp_ini_amostra_um_oito = salvarDados.esp_ini_amostra_um_oito;

                    editarDados.esp_ini_amostra_dois_um = salvarDados.esp_ini_amostra_dois_um;
                    editarDados.esp_ini_amostra_dois_dois = salvarDados.esp_ini_amostra_dois_dois;
                    editarDados.esp_ini_amostra_dois_tres = salvarDados.esp_ini_amostra_dois_tres;
                    editarDados.esp_ini_amostra_dois_quatro = salvarDados.esp_ini_amostra_dois_quatro;
                    editarDados.esp_ini_amostra_dois_cinco = salvarDados.esp_ini_amostra_dois_cinco;
                    editarDados.esp_ini_amostra_dois_seis = salvarDados.esp_ini_amostra_dois_seis;
                    editarDados.esp_ini_amostra_dois_sete = salvarDados.esp_ini_amostra_dois_sete;
                    editarDados.esp_ini_amostra_dois_oito = salvarDados.esp_ini_amostra_dois_oito;

                    editarDados.esp_ini_amostra_tres_um = salvarDados.esp_ini_amostra_tres_um;
                    editarDados.esp_ini_amostra_tres_dois = salvarDados.esp_ini_amostra_tres_dois;
                    editarDados.esp_ini_amostra_tres_tres = salvarDados.esp_ini_amostra_tres_tres;
                    editarDados.esp_ini_amostra_tres_quatro = salvarDados.esp_ini_amostra_tres_quatro;
                    editarDados.esp_ini_amostra_tres_cinco = salvarDados.esp_ini_amostra_tres_cinco;
                    editarDados.esp_ini_amostra_tres_seis = salvarDados.esp_ini_amostra_tres_seis;
                    editarDados.esp_ini_amostra_tres_sete = salvarDados.esp_ini_amostra_tres_sete;
                    editarDados.esp_ini_amostra_tres_oito = salvarDados.esp_ini_amostra_tres_oito;

                    //realizando calculo de media de cada tabela...
                    editarDados.lar_media_um = ((editarDados.lar_amostra_um_um + editarDados.lar_amostra_um_dois + editarDados.lar_amostra_um_tres + editarDados.lar_amostra_um_quatro) / 4);
                    editarDados.lar_media_dois = ((editarDados.lar_amostra_dois_um + editarDados.lar_amostra_dois_dois + editarDados.lar_amostra_dois_tres + editarDados.lar_amostra_dois_quatro) / 4);
                    editarDados.lar_media_tres = ((editarDados.lar_amostra_tres_um + editarDados.lar_amostra_tres_dois + editarDados.lar_amostra_tres_tres + editarDados.lar_amostra_tres_quatro) / 4);

                    editarDados.comp_media_um = ((editarDados.comp_amostra_um_um + editarDados.comp_amostra_um_dois + editarDados.comp_amostra_um_tres + editarDados.comp_amostra_um_quatro) / 4);
                    editarDados.comp_media_dois = ((editarDados.comp_amostra_dois_um + editarDados.comp_amostra_dois_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_dois_quatro) / 4);
                    editarDados.comp_media_tres = ((editarDados.comp_amostra_tres_um + editarDados.comp_amostra_tres_dois + editarDados.comp_amostra_tres_tres + editarDados.comp_amostra_tres_quatro) / 4);

                    editarDados.esp_ini_media_um = ((editarDados.esp_ini_amostra_um_um + editarDados.esp_ini_amostra_um_dois + editarDados.esp_ini_amostra_um_tres + editarDados.esp_ini_amostra_um_quatro + editarDados.esp_ini_amostra_um_cinco + editarDados.esp_ini_amostra_um_seis + editarDados.esp_ini_amostra_um_sete + editarDados.esp_ini_amostra_um_oito) / 8);
                    editarDados.esp_ini_media_dois = ((editarDados.esp_ini_amostra_dois_um + editarDados.esp_ini_amostra_dois_dois + editarDados.esp_ini_amostra_dois_tres + editarDados.esp_ini_amostra_dois_quatro + editarDados.esp_ini_amostra_dois_cinco + editarDados.esp_ini_amostra_dois_seis + editarDados.esp_ini_amostra_dois_sete + editarDados.esp_ini_amostra_dois_oito) / 8);
                    editarDados.esp_ini_media_tres = ((editarDados.esp_ini_amostra_tres_um + editarDados.esp_ini_amostra_tres_dois + editarDados.esp_ini_amostra_tres_tres + editarDados.esp_ini_amostra_tres_quatro + editarDados.esp_ini_amostra_tres_cinco + editarDados.esp_ini_amostra_tres_seis + editarDados.esp_ini_amostra_tres_sete + editarDados.esp_ini_amostra_tres_oito) / 8);

                    //editando os valores meida da espessura...
                    editarDados.media_espessura_um = editarDados.esp_ini_media_um;
                    editarDados.media_espessura_dois = editarDados.esp_ini_media_dois;
                    editarDados.media_espessura_tres = editarDados.esp_ini_media_tres;
                    editarDados.media_espessura_total = ((editarDados.esp_ini_media_um + editarDados.esp_ini_media_dois + editarDados.esp_ini_media_tres) / 3);

                    //qtd ciclos.
                    editarDados.ciclos_um = salvarDados.ciclos_um;
                    editarDados.ciclos_dois = salvarDados.ciclos_dois;
                    editarDados.ciclos_tres = salvarDados.ciclos_tres;

                    //esp final.
                    editarDados.esp_final_amostra_um_um = salvarDados.esp_final_amostra_um_um;
                    editarDados.esp_final_amostra_um_dois = salvarDados.esp_final_amostra_um_dois;
                    editarDados.esp_final_amostra_um_tres = salvarDados.esp_final_amostra_um_tres;
                    editarDados.esp_final_amostra_um_quatro = salvarDados.esp_final_amostra_um_quatro;
                    editarDados.esp_final_amostra_um_cinco = salvarDados.esp_final_amostra_um_cinco;
                    editarDados.esp_final_amostra_um_seis = salvarDados.esp_final_amostra_um_seis;
                    editarDados.esp_final_amostra_um_sete = salvarDados.esp_final_amostra_um_sete;
                    editarDados.esp_final_amostra_um_oito = salvarDados.esp_final_amostra_um_oito;

                    editarDados.esp_final_amostra_dois_um = salvarDados.esp_final_amostra_dois_um;
                    editarDados.esp_final_amostra_dois_dois = salvarDados.esp_final_amostra_dois_dois;
                    editarDados.esp_final_amostra_dois_tres = salvarDados.esp_final_amostra_dois_tres;
                    editarDados.esp_final_amostra_dois_quatro = salvarDados.esp_final_amostra_dois_quatro;
                    editarDados.esp_final_amostra_dois_cinco = salvarDados.esp_final_amostra_dois_cinco;
                    editarDados.esp_final_amostra_dois_seis = salvarDados.esp_final_amostra_dois_seis;
                    editarDados.esp_final_amostra_dois_sete = salvarDados.esp_final_amostra_dois_sete;
                    editarDados.esp_final_amostra_dois_oito = salvarDados.esp_final_amostra_dois_oito;

                    editarDados.esp_final_amostra_tres_um = salvarDados.esp_final_amostra_tres_um;
                    editarDados.esp_final_amostra_tres_dois = salvarDados.esp_final_amostra_tres_dois;
                    editarDados.esp_final_amostra_tres_tres = salvarDados.esp_final_amostra_tres_tres;
                    editarDados.esp_final_amostra_tres_quatro = salvarDados.esp_final_amostra_tres_quatro;
                    editarDados.esp_final_amostra_tres_cinco = salvarDados.esp_final_amostra_tres_cinco;
                    editarDados.esp_final_amostra_tres_seis = salvarDados.esp_final_amostra_tres_seis;
                    editarDados.esp_final_amostra_tres_sete = salvarDados.esp_final_amostra_tres_sete;
                    editarDados.esp_final_amostra_tres_oito = salvarDados.esp_final_amostra_tres_oito;

                    //media de esp final...
                    editarDados.media_esp_fin_um = ((editarDados.esp_final_amostra_um_um + editarDados.esp_final_amostra_um_dois + editarDados.esp_final_amostra_um_tres + editarDados.esp_final_amostra_um_quatro + editarDados.esp_final_amostra_um_cinco + editarDados.esp_final_amostra_um_seis + editarDados.esp_final_amostra_um_sete + editarDados.esp_final_amostra_um_oito) / 8);
                    editarDados.media_esp_fin_dois = ((editarDados.esp_final_amostra_dois_um + editarDados.esp_final_amostra_dois_dois + editarDados.esp_final_amostra_dois_tres + editarDados.esp_final_amostra_dois_quatro + editarDados.esp_final_amostra_dois_cinco + editarDados.esp_final_amostra_dois_seis + editarDados.esp_final_amostra_dois_sete + editarDados.esp_final_amostra_dois_oito) / 8);
                    editarDados.media_esp_fin_tres = ((editarDados.esp_final_amostra_tres_um + editarDados.esp_final_amostra_tres_dois + editarDados.esp_final_amostra_tres_tres + editarDados.esp_final_amostra_tres_quatro + editarDados.esp_final_amostra_tres_cinco + editarDados.esp_final_amostra_tres_seis + editarDados.esp_final_amostra_tres_sete + editarDados.esp_final_amostra_tres_oito) / 8);

                    editarDados.tempo_rep_esp_um = salvarDados.tempo_rep_esp_um;
                    editarDados.tempo_rep_esp_dois = salvarDados.tempo_rep_esp_dois;
                    editarDados.tempo_rep_esp_tres = salvarDados.tempo_rep_esp_tres;

                    //calculo de perda de espessura..
                    editarDados.pe_um_um = editarDados.media_espessura_um;
                    editarDados.pe_um_dois = editarDados.media_esp_fin_um;
                    editarDados.pe_um_tres = editarDados.media_esp_fin_um;
                    editarDados.pe_media_um = (((editarDados.pe_um_um - editarDados.pe_um_dois) / editarDados.pe_um_tres) * 100);

                    editarDados.pe_dois_um = editarDados.media_espessura_dois;
                    editarDados.pe_dois_dois = editarDados.media_esp_fin_dois;
                    editarDados.pe_dois_tres = editarDados.media_esp_fin_dois;
                    editarDados.pe_media_dois = (((editarDados.pe_dois_um - editarDados.pe_dois_dois) / editarDados.pe_dois_tres) * 100);

                    editarDados.pe_tres_um = editarDados.media_espessura_tres;
                    editarDados.pe_tres_dois = editarDados.media_esp_fin_tres;
                    editarDados.pe_tres_tres = editarDados.media_esp_fin_dois;
                    editarDados.pe_media_tres = (((editarDados.pe_tres_um - editarDados.pe_tres_dois) / editarDados.pe_tres_tres) * 100);

                    editarDados.pe_especificado = salvarDados.pe_especificado;
                    editarDados.pe_encontrado = ((editarDados.pe_media_um + editarDados.pe_media_dois + editarDados.pe_media_tres) / 3);
                    editarDados.min_max = salvarDados.min_max;

                    //realizando logica para saber se esta conforme ou nao conforme.
                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18)
                        {
                            //maximo 8 aqui
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 20)
                        {
                            //maximo 6aqui
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 23 || editarDados.densidade == 26 || editarDados.densidade == 28)
                        {
                            //maximo 5
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade == 33 || editarDados.densidade == 40 || editarDados.densidade == 45)
                        {
                            //maximo 4
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                    }
                    else if (editarDados.tipo_espuma == "Aglomerado")
                    {
                        if (editarDados.densidade >= 65)
                        {
                            //maximo 10
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //minimo 5
                            if (editarDados.pe_encontrado <= editarDados.pe_especificado)
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
                            editarDados.conforme = "C";
                        }
                    }

                    _context.lamina_fadiga_dinamica.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("LaminaFadiga", "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SalvarLaminaPFI(string os, string orcamento, ColetaModel.LaminaPFI salvarDados)
        {
            try
            {
                var editarDados = _context.lamina_pfi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {

                    //realizando media de largura, comprimento, e espessura.
                    //largura.
                    float lar_media_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.lar_media_um = lar_media_um;

                    float lar_media_dois = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.lar_media_dois = lar_media_dois;

                    float lar_media_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.lar_media_tres = lar_media_tres;

                    //comprimento.
                    float comp_media_um = ((salvarDados.lar_amostra_um_um + salvarDados.lar_amostra_um_dois + salvarDados.lar_amostra_um_tres + salvarDados.lar_amostra_um_quatro) / 4);
                    salvarDados.comp_media_um = comp_media_um;

                    float comp_media_dois = ((salvarDados.lar_amostra_dois_um + salvarDados.lar_amostra_dois_dois + salvarDados.lar_amostra_dois_tres + salvarDados.lar_amostra_dois_quatro) / 4);
                    salvarDados.comp_media_dois = comp_media_dois;

                    float comp_media_tres = ((salvarDados.lar_amostra_tres_um + salvarDados.lar_amostra_tres_dois + salvarDados.lar_amostra_tres_tres + salvarDados.lar_amostra_tres_quatro) / 4);
                    salvarDados.comp_media_tres = comp_media_tres;

                    //espessura.. 
                    float media_esp_um = ((salvarDados.esp_ini_amostra_um_um + salvarDados.esp_ini_amostra_um_dois + salvarDados.esp_ini_amostra_um_tres + salvarDados.esp_ini_amostra_um_quatro + salvarDados.esp_ini_amostra_um_cinco + salvarDados.esp_ini_amostra_um_seis + salvarDados.esp_ini_amostra_um_sete + salvarDados.esp_ini_amostra_um_oito) / 8);
                    salvarDados.esp_media_um = media_esp_um;

                    float media_esp_dois = ((salvarDados.esp_ini_amostra_dois_um + salvarDados.esp_ini_amostra_dois_dois + salvarDados.esp_ini_amostra_dois_tres + salvarDados.esp_ini_amostra_dois_quatro + salvarDados.esp_ini_amostra_dois_cinco + salvarDados.esp_ini_amostra_dois_seis + salvarDados.esp_ini_amostra_dois_sete + salvarDados.esp_ini_amostra_dois_oito) / 8);
                    salvarDados.esp_media_dois = media_esp_dois;

                    float media_esp_tres = ((salvarDados.esp_ini_amostra_tres_um + salvarDados.esp_ini_amostra_tres_dois + salvarDados.esp_ini_amostra_tres_tres + salvarDados.esp_ini_amostra_tres_quatro + salvarDados.esp_ini_amostra_tres_cinco + salvarDados.esp_ini_amostra_tres_seis + salvarDados.esp_ini_amostra_tres_sete + salvarDados.esp_ini_amostra_tres_oito) / 8);
                    salvarDados.esp_media_tres = media_esp_tres;

                    //media da espessura..
                    salvarDados.media_espessura_um = salvarDados.esp_media_um;
                    salvarDados.media_espessura_dois = salvarDados.esp_media_dois;
                    salvarDados.media_espessura_tres = salvarDados.esp_media_tres;


                    //calculo de reducao...
                    float red_25_um = ((salvarDados.media_espessura_um * salvarDados.comp_25_um) / 100);
                    salvarDados.red_25_um = red_25_um;

                    float red_25_dois = ((salvarDados.media_espessura_dois * salvarDados.comp_25_dois) / 100);
                    salvarDados.red_25_dois = red_25_dois;

                    float red_25_tres = ((salvarDados.media_espessura_tres * salvarDados.comp_25_tres) / 100);
                    salvarDados.red_25_tres = red_25_tres;


                    float red_40_um = ((salvarDados.media_espessura_um * salvarDados.comp_40_um) / 100);
                    salvarDados.red_40_um = red_40_um;

                    float red_40_dois = ((salvarDados.media_espessura_dois * salvarDados.comp_40_dois) / 100);
                    salvarDados.red_40_dois = red_40_dois;

                    float red_40_tres = ((salvarDados.media_espessura_tres * salvarDados.comp_40_tres) / 100);
                    salvarDados.red_40_tres = red_40_tres;


                    float red_65_um = ((salvarDados.media_espessura_um * salvarDados.comp_65_um) / 100);
                    salvarDados.red_65_um = red_65_um;

                    float red_65_dois = ((salvarDados.media_espessura_dois * salvarDados.comp_65_dois) / 100);
                    salvarDados.red_65_dois = red_65_dois;

                    float red_65_tres = ((salvarDados.media_espessura_tres * salvarDados.comp_65_tres) / 100);
                    salvarDados.red_65_tres = red_65_tres;


                    float media_red_total_25 = ((salvarDados.fi_25_um + salvarDados.fi_25_dois + salvarDados.fi_25_tres) / 3);
                    salvarDados.media_25_comp = media_red_total_25;

                    float media_red_total_40 = ((salvarDados.fi_40_um + salvarDados.fi_40_dois + salvarDados.fi_40_tres) / 3);
                    salvarDados.media_40_comp = media_red_total_40;

                    float media_red_total_65 = ((salvarDados.fi_65_um + salvarDados.fi_65_dois + salvarDados.fi_65_tres) / 3);
                    salvarDados.media_65_comp = media_red_total_65;

                    //força encontrada de indentação..
                    //salvarDados.forca_ind_enc_25 = salvarDados.media_25_comp;
                    salvarDados.forca_ind_enc_40 = salvarDados.media_40_comp;
                    //salvarDados.forca_ind_enc_65 = salvarDados.media_65_comp;

                    //inicio de calculos de pfi..
                    var buscarFi = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                    if (buscarFi == null)
                    {
                        TempData["Mensagem"] = "ATENÇÃO ENSAIO DE F.I NÃO REALIZADO!!!!! REALIZE PRIMEIRO O ENSAIO DE F.I PARA CONTINUAR ESSE ENSAIO";
                        return RedirectToAction(nameof(LaminaPFI), "Coleta", new { os, orcamento });
                    }

                    salvarDados.pfi_25_um = buscarFi.fator_ind_25;
                    salvarDados.pfi_25_dois = salvarDados.forca_ind_enc_25;
                    salvarDados.pfi_25_tres = salvarDados.pfi_25_um;

                    float pfi_25_encontrada = (((salvarDados.pfi_25_um - salvarDados.pfi_25_dois) / salvarDados.pfi_25_tres) * 100);
                    salvarDados.pfi_25_encontrada = pfi_25_encontrada;

                    //pfi de 40%.
                    salvarDados.pfi_40_um = buscarFi.fator_ind_40;
                    salvarDados.pfi_40_dois = salvarDados.forca_ind_enc_40;
                    salvarDados.pfi_40_tres = salvarDados.pfi_40_um;

                    float pfi_40_encotrada = (((salvarDados.pfi_40_um - salvarDados.pfi_40_dois) / salvarDados.pfi_40_tres) * 100);
                    salvarDados.pfi_40_encontrada = pfi_40_encotrada;

                    //pfi de 65%..
                    salvarDados.pfi_65_um = buscarFi.fator_ind_65;
                    salvarDados.pfi_65_dois = salvarDados.forca_ind_enc_65;
                    salvarDados.pfi_65_tres = salvarDados.pfi_65_um;

                    float pfi_65_encotrada = (((salvarDados.pfi_65_um - salvarDados.pfi_65_dois) / salvarDados.pfi_65_tres) * 100);
                    salvarDados.pfi_65_encontrada = pfi_65_encotrada;



                    // conformidades.
                    if (salvarDados.tipo_espuma == "Convencional")
                    {
                        if (salvarDados.densidade == 18 || salvarDados.densidade == 20 || salvarDados.densidade == 23 || salvarDados.densidade == 26 || salvarDados.densidade == 28 || salvarDados.densidade == 33 || salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //maximo 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Hipermacia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24 || salvarDados.densidade == 29 || salvarDados.densidade >= 35)
                        {
                            //maximo 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Macia")
                    {
                        if (salvarDados.densidade == 20 || salvarDados.densidade == 24 || salvarDados.densidade == 29)
                        {
                            //maximo 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else if (salvarDados.densidade >= 35)
                        {
                            //maximo 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //maximoo 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else if (salvarDados.tipo_espuma == "Visco elástica")
                    {
                        if (salvarDados.densidade >= 30)
                        {
                            //maxima 1
                            if (salvarDados.pfi_40_encontrada <= salvarDados.pfi_40_especificada)
                            {
                                salvarDados.conforme = "C";
                            }
                            else
                            {
                                salvarDados.conforme = "NC";
                            }
                        }
                        else
                        {
                            salvarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        salvarDados.conforme = "C";
                    }

                    _context.lamina_pfi.Add(salvarDados);
                    await _context.SaveChangesAsync();

                    TempData["Mensagem"] = "Dados Salvo com sucesso.";
                    return RedirectToAction("LaminaPFI", "Coleta", new { os, orcamento });
                }
                else
                {
                    //editando os dados recebidos do html..
                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.tipo_espuma = salvarDados.tipo_espuma;

                    //editando os valores recebidos de largura,compriment e espessura.
                    editarDados.lar_amostra_um_um = salvarDados.lar_amostra_um_um;
                    editarDados.lar_amostra_um_dois = salvarDados.lar_amostra_um_dois;
                    editarDados.lar_amostra_um_tres = salvarDados.lar_amostra_um_tres;
                    editarDados.lar_amostra_um_quatro = salvarDados.lar_amostra_um_quatro;

                    editarDados.lar_amostra_dois_um = salvarDados.lar_amostra_dois_um;
                    editarDados.lar_amostra_dois_dois = salvarDados.lar_amostra_dois_dois;
                    editarDados.lar_amostra_dois_tres = salvarDados.lar_amostra_dois_tres;
                    editarDados.lar_amostra_dois_quatro = salvarDados.lar_amostra_dois_quatro;

                    editarDados.lar_amostra_tres_um = salvarDados.lar_amostra_tres_um;
                    editarDados.lar_amostra_tres_dois = salvarDados.lar_amostra_tres_dois;
                    editarDados.lar_amostra_tres_tres = salvarDados.lar_amostra_tres_tres;
                    editarDados.lar_amostra_tres_quatro = salvarDados.lar_amostra_tres_quatro;

                    //comprimento..
                    editarDados.comp_amostra_um_um = salvarDados.comp_amostra_um_um;
                    editarDados.comp_amostra_um_dois = salvarDados.comp_amostra_um_dois;
                    editarDados.comp_amostra_um_tres = salvarDados.comp_amostra_um_tres;
                    editarDados.comp_amostra_um_quatro = salvarDados.comp_amostra_um_quatro;

                    editarDados.comp_amostra_dois_um = salvarDados.comp_amostra_dois_um;
                    editarDados.comp_amostra_dois_dois = salvarDados.comp_amostra_dois_dois;
                    editarDados.comp_amostra_dois_tres = salvarDados.comp_amostra_dois_tres;
                    editarDados.comp_amostra_dois_quatro = salvarDados.comp_amostra_dois_quatro;

                    editarDados.comp_amostra_tres_um = salvarDados.comp_amostra_tres_um;
                    editarDados.comp_amostra_tres_dois = salvarDados.comp_amostra_tres_dois;
                    editarDados.comp_amostra_tres_tres = salvarDados.comp_amostra_tres_tres;
                    editarDados.comp_amostra_tres_quatro = salvarDados.comp_amostra_tres_quatro;

                    //espessura...
                    editarDados.esp_ini_amostra_um_um = salvarDados.esp_ini_amostra_um_um;
                    editarDados.esp_ini_amostra_um_dois = salvarDados.esp_ini_amostra_um_dois;
                    editarDados.esp_ini_amostra_um_tres = salvarDados.esp_ini_amostra_um_tres;
                    editarDados.esp_ini_amostra_um_quatro = salvarDados.esp_ini_amostra_um_quatro;
                    editarDados.esp_ini_amostra_um_cinco = salvarDados.esp_ini_amostra_um_cinco;
                    editarDados.esp_ini_amostra_um_seis = salvarDados.esp_ini_amostra_um_seis;
                    editarDados.esp_ini_amostra_um_sete = salvarDados.esp_ini_amostra_um_sete;
                    editarDados.esp_ini_amostra_um_oito = salvarDados.esp_ini_amostra_um_oito;

                    editarDados.esp_ini_amostra_dois_um = salvarDados.esp_ini_amostra_dois_um;
                    editarDados.esp_ini_amostra_dois_dois = salvarDados.esp_ini_amostra_dois_dois;
                    editarDados.esp_ini_amostra_dois_tres = salvarDados.esp_ini_amostra_dois_tres;
                    editarDados.esp_ini_amostra_dois_quatro = salvarDados.esp_ini_amostra_dois_quatro;
                    editarDados.esp_ini_amostra_dois_cinco = salvarDados.esp_ini_amostra_dois_cinco;
                    editarDados.esp_ini_amostra_dois_seis = salvarDados.esp_ini_amostra_dois_seis;
                    editarDados.esp_ini_amostra_dois_sete = salvarDados.esp_ini_amostra_dois_sete;
                    editarDados.esp_ini_amostra_dois_oito = salvarDados.esp_ini_amostra_dois_oito;

                    editarDados.esp_ini_amostra_tres_um = salvarDados.esp_ini_amostra_tres_um;
                    editarDados.esp_ini_amostra_tres_dois = salvarDados.esp_ini_amostra_tres_dois;
                    editarDados.esp_ini_amostra_tres_tres = salvarDados.esp_ini_amostra_tres_tres;
                    editarDados.esp_ini_amostra_tres_quatro = salvarDados.esp_ini_amostra_tres_quatro;
                    editarDados.esp_ini_amostra_tres_cinco = salvarDados.esp_ini_amostra_tres_cinco;
                    editarDados.esp_ini_amostra_tres_seis = salvarDados.esp_ini_amostra_tres_seis;
                    editarDados.esp_ini_amostra_tres_sete = salvarDados.esp_ini_amostra_tres_sete;
                    editarDados.esp_ini_amostra_tres_oito = salvarDados.esp_ini_amostra_tres_oito;

                    //realizar calculos de media da tabela...

                    //media de larg..
                    editarDados.lar_media_um = ((editarDados.lar_amostra_um_um + editarDados.lar_amostra_um_dois + editarDados.lar_amostra_um_tres + editarDados.lar_amostra_um_quatro) / 4);
                    editarDados.lar_media_dois = ((editarDados.lar_amostra_dois_um + editarDados.lar_amostra_dois_dois + editarDados.lar_amostra_dois_tres + editarDados.lar_amostra_dois_quatro) / 4);
                    editarDados.lar_media_tres = ((salvarDados.lar_amostra_tres_um + editarDados.lar_amostra_tres_dois + editarDados.lar_amostra_tres_tres + editarDados.lar_amostra_tres_quatro) / 4);

                    //media comp..
                    editarDados.comp_media_um = ((editarDados.comp_amostra_um_um + editarDados.comp_amostra_um_dois + editarDados.comp_amostra_um_tres + editarDados.comp_amostra_um_quatro) / 4);
                    editarDados.comp_media_dois = ((editarDados.comp_amostra_dois_um + editarDados.comp_amostra_dois_dois + editarDados.comp_amostra_dois_tres + editarDados.comp_amostra_dois_quatro) / 4);
                    editarDados.comp_media_tres = ((editarDados.comp_amostra_tres_um + editarDados.comp_amostra_tres_dois + editarDados.comp_amostra_tres_tres + editarDados.comp_amostra_tres_quatro) / 4);

                    //media espessura.
                    editarDados.esp_media_um = ((editarDados.esp_ini_amostra_um_um + editarDados.esp_ini_amostra_um_dois + editarDados.esp_ini_amostra_um_tres + editarDados.esp_ini_amostra_um_quatro + editarDados.esp_ini_amostra_um_cinco + editarDados.esp_ini_amostra_um_seis + editarDados.esp_ini_amostra_um_sete + editarDados.esp_ini_amostra_um_oito) / 8);
                    editarDados.esp_media_dois = ((editarDados.esp_ini_amostra_dois_um + editarDados.esp_ini_amostra_dois_dois + editarDados.esp_ini_amostra_dois_tres + editarDados.esp_ini_amostra_dois_quatro + editarDados.esp_ini_amostra_dois_cinco + editarDados.esp_ini_amostra_dois_seis + editarDados.esp_ini_amostra_dois_sete + editarDados.esp_ini_amostra_dois_oito) / 8);
                    editarDados.esp_media_tres = ((editarDados.esp_ini_amostra_tres_um + editarDados.esp_ini_amostra_tres_dois + editarDados.esp_ini_amostra_tres_tres + editarDados.esp_ini_amostra_tres_quatro + editarDados.esp_ini_amostra_tres_cinco + editarDados.esp_ini_amostra_tres_seis + editarDados.esp_ini_amostra_tres_sete + editarDados.esp_ini_amostra_tres_oito) / 8);

                    //recebendo media de espessura.
                    editarDados.media_espessura_um = editarDados.esp_media_um;
                    editarDados.media_espessura_dois = editarDados.esp_media_dois;
                    editarDados.media_espessura_tres = editarDados.esp_media_tres;

                    //precarga.
                    editarDados.pre_carga = salvarDados.pre_carga;

                    //inico de compressao 25%.
                    editarDados.comp_25_um = salvarDados.comp_25_um;
                    editarDados.temp_25_um = salvarDados.temp_25_um;
                    editarDados.fi_25_um = salvarDados.fi_25_um;
                    editarDados.red_25_um = ((editarDados.media_espessura_um * editarDados.comp_25_um) / 100);


                    editarDados.comp_25_dois = salvarDados.comp_25_dois;
                    editarDados.temp_25_dois = salvarDados.temp_25_dois;
                    editarDados.fi_25_dois = salvarDados.fi_25_dois;
                    editarDados.red_25_dois = ((editarDados.media_espessura_dois * editarDados.comp_25_dois) / 100);

                    editarDados.comp_25_tres = salvarDados.comp_25_tres;
                    editarDados.temp_25_tres = salvarDados.temp_25_tres;
                    editarDados.fi_25_tres = salvarDados.fi_25_tres;
                    editarDados.red_25_tres = ((editarDados.media_espessura_tres * editarDados.comp_25_tres) / 100);

                    editarDados.media_25_comp = ((editarDados.red_25_um + editarDados.red_25_dois + editarDados.red_25_tres) / 3);

                    //compressao de 40%.
                    editarDados.comp_40_um = salvarDados.comp_40_um;
                    editarDados.temp_40_um = salvarDados.temp_40_um;
                    editarDados.fi_40_um = salvarDados.fi_40_um;
                    editarDados.red_40_um = ((editarDados.media_espessura_um * editarDados.comp_40_um) / 100);

                    editarDados.comp_40_dois = salvarDados.comp_40_dois;
                    editarDados.temp_40_dois = salvarDados.temp_40_dois;
                    editarDados.fi_40_dois = salvarDados.fi_40_dois;
                    editarDados.red_40_dois = ((editarDados.media_espessura_dois * editarDados.comp_40_dois) / 100);

                    editarDados.comp_40_tres = salvarDados.comp_40_tres;
                    editarDados.temp_40_tres = salvarDados.temp_40_tres;
                    editarDados.fi_40_tres = salvarDados.fi_40_tres;
                    editarDados.red_40_tres = ((editarDados.media_espessura_tres * editarDados.comp_40_tres) / 100);

                    editarDados.media_40_comp = ((editarDados.fi_40_um + editarDados.fi_40_dois + editarDados.fi_40_tres) / 3);

                    //comrpessao 65%;
                    editarDados.comp_65_um = salvarDados.comp_65_um;
                    editarDados.temp_65_um = salvarDados.temp_65_um;
                    editarDados.fi_65_um = salvarDados.fi_65_um;
                    editarDados.red_65_um = ((editarDados.media_espessura_um * editarDados.comp_65_um) / 100);

                    editarDados.comp_65_dois = salvarDados.comp_65_dois;
                    editarDados.temp_65_dois = salvarDados.temp_65_dois;
                    editarDados.fi_65_dois = salvarDados.fi_65_dois;
                    editarDados.red_65_dois = ((editarDados.media_espessura_dois * editarDados.comp_65_dois) / 100);

                    editarDados.comp_65_tres = salvarDados.comp_65_tres;
                    editarDados.temp_65_tres = salvarDados.temp_65_tres;
                    editarDados.fi_65_tres = salvarDados.fi_65_tres;
                    editarDados.red_65_tres = ((editarDados.media_espessura_tres * editarDados.comp_65_tres) / 100);

                    editarDados.media_65_comp = ((editarDados.fi_65_um + editarDados.fi_65_dois + editarDados.fi_65_tres) / 3);

                    //força indentação especificado e encontrado.
                    editarDados.forca_ind_esp_40 = salvarDados.forca_ind_esp_40;
                    editarDados.forca_ind_esp_25 = salvarDados.forca_ind_esp_25;
                    editarDados.forca_ind_esp_65 = salvarDados.forca_ind_esp_25;

                    //editarDados.forca_ind_enc_25 = editarDados.media_25_comp;
                    editarDados.forca_ind_enc_40 = editarDados.media_40_comp;
                    //editarDados.forca_ind_enc_65 = editarDados.media_65_comp;


                    //calculos de pfi.
                    var buscarFi = _context.lamina_fi.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                    if (buscarFi == null)
                    {
                        TempData["Mensagem"] = "Erro ao editar dados";
                        return RedirectToAction(nameof(LaminaPFI), "Coleta", new { os, orcamento });
                    }

                    editarDados.pfi_25_um = buscarFi.forca_esp_25;
                    editarDados.pfi_25_dois = editarDados.pfi_25_encontrada;
                    editarDados.pfi_25_tres = editarDados.pfi_25_um;
                    editarDados.pfi_25_especificada = salvarDados.pfi_25_especificada;
                    editarDados.pfi_25_encontrada = (((editarDados.pfi_25_um - editarDados.pfi_25_dois) / editarDados.pfi_25_tres) * 100);

                    editarDados.pfi_40_um = buscarFi.forca_esp_40;
                    editarDados.pfi_40_dois = editarDados.pfi_40_encontrada;
                    editarDados.pfi_40_tres = editarDados.pfi_40_tres;
                    editarDados.pfi_40_especificada = salvarDados.pfi_40_especificada;
                    editarDados.pfi_40_encontrada = (((editarDados.pfi_40_um - editarDados.pfi_40_dois) / editarDados.pfi_40_tres) * 100);

                    editarDados.pfi_65_um = buscarFi.forca_esp_65;
                    editarDados.pfi_65_dois = editarDados.pfi_65_encontrada;
                    editarDados.pfi_65_tres = editarDados.pfi_65_tres;
                    editarDados.pfi_65_especificada = salvarDados.pfi_65_especificada;
                    editarDados.pfi_65_encontrada = (((editarDados.pfi_65_um - editarDados.pfi_65_dois) / editarDados.pfi_65_tres) * 100);

                    // conformidades.
                    if (editarDados.tipo_espuma == "Convencional")
                    {
                        if (editarDados.densidade == 18 || editarDados.densidade == 20 || editarDados.densidade == 23 || salvarDados.densidade == 26 || salvarDados.densidade == 28 || salvarDados.densidade == 33 || salvarDados.densidade == 40 || salvarDados.densidade == 45)
                        {
                            //maximo 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Hipermacia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24 || editarDados.densidade == 29 || salvarDados.densidade >= 35)
                        {
                            //maximo 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Macia")
                    {
                        if (editarDados.densidade == 20 || editarDados.densidade == 24 || editarDados.densidade == 29)
                        {
                            //maximo 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "NC";
                            }
                        }
                        else if (editarDados.densidade >= 35)
                        {
                            //maximo 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
                            {
                                editarDados.conforme = "C";
                            }
                            else
                            {
                                editarDados.conforme = "C";
                            }
                        }
                        else
                        {
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Alta resiliência")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //maximoo 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else if (editarDados.tipo_espuma == "Visco elástica")
                    {
                        if (editarDados.densidade >= 30)
                        {
                            //maxima 1
                            if (editarDados.pfi_40_encontrada <= editarDados.pfi_40_especificada)
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
                            editarDados.conforme = "C";
                        }
                    }
                    else
                    {
                        editarDados.conforme = "C";
                    }


                    _context.lamina_pfi.Update(editarDados);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado com sucesso.";
                    return RedirectToAction("LaminaPFI", "Coleta", new { os, orcamento });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Anexar(List<IFormFile> arquivo, string os, string orcamento, List<string> titulo, List<string> layout, List<int> juntar)
        {
            try
            {
                for (int i = 0; i < arquivo.Count; i++)
                {
                    //pegando os dados do arquivo para salvar.
                    string newFileName = arquivo[i].FileName;
                    string tipoArquivo = Path.GetExtension(newFileName);

                    ////salvando no ftp
                    string url = "ftp://labsystem-nuvem.com.br/imagens_arq/imagens/relatorios/colchao/" + os + '-' + i + tipoArquivo;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                    request.Credentials = new NetworkCredential("u838556479.admin", "@7847Awse");
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    using (Stream ftpStream = request.GetRequestStream())
                    {
                        arquivo[i].CopyTo(ftpStream);
                    }

                    string newUrl = "https://labsystem-nuvem.com.br/imagens_arq/imagens/relatorios/colchao/" + os + '-' + i + tipoArquivo;
                    //salvando no banco de dados.
                    var dados = new Arquivos.Imagens
                    {
                        rae = int.Parse(os),
                        orcamento = orcamento,
                        titulo = titulo[i],
                        layout = layout[i],
                        juntar = juntar[i],
                        img = newUrl
                    };
                    _context.colchao_anexos.Add(dados);
                }
                await _context.SaveChangesAsync();
                //return Json(new { success = true, message = "Dados salvos com sucesso." });
                return RedirectToAction(nameof(EnviarFotos), "Coleta", new { os, orcamento });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }

        }
    }
}
