using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Especies
{
    public class EspecieRepository : BaseRepository, IEspecieRepository
    {
        public EspecieRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public async Task<IEnumerable<Especie>> GetAll()
        {
            return await _contexto.Especies.ToListAsync();
        }

        public async Task<Especie> GetById(int id)
        {
            return await _contexto.Especies.FindAsync(id);
        }
    }
}
