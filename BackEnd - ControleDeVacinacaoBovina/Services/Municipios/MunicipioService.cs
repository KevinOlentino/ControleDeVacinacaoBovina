using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Municipios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Municipios
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
        {
            this.municipioRepository = municipioRepository;
        }

        public Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<Municipio>>(EStatusCode.OK, null);
            try
            {
                response.Data = municipioRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return response.ResultAsync();
        }

        public Municipio GetId(int id)
        {
            return municipioRepository.GetId(id);
        }
    }
}
