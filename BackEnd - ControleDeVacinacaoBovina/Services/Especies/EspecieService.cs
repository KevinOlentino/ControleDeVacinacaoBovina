using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Especies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Especies
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository especieRepository;

        public EspecieService(IEspecieRepository especieRepository)
        {
            this.especieRepository = especieRepository;
        }

        public async Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<Especie>>(EStatusCode.OK, null);
            try
            {
                response.Data = await especieRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return await response.ResultAsync();

        }

        public Task<Especie> GetById(int id)
        {
            return especieRepository.GetById(id);
        }
    }
}
