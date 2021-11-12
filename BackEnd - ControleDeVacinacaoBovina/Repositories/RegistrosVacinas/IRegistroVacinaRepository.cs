using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.RegistrosVacinas
{
    interface IRegistroVacinaRepository
    {
        void Incluir(RegistroVacinacao registroVacina);
        void Cancelar(int id);
        Task<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual);
    }
}
