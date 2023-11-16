using Microsoft.CodeAnalysis.Classification;
using NuGet.Versioning;
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
            public string? borda_peri { get; set; }
            public string? isolante { get; set; }
            public string? latex { get; set; }
            public string? napa_cou_plas { get; set; }
            public string? manual { get; set; }
            public string? status { get; set; }

        }

        public class Ensaio4_3
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }

            public string? borda { get; set; }
            public string? borda1 { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float valor_enc_1 { get; set; }
            public float valor_enc_2 { get; set; }
            public string? man_parale_1 { get; set; }
            public string? man_parale_2 { get; set; }
            public string? executor { get; set; }
        }

        public class Ensaio7_5
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public TimeOnly temp_ensaio { get; set; }
            public string? faces { get; set; }
            public float esp_face_1 { get; set; }
            public float med_face_1 { get; set; }
            public float acom_esp_face_1 { get; set; }
            public float acom_enc_face_1 { get; set; }
            public float esp_face_2 { get; set; }
            public float med_face_2 { get; set; }
            public float acom_esp_face_2 { get; set; }
            public float acom_enc_face_2 { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }

        public class Ensaio7_1
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get;  set; }
            public DateOnly data_term { get; set; }
            public float  temp_ini { get; set; }
            public float temp_term { get; set; }
            public int quant_face { get; set; }
            public int velo_face_1 { get; set; }
            public int quant_face_1 { get; set; }
            public int velo_face_2 { get; set; }
            public int quant_face_2 { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }

        }

        public class Ensaio7_2
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini  { get; set; }
            public DateOnly data_term { get; set; }
            public float temp_ini { get; set; }
            public float temp_term { get; set;}
            public float comp_med_1 { get; set; }
            public float comp_med_2 { get; set; }
            public float comp_med_3 { get; set; }
            public float comp_espe { get; set; }
            public float com_media { get; set; }
            public float larg_med_1 { get; set; }
            public float larg_med_2 { get; set; }
            public float larg_med_3 { get; set; }
            public float larg_espe { get; set; }
            public float larg_media { get; set; }
            public float alt_med_1 { get; set; }
            public float alt_med_2 { get; set; }
            public float alt_med_3 { get; set; }
            public float alt_espe { get; set; }
            public float alt_media { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }
    }
}
