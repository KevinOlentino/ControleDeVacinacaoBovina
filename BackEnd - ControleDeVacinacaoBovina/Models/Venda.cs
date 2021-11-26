using System;

namespace ControleDeVacinacaoBovina.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int Quantidade { get; set; }
        public int IdOrigem { get; set; }
        public int IdDestino { get; set; }
        public int IdRebanho { get; set; }
        public int IdFinalidadeDeVenda { get; set; }
        public DateTime DataDeVenda { get; set; }
        public bool Ativo { get; private set; } = true;
        public Propriedade Origem { get; set; }
        public Propriedade Destino { get; set; }
        public Rebanho Rebanho { get; set; }
        public FinalidadeDeVenda FinalidadeDeVenda { get; set; }

        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }

    }
}
