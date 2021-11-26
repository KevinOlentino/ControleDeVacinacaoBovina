﻿using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public Vacina GetById(int id)
        {
            return _contexto.Vacinas.FirstOrDefault(x => x.IdVacina == id);
        }
    }
}
