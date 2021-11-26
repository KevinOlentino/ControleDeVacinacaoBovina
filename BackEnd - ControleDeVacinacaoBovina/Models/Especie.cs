using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class Especie
    {
        public int IdEspecie { get; set; }
        public string Nome { get; set; }

        public List<Rebanho> Rebanhos;
        public List<Animal> Animals;
        public List<Venda> Vendas;
    }
}
