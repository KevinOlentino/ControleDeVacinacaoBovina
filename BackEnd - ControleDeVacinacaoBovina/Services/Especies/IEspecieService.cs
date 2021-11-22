using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Especies
{
    public interface IEspecieService
    {
        Task<Especie> GetById(int id);
        Task<IEnumerable<Especie>> GetAll();
    }
}
