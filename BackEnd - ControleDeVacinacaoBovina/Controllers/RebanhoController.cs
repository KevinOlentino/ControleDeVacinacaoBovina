using ControleDeVacinacaoBovina.Services.Rebanhos;
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
    public class RebanhoController : ControllerBase
    {
        private readonly IRebanhoService rebanhoService;

        public RebanhoController(IRebanhoService rebanhoService)
        {
            this.rebanhoService = rebanhoService;
        }

        [HttpGet("Produtor/{idProdutor}")]
        public async Task<ActionResult> GetByProdutor(int idProdutor)
        {
            return await rebanhoService.GetByProdutor(idProdutor);
        }

        [HttpGet("Propriedade/{idPropriedade}")]
        public async Task<ActionResult> GetByPropriedade(int idPropriedade)
        {
            return await rebanhoService.GetByPropriedade(idPropriedade);
        }
    }
}
