using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas
{
    public interface IFinalidadeDeVendaRepository
    {
        IEnumerable<FinalidadeDeVenda> GetAll();
        FinalidadeDeVenda GetById(int id);
    }
}
