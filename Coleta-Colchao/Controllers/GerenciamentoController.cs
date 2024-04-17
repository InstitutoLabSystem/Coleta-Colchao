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
        [Route("Gerenciamento")]
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

        public async Task<IActionResult> buscarGerenciamento(string ensaio)
        {
            if (ensaio == "1")
            {
                //quando coleta nao esta iniciado
                var subQuery = (from colchao_os in _context.regtro_colchao
                                    where colchao_os.andamento != "Andamento" && colchao_os.andamento != "Finalizado"
                                    select colchao_os.os
                                ).ToList();

                var dados = (from lab_os in _bancoContext.ordemservico_laboratorio
                                where lab_os.Laboratorio == "Colchão" && !subQuery.Contains(lab_os.OS) && lab_os.DataSaidaAmReceb > new DateOnly(2024,4,10)
                                select new Gerenciamento
                                {
                                    os = lab_os.OS,
                                    orcamento = lab_os.orcamento,
                                }
                            ).ToList();


                return View("Molas", dados);

            }
            else if (ensaio == "2")
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
    }
}
