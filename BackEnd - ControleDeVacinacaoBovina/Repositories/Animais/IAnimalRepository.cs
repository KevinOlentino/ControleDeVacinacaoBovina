using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Animais
{
    public interface IAnimalRepository
    {
        void Incluir(Animal animal);
        void Cancelar(Animal animal);
        void Editar(Animal animal);
        IEnumerable<Animal> GetByProdutor(int idProdutor);
        IEnumerable<Animal> GetByPropriedade(int idProdutor);
        Animal GetById(int id);
    }
}
