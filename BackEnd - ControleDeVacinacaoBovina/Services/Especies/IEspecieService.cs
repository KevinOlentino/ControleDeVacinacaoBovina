using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Especies
{
    public interface IEspecieService
    {
        Task<Especie> GetById(int id);
    }
}
