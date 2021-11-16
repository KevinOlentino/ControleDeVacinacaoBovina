using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVacinacaoBovina.Repositories.Produtores
{
    public class ProdutorRepository : BaseRepository, IProdutorRepository
    {
        public ProdutorRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Produtor produtor)
        {
            _contexto.Produtores.Update(produtor);
        }

        public async Task<IEnumerable<Produtor>> GetAll()
        {
            return await _contexto.Produtores.ToListAsync();
        }

        public async Task<Produtor> GetByCPF(string CPF)
        {
            return await _contexto.Produtores.FirstOrDefaultAsync(x => x.CPF == CPF);
        }

        public void Incluir(Produtor produtor)
        {
            _contexto.Produtores.Add(produtor);
        }
    }
}
