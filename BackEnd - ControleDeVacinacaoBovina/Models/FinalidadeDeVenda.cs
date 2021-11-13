using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class FinalidadeDeVenda
    {
        public int IdFinalidadeDeVenda { get; set; }
        public string Nome { get; set; }

        public List<Venda> Vendas;
    }
}
