using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    interface IVendaRepository
    {
        void Incluir(Venda venda);
        void Cancelar(int id);
        Task<Produtor> GetByOrigem(string produtor);
        Task<Produtor> GetByDestino(string produtor);
    }
}
