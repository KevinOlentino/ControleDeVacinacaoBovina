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

        public async Task<IEnumerable<Produtor>> GetAll()
        {
            return await produtorRepository.GetAll();
        }

        public async Task<Produtor> GetByCPF(string CPF)
        {
            return await produtorRepository.GetByCPF(CPF);
        }

        public void Incluir(Produtor produtor)
        {
            produtorRepository.Incluir(produtor);
        }
    }
}
