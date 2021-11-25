using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repositories.TipoDeEntradas
{
    public class TipoDeEntradaRepository: BaseRepository,ITipoDeEntradaRepository
    {
        public TipoDeEntradaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public IEnumerable<TipoDeEntrada> GetAll()
        {
            return _contexto.TipoDeEntradas.ToList();
        }

        public TipoDeEntrada GetId(int id)
        {
            return _contexto.TipoDeEntradas.Find(id);
        }
    }
}
