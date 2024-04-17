using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class Gerenciamento
    {
        public int? Id { get; set; }
        public string os { get; set; }
        public string orcamento { get; set; }
        public string? andamento { get; set; }
        public string? num_proc { get; set; }
    }
}
