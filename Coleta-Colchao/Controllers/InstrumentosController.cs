using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coleta_Colchao.Controllers
{
    public class InstrumentosController : Controller
    {
        private readonly ColchaoContext _colchaoContext;
        private readonly BancoContext _bancoContext;
        private readonly ILogger<ColetaController> _logger;
        public InstrumentosController(ColchaoContext colchaoContext, ILogger<ColetaController> logger, BancoContext bancoContext)
        {
            _colchaoContext = colchaoContext;
            _bancoContext = bancoContext;
            _logger = logger;
        }
        public IActionResult Index(string os, string orcamento, InstrumentosViewModel retornarDados)
        {
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;
            var model = new InstrumentosViewModel();
            model.oInstrumentos = new Instrumentos();
            model.oInstrumentosColchao = new InstrumentosColchao();
            model.oInstrumentosColchaoSalvos = buscarInstrumentosSalvos(os, orcamento);
            return View(model);
        }

        //função para buscar se existe instrumento salvo na os;
        private List<InstrumentosColchaoSalvos> buscarInstrumentosSalvos(string os, string orcamento)
        {
            var dados = _colchaoContext.instrumentos_colchao.Where(x => x.os == os && x.orcamento == orcamento).ToList();
            return dados;
        }

        [HttpPost]
        public async Task<IActionResult> Index(InstrumentosViewModel retornarDados, string os, string orcamento)
        {
            //busca para trazer o codigo.
            var dados = (from c in _bancoContext.cad_instr
                         join x in _bancoContext.cad_instr_comp
                         on c.id equals x.id into ps
                         from res in ps.DefaultIfEmpty()
                         where c.Codigo == retornarDados.oInstrumentos.codigo
                         select new InstrumentosViewModel
                         {
                             oInstrumentosColchao = new InstrumentosColchao
                             {
                                 os = os,
                                 orcamento = orcamento,
                                 codigo = c.Codigo,
                                 descricao = c.Descricaoins,
                                 certificado = c.NC,
                                 validade = DateOnly.FromDateTime(c.data2)
                             }
                         }).FirstOrDefault();

            //retornar para a tela caso nao encontrar o codigo.
            if (dados == null)
            {
                TempData["Mensagem"] = "Codigo não encontrado.";
                return RedirectToAction("Index", "Instrumentos", new { os, orcamento });
            }

            // Inicializando a lista de instrumentos colchão salvos
            var viewModel = new InstrumentosViewModel();
            viewModel.oInstrumentosColchao = dados.oInstrumentosColchao;
            viewModel.oInstrumentosColchaoSalvos = buscarInstrumentosSalvos(os, orcamento);

            // Passando os valores para ViewBag
            ViewBag.os = os;
            ViewBag.orcamento = orcamento;


            return View(viewModel);
        }

        //função para salvar no banco os resultados buscados.
        [HttpPost]
        public async Task<IActionResult> salvarInstrumentos(InstrumentosViewModel dados)
        {
            var salvarBanco = new InstrumentosColchaoSalvos
            {
                os = dados.oInstrumentosColchao.os,
                orcamento = dados.oInstrumentosColchao.orcamento,
                codigo = dados.oInstrumentosColchao.codigo,
                descricao = dados.oInstrumentosColchao.descricao,
                certificado = dados.oInstrumentosColchao.certificado,
                validade = dados.oInstrumentosColchao.validade,
            };

            _colchaoContext.instrumentos_colchao.Add(salvarBanco);
            await _colchaoContext.SaveChangesAsync();

            return RedirectToAction("Index", new { dados.oInstrumentosColchao.os, dados.oInstrumentosColchao.orcamento });
        }
        [HttpPost]
        public async Task<IActionResult> excluirInstrumentos(int id)
        {
            // Busca o instrumento no banco de dados pelo id
            var instrumento = await _colchaoContext.instrumentos_colchao.FindAsync(id);

            // Se o instrumento existir, remove ele do banco de dados
            if (instrumento != null)
            {
                _colchaoContext.instrumentos_colchao.Remove(instrumento);
                await _colchaoContext.SaveChangesAsync();
            }

            // Redireciona para a página principal após a exclusão
            return RedirectToAction("Index");
        }
    }
}
