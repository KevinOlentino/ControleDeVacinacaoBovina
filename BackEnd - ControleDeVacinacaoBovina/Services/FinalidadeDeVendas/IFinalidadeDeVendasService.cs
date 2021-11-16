using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.FinalidadeDeVendas
{
    interface IFinalidadeDeVendasService
    {
        IEnumerable<FinalidadeDeVenda> GetAll();
        FinalidadeDeVenda GetById(int id);
    }
}
