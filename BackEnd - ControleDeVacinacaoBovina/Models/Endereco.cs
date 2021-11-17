using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Endereco
    {
        public int? IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get;set; }
        public int IdMunicipio { get; set; }
        public Municipio Municipio { get; }

        public List<Produtor> Produtores;
        public List<Propriedade> Propriedades;

        public int GetMunicipio()
        {
            return IdMunicipio;
        }

    }
}
