using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class RegistroVacinacao
    {
        public int IdRegistroVacinacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDaVacina { get; set; }
        public int IdAnimal { private get; set; }
        public int IdVacina { private get; set; }
        public Animal Animal { get; set; }
        public Vacina Vacina { get; set; }

        public int getIdAnimal()
        {
            return IdAnimal;
        }
        public int getIdVacina()
        {
            return IdVacina;
        }
    }
}
