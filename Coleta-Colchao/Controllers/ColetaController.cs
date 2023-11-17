using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
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
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Espuma/EnsaioEspuma4_1");
        }
        public IActionResult EnsaioEspuma4_3()
        {
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

        public IActionResult EnsaioMolas7_1(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_1");
        }
        public IActionResult EnsaioMolas7_2(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_2");
        }
        public IActionResult EnsaioMolas7_6(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_6");
        }

        public IActionResult EnsaioMolas7_3(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_3");
        }
        public IActionResult EnsaioMolas7_7(string os, string orcamento)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_7");
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
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            return View("Molas/EnsaioMolas7_8");
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
                    float esp_face_1 = salvarDados.esp_face_1;
                    float med_face_1 = salvarDados.med_face_1;
                    float esp_face_2 = salvarDados.esp_face_2;
                    float med_face_2 = salvarDados.med_face_2;

                    float acom_enc_face_1 = ((esp_face_1 * 100) / (esp_face_1 - med_face_1) - 100);
                    string conv_acom_enc_face_1 = acom_enc_face_1.ToString("N2");
                    float valor_final_conv_acom_enc_face_1 = float.Parse(conv_acom_enc_face_1);

                    float acom_enc_face_2 = ((esp_face_2 * 100) / (esp_face_2 - med_face_2) - 100);
                    string conv_acom_enc_face_2 = acom_enc_face_2.ToString("N2");
                    float valor_final_conv_acom_enc_face_2 = float.Parse(conv_acom_enc_face_2);

                    editarDados.data_ini = salvarDados.data_ini;
                    editarDados.data_term = salvarDados.data_term;
                    editarDados.temp_ensaio = salvarDados.temp_ensaio;
                    editarDados.faces = salvarDados.faces;
                    editarDados.acom_esp_face_1 = salvarDados.acom_esp_face_1;
                    editarDados.acom_esp_face_2 = salvarDados.acom_esp_face_2;
                    editarDados.esp_face_1 = esp_face_1;
                    editarDados.med_face_1 = med_face_1;
                    editarDados.esp_face_2 = esp_face_2;
                    editarDados.med_face_2 = med_face_2;
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
                    var esp_cm_um = mm_um/10;

                    var esp_tipo_dois = salvar.esp_tipo_dois;
                    var esp_lamina_dois = salvar.esp_lamina_dois;
                    var esp_especificado_dois = salvar.esp_especificado_dois;
                    var esp_mm_dois = salvar.esp_mm_dois;

                    double mm_dois = double.Parse(esp_mm_dois);
                    var esp_cm_dois = mm_dois/10;

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
                    var reves_cm_dois = reves_mm_/10;

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
                       reves_tipo_dois=reves_tipo_dois, 
                       reves_lamina_dois = reves_lamina_dois,
                       reves_especificado_dois = reves_especificado_dois,
                       reves_mm_dois = reves_mm_dois,
                       reves_cm_dois = reves_cm_dois.ToString(),

                    };

                    _context.Add(salvarEspuma);
                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Dados salvos com sucesso!!";
                    return RedirectToAction(nameof(EnsaioEspuma4_1), new { os, orcamento});

             

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }




















    }
}