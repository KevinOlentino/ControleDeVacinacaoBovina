using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public class PropriedadeRepository : BaseRepository, IPropriedadeRepository
    {
        public PropriedadeRepository(Contexto novoContexto) : base(novoContexto)
        {
        }
        public async Task Editar(Propriedade propriedade)
        {
            _contexto.Propriedades.Update(propriedade);
             await _contexto.SaveChangesAsync();
        }

        public async Task<Propriedade> GetByIncricao(string inscricaoEstadual)
        {
            return await _contexto.Propriedades.FirstOrDefaultAsync(propriedade => propriedade.IncricaoEstadual == inscricaoEstadual);
        }

        public async Task<Propriedade> GetByProdutor(Produtor produtor)
        {
            return await _contexto.Propriedades.FirstOrDefaultAsync(propriedade => propriedade.Produtor == produtor);
        }

        public async Task<Propriedade> Incluir(Propriedade propriedade)
        {
            await _contexto.Propriedades.AddAsync(propriedade);
            await _contexto.SaveChangesAsync();

            return propriedade;
        }
    }
}
