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
        public int IdEndereco { private get; set; }
        public Endereco Endereco { get; set; }

        public List<Propriedade> Propriedades;

        public int getEndereco()
        {
            return IdEndereco;
        }
    }
}
