using Coleta_Colchao.Models;
using Microsoft.EntityFrameworkCore;
namespace Coleta_Colchao.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<AcessModel.Usuario> usuario { get; set; }
        public DbSet<HomeModel.OrdemLaboratorioEnsaio> programacao_lab_ensaios { get; set; }
        public DbSet<HomeModel.OrdemServicoCopyLabItem> ordemservicocotacaoitem_hc_copylab { get; set; }
        public DbSet<HomeModel.Wmoddetprod> Wmoddetprod { get; set; }
        public DbSet<HomeModel.OrdemServico> ordemservicocotacao_hc_copylab { get; set; }
        public DbSet<HomeModel.OrdemServicoLaboratorio> ordemservico_laboratorio { get; set; }
        public DbSet<HomeModel.OrdemSericoCopyLab> ordemservico_copylab { get; set; }
        public DbSet<HomeModel.OrdemServicoCotacaoItemSup> ordemservicocotacao_itemsup { get; set; }
        public DbSet<HomeModel.NormasItens> tb_normasitens { get; set; }
        public DbSet<Cad_Instr> cad_instr { get; set; }
        public DbSet<Cad_instr_comp> cad_instr_comp { get; set; }
    }
}

