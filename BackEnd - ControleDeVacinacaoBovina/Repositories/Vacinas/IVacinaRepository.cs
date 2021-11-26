using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Vacinas
{
    public interface IVacinaRepository
    {
        Vacina GetById(int id);
        Task<IEnumerable<Vacina>> GetAll();
    }
}
