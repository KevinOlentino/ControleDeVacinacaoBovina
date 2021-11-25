using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Rebanhos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Rebanhos
{
    public class RebanhoService : IRebanhoService
    {
        private readonly IRebanhoRepository rebanhoRepository;

        public RebanhoService(IRebanhoRepository rebanhoRepository)
        {
            this.rebanhoRepository = rebanhoRepository;
        }

        public void Editar(Rebanho rebanho)
        {
            rebanhoRepository.Editar(rebanho);
        }

        public Task<ObjectResult> GetByProdutor(int idProdutor)
        {
            var response = new ResponseDto<IEnumerable<Rebanho>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Rebanho> listRebanho = rebanhoRepository.GetByProdutor(idProdutor);

                if (!listRebanho.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                response.Data = listRebanho;
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();
        }

        public Task<ObjectResult> GetByPropriedade(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<Rebanho>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Rebanho> listRebanho = rebanhoRepository.GetByPropriedade(idPropriedade);

                if (!listRebanho.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                response.Data = listRebanho;
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();
        }

        public void Incluir(Rebanho rebanho)
        {
                Rebanho rebanhoOld = rebanhoRepository.GetByPropriedade(rebanho.IdPropriedade)
                                                      .FirstOrDefault(x => x.IdEspecie == rebanho.IdEspecie);

                if(rebanhoOld == null)
                {
                    rebanhoRepository.Incluir(new Rebanho()
                    {
                        QuantidadeTotal = rebanho.QuantidadeTotal,
                        QuantidadeVacinada = rebanho.QuantidadeVacinada,
                        IdEspecie = rebanho.IdEspecie,
                        IdPropriedade = rebanho.IdPropriedade
                    });
                }                
                else
                {
                    rebanhoOld.QuantidadeTotal += rebanho.QuantidadeTotal;
                    rebanhoOld.QuantidadeVacinada += rebanho.QuantidadeVacinada;
                    Editar(rebanhoOld);
                }
        }                

        public void SubtrairRebanho(Rebanho rebanho)
        {
            Rebanho rebanhoOld = rebanhoRepository.GetByPropriedade(rebanho.IdPropriedade).FirstOrDefault( x => x.IdEspecie == rebanho.IdEspecie);

            rebanhoOld.QuantidadeTotal -= rebanho.QuantidadeTotal;
            rebanhoOld.QuantidadeVacinada -= rebanho.QuantidadeVacinada;

            Editar(rebanhoOld);
        }
    }
}
