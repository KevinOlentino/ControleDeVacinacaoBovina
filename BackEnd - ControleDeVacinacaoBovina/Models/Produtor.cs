using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class Produtor
    {
        public int IdProdutor { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

        public List<Propriedade> Propriedades;

        public int GetEndereco()
        {
            return IdEndereco;
        }
    }
}
