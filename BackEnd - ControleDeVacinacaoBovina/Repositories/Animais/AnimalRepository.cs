using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Animais
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        public AnimalRepository(Contexto novoContexto) : base(novoContexto){}

        public async void Cancelar()
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> GetByProdutor()
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> GetByPropriedade()
        {
            throw new NotImplementedException();
        }

        public async void Incluir(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
