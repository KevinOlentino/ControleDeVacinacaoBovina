using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Propriedades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Propriedades
{
    public class PropriedadeService : IPropriedadeService
    {
        private readonly IPropriedadeRepository propriedadeRepository;
        public PropriedadeService(IPropriedadeRepository propriedadeRepository)
        {
            this.propriedadeRepository = propriedadeRepository;
        }

        public Task<ObjectResult> Incluir(PropriedadeDto propriedadeDto)
        {
            propriedadeDto.Endereco.IdEndereco = null;
            propriedadeDto.SetInscricaoEstadual();
            Propriedade propriedade = propriedadeDto.DtoToPropriedade(propriedadeDto);           
            var response = new ResponseDto<Propriedade>(EStatusCode.OK, null);
            try
            {
                propriedadeRepository.Incluir(propriedade);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }
            return response.ResultAsync();
            
        }

        public async Task<ObjectResult> Editar(int id, PropriedadeDto propriedadeDto)
        {            
            Propriedade propriedadeAtualizada = propriedadeDto.DtoToPropriedade(propriedadeDto);
            Propriedade propriedadeOld = propriedadeRepository.GetById(id);
            propriedadeAtualizada.Endereco.IdEndereco = propriedadeOld.IdEndereco;
            propriedadeAtualizada.IdEndereco = propriedadeOld.IdEndereco;
            propriedadeAtualizada.InscricaoEstadual = propriedadeOld.InscricaoEstadual;
            var response = new ResponseDto<Produtor>(EStatusCode.OK, null);

            try
            {
                propriedadeRepository.Editar(propriedadeAtualizada);
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return await response.ResultAsync();
                                 
        }

        public async Task<ObjectResult> GetByInscricao(string InscricaoEstadual)
        {
            var response = new ResponseDto<Propriedade>(EStatusCode.OK, null);
            try
            {
                Propriedade propriedade = await propriedadeRepository.GetByIncricao(InscricaoEstadual);
                response.Data = propriedade;

                if (propriedade == null)
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

        public async Task<ObjectResult> GetByProdutor(int idProdutor)
        {
            var response = new ResponseDto<IEnumerable<Propriedade>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Propriedade> listPropriedades = propriedadeRepository.GetByProdutor(idProdutor);

                if (!listPropriedades.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }

                response.Data = propriedadeRepository.GetByProdutor(idProdutor);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return await response.ResultAsync();
        }                    
    }
}
