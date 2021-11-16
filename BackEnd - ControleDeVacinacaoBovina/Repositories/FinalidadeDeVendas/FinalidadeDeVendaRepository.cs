using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
