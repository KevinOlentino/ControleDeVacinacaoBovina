using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Repositories.TipoDeEntradas
{
    public interface ITipoDeEntradaRepository
    {
        IEnumerable<TipoDeEntrada> GetAll();
        TipoDeEntrada GetId(int Id);
    }
}
