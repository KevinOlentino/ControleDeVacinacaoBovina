using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class TipoDeEntrada
    {
        public int IdTipoDeEntrada { get; set; }
        public string Nome { get; set; }

        public List<Animal> Animals;
    }
}