using Microsoft.CodeAnalysis.Classification;
using Microsoft.Identity.Client;
using NuGet.Versioning;
using System.ComponentModel;
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
            public string? metalasse { get; set; }
            public string? qtd_face { get; set; }
            public float comprimento { get; set; }
            public float largura { get; set; }
            public float altura { get; set; }
            public string? isolante { get; set; }
            public string? latex { get; set; }
            public string? napa_cou_plas { get; set; }
            public string? manual { get; set; }
            public string? andamento { get; set; }

        }

        public class RegistroEspuma
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
            public string? clasi_produto { get; set; }
            public string? tipo_colchao { get; set; }
            public string? uso { get; set; }
            public string? tipo_espuma { get; set; }
            public string? tipo_espuma_2 { get; set; }
            public string? tipo_espuma_3 { get; set; }
            public string? tipo_espuma_4 { get; set; }
            public string? tipo_espuma_5 { get; set; }
            public int quant_laminas { get; set; }
            public string? densidade_1 { get; set; }
            public string? densidade_2 { get; set; }
            public string? densidade_3 { get; set; }
            public string? densidade_4 { get; set; }
            public string? densidade_5 { get; set; }
            public string? revestimento { get; set; }
            public string? anti_reflexo { get; set; }
            public string? outros_materia { get; set; }
            public float comprimento { get; set; }
            public float altura { get; set; }
            public float largura { get; set; }
            public string? andamento { get; set; }



        }

        public class EspumaUm
        {
            [Key]
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? dimensao_temp { get; set; }
            public float comprimento_um { get; set; }
            public float comprimento_dois { get; set; }
            public float comprimento_tres { get; set; }
            public float comprimento_esp { get; set; }
            public float comprimento_media { get; set; }
            public string? comprimento_result { get; set; }
            public float largura_um { get; set; }
            public float largura_dois { get; set; }
            public float largura_tres { get; set; }
            public float largura_esp { get; set; }
            public float largura_media { get; set; }
            public string? largura_result { get; set; }
            public float altura_um { get; set; }
            public float altura_dois { get; set; }
            public float altura_tres { get; set; }
            public float altura_esp { get; set; }
            public float altura_media { get; set; }
            public string? altura_result { get; set; }
            public string? temp_repouso { get; set; }
            public string? lamina_um { get; set; }
            public float lamina_comp_um { get; set; }
            public float lamina_comp_dois { get; set; }
            public float lamina_comp_tres { get; set; }
            public float lamina_esp_um { get; set; }
            public float lamina_media_um { get; set; }
            public string? lamina_tipo_um { get; set; }
            public float lamina_min_um { get; set; }
            public float lamina_max_um { get; set; }
            public string? lamina_resul_um { get; set; }
            public string? lamina_dois { get; set; }
            public float lamina_comp_quat { get; set; }
            public float lamina_comp_cinco { get; set; }
            public float lamina_comp_seis { get; set; }
            public float lamina_esp_dois { get; set; }
            public float lamina_media_dois { get; set; }
            public string? lamina_tipo_dois { get; set; }
            public float lamina_min_dois { get; set; }
            public float lamina_max_dois { get; set; }
            public string? lamina_resul_dois { get; set; }
            public string? lamina_tres { get; set; }
            public float lamina_comp_sete { get; set; }
            public float lamina_comp_oito { get; set; }
            public float lamina_comp_nove { get; set; }
            public float lamina_esp_tres { get; set; }
            public float lamina_media_tres { get; set; }
            public string? lamina_tipo_tres { get; set; }
            public float lamina_min_tres { get; set; }
            public float lamina_max_tres { get; set; }
            public string? lamina_resul_tres { get; set; }
            public string? lamina_quat { get; set; }
            public float lamina_comp_dez { get; set; }
            public float lamina_comp_onze { get; set; }
            public float lamina_comp_doze { get; set; }
            public float lamina_esp_quat { get; set; }
            public float lamina_media_quat { get; set; }
            public string? lamina_tipo_quat { get; set; }
            public float lamina_min_quat { get; set; }
            public float lamina_max_quat { get; set; }
            public string? lamina_resul_quat { get; set; }
            public string? lamina_cinco { get; set; }
            public float lamina_comp_treze { get; set; }
            public float lamina_comp_quatorze { get; set; }
            public float lamina_comp_quinze { get; set; }
            public float lamina_esp_cinco { get; set; }
            public float lamina_media_cinco { get; set; }
            public string? lamina_tipo_cinco { get; set; }
            public float lamina_min_cinco { get; set; }
            public float lamina_max_cinco { get; set; }
            public string? lamina_resul_cinco { get; set; }
            public string? lamina_resul_final { get; set; }
            public string? esp_tipo_um { get; set; }
            public float esp_lamina_um { get; set; }
            public float esp_especificado_um { get; set; }
            public float esp_mm_um { get; set; }
            public float esp_cm_um { get; set; }
            public string? esp_tipo_dois { get; set; }
            public float esp_lamina_dois { get; set; }
            public float esp_especificado_dois { get; set; }
            public float esp_mm_dois { get; set; }
            public float esp_cm_dois { get; set; }
            public string? col_tipo_um { get; set; }
            public float col_especificado_um { get; set; }
            public float col_encontrado_um { get; set; }
            public string? col_resul_um { get; set; }
            public string? col_tipo_dois { get; set; }
            public float col_lamina_dois { get; set; }
            public float col_especificado_dois { get; set; }
            public string? col_resul_dois { get; set; }
            public string? esp_resul_final { get; set; }
            public string? reves_tipo_um { get; set; }
            public float reves_lamina_um { get; set; }
            public float reves_especificado_um { get; set; }
            public float reves_mm_um { get; set; }
            public float reves_cm_um { get; set; }
            public string? reves_tipo_dois { get; set; }
            public float reves_lamina_dois { get; set; }
            public float reves_especificado_dois { get; set; }
            public float reves_mm_dois { get; set; }
            public float reves_cm_dois { get; set; }
            public string? reves_resul_final { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }
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
            public string? usuarioEdicao { get; set; }
            public int contem_molejo { get; set; }
            public string? pergunta_a { get; set; }
            public string? pergunta_b { get; set; }
            public string? pergunta_c { get; set; }
            public string? pergunta_d { get; set; }
        }

        public class Ensaio7_5
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? temp_ensaio { get; set; }
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
            public string? acordo { get; set; }
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
            public string? tipo_espuma_1 { get; set; }
            public string? tipo_espuma_2 { get; set; }
            public string? tipo_espuma_3 { get; set; }
            public string? tipo_espuma_4 { get; set; }
            public string? tipo_espuma_5 { get; set; }
            public string? tipo_espuma_6 { get; set; }
            public string? tipo_espuma_7 { get; set; }
            public string? tipo_espuma_8 { get; set; }
            public string? tipo_espuma_9 { get; set; }
            public string? tipo_espuma_10 { get; set; }
            public float esp_tipo_esp_1 { get; set; }
            public float esp_tipo_esp_2 { get; set; }
            public float esp_tipo_esp_3 { get; set; }
            public float esp_tipo_esp_4 { get; set; }
            public float esp_tipo_esp_5 { get; set; }
            public float esp_tipo_esp_6 { get; set; }
            public float esp_tipo_esp_7 { get; set; }
            public float esp_tipo_esp_8 { get; set; }
            public float esp_tipo_esp_9 { get; set; }
            public float esp_tipo_esp_10 { get; set; }
            public string? tem_metalasse { get; set; }
            public string? total_metalasse { get; set; }
            public string? mate_tipo_espuma_1 { get; set; }
            public float mata_esp_tipo_esp_1 { get; set; }
            public string? mate_tipo_espuma_2 { get; set; }
            public float mata_esp_tipo_esp_2 { get; set; }
            public string? conformidade { get; set; }
            public string? conformidade_mat { get; set; }
            public string? executor { get; set; }
            public string? auxiliar { get; set; }
            public float qtd_espuma { get; set; }
            public float enc_estofamento_1 { get; set; }
            public float enc_estofamento_2 { get; set; } 
            public float enc_estofamento_3 { get; set; } 
            public float enc_estofamento_4 { get; set; } 
            public float enc_estofamento_5 { get; set; } 
            public float enc_estofamento_6 { get; set; } 
            public float enc_estofamento_7 { get; set; }
            public float enc_estofamento_8 { get; set; } 
            public float enc_estofamento_9 { get; set; }
            public float enc_estofamento_10 { get; set; } 
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
            public string? contem_bonell_1 { get; set; }
            public string? contem_bonell_2 { get; set; }
            public string? contem_mola { get; set; }
            public string? contem_lkf { get; set; }
            public string? contem_vericoil { get; set; }
            public string? contem_fio_continuo_1 { get; set; }
            public string? contem_fio_continuo_2 { get; set; }
            public string? contem_offset { get; set; }
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
            public float calc_molas_duplicado { get; set; }
            public float calc_molas_duplicado_2 { get; set; }
            public float calc_molas_duplicado_3 { get; set; }
            public float resultado_calc_duplicado { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }
            public string? conforme { get; set; }
        }

        public class Ensaio7_3
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? pergunta_a { get; set; }
            public string? pergunta_b { get; set; }
            public string? pergunta_c { get; set; }
            public string? pergunta_d { get; set; }
            public string? pergunta_e { get; set; }
            public string? material { get; set; }
            public string? suportou { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }
            public int qtd_ciclos { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final {  get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? face_escolhida { get; set; }
            public float min_umidade { get; set; }
            public float max_umidade { get; set; }

        }


        public class EnsaioIdentificacaoEmbalagem
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? lingua_portuguesa { get; set; }
            public float area_etiqueta_1 { get; set; }
            public float area_etiqueta_2 { get; set; }
            public float area_etiqueta_media { get; set; }
            public string? cnpj_cpf { get; set; }
            public string? cnpj_cpf_2 { get; set; }
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
            public string? conforme_r { get; set; }
            public string? altura_letra { get; set; }
            public string? negrito { get; set; }
            public string? conforme_s { get; set; }
            public string? altura_letra_mat { get; set; }
            public string? caixa_alta_mat { get; set; }
            public string? contem_instru_uso { get; set; }
            public string? orientacoes { get; set; }
            public string? alerta_consumidor { get; set; }
            public string? desenho_esquematico { get; set; }
            public string? altura_letra_6_2 { get; set; }
            public string? caixa_alta_6_2 { get; set; }
            public string? embalagem_unitaria { get; set; }
            public string? colchao_disponivel { get; set; }
            public string? fixada { get; set; }
            public string? conforme_6_2 { get; set; }
            public string? executador { get; set; }
            public string? auxiliar { get; set; }
            public string? conforme_area { get; set; }
        }

        public class Espuma4_3
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }

            public string? lamina_central { get; set; }
            public string? tipo_ensaio { get; set; }
            public string? quant_colagens { get; set; }
            public string? colagens_densidade { get; set; }
            public string? espessura_nominal { get; set; }
            public string? espessura_central { get; set; }
            public string? porcentagem_enc { get; set; }
            public string? lamina_menor_esp { get; set; }
            public string? quant_colagens_dois { get; set; }
            public string? distancia_um { get; set; }
            public string? distancia_dois { get; set; }
            public string? colagens_comp { get; set; }
            public string? espuma { get; set; }
            public string? esp_lamina_um { get; set; }
            public string? esp_lamina_dois { get; set; }
            public string? esp_lamina_tres { get; set; }
            public string? esp_lamina_quat { get; set; }
            public string? esp_lamina_cinco { get; set; }
            public string? esp_lamina_seis { get; set; }
            public string? esp_lamina_sete { get; set; }
            public string? esp_lamina_oito { get; set; }
            public string? quant_colagens_tres { get; set; }
            public string? distancia_tres { get; set; }
            public string? distancia_quat { get; set; }
            public string? colchao_casal { get; set; }
            public string? colagem_comp { get; set; }
            public string? espuma_conv { get; set; }
            public string? espuma_densidade { get; set; }
            public string? colagem_largura { get; set; }
            public string? quant_colagens_quat { get; set; }
            public string? localidade { get; set; }
            public string? quant_colagens_cinco { get; set; }
            public string? espessura_lamina { get; set; }
            public string? adesivo { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }

        }


        public class Espuma_identificacao_embalagem
        {
            [Key]
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }

            public string? etiquieta_um { get; set; }
            public string? fixacao { get; set; }
            public string? material { get; set; }
            public string? area_um { get; set; }
            public string? area_dois { get; set; }
            public string? area_result { get; set; }
            public string? conforme_area_um { get; set; }
            public string? etiquieta_dois { get; set; }
            public string? marca { get; set; }
            public string? dimensoes { get; set; }
            public string? info_altura { get; set; }
            public string? medidas { get; set; }
            public string? colchoes { get; set; }
            public string? tipo_colchao { get; set; }
            public string? letras { get; set; }
            public float? altura_letra_um { get; set; }
            public string? negrito_um { get; set; }
            public string? caixa_alta_um { get; set; }
            public string? coloracao_um { get; set; }
            public string? classificacao { get; set; }
            public string? uso { get; set; }
            public string? composicao { get; set; }
            public string? tipo_espuma { get; set; }
            public string? densidade_nominal { get; set; }
            public string? espessura_mad { get; set; }
            public string? comp_revestimento { get; set; }
            public string? data_fabricacao { get; set; }
            public string? pais_fabricacao { get; set; }
            public string? cuidados { get; set; }
            public string? aviso_um { get; set; }
            public float? altura_letra_dois { get; set; }
            public string? negrito_dois { get; set; }
            public string? caixa_alta_dois { get; set; }
            public string? coloracao_dois { get; set; }
            public string? esclarecimento_um { get; set; }
            public float? altura_letra_tres { get; set; }
            public string? negrito_tres { get; set; }
            public string? caixa_alta_tres { get; set; }
            public string? coloracao_eti { get; set; }
            public string? esclarecimento_dois { get; set; }
            public float? altura_letra_quat { get; set; }
            public string? negrito_quat { get; set; }
            public string? caixa_alta_quat { get; set; }
            public string? coloracao_quat { get; set; }
            public string? colchao_infantil { get; set; }
            public string? embalagem_colchao { get; set; }
            public string? aviso_embalagem_um { get; set; }
            public float? altura_letra_cinco { get; set; }
            public string? negrito_cinco { get; set; }
            public string? caixa_alta_cinco { get; set; }
            public string? coloracao_cinco { get; set; }
            public string? aviso_odor { get; set; }
            public string? aviso_embalagem_dois { get; set; }
            public float? altura_letra_seis { get; set; }
            public string? negrito_seis { get; set; }
            public string? caixa_alta_seis { get; set; }
            public string? coloracao_seis { get; set; }
            public string? dec_voluntaria { get; set; }
            public string? texto_negrito { get; set; }
            public string? identificacao { get; set; }
            public string? identificacao_dois { get; set; }
            public string? desc_lamina { get; set; }
            public string? latex { get; set; }
            public string? embalagem_uni { get; set; }
            public string? embalagem_protecao { get; set; }
            public string? visualizacao { get; set; }
            public string? lingua_portuguesa { get; set; }
            public string? observacao { get; set; }
            public string? executador_um { get; set; }
            public string? executador_dois { get; set; }
            public string? executador_tres { get; set; }
            public string? executador_quat { get; set; }
            public string? conforme_inicial { get; set; }
            public string? conforme_letras { get; set; }
            public string? conforme_letras_dois { get; set; }
            public string? conforme_infantil { get; set; }
            public string? conforme_2_14_2 { get; set; }
            public string? conforme_2_14_3 { get; set; }
            public string? conforme6_2 { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }

        }

        public class EnsaioBaseDurabilidade
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }

            public DateOnly data_inicio { get; set; }

            public DateOnly data_termi { get; set; }


            public TimeOnly hora_inicio { get; set; }

            public TimeOnly hora_term { get; set; }
            public string? temp_min { get; set; }
            public string? temp_max { get; set; }
            public string? responsavel_cond { get; set; }
            public string? im { get; set; }
            public string? base_cama { get; set; }
            public string? angulo_encontrado { get; set; }
            public int distancia_ponto_a { get; set; }
            public int largura_ponto_a { get; set; }
            public string? suportou_ponto_a { get; set; }
            public string? ruptura_ponto_a { get; set; }
            public string? afundamento_ponto_a { get; set; }
            public string? rasgo_ponto_a { get; set; }
            public string? rompimento_ponto_a { get; set; }
            public string? prejudique_ponto_a { get; set; }
            public string? suportou_ponto_b { get; set; }
            public string? ruptura_ponto_b { get; set; }
            public string? afundamento_ponto_b { get; set; }
            public string? rasgo_ponto_b { get; set; }
            public string? rompimento_ponto_b { get; set; }
            public string? prejudique_ponto_b { get; set; }
            public string? suportou_ponto_c { get; set; }
            public string? ruptura_ponto_c { get; set; }
            public string? afundamento_ponto_c { get; set; }
            public string? rasgo_ponto_c { get; set; }
            public string? rompimento_ponto_c { get; set; }
            public string? prejudique_ponto_c { get; set; }
            public string? conforme_a { get; set; }
            public string? conforme_b { get; set; }
            public string? conforme_c { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }
            public string? temp_ini { get; set; }
            public string? temp_term { get; set; }


        }

        public class EnsaioBaseImpactoVertical
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public DateOnly data_ini_ens { get; set; }
            public DateOnly data_term_ens { get; set; }
            public TimeOnly hora_inic { get; set; }
            public TimeOnly hora_term { get; set; }
            public string? tem_min { get; set; }
            public string? tem_max { get; set; }
            public string? responsavel_cond { get; set; }
            public string? im { get; set; }
            public int comp_base { get; set; }
            public int larg_base { get; set; }
            public string? impac_um_a { get; set; }
            public string? impac_um_b { get; set; }
            public string? impac_um_c { get; set; }
            public string? impac_um_d { get; set; }
            public string? impac_um_g { get; set; }
            public string? impac_um_i { get; set; }
            public string? impac_um_j { get; set; }
            public string? ruptura_um { get; set; }
            public string? afundamento_um { get; set; }
            public string? rasgo_um { get; set; }
            public string? rompimento_um { get; set; }
            public string? prejudique_um { get; set; }
            public string? impac_dois_a { get; set; }
            public string? impac_dois_b { get; set; }
            public string? impac_dois_c { get; set; }
            public string? impac_dois_d { get; set; }
            public string? impac_dois_e { get; set; }
            public string? impac_dois_g { get; set; }
            public string? impac_dois_i { get; set; }
            public string? impac_dois_j { get; set; }
            public string? ruptura_dois { get; set; }
            public string? afundamento_dois { get; set; }
            public string? rasgo_dois { get; set; }
            public string? rompimento_dois { get; set; }
            public string? prejudique_dois { get; set; }
            public string? confome_ponto_a { get; set; }
            public string? confome_ponto_b { get; set; }
            public string? conforme_um { get; set; }
            public string? conforme_dois { get; set; }
            public string? temp_ini { get; set; }
            public string? temp_term { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }

        }

        public class EnsaioBaseDurabilidadeEstrutural
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }

            public TimeOnly hora_ini { get; set; }
            public TimeOnly hora_term { get; set; }
            public string? temp_max { get; set; }
            public string? temp_min { get; set; }
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? suportou { get; set; }
            public string? ruptura { get; set; }
            public string? quebra { get; set; }
            public string? prejudicou { get; set; }
            public string? conforme { get; set; }
            public string? temp_ini { get; set; }
            public string? temp_term { get; set; }

            public string? editarUsuario { get; set; }
            public string? executor { get; set; }
        }

        public class EnsaioEspuma4_4
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? superior_horizontal { get; set; }
            public string? inferior_horizontal { get; set; }
            public string? conforme { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }
        }

        public class CargasEstatica
        {
            [Key]
            public int Id { get; set; }
            public string os { get; set; }
            public string orcamento { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public DateOnly data_ini_ens { get; set; }
            public DateOnly data_term_ens { get; set; }
            public TimeOnly hora_ensaio { get; set; }
            public TimeOnly term_ensaio { get; set; }
            public string? temp_min { get; set; }
            public string? temp_max { get; set; }
            public string? local_aplicado { get; set; }
            public string? forca_aplicada { get; set; }
            public string? aplicacao_carga { get; set; }
            public string? suportou_aplicacao { get; set; }
            public string? ruptura { get; set; }
            public string? afundamento { get; set; }
            public string? rasgo { get; set; }
            public string? rompimento { get; set; }
            public string? prejudique { get; set; }
            public string? conforme_pontoA { get; set; }
        }

        public class RegistroLamina
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
            public string? desc_lamina { get; set; }
            public string? tipo_cert { get; set; }
            public string? modelo_cert { get; set; }
            public string? tipo_proc { get; set; }
            public string? produto { get; set; }
            public string? andamento { get; set; }
        }

        public class SalvarLaminaDeterminacaoDensidade
        {
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public int densidade { get; set; }
            public string? tipo_espuma { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? tem_maior_igual { get; set; }
            public float esp_amostra_um_um { get; set; }
            public float esp_amostra_um_dois { get; set; }
            public float esp_amostra_um_tres { get; set; }
            public float esp_amostra_um_quat { get; set; }
            public float esp_amostra_um_cinco { get; set; }
            public float esp_amostra_um_seis { get; set; }
            public float esp_amostra_um_sete { get; set; }
            public float esp_amostra_um_oito { get; set; }
            public float esp_amostra_dois_um { get; set; }
            public float esp_amostra_dois_dois { get; set; }
            public float esp_amostra_dois_tres { get; set; }
            public float esp_amostra_dois_quat { get; set; }
            public float esp_amostra_dois_cinco { get; set; }
            public float esp_amostra_dois_seis { get; set; }
            public float esp_amostra_dois_sete { get; set; }
            public float esp_amostra_dois_oito { get; set; }
            public float esp_amostra_tres_um { get; set; }
            public float esp_amostra_tres_dois { get; set; }
            public float esp_amostra_tres_tres { get; set; }
            public float esp_amostra_tres_quat { get; set; }
            public float esp_amostra_tres_cinco { get; set; }
            public float esp_amostra_tres_seis { get; set; }
            public float esp_amostra_tres_sete { get; set; }
            public float esp_amostra_tres_oito { get; set; }
            public float esp_media_um { get; set; }
            public float esp_media_dois { get; set; }
            public float esp_media_tres { get; set; }
            public float calc_amostra_um { get; set; }
            public float calc_amostra_dois { get; set; }
            public float calc_amostra_tres { get; set; }
            public float massa_um { get; set; }
            public float massa_dois { get; set; }
            public float massa_tres { get; set; }
            public float dr_um_um { get; set; }
            public float dr_um_dois { get; set; }
            public float dr_resul_um { get; set; }
            public float dr_dois_um { get; set; }
            public float dr_dois_dois { get; set; }
            public float dr_resul_dois { get; set; }
            public float dr_tres_um { get; set; }
            public float dr_tres_dois { get; set; }
            public float dr_resul_tres { get; set; }
            public float dr_media { get; set; }
            public float maxima_densidade { get; set; }
            public float minima_densidade { get; set; }
            public string? executador { get; set; }
            public string? editorUsuario { get; set; }
            public string? conforme { get; set; }
           
        }

        public class LaminaResiliencia
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? tipo_espuma { get; set; }
            public int densidade { get; set; }
            public float resil_amostra_um_um { get; set; }
            public float resil_amostra_um_dois { get; set; }
            public float resil_amostra_um_tres { get; set; }
            public float varia_amostra_um_um { get; set; }
            public float varia_amostra_um_dois { get; set; }
            public float media_res_um { get; set; }
            public float resil_amostra_dois_um { get; set; }
            public float resil_amostra_dois_dois { get; set; }
            public float resil_amostra_dois_tres { get; set; }
            public float varia_amostra_dois_um { get; set; }
            public float varia_amostra_dois_dois { get; set; }
            public float media_res_dois { get; set; }
            public float resil_amostra_tres_um { get; set; }
            public float resil_amostra_tres_dois { get; set; }
            public float resil_amostra_tres_tres { get; set; }
            public float varia_amostra_tres_um { get; set; }
            public float varia_amostra_tres_dois { get; set; }
            public float media_res_tres { get; set; }
            public float resiliencia_esp { get; set; }
            public float resiliencia_enc { get; set; }
            public string? min_max { get; set; }
            public string? conforme { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }         
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? executor { get; set; }
            public string? editorUsuario { get; set; }
        }

        public class LaminaDPC
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly date_term { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }
            public string? im { get; set; }
            public string? responsavel_cond_um { get; set; }
            public DateOnly acond_inicio_dois { get; set; }
            public DateOnly acond_final_dois { get; set; }
            public TimeOnly hora_inicio_dois { get; set; }
            public TimeOnly hora_final_dois { get; set; }
            public float temp_inicio_dois { get; set; }
            public float temp_final_dois { get; set; }
            public float umidade_inicio_dois { get; set; }
            public float umidade_final_dois { get; set; }
            public string? im_dois { get; set; }
            public string? responsavel_cond_dois { get; set; }
            public float esp_ini_amostra_um_um { get; set; }
            public float esp_ini_amostra_um_dois { get; set; }
            public float esp_ini_amostra_um_tres { get; set; }
            public float esp_ini_amostra_um_quatro { get; set; }
            public float esp_ini_amostra_um_cinco { get; set; }
            public float esp_ini_amostra_um_seis { get; set; }
            public float esp_ini_amostra_um_sete { get; set; }
            public float esp_ini_amostra_um_oito { get; set; }
            public float esp_ini_amostra_dois_um { get; set; }
            public float esp_ini_amostra_dois_dois { get; set; }
            public float esp_ini_amostra_dois_tres { get; set; }
            public float esp_ini_amostra_dois_quatro { get; set; }
            public float esp_ini_amostra_dois_cinco { get; set; }
            public float esp_ini_amostra_dois_seis { get; set; }
            public float esp_ini_amostra_dois_sete { get; set; }
            public float esp_ini_amostra_dois_oito { get; set; }
            public float esp_ini_amostra_tres_um { get; set; }
            public float esp_ini_amostra_tres_dois { get; set; }
            public float esp_ini_amostra_tres_tres { get; set; }
            public float esp_ini_amostra_tres_quatro { get; set; }
            public float esp_ini_amostra_tres_cinco { get; set; }
            public float esp_ini_amostra_tres_seis { get; set; }
            public float esp_ini_amostra_tres_sete { get; set; }
            public float esp_ini_amostra_tres_oito { get; set; }
            public float esp_media_um { get; set; }
            public float esp_media_dois { get; set; }
            public float esp_media_tres { get; set; }
            public float media_esp_total { get; set; }
            public float media_esp_amostra_um { get; set; }
            public float media_esp_amostra_dois { get; set; }
            public float media_esp_amostra_tres { get; set; }
            public float reducao_porc { get; set; }
            public float reducao_mm { get; set; }
            public float esp_fin_amostra_um_um { get; set; }
            public float esp_fin_amostra_um_dois { get; set; }
            public float esp_fin_amostra_um_tres { get; set; }
            public float esp_fin_amostra_um_quatro { get; set; }
            public float esp_fin_amostra_um_cinco { get; set; }
            public float esp_fin_amostra_um_seis { get; set; }
            public float esp_fin_amostra_um_sete { get; set; }
            public float esp_fin_amostra_um_oito { get; set; }
            public float esp_fin_amostra_dois_um { get; set; }
            public float esp_fin_amostra_dois_dois { get; set; }
            public float esp_fin_amostra_dois_tres { get; set; }
            public float esp_fin_amostra_dois_quatro { get; set; }
            public float esp_fin_amostra_dois_cinco { get; set; }
            public float esp_fin_amostra_dois_seis { get; set; }
            public float esp_fin_amostra_dois_sete { get; set; }
            public float esp_fin_amostra_dois_oito { get; set; }
            public float esp_fin_amostra_tres_um { get; set; }
            public float esp_fin_amostra_tres_dois { get; set; }
            public float esp_fin_amostra_tres_tres { get; set; }
            public float esp_fin_amostra_tres_quatro { get; set; }
            public float esp_fin_amostra_tres_cinco { get; set; }
            public float esp_fin_amostra_tres_seis { get; set; }
            public float esp_fin_amostra_tres_sete { get; set; }
            public float esp_fin_amostra_tres_oito { get; set; }
            public float media_esp_fin_um { get; set; }
            public float media_esp_fin_dois { get; set; }
            public float media_esp_fin_tres { get; set; }
            public int tempo_repouso_um { get; set; }
            public int tempo_repouso_dois { get; set; }
            public int tempo_repouso_tres { get; set; }
            public float dpc_amostra_um_um { get; set; }
            public float dpc_amostra_um_dois { get; set; }
            public float dpc_amostra_um_tres { get; set; }
            public float dpc_amostra_dois_um { get; set; }
            public float dpc_amostra_dois_dois { get; set; }
            public float dpc_amostra_dois_tres { get; set; }
            public float dpc_amostra_tres_um { get; set; }
            public float dpc_amostra_tres_dois { get; set; }
            public float dpc_amostra_tres_tres { get; set; }
            public float med_dpc_amostra_um { get; set; }
            public float med_dpc_amostra_dois { get; set; }
            public float med_dpc_amostra_tres { get; set; }
            public float vari_amsotra_dois { get; set; }
            public float vari_amsotra_tres { get; set; }
            public float especificada { get; set; }
            public float encontrada { get; set; }
            public string? tipo_espuma { get; set; }
            public int densidade { get; set; }
            public string? conforme { get; set; }
            public string? min_max { get; set; }
            public string? executor { get; set; }
            public string? editorUsuario { get; set; }


        }

        public class LaminaFI
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? tipo_espuma { get; set; }
            public int densidade { get; set; }

            public float esp_ini_amostra_um_um { get; set; }
            public float esp_ini_amostra_um_dois { get; set; }
            public float esp_ini_amostra_um_tres { get; set; }
            public float esp_ini_amostra_um_quatro { get; set; }
            public float esp_ini_amostra_um_cinco { get; set; }
            public float esp_ini_amostra_um_seis { get; set; }
            public float esp_ini_amostra_um_sete { get; set; }
            public float esp_ini_amostra_um_oito { get; set; }
            public float esp_ini_amostra_dois_um { get; set; }
            public float esp_ini_amostra_dois_dois { get; set; }
            public float esp_ini_amostra_dois_tres { get; set; }
            public float esp_ini_amostra_dois_quatro { get; set; }
            public float esp_ini_amostra_dois_cinco { get; set; }
            public float esp_ini_amostra_dois_seis { get; set; }
            public float esp_ini_amostra_dois_sete { get; set; }
            public float esp_ini_amostra_dois_oito { get; set; }
            public float esp_ini_amostra_tres_um { get; set; }
            public float esp_ini_amostra_tres_dois { get; set; }
            public float esp_ini_amostra_tres_tres { get; set; }
            public float esp_ini_amostra_tres_quatro { get; set; }
            public float esp_ini_amostra_tres_cinco { get; set; }
            public float esp_ini_amostra_tres_seis { get; set; }
            public float esp_ini_amostra_tres_sete { get; set; }
            public float esp_ini_amostra_tres_oito { get; set; }
            public float esp_media_um { get; set; }
            public float esp_media_dois { get; set; }
            public float esp_media_tres { get; set; }
            public float media_espessura_um { get; set; }
            public float media_espessura_dois { get; set; }
            public float media_espessura_tres { get; set; }

            public float pre_carga { get; set; }
            public float reducao_um { get; set; }
            public float reducao_dois { get; set; }
            public float reducao_tres { get; set; }
            public string? espuma_vsiocoelastica { get; set; }
            public int comp_25_um { get; set; }
            public int comp_25_dois { get; set; }
            public int comp_25_tres { get; set; }
            public float reducao_25_um { get; set; }
            public float reducao_25_dois { get; set; }
            public float reducao_25_tres { get; set; }
            public int temp_25_um { get; set; }
            public int temp_25_dois { get; set; }
            public int temp_25_tres { get; set; }
            public float fi_25_um { get; set; }
            public float fi_25_dois { get; set; }
            public float fi_25_tres { get; set; }
            public float media_25 { get; set; }
            public int comp_40_um { get; set; }
            public int comp_40_dois { get; set; }
            public int comp_40_tres { get; set; }
            public int temp_40_um { get; set; }
            public int temp_40_dois { get; set; }
            public int temp_40_tres { get; set; }
            public float reducao_40_um { get; set; }
            public float reducao_40_dois { get; set; }
            public float reducao_40_tres { get; set; }
            public float fi_40_um { get; set; }
            public float fi_40_dois { get; set; }
            public float fi_40_tres { get; set; }
            public float media_40 { get; set; }
            public int comp_65_um { get; set; }
            public int comp_65_dois { get; set; }
            public int comp_65_tres { get; set; }
            public int temp_65_um { get; set; }
            public int temp_65_dois { get; set; }
            public int temp_65_tres { get; set; }
            public float fi_65_um { get; set; }
            public float fi_65_dois { get; set; }
            public float fi_65_tres { get; set; }
            public float reducao_65_um { get; set; }
            public float reducao_65_dois { get; set; }
            public float reducao_65_tres { get; set; }
            public float media_65 { get; set; }
            public float fator_ind_65 { get; set; }
            public float fator_ind_40 { get; set; }
            public float fator_ind_25 { get; set; }
            public float forca_esp_25 { get; set; }
            public float forca_esp_40 { get; set; }
            public float forca_esp_65 { get; set; }
            public float reducao_porc_um { get; set; }
            public float reducao_porc_dois { get; set; }
            public float reducao_porc_tres { get; set; }
            public int tempo_espera { get; set; }
            public float conforto_65 { get; set; }
            public float conforto_25 { get; set; }
            public float media_conforto { get; set; }
            public string? fc_especificado { get; set; }
            public string? conforme { get; set; }
            public string? conforme_conforto { get; set; }
            public string? min_max { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }         
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? executor { get; set; }
            public string? editorUsuario { get; set; }
        }

        public class LaminaFadigaRotativa
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }
            
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public float esp_ini_amostra_um_um { get; set; }
            public float esp_ini_amostra_um_dois { get; set; }
            public float esp_ini_amostra_um_tres { get; set; }
            public float esp_ini_amostra_um_quatro { get; set; }
            public float esp_ini_amostra_um_cinco { get; set; }
            public float esp_ini_amostra_um_seis { get; set; }
            public float esp_ini_amostra_um_sete { get; set; }
            public float esp_ini_amostra_um_oito { get; set; }
            public float esp_ini_amostra_dois_um { get; set; }
            public float esp_ini_amostra_dois_dois { get; set; }
            public float esp_ini_amostra_dois_tres { get; set; }
            public float esp_ini_amostra_dois_quatro { get; set; }
            public float esp_ini_amostra_dois_cinco { get; set; }
            public float esp_ini_amostra_dois_seis { get; set; }
            public float esp_ini_amostra_dois_sete { get; set; }
            public float esp_ini_amostra_dois_oito { get; set; }
            public float esp_ini_amostra_tres_um { get; set; }
            public float esp_ini_amostra_tres_dois { get; set; }
            public float esp_ini_amostra_tres_tres { get; set; }
            public float esp_ini_amostra_tres_quatro { get; set; }
            public float esp_ini_amostra_tres_cinco { get; set; }
            public float esp_ini_amostra_tres_seis { get; set; }
            public float esp_ini_amostra_tres_sete { get; set; }
            public float esp_ini_amostra_tres_oito { get; set; }
            public float esp_ini_media_um { get; set; }
            public float esp_ini_media_dois { get; set; }
            public float esp_ini_media_tres { get; set; }

            public float media_espessura_um { get; set; }
            public float media_espessura_dois { get; set; }
            public float media_espessura_tres { get; set; }
            public float media_espessura_total { get; set; }
            public int ciclos_um { get; set; }
            public int ciclos_dois { get; set; }
            public int ciclos_tres { get; set; }
            public float esp_final_amostra_um_um { get; set; }
            public float esp_final_amostra_um_dois { get; set; }
            public float esp_final_amostra_um_tres { get; set; }
            public float esp_final_amostra_um_quatro { get; set; }
            public float esp_final_amostra_um_cinco { get; set; }
            public float esp_final_amostra_um_seis { get; set; }
            public float esp_final_amostra_um_sete { get; set; }
            public float esp_final_amostra_um_oito { get; set; }
            public float esp_final_amostra_dois_um { get; set; }
            public float esp_final_amostra_dois_dois { get; set; }
            public float esp_final_amostra_dois_tres { get; set; }
            public float esp_final_amostra_dois_quatro { get; set; }
            public float esp_final_amostra_dois_cinco { get; set; }
            public float esp_final_amostra_dois_seis { get; set; }
            public float esp_final_amostra_dois_sete { get; set; }
            public float esp_final_amostra_dois_oito { get; set; }
            public float esp_final_amostra_tres_um { get; set; }
            public float esp_final_amostra_tres_dois { get; set; }
            public float esp_final_amostra_tres_tres { get; set; }
            public float esp_final_amostra_tres_quatro { get; set; }
            public float esp_final_amostra_tres_cinco { get; set; }
            public float esp_final_amostra_tres_seis { get; set; }
            public float esp_final_amostra_tres_sete { get; set; }
            public float esp_final_amostra_tres_oito { get; set; }
            public float media_esp_fin_um { get; set; }
            public float media_esp_fin_dois { get; set; }
            public float media_esp_fin_tres { get; set; }
            public string? tempo_rep_esp_um { get; set; }
            public string? tempo_rep_esp_dois { get; set; }
            public string? tempo_rep_esp_tres { get; set; }
            public float pe_um_um { get; set; }
            public float pe_um_dois { get; set; }
            public float pe_um_tres { get; set; }
            public float pe_media_um { get; set; }
            public float pe_dois_um { get; set; }
            public float pe_dois_dois { get; set; }
            public float pe_dois_tres { get; set; }
            public float pe_media_dois { get; set; }
            public float pe_tres_um { get; set; }
            public float pe_tres_dois { get; set; }
            public float pe_tres_tres { get; set; }
            public float pe_media_tres { get; set; }
            public float pe_especificado { get; set; }
            public float pe_encontrado { get; set; }
            public string? min_max { get; set; }
            public string? tipo_espuma { get; set; }
            public int densidade { get; set; }
            public string? conforme { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }

        }

        public class LaminaPFI
        {
            [Key]
            public int Id { get; set; }
            public string orcamento { get; set; }
            public string os { get; set; }
            public DateOnly data_ini { get; set; }
            public DateOnly data_term { get; set; }
            public string? tipo_espuma { get; set; }
            public int densidade { get; set; }          
            public float esp_ini_amostra_um_um { get; set; }
            public float esp_ini_amostra_um_dois { get; set; }
            public float esp_ini_amostra_um_tres { get; set; }
            public float esp_ini_amostra_um_quatro { get; set; }
            public float esp_ini_amostra_um_cinco { get; set; }
            public float esp_ini_amostra_um_seis { get; set; }
            public float esp_ini_amostra_um_sete { get; set; }
            public float esp_ini_amostra_um_oito { get; set; }
            public float esp_ini_amostra_dois_um { get; set; }
            public float esp_ini_amostra_dois_dois { get; set; }
            public float esp_ini_amostra_dois_tres { get; set; }
            public float esp_ini_amostra_dois_quatro { get; set; }
            public float esp_ini_amostra_dois_cinco { get; set; }
            public float esp_ini_amostra_dois_seis { get; set; }
            public float esp_ini_amostra_dois_sete { get; set; }
            public float esp_ini_amostra_dois_oito { get; set; }
            public float esp_ini_amostra_tres_um { get; set; }
            public float esp_ini_amostra_tres_dois { get; set; }
            public float esp_ini_amostra_tres_tres { get; set; }
            public float esp_ini_amostra_tres_quatro { get; set; }
            public float esp_ini_amostra_tres_cinco { get; set; }
            public float esp_ini_amostra_tres_seis { get; set; }
            public float esp_ini_amostra_tres_sete { get; set; }
            public float esp_ini_amostra_tres_oito { get; set; }
            public float lar_media_um { get; set; }
            public float lar_media_dois { get; set; }
            public float lar_media_tres { get; set; }
            public float comp_media_um { get; set; }
            public float comp_media_dois { get; set; }
            public float comp_media_tres { get; set; }
            public float esp_media_um { get; set; }
            public float esp_media_dois { get; set; }
            public float esp_media_tres { get; set; }
            public float media_espessura_um { get; set; }
            public float media_espessura_dois { get; set; }
            public float media_espessura_tres { get; set; }
            public float pre_carga { get; set; }
            public int comp_25_um { get; set; }
            public int comp_25_dois { get; set; }
            public int comp_25_tres { get; set; }
            public float red_25_um { get; set; }
            public float red_25_dois { get; set; }
            public float red_25_tres { get; set; }
            public string? temp_25_um { get; set; }
            public string? temp_25_dois { get; set; }
            public string? temp_25_tres { get; set; }
            public float fi_25_um { get; set; }
            public float fi_25_dois { get; set; }
            public float fi_25_tres { get; set; }
            public float media_25_comp { get; set; }
            public int comp_40_um { get; set; }
            public int comp_40_dois { get; set; }
            public int comp_40_tres { get; set; }
            public float red_40_um { get; set; }
            public float red_40_dois { get; set; }
            public float red_40_tres { get; set; }
            public string? temp_40_um { get; set; }
            public string? temp_40_dois { get; set; }
            public string? temp_40_tres { get; set; }
            public float fi_40_um { get; set; }
            public float fi_40_dois { get; set; }
            public float fi_40_tres { get; set; }
            public float media_40_comp { get; set; }
            public int comp_65_um { get; set; }
            public int comp_65_dois { get; set; }
            public int comp_65_tres { get; set; }
            public float red_65_um { get; set; }
            public float red_65_dois { get; set; }
            public float red_65_tres { get; set; }
            public string? temp_65_um { get; set; }
            public string? temp_65_dois { get; set; }
            public string? temp_65_tres { get; set; }
            public float fi_65_um { get; set; }
            public float fi_65_dois { get; set; }
            public float fi_65_tres { get; set; }
            public float media_65_comp { get; set; }
            public string? forca_ind_esp_25 { get; set; }
            public string? forca_ind_esp_40 { get; set; }
            public string? forca_ind_esp_65 { get; set; }
            public float forca_ind_enc_25 { get; set; }
            public float forca_ind_enc_40 { get; set; }
            public float forca_ind_enc_65 { get; set; }
            public float pfi_25_um { get; set; }
            public float pfi_25_dois { get; set; }
            public float pfi_25_tres { get; set; }
            public string? pfi_25_especificada { get; set; }
            public float pfi_25_encontrada { get; set; }
            public float pfi_40_um { get; set; }
            public float pfi_40_dois { get; set; }
            public float pfi_40_tres { get; set; }
            public int pfi_40_especificada { get; set; }
            public float pfi_40_encontrada { get; set; }
            public float pfi_65_um { get; set; }
            public float pfi_65_dois { get; set; }
            public float pfi_65_tres { get; set; }
            public string? pfi_65_especificada { get; set; }
            public float pfi_65_encontrada { get; set; }
            public float media_espessura_total { get; set; }
            public DateOnly acond_inicio { get; set; }
            public DateOnly acond_final { get; set; }
            public TimeOnly hora_inicio { get; set; }
            public TimeOnly hora_final { get; set; }
            public float temp_inicio { get; set; }
            public float temp_final { get; set; }
            public float umidade_inicio { get; set; }
            public float umidade_final { get; set; }
            public string? im { get; set; }
            public string? responsavel_cond { get; set; }
            public string? conforme { get; set; }
            public string? executor { get; set; }
            public string? editarUsuario { get; set; }
        }

    }
}
