using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    public interface IVendaRepository
    {
        void Incluir(Venda venda);
        void Cancelar(Venda venda);
        Venda GetById(int id);
        IEnumerable<Venda> GetByOrigem(int idPropriedade);
        IEnumerable<Venda> GetByDestino(int idPropriedade);
        IEnumerable<Venda> GetByRebanho(int idRebanho);
    }
}
