using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Vacinas
{
    public class VacinaRepository : BaseRepository, IVacinaRepository
    {
        public VacinaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Vacina vacina)
        {
            _contexto.Vacinas.Update(vacina);
            _contexto.SaveChanges();
        }

        public async Task<Vacina> GetById(int id)
        {
            return await _contexto.Vacinas.FirstOrDefaultAsync(x => x.IdVacina == id);
        }

        public void Incluir(Vacina vacina)
        {
            _contexto.Vacinas.Add(vacina);
            _contexto.SaveChanges();
        }
    }
}
