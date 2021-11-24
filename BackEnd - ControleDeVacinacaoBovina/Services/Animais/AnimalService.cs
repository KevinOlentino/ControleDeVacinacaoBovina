using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using Microsoft.AspNetCore.Mvc;
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

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<Animal>(EStatusCode.NO_CONTENT, null);
            Animal animal = animalRepository.GetById(id);

            if(animal == null)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }            
            try
            {
                animalRepository.Cancelar(animal);
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();
        }

        public void Editar(Animal animal)
        {
            animalRepository.Editar(animal);
        }

        public Task<ObjectResult> GetByProdutor(int idProdutor)
        {
            var response = new ResponseDto<IEnumerable<Animal>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Animal> listAnimal = animalRepository.GetByProdutor(idProdutor);          

                if (!listAnimal.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                response.Data = listAnimal;
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();
        }

        public Task<ObjectResult> GetByPropriedade(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<Animal>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Animal> listAnimal = animalRepository.GetByPropriedade(idPropriedade);

                if (!listAnimal.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                response.Data = listAnimal;
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();  
        }

        public Task<ObjectResult> Incluir(AnimalDto animalDto)
        {
            var response = new ResponseDto<IEnumerable<Animal>>(EStatusCode.OK, null);
            Animal animal = animalDto.DtoToAnimal(animalDto);

            if (animal.QuantidadeVacinada > animal.QuantidadeTotal)
            {
                response.Errors.Add("QuantidadeAnimal","A quantidade de animal vacinada não pode ser maior que o total de animais.");
                response.StatusCode = EStatusCode.BAD_REQUEST;
            }

            try
            {
               if (!response.Errors.Any())
               animalRepository.Incluir(animal);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();

        }
    }
}
