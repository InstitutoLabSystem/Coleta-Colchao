using Coleta_Colchao.Models;
using Microsoft.EntityFrameworkCore;

namespace Coleta_Colchao.Data
{
    public class ColchaoContext : DbContext
    {
        public ColchaoContext(DbContextOptions<ColchaoContext> options) : base(options)
        {
        }
        public DbSet<ColetaModel.Registro> regtro_colchao { get; set; }
        public DbSet<ColetaModel.EspumaUm> ensaio_espuma4_1 { get; set; }
        public DbSet<ColetaModel.Ensaio4_3> ensaio_molas_item4_3 { get; set; }
        public DbSet<ColetaModel.Ensaio7_5> ensaio_molas_item7_5 { get; set; }
        public DbSet<ColetaModel.Ensaio7_1> ensaio_molas_item7_1 { get; set; }
        public DbSet<ColetaModel.Ensaio7_2> ensaio_molas_item7_2 { get; set; }
        public DbSet<ColetaModel.Ensaio7_8> ensaio_molas_item7_8 { get; set; }
        public DbSet<ColetaModel.Ensaio7_6> ensaio_molas_item7_6 { get; set; }
        public DbSet<ColetaModel.Ensaio7_7> ensaio_molas_item7_7 { get; set; }
        public DbSet<ColetaModel.Ensaio7_3> ensaio_molas_item7_3 { get; set; }
        public DbSet<ColetaModel.Espuma4_3> ensaio_espuma4_3 { get; set; }
        public DbSet<ColetaModel.Espuma_identificacao_embalagem> espuma_identificacao_embalagem { get; set; }
        public DbSet<ColetaModel.EnsaioIdentificacaoEmbalagem> ensaio_identificacao_embalagem { get; set; }
        //public DbSet<ColetaModel.Teste> teste { get; set; }
        public DbSet<ColetaModel.EnsaioBaseDurabilidade> ensaio_base_durabilidade { get; set; }

    }
}