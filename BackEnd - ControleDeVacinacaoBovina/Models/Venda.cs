using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int Quantidade { get; set; }
        public Propriedade Origem { get; set; }
        public Propriedade Destino { get; set; }
        public Especie Especie { get; set; }
        public FinalidadeDeVenda FinalidadeDeVenda { get; set; }
    }
}
