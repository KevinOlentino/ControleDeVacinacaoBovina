using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Produtores
{
    public class ProdutorRepository : BaseRepository, IProdutorRepository
    {
        public ProdutorRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public async Task<Produtor> Editar(Produtor produtor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produtor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Produtor> GetByCPF(string CPF)
        {
            throw new NotImplementedException();
        }

        public async void Incluir(Produtor produtor)
        {
            throw new NotImplementedException();
        }
    }
}
