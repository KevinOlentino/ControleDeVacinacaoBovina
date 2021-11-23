using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.RegistrosVacinas
{
    public class RegistroVacinaService : IRegistroVacinaService
    {
        private readonly IRegistroVacinaRepository registroVacinaRepository;
        private readonly IAnimalRepository animalRepository;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository, IAnimalRepository animalRepository)
        {
            this.registroVacinaRepository = registroVacinaRepository;
            this.animalRepository = animalRepository;
        }

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<RegistroVacinacao>(EStatusCode.NO_CONTENT, null);
            RegistroVacinacao registroVacinacao = registroVacinaRepository.GetById(id);

            if (registroVacinacao == null)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }
            try
            {
                registroVacinaRepository.Cancelar(registroVacinacao);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();            
        }

        public async Task<ObjectResult> GetByPropriedade(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<RegistroVacinacao>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<RegistroVacinacao> registroVacinacao = registroVacinaRepository.GetByPropriedade(idPropriedade);
                response.Data = registroVacinacao;

                if (!registroVacinacao.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }

            return await response.ResultAsync();            
        }

        public async Task<ObjectResult> Incluir(RegistroVacinacaoDto registroVacinacaoDto)
        {
            var response = new ResponseDto<RegistroVacinacao>(EStatusCode.NO_CONTENT, null);

            RegistroVacinacao registroVacinacaOld = ObterUltimaVacinaPorEspecie(registroVacinacaoDto.IdAnimal);
            Animal animaisAVacinar = animalRepository.GetById(registroVacinacaoDto.IdAnimal);
            RegistroVacinacao registroVacinacaoNovo = registroVacinacaoDto.DtoToRegistroVacinacao(registroVacinacaoDto);                     

            if (ValidarRegistroDeVacinas(registroVacinacaoDto.Quantidade, animaisAVacinar, response))
            {
                animaisAVacinar.QuantidadeVacinada += registroVacinacaoDto.Quantidade;
                await registroVacinaRepository.Incluir(registroVacinacaoNovo);
                await animalRepository.Editar(animaisAVacinar);
            }

            return await response.ResultAsync();
        }

        private static bool ValidarRegistroDeVacinas(int Quantidade, Animal animaisAVacinar, ResponseDto<RegistroVacinacao> response)
        {
            if (animaisAVacinar.QuantidadeVacinada == animaisAVacinar.QuantidadeTotal)
            {
                response.Errors.Add("error","Todos os animais já foram vacinados esse ano");
            }
            if (Quantidade > animaisAVacinar.QuantidadeTotal - animaisAVacinar.QuantidadeVacinada)
            {
                response.Errors.Add("error","Valor não pode ser maior que a quantidade total de animais");                
            }
            if (response.Errors.Any())
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                return false;
            }
            return true;
        }

        public RegistroVacinacao ObterUltimaVacinaPorEspecie(int idAnimal)
        {
            IEnumerable<RegistroVacinacao> registro = registroVacinaRepository.GetByAnimal(idAnimal);
            if (registro.Any())
                return registro.Last();
  
            return null;
        }

    }
}
