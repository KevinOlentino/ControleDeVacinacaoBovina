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
            animalRepository.Cancelar(animalRepository.GetById(id));
        }

        public async Task Editar(Animal animal)
        {
            await animalRepository.Editar(animal);
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
            if(animal.QuantidadeVacinada > animal.QuantidadeTotal)
            {
                throw new Exception("A quantidade de animal vacinada não pode ser maior que o total de animais.");
            }

            animalRepository.Incluir(animal);
        }

        public Animal GetById(int id)
        {
            return animalRepository.GetById(id);
        }
    }
}
