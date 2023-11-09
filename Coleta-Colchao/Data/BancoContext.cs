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
       public DbSet<HomeModel.OrdemLaboratorio> ordemservico_laboratorio { get; set; }
        public DbSet<HomeModel.OrdemServicoCopyLab> ordemservicocotacao_hc_copylab { get; set; }

    }
}

