using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.Rebanhos;
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
        private readonly IRebanhoRepository rebanhoRepository;        

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository, IRebanhoRepository rebanhoRepository)
        {
            this.registroVacinaRepository = registroVacinaRepository;
            this.rebanhoRepository = rebanhoRepository;            
        }

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<RegistroVacinacao>(EStatusCode.NO_CONTENT, null);
            RegistroVacinacao registroVacinacao = registroVacinaRepository.GetById(id);

            if (registroVacinacao == null || registroVacinacao.Ativo == false)
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
            
            Rebanho rebanhoAVacinar = rebanhoRepository.GetById(registroVacinacaoDto.IdRebanho);
            RegistroVacinacao registroVacinacaoNovo = registroVacinacaoDto.DtoToRegistroVacinacao(registroVacinacaoDto);                     

            if (ValidarRegistroDeVacinas(registroVacinacaoDto.Quantidade, rebanhoAVacinar, response))
            {
                rebanhoAVacinar.QuantidadeVacinada += registroVacinacaoDto.Quantidade;
                await registroVacinaRepository.Incluir(registroVacinacaoNovo);
                rebanhoRepository.Editar(rebanhoAVacinar);
            }

            return await response.ResultAsync();
        }

        private static bool ValidarRegistroDeVacinas(int Quantidade, Rebanho rebanhoAVacinar, ResponseDto<RegistroVacinacao> response)
        {
            bool todosVacinados = rebanhoAVacinar.QuantidadeVacinada == rebanhoAVacinar.QuantidadeTotal;
            if (todosVacinados)
            {
                response.AddError("quantidadeVacinada","Todos os animais já foram vacinados esse ano");
            }
            if (Quantidade > rebanhoAVacinar.QuantidadeTotal - rebanhoAVacinar.QuantidadeVacinada && !todosVacinados)
            {
                response.AddError("error",
                    "Valor não pode ser maior que a quantidade total de animais Restante a Vacinar: " +
                    $"{rebanhoAVacinar.QuantidadeTotal - rebanhoAVacinar.QuantidadeVacinada}");                
            }
            if (response.Errors.Any())
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                return false;
            }
            return true;
        }

        public RegistroVacinacao ObterUltimaVacinaPorEspecie(int idRebanho)
        {
            IEnumerable<RegistroVacinacao> registro = registroVacinaRepository.GetByRebanho(idRebanho);
            if (registro.Any())
                return registro.Last();
  
            return null;
        }

    }
}
