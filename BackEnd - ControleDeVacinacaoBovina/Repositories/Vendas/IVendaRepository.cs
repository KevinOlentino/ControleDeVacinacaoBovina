using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    public interface IVendaRepository
    {
        void Incluir(Venda venda);
        void Cancelar(int id);
        IEnumerable<Venda> GetByOrigem(int idPropriedade);
        IEnumerable<Venda> GetByDestino(int idPropriedade);
    }
}
