using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ControleDeVacinacaoBovina.DbMappings;

namespace ControleDeVacinacaoBovina.Repositories.Produtores
{
    public class ProdutorRepository : BaseRepository, IProdutorRepository
    {
        public ProdutorRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Produtor produtor)
        {
            produtor.IdEndereco = produtor.Endereco.IdEndereco.Value;
            _contexto.Produtores.Update(produtor);
            _contexto.SaveChanges();
        }

        public async Task<IEnumerable<Produtor>> GetAll()
        {
            return await _contexto.Produtores.Include(x => x.Endereco).ThenInclude(x => x.Municipio).ToListAsync();
        }

        public async Task<Produtor> GetByCPF(string CPF)
        {
            return await _contexto.Produtores.Include(x => x.Endereco).ThenInclude(x => x.Municipio).FirstOrDefaultAsync(x => x.CPF == CPF);
        }

        public Produtor GetById(int id)
        {
            return _contexto.Produtores.AsNoTracking().FirstOrDefault(x => x.IdProdutor == id);
        }

        public void Incluir(Produtor produtor)
        {
            _contexto.Produtores.Add(produtor);
            _contexto.SaveChanges();
        }

        public bool ExistByCPF(string cpf)
        {
            return _contexto.Produtores.Any(x => x.CPF == cpf);
        }
    }
}
