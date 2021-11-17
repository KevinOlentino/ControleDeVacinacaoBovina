using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.RegistrosVacinas
{
    public interface IRegistroVacinaService
    {
        void Incluir(RegistroVacinacao registroVacina);
        void Cancelar(int id);
        IEnumerable<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual);
        DateTime ObterUltimaVacinaPorEspecie(int idAnimal);
    }
}
