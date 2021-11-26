using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using ControleDeVacinacaoBovina.Services.Rebanhos;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
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
        private readonly IRebanhoService rebanhoService;
        private readonly IRegistroVacinaRepository registroVacinaRepository;

        public AnimalService(IAnimalRepository animalRepository, IRebanhoService rebanhoService, IRegistroVacinaRepository registroVacinaRepository)
        {
            this.animalRepository = animalRepository;
            this.rebanhoService = rebanhoService;
            this.registroVacinaRepository = registroVacinaRepository;
        }

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<Animal>(EStatusCode.NO_CONTENT, null);
            Animal animal = animalRepository.GetById(id);        

            if(animal == null || animal.Ativo == false)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }

            IEnumerable<RegistroVacinacao> registroVacina = registroVacinaRepository.GetByPropriedade(animal.IdPropriedade);
            RegistroVacinacao registroVacinacao;

            if (registroVacina.Any())
            {
                registroVacinacao = registroVacina.Last();
                if (registroVacinacao.DataDeCadastro.CompareTo(animal.DataDeEntrada) > 0)
                {
                    response.AddError("error","Não pode cancelar este registro pois já foi vacinado!");
                    response.StatusCode = EStatusCode.BAD_REQUEST;

                    return response.ResultAsync();
                }
            }
            try
            {
                animalRepository.Cancelar(animal);
                rebanhoService.SubtrairRebanho(new Rebanho()
                {
                    IdPropriedade = animal.IdPropriedade,
                    IdEspecie = animal.IdEspecie,
                    QuantidadeTotal = animal.QuantidadeTotal,
                    QuantidadeVacinada = animal.QuantidadeVacinada
                });
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();
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
                response.AddError("QuantidadeVacinada","A quantidade de animal vacinada não pode ser maior que o total de animais.");
                response.StatusCode = EStatusCode.BAD_REQUEST;
            }
            try
            {
               if (!response.Errors.Any())
                {
                    AdicionarRebanhoAnimal(animal);
                }               
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();

        }

        public void AdicionarRebanhoAnimal(Animal animal)
        {
            animalRepository.Incluir(animal);

            rebanhoService.Incluir(new Rebanho()
            {
                IdPropriedade = animal.IdPropriedade,
                IdEspecie = animal.IdEspecie,
                QuantidadeTotal = animal.QuantidadeTotal,
                QuantidadeVacinada = animal.QuantidadeVacinada
            });
        }
    }
}
