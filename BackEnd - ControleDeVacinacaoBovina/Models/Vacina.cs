using System.Collections.Generic;

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
