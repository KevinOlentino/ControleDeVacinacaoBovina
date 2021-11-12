using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeVacinada { get; set; }
        public Especie Especie { get; set; }
        public Propriedade Propriedade { get; set; }
    }
}
