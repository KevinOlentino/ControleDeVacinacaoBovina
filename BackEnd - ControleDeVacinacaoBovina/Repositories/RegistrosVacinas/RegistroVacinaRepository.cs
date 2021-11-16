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

        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual)
        {
            return _contexto.RegistroVacinacoes.Include(x => x.Animal)
                                                .ThenInclude(x => x.Propriedade)
                                                  .Where(x => x.Animal.Propriedade.IncricaoEstadual == IncricaoEstadual);
        }

        public void Incluir(RegistroVacinacao registroVacina)
        {
            _contexto.RegistroVacinacoes.Add(registroVacina);
        }
    }
}
