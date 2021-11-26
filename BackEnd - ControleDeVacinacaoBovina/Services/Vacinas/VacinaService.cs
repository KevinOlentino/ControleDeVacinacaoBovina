using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Vacinas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vacinas
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepository vacinaRepository;

        public VacinaService(IVacinaRepository vacinaRepository)
        {
            this.vacinaRepository = vacinaRepository;
        }
        public Vacina GetById(int id)
        {
            return vacinaRepository.GetById(id);
        }

        public async Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<Vacina>>(EStatusCode.OK, null);
            try
            {
                response.Data = await vacinaRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return await response.ResultAsync();
        }
    }
}
