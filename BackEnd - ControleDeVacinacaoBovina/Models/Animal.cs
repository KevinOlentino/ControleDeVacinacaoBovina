using System;

namespace ControleDeVacinacaoBovina.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeVacinada { get; set; }
        public int IdEspecie { get; set; }
        public int IdPropriedade { get; set; }
        public int IdTipoDeEntrada { get; set; }
        public DateTime DataDeEntrada { get; set; }
        public bool Ativo { get; private set; } = true;
        public TipoDeEntrada TipoDeEntrada { get; set; }
        public Especie Especie { get; set; }
        public Propriedade Propriedade { get; set; }

        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
