using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Propriedade
    {
        public int IdPropriedade { get; set; }
        public string IncricaoEstadual { get; set; }
        public string Nome { get; set; }
        public int IdEndereco { private get; set; }
        public int IdProdutor { get; set; }
        public Endereco Endereco { get; set; }
        public Produtor Produtor { get; set; }

        public List<Animal> Animals;

        public List<Venda> Origem;
        public List<Venda> Destino;

        public int GetEndereco()    
        {
            return IdEndereco;
        }
        public int GetProdutor()
        {
            return IdProdutor;
        }        
    }
}
