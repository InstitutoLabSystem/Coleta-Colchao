using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class HomeModel
    {
        public class OrdemLaboratorioEnsaio
        {
            [Key]
            public int pk { get; set; }
            public string Orcamento { get; set; }
            public string OS { get; set; }
            public string CodigoEnsaio { get; set; }
            public string Item { get; set; }
        }

        public class OrdemServicoCopyLabItem
        {
            [Key]
            public int Numero { get; set; }
            public string Mes { get; set; }
            public string Ano { get; set; }
            public string orcamento { get; set; }
            public string CodigoEnsaio { get; set; }
            public int Item { get; set; }

            [MaxLength(60)]
            public string ProdEnsaiado { get; set; }
        }
        public class Wmoddetprod
        {
            [Key]
            public int cod { get; set; }
            public string codmaster { get; set; }
            public string codigo { get; set; }
            public string descricao { get; set; }
        }

        public class OrdemServico
        {
            [Key]
            public int codigo { get; set; }
            public string mes { get; set; }
            public string ano { get; set; }
            public int Rev { get; set; }
            public string Solicitante { get; set; }
        }

        [Keyless]
        public class OrdemServicoLaboratorio
        {
            public string OS { get; set; }
            public string orcamento { get; set; }
            public string? Laboratorio { get; set; }
            public DateOnly DataSaidaAmReceb { get; set; }
        }

        public class Resposta
        {
            public string OS { get; set; }
            public string orcamento { get; set; }
            public string codigo { get; set; }
            public string descricao { get; set; }
            public string codmaster { get; set; }
            public string ProdEnsaiado { get; set; } 
        }
    }
}
