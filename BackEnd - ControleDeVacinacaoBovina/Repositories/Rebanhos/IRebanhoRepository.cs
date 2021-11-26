using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;

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
