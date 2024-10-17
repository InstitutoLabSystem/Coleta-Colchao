using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class LogRevisao
    {
        [Key]
        public int Id { get; set; }
        public string? os { get; set; }
        public string? orcamento { get; set; }
        public int rev { get; set; }
        public string? motivo { get; set; }
        public string? nota { get; set; }
        public string? ensaio { get; set; }
        public string? usuario { get; set; }
    }
}
