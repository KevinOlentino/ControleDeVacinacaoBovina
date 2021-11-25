using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.TipoDeEntradas
{
    public interface ITipoDeEntradaRepository
    {
        IEnumerable<TipoDeEntrada> GetAll();
        TipoDeEntrada GetId(int Id);
    }
}
