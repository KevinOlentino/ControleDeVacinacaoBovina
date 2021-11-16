using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Vacina
    {
        public int IdVacina { get; set; }
        public string Nome { get; set; }
        public string Doenca { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }

        public List<RegistroVacinacao> RegistroVacinas;
    }
}
