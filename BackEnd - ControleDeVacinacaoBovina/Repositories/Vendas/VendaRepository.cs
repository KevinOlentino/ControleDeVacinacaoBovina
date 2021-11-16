using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        public VendaRepository(Contexto novoContexto) : base(novoContexto){ }
        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda> GetByDestino(int idProdutor)
        {
            return _contexto.Vendas.Include(x => x.Destino).Include(x => x.Origem)
                                     .Include(x => x.Especie).Include(x => x.FinalidadeDeVenda)
                                      .Where(x => x.IdDestino == idProdutor);
        }

        public IEnumerable<Venda> GetByOrigem(int idProdutor)
        {            
            return _contexto.Vendas.Include(x => x.Destino).Include(x => x.Origem)
                                     .Include(x => x.Especie).Include(x => x.FinalidadeDeVenda)
                                      .Where(x => x.IdOrigem == idProdutor);
        }

        public void Incluir(Venda venda)
        {
            _contexto.Vendas.Add(venda);
            _contexto.SaveChanges();
        }
    }
}
