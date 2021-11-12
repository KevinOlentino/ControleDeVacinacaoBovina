using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Animais
{
    public interface IAnimalRepository
    {
        void Incluir(Animal animal);
        void Cancelar();
        Task<Animal> GetByProdutor();
        Task<Animal> GetByPropriedade();
    }
}
