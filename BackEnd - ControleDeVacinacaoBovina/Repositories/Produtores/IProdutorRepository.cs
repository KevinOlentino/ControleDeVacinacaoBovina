using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Produtores
{
    public interface IProdutorRepository
    {
        void Incluir(Produtor produtor);
        Task<Produtor> Editar(Produtor produtor);
        Task<Produtor> GetByCPF(string CPF);
        Task<IEnumerable<Produtor>> GetAll();
    }
}
