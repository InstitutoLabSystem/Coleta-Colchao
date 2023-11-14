using Coleta_Colchao.Models;
using Microsoft.EntityFrameworkCore;
namespace Coleta_Colchao.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<AcessModel.Usuario> usuario_copy { get; set; }
        public DbSet<HomeModel.OrdemLaboratorioEnsaio> programacao_lab_ensaios { get; set; }
        public DbSet<HomeModel.OrdemServicoCopyLabItem> ordemservicocotacaoitem_hc_copylab { get; set; }
        public DbSet<HomeModel.Wmoddetprod> Wmoddetprod { get; set; }
        public DbSet<HomeModel.OrdemServico> ordemservicocotacao_hc_copylab { get; set; }
    }
}

