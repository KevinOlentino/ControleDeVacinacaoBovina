using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public void Incluir(RegistroVacinacao registroVacina)
        {
            throw new NotImplementedException();
        }
    }
}
