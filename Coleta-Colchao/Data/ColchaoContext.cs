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
        public DbSet<ColetaModel.EnsaioEspuma4_4> ensaio_espuma_item_4_4 { get; set; }
        public DbSet<ColetaModel.Espuma_identificacao_embalagem> espuma_identificacao_embalagem { get; set; }
        public DbSet<ColetaModel.EnsaioIdentificacaoEmbalagem> ensaio_identificacao_embalagem { get; set; }
        public DbSet<ColetaModel.CargasEstatica> ensaio_base_carga_estatica { get; set; }
        public DbSet<ColetaModel.EnsaioBaseDurabilidade> ensaio_base_durabilidade { get; set; }
        public DbSet<ColetaModel.EnsaioBaseImpactoVertical> ensaio_base_impacto_vertical { get; set; }
        public DbSet<ColetaModel.EnsaioBaseDurabilidadeEstrutural> ensaio_base_durabilidade_estrutural { get; set; }
        public DbSet<ColetaModel.RegistroEspuma> regtro_colchao_espuma { get; set; }
        public DbSet<ColetaModel.RegistroLamina> regtro_colchao_lamina { get; set; }
        public DbSet<ColetaModel.SalvarLaminaDeterminacaoDensidade> lamina_determinacao_densidade { get; set; }
        public DbSet<ColetaModel.LaminaResiliencia> lamina_resiliencia { get; set; }
        public DbSet<ColetaModel.LaminaDPC> lamina_dpc { get; set; }
        public DbSet<ColetaModel.LaminaFI> lamina_fi { get; set; }
        public DbSet<ColetaModel.LaminaFadigaRotativa> lamina_fadiga_dinamica { get; set; }
        public DbSet<ColetaModel.LaminaPFI> lamina_pfi { get; set; }
        public DbSet<Arquivos.Imagens> colchao_anexos { get; set; }
        public DbSet<InstrumentosColchaoSalvos> instrumentos_colchao { get; set; }
    }
}