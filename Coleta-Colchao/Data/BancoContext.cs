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
        public DbSet <HomeModel.OrdemServicoCotacaoItem> ordemservicocotacaoitem_hc_copylab { get; set; }
        public DbSet<HomeModel.OrdemServicoCopylab> ordemservico_copylab { get; set; }

    }
}

