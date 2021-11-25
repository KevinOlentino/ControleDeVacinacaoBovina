using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.TipoDeEntradas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.TipoDeEntradas
{
    public class TipoDeEntradaService : ITipoDeEntradaService
    {
        private readonly ITipoDeEntradaRepository tipoDeEntradaRepository;

        public TipoDeEntradaService(ITipoDeEntradaRepository tipoDeEntradaRepository)
        {
            this.tipoDeEntradaRepository = tipoDeEntradaRepository;
        }

        public async Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<TipoDeEntrada>>(EStatusCode.OK, null);
            try
            {
                response.Data = tipoDeEntradaRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return await response.ResultAsync();
        }

        public TipoDeEntrada GetById(int id)
        {
            return tipoDeEntradaRepository.GetId(id);
        }
    }
}
