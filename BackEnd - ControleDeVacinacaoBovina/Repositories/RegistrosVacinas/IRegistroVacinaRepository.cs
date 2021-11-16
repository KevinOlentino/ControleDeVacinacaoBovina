using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.RegistrosVacinas
{
    public interface IRegistroVacinaRepository
    {
        void Incluir(RegistroVacinacao registroVacina);
        void Cancelar(int id);
        IEnumerable<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual);
        RegistroVacinacao GetByAnimal(int id);
    }
}
