using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Especies
{
    interface IEspecieRepository
    {
        Task<Especie> GetById(int id);        
    }
}
