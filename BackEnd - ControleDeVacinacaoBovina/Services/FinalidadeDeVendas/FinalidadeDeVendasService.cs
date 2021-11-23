using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.FinalidadeDeVendas
{
    public class FinalidadeDeVendasService : IFinalidadeDeVendasService
    {
        private readonly IFinalidadeDeVendaRepository finalidadeDeVendasRepository;

        public FinalidadeDeVendasService(IFinalidadeDeVendaRepository finalidadeDeVendasRepository)
        {
            this.finalidadeDeVendasRepository = finalidadeDeVendasRepository;
        }

        public Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<FinalidadeDeVenda>>(EStatusCode.OK, null);
            try
            {
                response.Data = finalidadeDeVendasRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return response.ResultAsync();
        }

        public FinalidadeDeVenda GetById(int id)
        {
            return finalidadeDeVendasRepository.GetById(id);
        }
    }
}
