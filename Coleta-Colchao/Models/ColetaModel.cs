using Microsoft.CodeAnalysis.Classification;
using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class ColetaModel
    {

        public class Registro
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public string? lacre { get; set; }
            public string? realizacao_ensaios { get; set; }
            public string? quant_recebida { get; set; }
            public string? quant_ensaiada { get; set; }
            public DateOnly data_realizacao_ini { get; set; }
            public DateOnly data_realizacao_term { get; set; }
            public string? num_proc { get; set; }
            public string? cod_ref { get; set; }
            public string? tipo_cert { get; set; }
            public string? modelo_cert { get; set; }
            public string? tipo_proc { get; set; }
            public string? produto { get; set; }
            public string? estrutura { get; set; }
            public string? tipo_molejo { get; set; }
            public string? quant_molejo { get; set; }
            public string? fornecedor_um { get; set; }
            public string? fornecedor_dois { get; set; }
            public string? nome_molejo_um { get; set; }
            public string? nome_molejo_dois { get; set; }
            public string? quant_media_um { get; set; }
            public string? quant_media_dois { get; set; }
            public string? bitola_arame_um { get; set; }
            public string? bitola_arame_dois { get; set; } 
            public string? borda_peri {  get; set; }
            public string? isolante { get; set; }
            public string? latex { get; set; } 
            public string? napa_cou_plas { get; set; }
            public string? manual { get; set; }
            public string? status { get; set; }

        }

    }
}
