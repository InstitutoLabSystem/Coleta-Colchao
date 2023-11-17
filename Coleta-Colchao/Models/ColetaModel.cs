using Microsoft.CodeAnalysis.Classification;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.Metadata;

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

        public class EspumaUm
        {
            [Key]
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly? data_ini { get; set; }
            public DateOnly? data_term { get; set; }
            public string? temp_ini { get; set; }
            public string? temp_fim { get; set; }
            public string? dimensao_temp { get; set; }
            public string? comprimento_um { get; set; }
            public string? comprimento_dois { get; set; }
            public string?  comprimento_tres { get; set; }
            public string? comprimento_esp { get; set; }
            public string?   comprimento_media { get; set; }
            public string? comprimento_result { get; set; }
            public string? largura_um { get; set; }
            public string? largura_esp { get; set; }
            public string? largura_dois { get; set; }
            public string? largura_tres { get; set; }
            public string? largura_media { get; set; }
            public string? largura_result { get; set; }
            public string?    altura_um { get; set; }
            public string? altura_dois { get; set; }
            public string? altura_tres { get; set; }
            public string? altura_esp { get; set; }
            public string? altura_media { get; set; }
            public string? altura_result { get; set; }
            public string? temp_repouso { get; set; }
            public string? lamina_um { get; set; }
            public string? lamina_comp_um { get; set; }
            public string? lamina_comp_dois { get; set; }
            public string? lamina_comp_tres { get; set; }
            public string? lamina_esp_um { get; set; }
            public string? lamina_tipo_um { get; set; }
            public string? lamina_min_um { get; set; }
            public  string? lamina_max_um { get; set; }
            public string? lamina_resul_um { get; set; }
            public string? lamina_dois { get; set; }
            public string? lamina_comp_quat { get; set; }
            public string? lamina_comp_cinco { get; set; }
            public string? lamina_comp_seis { get; set; }
            public string? lamina_esp_dois { get; set; }
            public string? lamina_media_dois { get; set; }
            public string? lamina_tipo_dois { get; set; }
            public string? lamina_min_dois { get; set; }
            public string? lamina_max_dois { get; set; }
            public string? lamina_resul_dois { get; set; }
            public string?    lamina_tres { get; set; }
            public string? lamina_comp_sete { get; set; }
            public string? lamina_comp_oito { get; set; }
            public string? lamina_comp_nove { get; set; }
            public string? lamina_esp_tres { get; set; }
            public string? lamina_media_tres { get; set; }
            public string? lamina_tipo_tres { get; set; }
            public string? lamina_min_tres { get; set; }
            public string? lamina_max_tres { get; set; }
            public string? lamina_resul_tres { get; set; }
            public string? lamina_quat { get; set; }
            public string? lamina_comp_dez { get; set; }
            public string? lamina_comp_onze { get; set; }
            public string? lamina_comp_doze { get; set; }
            public string? lamina_esp_quat { get; set; }
            public string? lamina_media_quat { get; set; }
            public string? lamina_tipo_quat { get; set; }
            public string? lamina_min_quat { get; set; }
            public string? lamina_max_quat { get; set; }
            public string? lamina_resul_quat { get; set; }
            public string? lamina_cinco { get; set; }
            public string? lamina_comp_treze { get; set; }

            public string? lamina_esp_cinco { get; set; }
            public string? lamina_comp_quatorze { get; set; }
            public string? lamina_comp_quinze { get; set; }
            public string? lamina_media_cinco { get; set; }
            public string? lamina_tipo_cinco { get; set; }
            public string? lamina_min_cinco { get; set; }
            public string? lamina_max_cinco { get; set; }
            public string? lamina_resul_cinco { get; set; }
            public string? esp_tipo_um { get; set; }
            public string? esp_lamina_um { get; set; }
            public string? esp_especificado_um { get; set; }
            public string? esp_mm_um { get; set; }
            public string? esp_cm_um { get; set; }
            public string? esp_tipo_dois { get; set; }
            public string? esp_lamina_dois { get; set; }
            public string? esp_especificado_dois { get; set; }
            public string? esp_mm_dois { get; set; }
            public string? esp_cm_dois { get; set; }
            public string? col_tipo_um { get; set; }
            public string? col_especificado_um { get; set; }
            public string? col_encontrado_um { get; set; }
            public string? col_resul_um { get; set; }
            public string? col_tipo_dois { get; set; }
            public string? col_lamina_dois { get;set; }
            public string? col_especificado_dois { get; set; }
            public string? col_resul_dois { get; set; }
            public string? reves_tipo_um { get;set; }
            public string? reves_lamina_um { get; set; }
            public string? reves_especificado_um { get; set; }
            public string? reves_mm_um { get; set; }
            public string? reves_cm_um { get; set; }
            public string?    reves_tipo_dois { get; set; }
            public string? reves_lamina_dois { get; set; }
            public string? reves_especificado_dois { get; set; }
            public string?    reves_mm_dois { get; set; }
            public string?   reves_cm_dois { get; set; }
            public string? lamina_media_um { get; set; }



        }




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

    }
}
