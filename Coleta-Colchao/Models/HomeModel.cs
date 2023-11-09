using System.ComponentModel.DataAnnotations;

namespace Coleta_Colchao.Models
{
    public class HomeModel
    {
        public class OrdemLaboratorio
        {
            [Key]
            public string seq { get; set; }
            public string mes {  get; set; }
            public string ano { get; set; }
            public string orcamento { get; set; }
            public string OS { get; set; }
            public string Laboratorio { get; set; }
        }

        public class OrdemServicoCopyLab
        {
            [Key]
            public int codigo { get; set; }
            public string mes { get; set; }
            public string ano { get; set;}
            public string  Solicitante { get; set; }
        }

        public class Resposta
        {
            public string OS { get; set; }
            public string orcamento { get; set; }
            public string Solicitante { get; set; }
        }
    }
}
