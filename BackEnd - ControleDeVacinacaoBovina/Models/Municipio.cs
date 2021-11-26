using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Models
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }

        public List<Endereco> Endereco;
    }
}
