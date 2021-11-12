using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository.Vendas
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        public VendaRepository(Contexto novoContexto) : base(novoContexto){ }
        public async void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Produtor> GetByDestino(string produtor)
        {
            throw new NotImplementedException();
        }

        public async Task<Produtor> GetByOrigem(string produtor)
        {
            throw new NotImplementedException();
        }

        public async void Incluir(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
