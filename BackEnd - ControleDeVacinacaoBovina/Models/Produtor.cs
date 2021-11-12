using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Produtor
    {
        public int IdProdutor { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}
