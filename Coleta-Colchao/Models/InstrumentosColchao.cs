using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class InstrumentosColchao
    {
        [Key]
        public int Id { get; set; }
        public string? os { get; set; }
        public string? orcamento { get; set; }
        public string? codigo { get; set; }
        public string? descricao { get; set; }
        public string? certificado { get; set; }
        public DateOnly validade { get; set; }
    }
}
