using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVacinaController : ControllerBase
    {
        private readonly IRegistroVacinaService registroVacinaService;

        public RegistroVacinaController(IRegistroVacinaService registroVacinaService)
        {
            this.registroVacinaService = registroVacinaService;
        }

        [HttpGet]
        public ActionResult<List<RegistroVacinacao>> GetByPropriedade(string IncricaoEstadual)
        {
            List<RegistroVacinacao> listRegistroVacinacaos;
            try
            {
                listRegistroVacinacaos = registroVacinaService.GetByPropriedade(IncricaoEstadual).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(registroVacinaService.GetByPropriedade(IncricaoEstadual));
        }

        [HttpPost]
        public ActionResult Incluir(RegistroVacinacaoDto registroVacina)
        {            
            try
            {
                registroVacinaService.Incluir(registroVacina.DtoToRegistroVacinacao(registroVacina));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            return Ok();
        }

        [HttpDelete]
        public ActionResult Cancelar(int id)
        {
            registroVacinaService.Cancelar(id);
            return Ok();
        }
    }
}
