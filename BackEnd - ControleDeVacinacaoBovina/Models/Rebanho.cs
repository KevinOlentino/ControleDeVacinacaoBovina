using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class Rebanho
    {
        public int IdRebanho { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeVacinada { get; set; }
        public int IdEspecie { get; set; }
        public int IdPropriedade { get; set; }
        public Especie Especie { get; set; }
        public Propriedade Propriedade { get; set; }

        public List<RegistroVacinacao> RegistroVacinacoes;
        public List<Venda> Vendas;
    }
}