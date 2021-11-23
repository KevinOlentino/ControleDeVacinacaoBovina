using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Vacinas
{
    public class VacinaRepository : BaseRepository, IVacinaRepository
    {
        public VacinaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }
        public async Task<IEnumerable<Vacina>> GetAll()
        {
            return await _contexto.Vacinas.ToListAsync();
        }

        public async Task<Vacina> GetById(int id)
        {
            return await _contexto.Vacinas.FirstOrDefaultAsync(x => x.IdVacina == id);
        }
    }
}
