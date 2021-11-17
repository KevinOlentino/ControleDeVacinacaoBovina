using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVacinacaoBovina.Repositories.RegistrosVacinas
{
    public class RegistroVacinaRepository : BaseRepository, IRegistroVacinaRepository
    {
        public RegistroVacinaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Cancelar(RegistroVacinacao registroVacinacao)
        {
            _contexto.Entry(registroVacinacao).State = EntityState.Modified;
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual)
        {
            return _contexto.RegistroVacinacoes.Include(x => x.Animal).ThenInclude(x => x.Propriedade).Include(x => x.Animal.Especie)                                                
                                                  .Where(x => x.Animal.Propriedade.IncricaoEstadual == IncricaoEstadual);
        }

        public void Incluir(RegistroVacinacao registroVacina)
        {
            _contexto.RegistroVacinacoes.Add(registroVacina);
            _contexto.SaveChanges();
        }

        public RegistroVacinacao GetByAnimal(int id)
        {
            return _contexto.RegistroVacinacoes.Include(x => x.Animal)
                                                .ThenInclude(x => x.Especie).OrderBy(x => x.IdRegistroVacinacao)
                                                        .Last(x => x.IdAnimal == id);
        }

        public RegistroVacinacao GetById(int id)
        {
            return _contexto.RegistroVacinacoes.Find(id);
        }
    }
}
