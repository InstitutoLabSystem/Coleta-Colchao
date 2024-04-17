using Coleta_Colchao.Data;
using Coleta_Colchao.Models;
using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class GerenciamentoController : Controller
    {
        private readonly ILogger<GerenciamentoController> _logger;
        private readonly ColchaoContext _context;
        private readonly BancoContext _bancoContext;

        public GerenciamentoController(ILogger<GerenciamentoController> logger, ColchaoContext colchaoContex, BancoContext bancoContext)
        {
            _logger = logger;
            _context = colchaoContex;
            _bancoContext = bancoContext;
        }

        public IActionResult Molas()
        {

            var dados = (from molas in _context.regtro_colchao
                         where molas.andamento == "Andamento" || molas.andamento == "Finalizado"
                         select new Models.Gerenciamento
                         {
                             Id = molas.Id,
                             os = molas.os,
                             orcamento = molas.orcamento,
                             andamento = molas.andamento,
                         }).ToList();

            return View(dados);
        }


        public IActionResult Espuma()
        {
            var dados = (from espuma in _context.regtro_colchao_espuma
                         where espuma.andamento == "Andamento" || espuma.andamento == "Finalizado"
                         select new Gerenciamento
                         {
                             Id = espuma.Id,
                             os = espuma.os,
                             orcamento = espuma.orcamento,
                             andamento = espuma.andamento,
                         }).ToList();

            return View(dados);
        }
        public IActionResult Laminas()
        {
            var dados = (from espuma in _context.regtro_colchao_lamina
                         where espuma.andamento == "Andamento" || espuma.andamento == "Finalizado"
                         select new Gerenciamento
                         {
                             Id = espuma.Id,
                             os = espuma.os,
                             orcamento = espuma.orcamento,
                             andamento = espuma.andamento,
                         }).ToList();

            return View(dados);
        }

        public async Task<IActionResult> buscarGerenciamentoMolas(string ensaio)
        {
            try
            {
                if (ensaio == "Não iniciado")
                {
                    //quando coleta nao esta iniciado
                    var subQuery = (from colchao_os in _context.regtro_colchao
                                    where colchao_os.andamento != "Andamento" && colchao_os.andamento != "Finalizado"
                                    select colchao_os.os
                                    ).ToList();

                    var dados = (from lab_os in _bancoContext.ordemservico_laboratorio
                                 where lab_os.Laboratorio == "Colchão" && !subQuery.Contains(lab_os.OS) && lab_os.DataSaidaAmReceb > new DateOnly(2024, 4, 10)
                                 select new Gerenciamento
                                 {
                                     os = lab_os.OS,
                                     orcamento = lab_os.orcamento,
                                     andamento = "Não Iniciado",
                                 }).ToList();

                    return View("Molas", dados);

                }
                else if (ensaio == "Andamento")
                {
                    //quando coleta esta andamento
                    var dados = (from molas in _context.regtro_colchao
                                 where molas.andamento == "Andamento"
                                 select new Gerenciamento
                                 {
                                     Id = molas.Id,
                                     os = molas.os,
                                     orcamento = molas.orcamento,
                                     andamento = molas.andamento,
                                 }).ToList();
                    return View("Molas", dados);
                }
                else
                {
                    //quando esta finalizada.
                    var dados = (from molas in _context.regtro_colchao
                                 where molas.andamento == "Finalizado"
                                 select new Gerenciamento
                                 {
                                     Id = molas.Id,
                                     os = molas.os,
                                     orcamento = molas.orcamento,
                                     andamento = molas.andamento,
                                 }).ToList();

                    return View("Molas", dados);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        public async Task<IActionResult> buscarGerenciamentoEspuma(string ensaio)
        {
            try
            {
                if (ensaio == "Não iniciado")
                {
                    var subQuery = (from colchao_os in _context.regtro_colchao_espuma
                                    where colchao_os.andamento != "Andamento" && colchao_os.andamento != "Finalizado"
                                    select colchao_os.os
                                   ).ToList();

                    var dados = (from lab_os in _bancoContext.ordemservico_laboratorio
                                 where lab_os.Laboratorio == "Colchão" && !subQuery.Contains(lab_os.OS) && lab_os.DataSaidaAmReceb > new DateOnly(2024, 4, 10)
                                 select new Gerenciamento
                                 {
                                     os = lab_os.OS,
                                     orcamento = lab_os.orcamento,
                                     andamento = "Não Iniciado",
                                 }).ToList();

                    return View("Espuma", dados);
                }
                else if (ensaio == "Andamento")
                {
                    var dados = (from espuma in _context.regtro_colchao_espuma
                                 where espuma.andamento == "Andamento"
                                 select new Gerenciamento
                                 {
                                     Id = espuma.Id,
                                     os = espuma.os,
                                     orcamento = espuma.orcamento,
                                     andamento = espuma.andamento,
                                 }).ToList();

                    return View("Espuma", dados);
                }
                else
                {
                    var dados = (from espuma in _context.regtro_colchao_espuma
                                 where espuma.andamento == "Finalizado"
                                 select new Gerenciamento
                                 {
                                     Id = espuma.Id,
                                     os = espuma.os,
                                     orcamento = espuma.orcamento,
                                     andamento = espuma.andamento,
                                 }).ToList();

                    return View("Espuma", dados);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error", ex.Message);
                throw;
            }
        }

        public async Task<IActionResult> buscarGerenciamentoLaminas(string ensaio)
        {
            try
            {
                if (ensaio == "Não iniciado")
                {
                    var subQuery = (from colchao_os in _context.regtro_colchao_lamina
                                    where colchao_os.andamento != "Andamento" && colchao_os.andamento != "Finalizado"
                                    select colchao_os.os
                                   ).ToList();

                    var dados = (from lab_os in _bancoContext.ordemservico_laboratorio
                                 where lab_os.Laboratorio == "Colchão" && !subQuery.Contains(lab_os.OS) && lab_os.DataSaidaAmReceb > new DateOnly(2024, 4, 10)
                                 select new Gerenciamento
                                 {
                                     os = lab_os.OS,
                                     orcamento = lab_os.orcamento,
                                     andamento = "Não Iniciado",
                                 }).ToList();

                    return View("Laminas", dados);
                }
                else if (ensaio == "Andamento")
                {
                    var dados = (from espuma in _context.regtro_colchao_lamina
                                 where espuma.andamento == "Andamento"
                                 select new Gerenciamento
                                 {
                                     Id = espuma.Id,
                                     os = espuma.os,
                                     orcamento = espuma.orcamento,
                                     andamento = espuma.andamento,
                                 }).ToList();

                    return View("Laminas", dados);
                }
                else
                {
                    var dados = (from espuma in _context.regtro_colchao_lamina
                                 where espuma.andamento == "Finalizado"
                                 select new Gerenciamento
                                 {
                                     Id = espuma.Id,
                                     os = espuma.os,
                                     orcamento = espuma.orcamento,
                                     andamento = espuma.andamento,
                                 }).ToList();

                    return View("Laminas", dados);
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
