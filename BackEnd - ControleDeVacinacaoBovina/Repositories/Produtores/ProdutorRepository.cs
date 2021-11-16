using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repositories.Produtores
{
    public class ProdutorRepository : BaseRepository, IProdutorRepository
    {
        public ProdutorRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Produtor produtor)
        {
            Produtor produtorEdit = _contexto.Produtores.FirstOrDefault(x => x.IdProdutor == produtor.IdProdutor);

            produtor.Endereco.IdEndereco = produtorEdit.GetEndereco();

            _contexto.Produtores.Update(produtor);
            _contexto.SaveChanges();
        }

        public async Task<IEnumerable<Produtor>> GetAll()
        {
            return await _contexto.Produtores.Include(x => x.Endereco).ThenInclude(x => x.Municipio).ToListAsync();
        }

        public async Task<Produtor> GetByCPF(string CPF)
        {
            return await _contexto.Produtores.FirstOrDefaultAsync(x => x.CPF == CPF);
        }

        public void Incluir(Produtor produtor)
        {
            _contexto.Produtores.Add(produtor);
            _contexto.SaveChanges();
        }
    }
}
