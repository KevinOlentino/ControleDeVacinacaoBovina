using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.FinalidadeDeVendas
{
    public class FinalidadeDeVendasService : IFinalidadeDeVendasService
    {
        private readonly IFinalidadeDeVendaRepository finalidadeDeVendasRepository;

        public FinalidadeDeVendasService(IFinalidadeDeVendaRepository finalidadeDeVendasRepository)
        {
            this.finalidadeDeVendasRepository = finalidadeDeVendasRepository;
        }

        public IEnumerable<FinalidadeDeVenda> GetAll()
        {
            return finalidadeDeVendasRepository.GetAll();
        }

        public FinalidadeDeVenda GetById(int id)
        {
            return finalidadeDeVendasRepository.GetById(id);
        }
    }
}
