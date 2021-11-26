using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class FinalidadeDeVenda
    {
        public int IdFinalidadeDeVenda { get; set; }
        public string Nome { get; set; }

        public List<Venda> Vendas;
    }
}
