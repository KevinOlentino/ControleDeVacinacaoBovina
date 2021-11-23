using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas
{
    public class FinalidadeDeVendaRepository : BaseRepository, IFinalidadeDeVendaRepository
    {
        public FinalidadeDeVendaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public IEnumerable<FinalidadeDeVenda> GetAll()
        {
            return _contexto.FinalidadeDeVendas.ToList();
        }

        public FinalidadeDeVenda GetById(int id)
        {
            return _contexto.FinalidadeDeVendas.Find(id);
        }
    }
}
