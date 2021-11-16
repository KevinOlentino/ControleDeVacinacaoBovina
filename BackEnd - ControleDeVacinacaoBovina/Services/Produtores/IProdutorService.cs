using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Produtores
{
    public interface IProdutorService
    {
        void Incluir(Produtor produtor);
        void Editar(Produtor produtor);
        Task<Produtor> GetByCPF(string CPF);
        Task<IEnumerable<Produtor>> GetAll();
    }
}
