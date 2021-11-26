using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public interface IPropriedadeRepository
    {
        Propriedade Incluir(Propriedade propriedade);
        void Editar(Propriedade propriedade);
        IEnumerable<Propriedade> GetByProdutor(int idProdutor);
        Task<Propriedade> GetByIncricao(string inscricaoEstadual);
        Propriedade GetById(int id);
    }
}
