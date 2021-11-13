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

        public int IdOrigem { private get; set; }
        public int IdDestino { private get; set; }
        public int IdEspecie { private get; set; }
        public int IdFinalidadeDeVenda { private get; set; }

        public Propriedade Origem { get; set; }
        public Propriedade Destino { get; set; }
        public Especie Especie { get; set; }
        public FinalidadeDeVenda FinalidadeDeVenda { get; set; }

        public int getOrigem()
        {
            return IdOrigem;
        }
        public int getDestino()
        {
            return IdDestino;
        }
        public int getEspecie()
        {
            return IdEspecie;
        }
        public int getFinalidadeDeVenda()
        {
            return IdFinalidadeDeVenda;
        }
    }
}
