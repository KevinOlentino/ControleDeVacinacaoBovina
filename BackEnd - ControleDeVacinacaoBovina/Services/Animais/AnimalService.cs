using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Animais
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Animal animal)
        {
            animalRepository.Editar(animal);
        }

        public IEnumerable<Animal> GetByProdutor(int idProdutor)
        {
            return animalRepository.GetByProdutor(idProdutor);
        }

        public IEnumerable<Animal> GetByPropriedade(int idProdutor)
        {
            return animalRepository.GetByPropriedade(idProdutor);
        }

        public void Incluir(Animal animal)
        {
            animalRepository.Incluir(animal);
        }
    }
}
