using ControleDeVacinacaoBovina.Models;
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

        [HttpGet("incricao/{inscricao}")]
        public async Task<ActionResult<Propriedade>> GetByInscricao(string inscricao)
        {
            return Ok(await propriedadeService.GetByInscricao(inscricao));
        }

        [HttpGet("produtor/{produtor}")]
        public ActionResult<Propriedade> GetByProdutor(Produtor produtor)
        {
           return Ok(propriedadeService.GetByProdutor(produtor));
        }

        [HttpPost]
        public ActionResult<Propriedade> Incluir(Propriedade propriedade)
        {
           return Ok(propriedadeService.Incluir(propriedade));
        }

        [HttpPut]
        public ActionResult Editar(Propriedade propriedade)
        {
            propriedadeService.Editar(propriedade);
            return NoContent();
        }
    }
}
