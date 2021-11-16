using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public interface IPropriedadeRepository
    {
        Propriedade Incluir(Propriedade propriedade);
        void Editar(Propriedade propriedade);
        IEnumerable<Propriedade> GetByProdutor(int idProdutor);
        Task<Propriedade> GetByIncricao(string inscricaoEstadual);
    }
}
