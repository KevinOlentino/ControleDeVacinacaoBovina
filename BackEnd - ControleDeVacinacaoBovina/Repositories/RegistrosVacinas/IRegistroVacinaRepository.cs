using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.RegistrosVacinas
{
    public interface IRegistroVacinaRepository
    {
        Task Incluir(RegistroVacinacao registroVacina);
        void Cancelar(RegistroVacinacao registroVacina);
        IEnumerable<RegistroVacinacao> GetByPropriedade(int idPropriedade);
        IEnumerable<RegistroVacinacao> GetByAnimal(int id);
        RegistroVacinacao GetById(int id);
    }
}
