using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
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
            throw new NotImplementedException();
        }

        public Task<Vacina> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vacina> Incluir(Vacina vacina)
        {
            throw new NotImplementedException();
        }
    }
}
