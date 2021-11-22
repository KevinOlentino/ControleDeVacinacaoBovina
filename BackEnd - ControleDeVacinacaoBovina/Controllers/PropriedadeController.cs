    using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.Propriedades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        private readonly IPropriedadeService propriedadeService;

        public PropriedadeController(IPropriedadeService propriedadeService)
        {
            this.propriedadeService = propriedadeService;
        }

        [HttpGet("{inscricao}")]
        public async Task<ActionResult<Propriedade>> GetByInscricao(string inscricao)
        {
            return Ok(await propriedadeService.GetByInscricao(inscricao));
        }

        [HttpGet("produtor/{idProdutor}")]
        public ActionResult<Propriedade> GetByProdutor(int idProdutor)
        {
            List<Propriedade> propriedades;

            try
            {
                propriedades = propriedadeService.GetByProdutor(idProdutor).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok(propriedadeService.GetByProdutor(idProdutor));
        }
        
        [HttpPost]
        public ActionResult Incluir(PropriedadeDto propriedade)
        {
            try
            {
                propriedadeService.Incluir(propriedade);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Editar(int id,PropriedadeDto propriedade)
        {
            try
            {
                Propriedade PropriedadeOld = propriedadeService.GetById(id);
                propriedade.LockInscricaoEstadual(PropriedadeOld.InscricaoEstadual);
                propriedade.Endereco.IdEndereco = PropriedadeOld.GetEndereco();
                propriedadeService.Editar(propriedade.DtoToPropriedade(propriedade));

            }catch(Exception ex)
            {
                return NotFound(ex);
            }
            return NoContent();
        }
    }
}
