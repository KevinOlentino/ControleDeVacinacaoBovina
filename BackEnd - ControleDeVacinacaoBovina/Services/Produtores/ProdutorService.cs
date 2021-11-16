using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Produtores
{
    public class ProdutorService : IProdutorService
    {
        private readonly IProdutorRepository produtorRepository;

        public ProdutorService(IProdutorRepository produtorRepository)
        {
            this.produtorRepository = produtorRepository;
        }

        public void Editar(Produtor produtor)
        {
            produtorRepository.Editar(produtor);
        }

        public Task<IEnumerable<Produtor>> GetAll()
        {
            return produtorRepository.GetAll();
        }

        public Task<Produtor> GetByCPF(string CPF)
        {
            return produtorRepository.GetByCPF(CPF);
        }

        public void Incluir(Produtor produtor)
        {
            produtorRepository.Incluir(produtor);
        }
    }
}
