using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas
{
    public interface IFinalidadeDeVendaRepository
    {
        IEnumerable<FinalidadeDeVenda> GetAll();
        FinalidadeDeVenda GetById(int id);
    }
}
