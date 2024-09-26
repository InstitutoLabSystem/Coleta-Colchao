using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class Cad_Instr
    {
        [Key]
        public string Codigo { get; set; }
        public string? Descricaoins { get; set; }
        public string? NC { get; set; }
        public int id { get; set; }
        public DateTime data2 { get; set; }
    }
}
