using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            this.vendaRepository = vendaRepository;
        }

        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda> GetByDestino(int idProdutor)
        {
            return vendaRepository.GetByDestino(idProdutor);
        }

        public IEnumerable<Venda> GetByOrigem(int idProdutor)
        {
            return vendaRepository.GetByOrigem(idProdutor);
        }

        public void Incluir(Venda venda)
        {
            vendaRepository.Incluir(venda);
        }
    }
}
