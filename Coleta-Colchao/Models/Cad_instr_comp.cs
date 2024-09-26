using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class Cad_instr_comp
    {
        [Key]
        public int pk { get; set; }
        public int id { get; set; }
        public string? codigo { get; set; }
        public string? Laboratorio { get; set; }
    }
}
