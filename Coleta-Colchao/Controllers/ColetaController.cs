using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Security.Claims;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
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
        public IActionResult EditarRegistro(string os, string orcamento)
        {
            var dados = _context.regtro_colchao.Where(x => x.os == os && x.orcamento == orcamento).ToList();
            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("EditarRegistro", dados);
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

            if (dados != null)
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/EnsaioEspuma4_1", dados);

            }
            else
            {
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Espuma/EnsaioEspuma4_1");
            }

        }
        public IActionResult EnsaioEspuma4_3(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Espuma/EnsaioEspuma4_3");
        }
        public IActionResult EnsaioEspuma4_4()
        {
            return View("Espuma/EnsaioEspuma4_4");
        }
        public IActionResult EnsaioIdentificacao()
        {
            return View("Espuma/EnsaioIdentificacao");
        }
        public IActionResult IdentificacaoEmbalagem()
        {
            return View("Espuma/IdentificacaoEmbalagem");
        }
        public IActionResult EnsaioBaseCargaEstatica()
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
                ViewBag.os = os;
                ViewBag.orcamento = orcamento;
                return View("Molas/EnsaioMolas7_7");
            }
            else
            {
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
        public async Task<IActionResult> SalvarRegistro(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,num_proc,cod_ref,tipo_cert,modelo_cert,tipo_proc,produto,estrutura,tipo_molejo,quant_molejo,fornecedor_um,fornecedor_dois,nome_molejo_um,nome_molejo_dois,quant_media_um,quant_media_dois,bitola_arame_um,bitola_arame_dois,borda_peri,isolante,latex,napa_cou_plas,manual")] ColetaModel.Registro registro)
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
        public async Task<IActionResult> EditarRegistro(string os, string orcamento, [Bind("lacre,realizacao_ensaios,quant_recebida,quant_ensaiada,data_realizacao_ini,data_realizacao_term,num_proc,cod_ref,tipo_cert,modelo_cert,tipo_proc,produto,estrutura,tipo_molejo,quant_molejo,fornecedor_um,fornecedor_dois,nome_molejo_um,nome_molejo_dois,quant_media_um,quant_media_dois,bitola_arame_um,bitola_arame_dois,borda_peri,isolante,latex,napa_cou_plas,manual")] ColetaModel.Registro EditarRegistros)
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
                    return RedirectToAction(nameof(EditarRegistro), "Coleta", new { os, orcamento });
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
        public async Task<IActionResult> SalvarEnsaio4_3(string os, string orcamento, [Bind("borda,borda1,data_ini,data_term,valor_enc_1,valor_enc_2,man_parale_1,man_parale_2")] ColetaModel.Ensaio4_3 salvarDados)
        {
            try
            {
                var dados = _context.ensaio_molas_item4_3.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();

                if (dados == null)
                {
                    string borda = salvarDados.borda;
                    string borda1 = salvarDados.borda1;
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    float valor_enc_1 = salvarDados.valor_enc_1;
                    float valor_enc_2 = salvarDados.valor_enc_2;
                    string man_parale_1 = salvarDados.man_parale_1;
                    string man_parale_2 = salvarDados.man_parale_2;

                    var registro = new ColetaModel.Ensaio4_3
                    {
                        os = os,
                        orcamento = orcamento,
                        borda = borda,
                        borda1 = borda1,
                        data_ini = data_ini,
                        data_term = data_term,
                        valor_enc_1 = valor_enc_1,
                        valor_enc_2 = valor_enc_2,
                        man_parale_1 = man_parale_1,
                        man_parale_2 = man_parale_2,
                    };

                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Salvo Com Sucesso";
                    return View("Molas/EnsaioMolas4_3");
                }
                else
                {
                    dados.borda = salvarDados.borda;
                    dados.borda1 = salvarDados.borda1;
                    dados.data_ini = salvarDados.data_ini;
                    dados.data_term = salvarDados.data_term;
                    dados.valor_enc_1 = salvarDados.valor_enc_1;
                    dados.valor_enc_2 = salvarDados.valor_enc_2;
                    dados.man_parale_1 = salvarDados.man_parale_1;
                    dados.man_parale_2 = salvarDados.man_parale_2;

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
        public async Task<IActionResult> SalvarEnsaio7_5(string os, string orcamento, [Bind("data_ini,data_term,temp_ensaio,faces,esp_face_1,med_face_1,acom_esp_face_1,acom_enc_face_1,esp_face_2,med_face_2,acom_esp_face_2,acom_enc_face_2,executor,auxiliar")] ColetaModel.Ensaio7_5 salvarDados)
        {
            try
            {
                var editarDados = _context.ensaio_molas_item7_5.Where(x => x.os == os && x.orcamento == orcamento).FirstOrDefault();
                if (editarDados == null)
                {
                    DateOnly data_ini = salvarDados.data_ini;
                    DateOnly data_term = salvarDados.data_term;
                    TimeOnly temp_ensaio = salvarDados.temp_ensaio;
                    string faces = salvarDados.faces;
                    float esp_face_1 = salvarDados.esp_face_1;
                    float med_face_1 = salvarDados.med_face_1;
                    float acom_esp_face_1 = salvarDados.acom_esp_face_1;
                    float esp_face_2 = salvarDados.esp_face_2;
                    float med_face_2 = salvarDados.med_face_2;
                    float acom_esp_face_2 = salvarDados.acom_esp_face_2;

                    //realizando calculo para pegar porcetagem, convertendo para pegar 2 numeros depois da virgula.
                    float acom_enc_face_1 = ((esp_face_1 * 100) / (esp_face_1 - med_face_1) - 100);
                    string conv_acom_enc_face_1 = acom_enc_face_1.ToString("N2");
                    float valor_final_conv_acom_enc_face_1 = float.Parse(conv_acom_enc_face_1);

                    float acom_enc_face_2 = ((esp_face_2 * 100) / (esp_face_2 - med_face_2) - 100);
                    string conv_acom_enc_face_2 = acom_enc_face_2.ToString("N2");
                    float valor_final_conv_acom_enc_face_2 = float.Parse(conv_acom_enc_face_2);

                    var registro = new ColetaModel.Ensaio7_5
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        temp_ensaio = temp_ensaio,
                        esp_face_1 = esp_face_1,
                        med_face_1 = med_face_1,
                        acom_esp_face_1 = acom_esp_face_1,
                        acom_enc_face_1 = valor_final_conv_acom_enc_face_1,
                        esp_face_2 = esp_face_2,
                        med_face_2 = med_face_2,
                        acom_esp_face_2 = acom_esp_face_2,
                        acom_enc_face_2 = valor_final_conv_acom_enc_face_2,
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
                    editarDados.faces = salvarDados.faces;
                    editarDados.acom_esp_face_1 = salvarDados.acom_esp_face_1;
                    editarDados.acom_esp_face_2 = salvarDados.acom_esp_face_2;
                    editarDados.esp_face_1 = salvarDados.esp_face_1;
                    editarDados.med_face_1 = salvarDados.med_face_1;
                    editarDados.esp_face_2 = salvarDados.esp_face_2;
                    editarDados.med_face_2 = salvarDados.med_face_2;

                    //realizando as contas necessarias.
                    float acom_enc_face_1 = ((editarDados.esp_face_1 * 100) / (editarDados.esp_face_1 - editarDados.med_face_1) - 100);
                    string conv_acom_enc_face_1 = acom_enc_face_1.ToString("N2");
                    float valor_final_conv_acom_enc_face_1 = float.Parse(conv_acom_enc_face_1);

                    float acom_enc_face_2 = ((editarDados.esp_face_2 * 100) / (editarDados.esp_face_2 - editarDados.med_face_2) - 100);
                    string conv_acom_enc_face_2 = acom_enc_face_2.ToString("N2");
                    float valor_final_conv_acom_enc_face_2 = float.Parse(conv_acom_enc_face_2);

                    editarDados.acom_enc_face_2 = valor_final_conv_acom_enc_face_2;
                    editarDados.acom_enc_face_1 = valor_final_conv_acom_enc_face_1;

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

                    float media_comprimeto = (editarDados.comp_med_1 + editarDados.comp_med_2 + editarDados.comp_med_3) / 3;
                    string conv_media_comprimeto = media_comprimeto.ToString("N1");
                    media_comprimeto = float.Parse(conv_media_comprimeto);

                    float media_largura = (editarDados.larg_med_1 + editarDados.larg_med_2 + editarDados.larg_med_3) / 3;
                    string conv_media_largura = media_largura.ToString("N1");
                    media_largura = float.Parse(conv_media_largura);

                    float media_altura = (editarDados.alt_med_1 + editarDados.alt_med_2 + editarDados.alt_med_3) / 3;
                    string conv_media_altura = media_altura.ToString("N1");
                    media_altura = float.Parse(conv_media_altura);


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

                    var data_ini = salvar.data_ini;
                    var data_term = salvar.data_term;
                    var temp_ini = salvar.temp_ini;
                    var temp_fim = salvar.temp_fim;
                    var dimensao_temp = salvar.dimensao_temp;
                    var comprimento_result = salvar.comprimento_result;
                    var comprimento_um = salvar.comprimento_um;
                    var comprimento_esp = salvar.comprimento_esp;
                    var comprimento_dois = salvar.comprimento_dois;
                    var comprimento_tres = salvar.comprimento_tres;
                    var temp_repouso = salvar.temp_repouso;

                    double comprimentoum = double.Parse(comprimento_um);
                    double comprimentodois = double.Parse(comprimento_dois);
                    double comprimentotres = double.Parse(comprimento_tres);
                    var comprimento_media = ((comprimentoum + comprimentodois + comprimentotres) / 3);


                    var largura_result = salvar.largura_result;
                    var largura_um = salvar.largura_um;
                    var largura_esp = salvar.largura_esp;
                    var largura_dois = salvar.largura_dois;
                    var largura_tres = salvar.largura_tres;


                    double larguraum = double.Parse(largura_um);
                    double larguradois = double.Parse(largura_dois);
                    double larguratres = double.Parse(largura_tres);
                    var largura_media = ((larguraum + larguradois + larguratres) / 3);


                    var altura_result = salvar.altura_result;
                    var altura_um = salvar.altura_um;
                    var altura_esp = salvar.altura_esp;
                    var altura_dois = salvar.altura_dois;
                    var altura_tres = salvar.altura_tres;

                    double alturaum = double.Parse(altura_um);
                    double alturadois = double.Parse(altura_dois);
                    double alturatres = double.Parse(altura_tres);
                    var altura_media = ((alturaum + alturadois + alturatres) / 3);

                    var lamina_um = salvar.lamina_um;
                    var lamina_comp_um = salvar.lamina_comp_um;
                    var lamina_esp_um = salvar.lamina_esp_um;
                    var lamina_comp_dois = salvar.lamina_comp_dois;
                    var lamina_comp_tres = salvar.lamina_comp_tres;


                    double laminacompum = double.Parse(lamina_comp_um);
                    double laminacompdois = double.Parse(lamina_comp_dois);
                    double laminacomptres = double.Parse(lamina_comp_tres);
                    var lamina_media_um = ((laminacompum + laminacompdois + laminacomptres) / 3);


                    var lamina_tipo_um = salvar.lamina_tipo_um;
                    var lamina_min_um = salvar.lamina_min_um;
                    var lamina_max_um = salvar.lamina_max_um;
                    var lamina_resul_um = salvar.lamina_resul_um;
                    var lamina_dois = salvar.lamina_dois;
                    var lamina_comp_quat = salvar.lamina_comp_quat;
                    var lamina_esp_dois = salvar.lamina_esp_dois;
                    var lamina_comp_cinco = salvar.lamina_comp_cinco;
                    var lamina_comp_seis = salvar.lamina_comp_seis;

                    double laminacompquat = double.Parse(lamina_comp_quat);
                    double laminacompcinco = double.Parse(lamina_comp_cinco);
                    double laminacompseis = double.Parse(lamina_comp_seis);
                    var lamina_media_dois = ((laminacompquat + laminacompcinco + laminacompseis) / 3);

                    var lamina_tipo_dois = salvar.lamina_tipo_dois;
                    var lamina_min_dois = salvar.lamina_min_dois;
                    var lamina_max_dois = salvar.lamina_max_dois;
                    var lamina_resul_dois = salvar.lamina_resul_dois;
                    var lamina_tres = salvar.lamina_tres;
                    var lamina_comp_sete = salvar.lamina_comp_sete;
                    var lamina_esp_tres = salvar.lamina_esp_tres;
                    var lamina_comp_oito = salvar.lamina_comp_oito;
                    var lamina_comp_nove = salvar.lamina_comp_nove;

                    double laminacompsete = double.Parse(lamina_comp_sete);
                    double laminacompoito = double.Parse(lamina_comp_oito);
                    double laminacompnove = double.Parse(lamina_comp_nove);
                    var lamina_media_tres = ((laminacompsete + laminacompoito + laminacompnove) / 3);

                    var lamina_tipo_tres = salvar.lamina_tipo_tres;
                    var lamina_min_tres = salvar.lamina_min_tres;
                    var lamina_max_tres = salvar.lamina_max_tres;
                    var lamina_resul_tres = salvar.lamina_resul_tres;
                    var lamina_quat = salvar.lamina_quat;
                    var lamina_comp_dez = salvar.lamina_comp_dez;
                    var lamina_esp_quat = salvar.lamina_esp_quat;
                    var lamina_comp_onze = salvar.lamina_comp_onze;
                    var lamina_comp_doze = salvar.lamina_comp_doze;


                    double laminacompdez = double.Parse(lamina_comp_dez);
                    double laminacomponze = double.Parse(lamina_comp_onze);
                    double laminacompdoze = double.Parse(lamina_comp_doze);
                    var lamina_media_quat = ((laminacompdez + laminacomponze + laminacompdoze) / 3);

                    var lamina_tipo_quat = salvar.lamina_tipo_quat;
                    var lamina_min_quat = salvar.lamina_min_quat;
                    var lamina_max_quat = salvar.lamina_max_quat;
                    var lamina_resul_quat = salvar.lamina_resul_quat;
                    var lamina_cinco = salvar.lamina_cinco;
                    var lamina_comp_treze = salvar.lamina_comp_treze;
                    var lamina_esp_cinco = salvar.lamina_esp_cinco;
                    var lamina_comp_quatorze = salvar.lamina_comp_quatorze;
                    var lamina_comp_quinze = salvar.lamina_comp_quinze;


                    double laminacomptreze = double.Parse(lamina_comp_treze);
                    double laminacompquatorze = double.Parse(lamina_comp_quatorze);
                    double laminacompquinze = double.Parse(lamina_comp_quinze);
                    var lamina_media_cinco = ((laminacomptreze + laminacompquatorze + laminacompquinze) / 3);

                    var lamina_tipo_cinco = salvar.lamina_tipo_cinco;
                    var lamina_min_cinco = salvar.lamina_min_cinco;
                    var lamina_max_cinco = salvar.lamina_max_cinco;
                    var lamina_resul_cinco = salvar.lamina_resul_cinco;
                    var esp_tipo_um = salvar.esp_tipo_um;
                    var esp_lamina_um = salvar.esp_lamina_um;
                    var esp_especificado_um = salvar.esp_especificado_um;
                    var esp_mm_um = salvar.esp_mm_um;

                    double mm_um = double.Parse(esp_mm_um);
                    var esp_cm_um = mm_um / 10;

                    var esp_tipo_dois = salvar.esp_tipo_dois;
                    var esp_lamina_dois = salvar.esp_lamina_dois;
                    var esp_especificado_dois = salvar.esp_especificado_dois;
                    var esp_mm_dois = salvar.esp_mm_dois;

                    double mm_dois = double.Parse(esp_mm_dois);
                    var esp_cm_dois = mm_dois / 10;

                    var col_tipo_um = salvar.col_tipo_um;
                    var col_especificado_um = salvar.col_especificado_um;
                    var col_encontrado_um = salvar.col_encontrado_um;
                    var col_resul_um = salvar.col_resul_um;
                    var col_tipo_dois = salvar.col_tipo_dois;
                    var col_lamina_dois = salvar.col_lamina_dois;
                    var col_especificado_dois = salvar.col_especificado_dois;
                    var col_resul_dois = salvar.col_resul_dois;
                    var reves_tipo_um = salvar.reves_tipo_um;
                    var reves_lamina_um = salvar.reves_lamina_um;
                    var reves_especificado_um = salvar.reves_especificado_um;
                    var reves_mm_um = salvar.reves_mm_um;

                    double reves_mm = double.Parse(reves_mm_um);
                    var reves_cm_um = reves_mm / 10;

                    var reves_tipo_dois = salvar.reves_tipo_dois;
                    var reves_lamina_dois = salvar.reves_lamina_dois;
                    var reves_especificado_dois = salvar.reves_especificado_dois;
                    var reves_mm_dois = salvar.reves_mm_dois;

                    double reves_mm_ = double.Parse(reves_mm_dois);
                    var reves_cm_dois = reves_mm_ / 10;

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
                        comprimento_media = comprimento_media.ToString(),
                        comprimento_result = comprimento_result,
                        largura_um = largura_um,
                        largura_dois = largura_dois,
                        largura_tres = largura_tres,
                        largura_esp = largura_esp,
                        largura_media = largura_media.ToString(),
                        largura_result = largura_result,
                        altura_um = altura_um,
                        altura_dois = altura_dois,
                        altura_tres = altura_tres,
                        altura_esp = altura_esp,
                        altura_media = altura_media.ToString(),
                        altura_result = altura_result,
                        temp_repouso = temp_repouso,
                        //lamina_tempo = lamina_tempo,
                        lamina_um = lamina_um,
                        lamina_comp_um = lamina_comp_um,
                        lamina_comp_dois = lamina_comp_dois,
                        lamina_comp_tres = lamina_comp_tres,
                        lamina_esp_um = lamina_esp_um,
                        lamina_media_um = lamina_media_um.ToString(),
                        lamina_tipo_um = lamina_tipo_um,
                        lamina_min_um = lamina_min_um,
                        lamina_max_um = lamina_max_um,
                        lamina_resul_um = lamina_resul_um,
                        lamina_dois = lamina_dois,
                        lamina_comp_quat = lamina_comp_quat,
                        lamina_comp_cinco = lamina_comp_cinco,
                        lamina_comp_seis = lamina_comp_seis,
                        lamina_esp_dois = lamina_esp_dois,
                        lamina_media_dois = lamina_media_dois.ToString(),
                        lamina_tipo_dois = lamina_tipo_dois,
                        lamina_min_dois = lamina_min_dois,
                        lamina_max_dois = lamina_max_dois,
                        lamina_resul_dois = lamina_resul_dois,
                        lamina_tres = lamina_tres,
                        lamina_comp_sete = lamina_comp_sete,
                        lamina_comp_oito = lamina_comp_oito,
                        lamina_comp_nove = lamina_comp_nove,
                        lamina_esp_tres = lamina_esp_tres,
                        lamina_media_tres = lamina_media_tres.ToString(),
                        lamina_tipo_tres = lamina_tipo_tres,
                        lamina_min_tres = lamina_min_tres,
                        lamina_max_tres = lamina_max_tres,
                        lamina_resul_tres = lamina_resul_tres,
                        lamina_quat = lamina_quat,
                        lamina_comp_dez = lamina_comp_dez,
                        lamina_comp_onze = lamina_comp_onze,
                        lamina_comp_doze = lamina_comp_doze,
                        lamina_esp_quat = lamina_esp_quat,
                        lamina_media_quat = lamina_media_quat.ToString(),
                        lamina_tipo_quat = lamina_tipo_quat,
                        lamina_min_quat = lamina_min_quat,
                        lamina_max_quat = lamina_max_quat,
                        lamina_resul_quat = lamina_resul_quat,
                        lamina_cinco = lamina_cinco,
                        lamina_comp_treze = lamina_comp_treze,
                        lamina_comp_quatorze = lamina_comp_quatorze,
                        lamina_comp_quinze = lamina_comp_quinze,
                        lamina_esp_cinco = lamina_esp_cinco,
                        lamina_media_cinco = lamina_media_cinco.ToString(),
                        lamina_tipo_cinco = lamina_tipo_cinco,
                        lamina_min_cinco = lamina_min_cinco,
                        lamina_max_cinco = lamina_max_cinco,
                        lamina_resul_cinco = lamina_resul_cinco,
                        esp_tipo_um = esp_tipo_um,
                        esp_lamina_um = esp_lamina_um,
                        esp_especificado_um = esp_especificado_um,
                        esp_mm_um = esp_mm_um,
                        esp_cm_um = esp_cm_um.ToString(),
                        esp_tipo_dois = esp_tipo_dois,
                        esp_lamina_dois = esp_lamina_dois,
                        esp_especificado_dois = esp_especificado_dois,
                        esp_mm_dois = esp_mm_dois,
                        esp_cm_dois = esp_cm_dois.ToString(),
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
                        reves_cm_um = reves_cm_um.ToString(),
                        reves_tipo_dois = reves_tipo_dois,
                        reves_lamina_dois = reves_lamina_dois,
                        reves_especificado_dois = reves_especificado_dois,
                        reves_mm_dois = reves_mm_dois,
                        reves_cm_dois = reves_cm_dois.ToString(),

                    };

                    _context.Add(salvarEspuma);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados Editado Com Sucesso";
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

                    double comprimentoum = double.Parse(editarDados.comprimento_um);
                    double comprimentodois = double.Parse(editarDados.comprimento_dois);
                    double comprimentotres = double.Parse(editarDados.comprimento_tres);
                    editarDados.comprimento_media = ((comprimentoum + comprimentodois + comprimentotres) / 3).ToString();


                    editarDados.largura_result = salvar.largura_result;
                    editarDados.largura_um = salvar.largura_um;
                    editarDados.largura_esp = salvar.largura_esp;
                    editarDados.largura_dois = salvar.largura_dois;
                    editarDados.largura_tres = salvar.largura_tres;


                    double larguraum = double.Parse(editarDados.largura_um);
                    double larguradois = double.Parse(editarDados.largura_dois);
                    double larguratres = double.Parse(editarDados.largura_tres);
                    editarDados.largura_media = ((larguraum + larguradois + larguratres) / 3).ToString();


                    editarDados.altura_result = salvar.altura_result;
                    editarDados.altura_um = salvar.altura_um;
                    editarDados.altura_esp = salvar.altura_esp;
                    editarDados.altura_dois = salvar.altura_dois;
                    editarDados.altura_tres = salvar.altura_tres;

                    double alturaum = double.Parse(editarDados.altura_um);
                    double alturadois = double.Parse(editarDados.altura_dois);
                    double alturatres = double.Parse(editarDados.altura_tres);
                    var altura_media = ((alturaum + alturadois + alturatres) / 3);

                    editarDados.lamina_um = salvar.lamina_um;
                    editarDados.lamina_comp_um = salvar.lamina_comp_um;
                    editarDados.lamina_esp_um = salvar.lamina_esp_um;
                    editarDados.lamina_comp_dois = salvar.lamina_comp_dois;
                    editarDados.lamina_comp_tres = salvar.lamina_comp_tres;


                    //double laminacompum = double.Parse(lamina_comp_um);
                    //double laminacompdois = double.Parse(lamina_comp_dois);
                    //double laminacomptres = double.Parse(lamina_comp_tres);
                    //var lamina_media_um = ((laminacompum + laminacompdois + laminacomptres) / 3);


                    editarDados.lamina_tipo_um = salvar.lamina_tipo_um;
                    editarDados.lamina_min_um = salvar.lamina_min_um;
                    editarDados.lamina_max_um = salvar.lamina_max_um;
                    editarDados.lamina_resul_um = salvar.lamina_resul_um;
                    editarDados.lamina_dois = salvar.lamina_dois;
                    editarDados.lamina_comp_quat = salvar.lamina_comp_quat;
                    editarDados.lamina_esp_dois = salvar.lamina_esp_dois;
                    editarDados.lamina_comp_cinco = salvar.lamina_comp_cinco;
                    editarDados.lamina_comp_seis = salvar.lamina_comp_seis;

                    //double laminacompquat = double.Parse(lamina_comp_quat);
                    //double laminacompcinco = double.Parse(lamina_comp_cinco);
                    //double laminacompseis = double.Parse(lamina_comp_seis);
                    //var lamina_media_dois = ((laminacompquat + laminacompcinco + laminacompseis) / 3);

                    editarDados.lamina_tipo_dois = salvar.lamina_tipo_dois;
                    editarDados.lamina_min_dois = salvar.lamina_min_dois;
                    editarDados.lamina_max_dois = salvar.lamina_max_dois;
                    editarDados.lamina_resul_dois = salvar.lamina_resul_dois;
                    editarDados.lamina_tres = salvar.lamina_tres;
                    editarDados.lamina_comp_sete = salvar.lamina_comp_sete;
                    editarDados.lamina_esp_tres = salvar.lamina_esp_tres;
                    editarDados.lamina_comp_oito = salvar.lamina_comp_oito;
                    editarDados.lamina_comp_nove = salvar.lamina_comp_nove;

                    //double laminacompsete = double.Parse(lamina_comp_sete);
                    //double laminacompoito = double.Parse(lamina_comp_oito);
                    //double laminacompnove = double.Parse(lamina_comp_nove);
                    //var lamina_media_tres = ((laminacompsete + laminacompoito + laminacompnove) / 3);

                    editarDados.lamina_tipo_tres = salvar.lamina_tipo_tres;
                    editarDados.lamina_min_tres = salvar.lamina_min_tres;
                    editarDados.lamina_max_tres = salvar.lamina_max_tres;
                    editarDados.lamina_resul_tres = salvar.lamina_resul_tres;
                    editarDados.lamina_quat = salvar.lamina_quat;
                    editarDados.lamina_comp_dez = salvar.lamina_comp_dez;
                    editarDados.lamina_esp_quat = salvar.lamina_esp_quat;
                    editarDados.lamina_comp_onze = salvar.lamina_comp_onze;
                    editarDados.lamina_comp_doze = salvar.lamina_comp_doze;


                    //double laminacompdez = double.Parse(lamina_comp_dez);
                    //double laminacomponze = double.Parse(lamina_comp_onze);
                    //double laminacompdoze = double.Parse(lamina_comp_doze);
                    //var lamina_media_quat = ((laminacompdez + laminacomponze + laminacompdoze) / 3);

                    editarDados.lamina_tipo_quat = salvar.lamina_tipo_quat;
                    editarDados.lamina_min_quat = salvar.lamina_min_quat;
                    editarDados.lamina_max_quat = salvar.lamina_max_quat;
                    editarDados.lamina_resul_quat = salvar.lamina_resul_quat;
                    editarDados.lamina_cinco = salvar.lamina_cinco;
                    editarDados.lamina_comp_treze = salvar.lamina_comp_treze;
                    editarDados.lamina_esp_cinco = salvar.lamina_esp_cinco;
                    editarDados.lamina_comp_quatorze = salvar.lamina_comp_quatorze;
                    editarDados.lamina_comp_quinze = salvar.lamina_comp_quinze;


                    //double laminacomptreze = double.Parse(lamina_comp_treze);
                    //double laminacompquatorze = double.Parse(lamina_comp_quatorze);
                    //double laminacompquinze = double.Parse(lamina_comp_quinze);
                    //var lamina_media_cinco = ((laminacomptreze + laminacompquatorze + laminacompquinze) / 3);

                    //var lamina_tipo_cinco = salvar.lamina_tipo_cinco;
                    //var lamina_min_cinco = salvar.lamina_min_cinco;
                    //var lamina_max_cinco = salvar.lamina_max_cinco;
                    //var lamina_resul_cinco = salvar.lamina_resul_cinco;
                    //var esp_tipo_um = salvar.esp_tipo_um;
                    //var esp_lamina_um = salvar.esp_lamina_um;
                    //var esp_especificado_um = salvar.esp_especificado_um;
                    //var esp_mm_um = salvar.esp_mm_um;

                    //double mm_um = double.Parse(esp_mm_um);
                    //var esp_cm_um = mm_um / 10;

                    //var esp_tipo_dois = salvar.esp_tipo_dois;
                    //var esp_lamina_dois = salvar.esp_lamina_dois;
                    //var esp_especificado_dois = salvar.esp_especificado_dois;
                    //var esp_mm_dois = salvar.esp_mm_dois;

                    //double mm_dois = double.Parse(esp_mm_dois);
                    //var esp_cm_dois = mm_dois / 10;

                    //var col_tipo_um = salvar.col_tipo_um;
                    //var col_especificado_um = salvar.col_especificado_um;
                    //var col_encontrado_um = salvar.col_encontrado_um;
                    //var col_resul_um = salvar.col_resul_um;
                    //var col_tipo_dois = salvar.col_tipo_dois;
                    //var col_lamina_dois = salvar.col_lamina_dois;
                    //var col_especificado_dois = salvar.col_especificado_dois;
                    //var col_resul_dois = salvar.col_resul_dois;
                    //var reves_tipo_um = salvar.reves_tipo_um;
                    //var reves_lamina_um = salvar.reves_lamina_um;
                    //var reves_especificado_um = salvar.reves_especificado_um;
                    //var reves_mm_um = salvar.reves_mm_um;

                    //double reves_mm = double.Parse(reves_mm_um);
                    //var reves_cm_um = reves_mm / 10;

                    //var reves_tipo_dois = salvar.reves_tipo_dois;
                    //var reves_lamina_dois = salvar.reves_lamina_dois;
                    //var reves_especificado_dois = salvar.reves_especificado_dois;
                    //var reves_mm_dois = salvar.reves_mm_dois;

                    //double reves_mm_ = double.Parse(reves_mm_dois);
                    //var reves_cm_dois = reves_mm_ / 10;




                    _context.Add(editarDados);
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

                    //realizando calculos.
                    float media_copos = (copos_prov_1 + copos_prov_2 + copos_prov_3 + copos_prov_4 + copos_prov_5 + copos_prov_6 + copos_prov_7 + copos_prov_8 + copos_prov_9 + copos_prov_10) / 10;
                    string conv_media_copos = media_copos.ToString("N4");
                    media_copos = float.Parse(conv_media_copos);

                    float gramatura = (media_copos / (area_corpo_1 * area_corpo_2 / 100) * 10000);

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

                    //realizando contas.
                    float media_copos = (editarDados.copos_prov_1 + editarDados.copos_prov_2 + editarDados.copos_prov_3 + editarDados.copos_prov_4 + editarDados.copos_prov_5 + editarDados.copos_prov_6 + editarDados.copos_prov_7 + editarDados.copos_prov_8 + editarDados.copos_prov_9 + editarDados.copos_prov_10) / 10;
                    string conv_media_copos = media_copos.ToString("N4");
                    media_copos = float.Parse(conv_media_copos);

                    float gramatura = (media_copos / (editarDados.area_corpo_1 * editarDados.area_corpo_2 / 100) * 10000);

                    //editando os valores das contas, caso precise.
                    editarDados.copos_media = media_copos;
                    editarDados.gramatura = gramatura;

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

                    //realizando calculos necessarios.
                    float media_3 = (rep_1 + rep_2 + rep_3) / 3;
                    float media_det = (rep_det_1 + rep_det_2 + rep_det_3) / 3;

                    //calculando porcentual e passando para possitivo.
                    float perda_porcentual = ((((media_det - media_3) / media_3) * 100) * -1);
                    string conv_perda_porcentual = perda_porcentual.ToString("N2");
                    perda_porcentual = float.Parse(conv_perda_porcentual);

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

                    editarDados.media_rep = media_3;
                    editarDados.media_det = media_det;
                    editarDados.perda_porc = perda_porcentual;

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
        public async Task<IActionResult> SalvarEnsaio7_7(string os, string orcamento, [Bind("data_ini,data_term,rasgo,quebra,contem_tipo_1,contem_tipo_2,contem_tipo_3,contem_tipo_4,contem_tipo_5,contem_tipo_6,contem_tipo_7,contem_tipo_8,minim_bitola_1,minim_bitola_2,mini_molas_1,mini_molas_2,mini_molas_3,mini_molas_4,mini_molas_5,mini_molas_6,mini_molas_7,mini_molas_8,calc_molas_1,calc_molas_2,calc_molas_3")] ColetaModel.Ensaio7_7 salvarDados)
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
                    string contem_tipo_1 = salvarDados.contem_tipo_1;
                    string contem_tipo_2 = salvarDados.contem_tipo_2;
                    string contem_tipo_3 = salvarDados.contem_tipo_3;
                    string contem_tipo_4 = salvarDados.contem_tipo_4;
                    string contem_tipo_5 = salvarDados.contem_tipo_5;
                    string contem_tipo_6 = salvarDados.contem_tipo_6;
                    string contem_tipo_7 = salvarDados.contem_tipo_7;
                    string contem_tipo_8 = salvarDados.contem_tipo_8;
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

                    //calculando resultado necassario.
                    float resultado_calc = (calc_molas_1 / (calc_molas_2 * calc_molas_3) * 10000);
                    string conv_resultado_calc = resultado_calc.ToString("N2");
                    resultado_calc = float.Parse(conv_resultado_calc);

                    var registro = new ColetaModel.Ensaio7_7
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        rasgo = rasgo,
                        quebra = quebra,
                        contem_tipo_1 = contem_tipo_1,
                        contem_tipo_2 = contem_tipo_2,
                        contem_tipo_3 = contem_tipo_3,
                        contem_tipo_4 = contem_tipo_4,
                        contem_tipo_5 = contem_tipo_5,
                        contem_tipo_6 = contem_tipo_6,
                        contem_tipo_7 = contem_tipo_7,
                        contem_tipo_8 = contem_tipo_8,
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
                    editarDados.contem_tipo_1 = salvarDados.contem_tipo_1;
                    editarDados.contem_tipo_2 = salvarDados.contem_tipo_2;
                    editarDados.contem_tipo_3 = salvarDados.contem_tipo_3;
                    editarDados.contem_tipo_4 = salvarDados.contem_tipo_4;
                    editarDados.contem_tipo_5 = salvarDados.contem_tipo_5;
                    editarDados.contem_tipo_6 = salvarDados.contem_tipo_6;
                    editarDados.contem_tipo_7 = salvarDados.contem_tipo_7;
                    editarDados.contem_tipo_8 = salvarDados.contem_tipo_8;
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

                    //calculando resultado necassario.
                    editarDados.resultado_calc = (editarDados.calc_molas_1 / (editarDados.calc_molas_2 * editarDados.calc_molas_3) * 10000);
                    string conv_resultado_calc = editarDados.resultado_calc.ToString("N2");
                    editarDados.resultado_calc = float.Parse(conv_resultado_calc);

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
        public async Task<IActionResult> SalvarEnsaio7_3(string os, string orcamento, [Bind("data_ini,data_term,bordas,faces_utilizadas,velocidade_face_1,quant_face_1,velocidade_face_2,quant_face_2,rasgo,quebra")] ColetaModel.Ensaio7_3 salvarDados)
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
                    int velocidade_face_1 = salvarDados.velocidade_face_1;
                    int quant_face_1 = salvarDados.quant_face_1;
                    int velocidade_face_2 = salvarDados.velocidade_face_2;
                    int quant_face_2 = salvarDados.quant_face_2;
                    string rasgo = salvarDados.rasgo;
                    string quebra = salvarDados.quebra;

                    var registro = new ColetaModel.Ensaio7_3
                    {
                        os = os,
                        orcamento = orcamento,
                        data_ini = data_ini,
                        data_term = data_term,
                        bordas = bordas,
                        faces_utilizadas = faces_utilizadas,
                        velocidade_face_1 = velocidade_face_1,
                        quant_face_1 = quant_face_1,
                        velocidade_face_2 = velocidade_face_2,
                        quant_face_2 = quant_face_2,
                        rasgo = rasgo,
                        quebra = quebra,
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
                    editarDados.velocidade_face_1 = salvarDados.velocidade_face_1;
                    editarDados.quant_face_1 = salvarDados.quant_face_1;
                    editarDados.velocidade_face_2 = salvarDados.velocidade_face_2;
                    editarDados.quant_face_2 = salvarDados.quant_face_2;
                    editarDados.rasgo = salvarDados.rasgo;
                    editarDados.quebra = salvarDados.quebra;

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
    }
}