using Coleta_Colchao.Models;
using Microsoft.EntityFrameworkCore;

namespace Coleta_Colchao.Data
{
    public class ColchaoContext : DbContext
    {
        public ColchaoContext(DbContextOptions<ColchaoContext> options) : base(options)
        {
        }
        public DbSet <ColetaModel.Registro> regtro_colchao { get; set; }  

        public DbSet <ColetaModel.EspumaUm> ensaio_espuma4_1 { get; set; }
        public DbSet<ColetaModel.Registro> regtro_colchao { get; set; }
        public DbSet<ColetaModel.Ensaio4_3> ensaio_molas_item4_3 { get; set; }
        public DbSet<ColetaModel.Ensaio7_5> ensaio_molas_item7_5 { get; set; }
        public DbSet<ColetaModel.Ensaio7_1> ensaio_molas_item7_1 { get; set; }
        public DbSet<ColetaModel.Ensaio7_2> ensaio_molas_item7_2 { get; set; }
    }

}
