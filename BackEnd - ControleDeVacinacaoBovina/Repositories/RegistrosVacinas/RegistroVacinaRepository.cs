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
            registroVacinacao.SetAtivo(false);
            _contexto.Entry(registroVacinacao).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(int idPropriedade)
        {
            return _contexto.RegistroVacinacoes.Include(x => x.Animal).ThenInclude(x => x.Propriedade).Include(x => x.Animal.Especie)                                                
                                                  .Where(x => x.Animal.IdPropriedade == idPropriedade)
                                                    .Where(x => x.Ativo == true);
        }

        public async Task Incluir(RegistroVacinacao registroVacina)
        {
            await _contexto.RegistroVacinacoes.AddAsync(registroVacina);
            await _contexto.SaveChangesAsync();                        
                        
        }

        public IEnumerable<RegistroVacinacao> GetByAnimal(int id)
        {
            return _contexto.RegistroVacinacoes.AsNoTracking().Include(x => x.Animal)
                                                .ThenInclude(x => x.Especie).OrderBy(x => x.IdRegistroVacinacao)
                                                .Where(x => x.IdAnimal == id).Where(x => x.Ativo == true);                     
        }

        public RegistroVacinacao GetById(int id)
        {
            return _contexto.RegistroVacinacoes.Find(id);
        }
     
    }
}
