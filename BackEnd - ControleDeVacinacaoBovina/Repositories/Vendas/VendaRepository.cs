using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        public VendaRepository(Contexto novoContexto) : base(novoContexto) { }
        public void Cancelar(Venda venda)
        {
            venda.SetAtivo(false);
            _contexto.Entry(venda).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Venda> GetByDestino(int idProdutor)
        {
            return _contexto.Vendas.Include(x => x.Destino)
                .Include(x => x.Origem)
                .Include(x => x.Rebanho)
                .ThenInclude(x => x.Especie)
                .Include(x => x.FinalidadeDeVenda)
                .Where(x => x.Ativo == true)
                .Where(x => x.Destino.IdProdutor == idProdutor);
        }

        public IEnumerable<Venda> GetByOrigem(int idProdutor)
        {
            return _contexto.Vendas.Include(x => x.Destino)
                .Include(x => x.Origem)
                .Include(x => x.Rebanho)
                .ThenInclude(x => x.Especie)
                .Include(x => x.FinalidadeDeVenda)
                .Where(x => x.Ativo == true)
                .Where(x => x.Origem.IdProdutor == idProdutor);
        }

        public Venda GetById(int id)
        {
            return _contexto.Vendas.Where(x => x.Ativo == true)
                                   .Include(x => x.Rebanho)
                                    .FirstOrDefault(x => x.IdVenda == id);
        }

        public IEnumerable<Venda> GetByRebanho(int idRebanho)
        {
            return _contexto.Vendas.AsNoTracking().Where(x => x.IdRebanho == idRebanho);
        }

        public void Incluir(Venda venda)
        {
            _contexto.Vendas.Add(venda);
            _contexto.SaveChanges();
        }
    }
}
