using System.Collections.Generic;
using System.Threading.Tasks;
using ControleDeVacinacaoBovina.Models;

namespace ControleDeVacinacaoBovina.Repositories.Rebanhos
{
    public interface IRebanhoRepository
    {
        void Incluir(Rebanho animal);
        void Editar(Rebanho animal);
        IEnumerable<Rebanho> GetByProdutor(int idProdutor);
        IEnumerable<Rebanho> GetByPropriedade(int idPropriedade);
        Rebanho GetById(int id);
    }
}
