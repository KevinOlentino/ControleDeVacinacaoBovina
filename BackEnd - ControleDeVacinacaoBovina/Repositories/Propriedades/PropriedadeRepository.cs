using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public class PropriedadeRepository : BaseRepository, IPropriedadeRepository
    {
        public PropriedadeRepository(Contexto novoContexto) : base(novoContexto)
        {
        }
        public async Task<Propriedade> Editar(Propriedade propridade)
        {
            throw new NotImplementedException();
        }

        public async Task<Propriedade> GetByIncricao(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public async Task<Propriedade> GetByProdutor(Produtor produtor)
        {
            throw new NotImplementedException();
        }

        public async void Incluir(Propriedade propridade)
        {
            throw new NotImplementedException();
        }
    }
}
