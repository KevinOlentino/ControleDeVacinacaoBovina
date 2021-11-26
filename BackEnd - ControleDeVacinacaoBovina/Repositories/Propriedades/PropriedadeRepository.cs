using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public class PropriedadeRepository : BaseRepository, IPropriedadeRepository
    {
        public PropriedadeRepository(Contexto novoContexto) : base(novoContexto)
        {
        }
        public void Editar(Propriedade propriedade)
        {
            propriedade.IdEndereco = propriedade.Endereco.IdEndereco.Value;
            _contexto.Propriedades.Update(propriedade);
            _contexto.SaveChanges();
        }

        public async Task<Propriedade> GetByIncricao(string inscricaoEstadual)
        {
            return await _contexto.Propriedades.Include(propriedade => propriedade.Endereco)
                .ThenInclude(endereco => endereco.Municipio)
                .Include(propriedade => propriedade.Produtor)
                .FirstOrDefaultAsync(propriedade => propriedade.InscricaoEstadual == inscricaoEstadual);
        }

        public IEnumerable<Propriedade> GetByProdutor(int idProdutor)
        {
            return _contexto.Propriedades.Include(propriedade => propriedade.Endereco)
                .ThenInclude(endereco => endereco.Municipio)
                .Include(propriedade => propriedade.Produtor)
                .Where(propriedade => propriedade.IdProdutor == idProdutor);
        }

        public Propriedade Incluir(Propriedade propriedade)
        {
            propriedade.Endereco.IdEndereco = null;
            _contexto.Propriedades.Add(propriedade);
            _contexto.SaveChanges();

            return propriedade;
        }

        public Propriedade GetById(int id)
        {
            return _contexto.Propriedades.AsNoTracking().FirstOrDefault(x => x.IdPropriedade == id);
        }
    }
}
