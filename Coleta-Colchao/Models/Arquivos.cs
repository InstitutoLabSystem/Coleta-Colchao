using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class Arquivos
    {
        public class Imagens
        {
            [Key]
            public int controle { get; set; }
            public int rae { get; set; }
            public string orcamento { get; set; }
            public int? revisao { get; set; }
            public string? titulo { get; set; }
            public string? layout { get; set; }
            public int? juntar { get; set; }
            public string? img { get; set; }
        }
    }
}
