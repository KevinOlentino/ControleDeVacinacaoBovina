using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Especies
{
    public class EspecieRepository : BaseRepository,IEspecieRepository
    {
        public EspecieRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public async Task<Especie> GetById(int id)
        {
            return await _contexto.Especies.FindAsync(id);
        }
    }
}
