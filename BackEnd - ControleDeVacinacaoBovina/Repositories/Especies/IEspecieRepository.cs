using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Especies
{
    public interface IEspecieRepository
    {
        Task<Especie> GetById(int id);        
    }
}
