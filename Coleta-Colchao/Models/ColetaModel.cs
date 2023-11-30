﻿using Microsoft.CodeAnalysis.Classification;
using NuGet.Versioning;
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
            public string? comprimento_tres { get; set; }
            public string? comprimento_esp { get; set; }
            public string? comprimento_media { get; set; }
            public string? comprimento_result { get; set; }
            public string? largura_um { get; set; }
            public string? largura_esp { get; set; }
            public string? largura_dois { get; set; }
            public string? largura_tres { get; set; }
            public string? largura_media { get; set; }
            public string? largura_result { get; set; }
            public string? altura_um { get; set; }
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
            public string? lamina_max_um { get; set; }
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
            public string? lamina_tres { get; set; }
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
            public string? col_lamina_dois { get; set; }
            public string? col_especificado_dois { get; set; }
            public string? col_resul_dois { get; set; }
            public string? reves_tipo_um { get; set; }
            public string? reves_lamina_um { get; set; }
            public string? reves_especificado_um { get; set; }
            public string? reves_mm_um { get; set; }
            public string? reves_cm_um { get; set; }
            public string? reves_tipo_dois { get; set; }
            public string? reves_lamina_dois { get; set; }
            public string? reves_especificado_dois { get; set; }
            public string? reves_mm_dois { get; set; }
            public string? reves_cm_dois { get; set; }
            public string? lamina_media_um { get; set; }
        }


        public class Ensaio4_3
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }

            public string? borda_aco { get; set; }
            public string? borda_espuma { get; set; }
            public string? borda_aco_molejo { get; set; }
            public string? borda_espuma_molejo { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float valor_enc_aco { get; set; }
            public float valor_enc_espuma { get; set; }
            public float valor_enc_aco_molejo { get; set; }
            public float valor_enc_espuma_molejo { get; set; }
            public string? man_parale_aco { get; set; }
            public string? man_parale_aco_molejo { get; set; }
            public string? man_parale_espuma { get; set; }
            public string? man_parale_espuma_molejo { get; set; }
            public string? executor { get; set; }
            public int contem_molejo { get; set; }
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
            public int qtd_face { get; set; }
            public string? faces { get; set; }
            public float esp_face_1 { get; set; }
            public float med_face_1 { get; set; }
            public float acom_esp_face_1 { get; set; }
            public float acom_enc_face_1 { get; set; }
            public float esp_face_2 { get; set; }
            public float med_face_2 { get; set; }
            public float acom_esp_face_2 { get; set; }
            public float acom_enc_face_2 { get; set; }
            public string? conforme { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }

        public class Ensaio7_1
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float temp_ini { get; set; }
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
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float temp_ini { get; set; }
            public float temp_term { get; set; }
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
            public string? conforme_comprimento { get; set; }
            public string? conforme_largura { get; set; }
            public string? conforme_altura { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }

        public class Ensaio7_8
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public string tipo_material { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float copos_prov_1 { get; set; }
            public float copos_prov_2 { get; set; }
            public float copos_prov_3 { get; set; }
            public float copos_prov_4 { get; set; }
            public float copos_prov_5 { get; set; }
            public float copos_prov_6 { get; set; }
            public float copos_prov_7 { get; set; }
            public float copos_prov_8 { get; set; }
            public float copos_prov_9 { get; set; }
            public float copos_prov_10 { get; set; }
            public float copos_media { get; set; }
            public int area_corpo_1 { get; set; }
            public int area_corpo_2 { get; set; }
            public float gramatura { get; set; }
            public float dim_corpo_1 { get; set; }
            public float dim_corpo_2 { get; set; }
            public string? trincas { get; set; }
            public string? rompimentos { get; set; }
            public string? conforme { get; set; }
            public string? conforme_gramas { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }

        public class Ensaio7_6
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string faces { get; set; }
            public float alterar_queda { get; set; }
            public float rep_1 { get; set; }
            public float rep_2 { get; set; }
            public float rep_3 { get; set; }
            public float media_rep { get; set; }
            public float alt_queda_det { get; set; }
            public float rep_det_1 { get; set; }
            public float rep_det_2 { get; set; }
            public float rep_det_3 { get; set; }
            public float media_det { get; set; }
            public int temp_ens_rolagem { get; set; }
            public float perda_porc { get; set; }
            public string? conforme { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
        }

        public class Ensaio7_7
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? rasgo { get; set; }
            public string? quebra { get; set; }
            public string? contem_bonell { get; set; }
            public string? contem_mola { get; set; }
            public string? contem_lkf { get; set; }
            public string? contem_vericoil { get; set; }
            public string? contem_fio_continuo_1 { get; set; }
            public string? contem_fio_continuo_2 { get; set; }
            public string? contem_offset { get; set; }
            public string? contem_bonel_2 { get; set; }
            public string? minim_bitola_1 { get; set; }
            public string? minim_bitola_2 { get; set; }
            public float mini_molas_1 { get; set; }
            public float mini_molas_2 { get; set; }
            public float mini_molas_3 { get; set; }
            public float mini_molas_4 { get; set; }
            public float mini_molas_5 { get; set; }
            public float mini_molas_6 { get; set; }
            public float mini_molas_7 { get; set; }
            public float mini_molas_8 { get; set; }
            public float calc_molas_1 { get; set; }
            public float calc_molas_2 { get; set; }
            public float calc_molas_3 { get; set; }
            public float resultado_calc { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }

        }

        public class Ensaio7_3
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public float bordas { get; set; }
            public string faces_utilizadas { get; set; }
            public string? rasgo { get; set; }
            public string? quebra { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }
        }


        public class EnsaioIdentificacaoEmbalagem
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? etiqueta_ident { get; set; }
            public string? revest_permanente { get; set; }
            public string? etiqueta_duravel_indele { get; set; }
            public string? face_superior { get; set; }
            public string? visualizacao { get; set; }
            public string? lingua_portuguesa { get; set; }

            public float area_etiqueta_1 { get; set; }
            public float area_etiqueta_2 { get; set; }
            public float area_etiqueta_media { get; set; }
            public string? cnpj_cpf { get; set; }
            public string? marca_modelo { get; set; }
            public string? dimensoes_prod { get; set; }
            public string? informada_altura { get; set; }
            public string? composicoes { get; set; }
            public string? tipo_molejo { get; set; }
            public string? contem_borda { get; set; }
            public string? densidade_espuma { get; set; }
            public string? composi_revestimento { get; set; }
            public string? data_fabricacao { get; set; }
            public string? ident_lote { get; set; }
            public string? pais_origem { get; set; }
            public string? codigo_barras { get; set; }
            public string? cuidado_minimos { get; set; }
            public string? aviso_esclarecimento { get; set; }
            public string? possui_mais_laminas { get; set; }
            public string? contem_advertencia { get; set; }
            public string? altura_letra { get; set; }
            public string? negrito { get; set; }
            public string? caixa_alta { get; set; }
            public string? contem_advertencia_mat { get; set; }
            public string? altura_letra_mat { get; set; }
            public string? negrito_mat { get; set; }
            public string? caixa_alta_mat { get; set; }
            public string? contem_instru_uso { get; set; }
            public string? orientacoes { get; set; }
            public string? alerta_consumidor { get; set; }
            public string? desenho_esquematico { get; set; }
            public string? contem_advertencia_6_2 { get; set; }
            public string? altura_letra_6_2 { get; set; }
            public string? negrito6_2 { get; set; }
            public string? caixa_alta_6_2 { get; set; }
            public string? embalagem_unitaria { get; set; }
            public string? embalagem_garante { get; set; }
            public string? conforme { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }
        }



        public class Espuma4_3
        {
            [Key]
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string temp_ini { get; set; }
            public string temp_fim { get; set; }
            public string lamina_central { get; set; }
            public string quant_colagens { get; set; }
            public string colagens_densidade { get; set; }
            public string espessura_nominal { get; set; }
            public string espessura_central { get; set; }
            public string porcentagem_enc { get; set; }
            public string lamina_menor_esp { get; set; }
            public string quant_colagens_dois { get; set; }
            public string distancia_um { get; set; }
            public string distancia_dois { get; set; }
            public string colagens_comp { get; set; }
            public string espuma { get; set; }
            public string esp_lamina_um { get; set; }
            public string esp_lamina_dois { get; set; }
            public string esp_lamina_tres { get; set; }
            public string esp_lamina_quat { get; set; }
            public string esp_lamina_cinco { get; set; }
            public string esp_lamina_seis { get; set; }
            public string esp_lamina_sete { get; set; }
            public string esp_lamina_oito { get; set; }
            public string quant_colagens_tres { get; set; }
            public string distancia_tres { get; set; }
            public string distancia_quat { get; set; }
            public string colchao_casal { get; set; }
            public string colagem_comp { get; set; }
            public string espuma_conv { get; set; }
            public string espuma_densidade { get; set; }
            public string colagem_largura { get; set; }
            public string quant_colagens_quat { get; set; }
            public string localidade { get; set; }
            public string quant_colagens_cinco { get; set; }
            public string espessura_lamina { get; set; }
            public string adesivo { get; set; }
            public string cascas_superiores { get; set; }
            public string cascas_inferiores { get; set; }
            public string observacoes { get; set; }
            public string executador_um { get; set; }
            public string executador_dois { get; set; }
            public string executador_tres { get; set; }
            public string executador_quat { get; set; }

        }


        public class Espuma_identificacao_embalagem
        {
            [Key]
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string temp_ini { get; set; }
            public string temp_fim { get; set; }
            public string etiquieta_um { get; set; }
            public string fixacao { get; set; }
            public string material { get; set; }
            public string area_um { get; set; }
            public string area_dois { get; set; }
            public string area_result { get; set; }
            public string etiquieta_dois { get; set; }
            public string marca { get; set; }
            public string dimensoes { get; set; }
            public string info_altura { get; set; }
            public string medidas { get; set; }
            public string colchoes { get; set; }
            public string tipo_colchao { get; set; }
            public string letras { get; set; }
            public string altura_letra_um { get; set; }
            public string negrito_um { get; set; }
            public string caixa_alta_um { get; set; }
            public string coloracao_um { get; set; }
            public string classificacao { get; set; }
            public string uso { get; set; }
            public string composicao { get; set; }
            public string tipo_espuma { get; set; }
            public string densidade_nominal { get; set; }
            public string espessura_mad { get; set; }
            public string comp_revestimento { get; set; }
            public string data_fabricacao { get; set; }
            public string pais_fabricacao { get; set; }
            public string cuidados { get; set; }
            public string aviso_um { get; set; }
            public string altura_letra_dois { get; set; }
            public string negrito_dois { get; set; }
            public string caixa_alta_dois { get; set; }
            public string coloracao_dois { get; set; }
            public string esclarecimento_um { get; set; }
            public string altura_letra_tres { get; set; }
            public string negrito_tres { get; set; }
            public string caixa_alta_tres { get; set; }
            public string coloracao_eti { get; set; }
            public string esclarecimento_dois { get; set; }
            public string altura_letra_quat { get; set; }
            public string negrito_quat { get; set; }
            public string caixa_alta_quat { get; set; }
            public string coloracao_quat { get; set; }
            public string colchao_infantil { get; set; }
            public string embalagem_colchao { get; set; }
            public string aviso_embalagem_um { get; set; }
            public string altura_letra_cinco { get; set; }
            public string negrito_cinco { get; set; }
            public string caixa_alta_cinco { get; set; }
            public string coloracao_cinco { get; set; }
            public string aviso_odor { get; set; }
            public string aviso_embalagem_dois { get; set; }
            public string altura_letra_seis { get; set; }
            public string negrito_seis { get; set; }
            public string caixa_alta_seis { get; set; }
            public string coloracao_seis { get; set; }
            public string dec_voluntaria { get; set; }
            public string texto_negrito { get; set; }
            public string identificacao { get; set; }
            public string identificacao_dois { get; set; }
            public string desc_lamina { get; set; }
            public string latex { get; set; }
            public string embalagem_uni { get; set; }
            public string embalagem_protecao { get; set; }
            public string observacao { get; set; }
            public string executador_um { get; set; }
            public string executador_dois { get; set; }
            public string executador_tres { get; set; }
            public string executador_quat { get; set; }

        }

        //public class Teste
        //{
        //    [Key]
        //    public int Id { get; set; }

        //    [Required(ErrorMessage = "Nome obrigatorio")]
        //    public string nome { get; set; }

        //    [Required(ErrorMessage = "Senha Obrigatoria")]
        //    public string senha { get; set; }
        //    public string os { get; set; }
        //    public string orcamento { get; set; }
        //}
    }

}
