using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Services.TipoDeEntradas;
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
    public class TipoDeEntradaController : ControllerBase
    {
        private readonly ITipoDeEntradaService tipoDeEntradaService;

        public TipoDeEntradaController(ITipoDeEntradaService tipoDeEntradaService)
        {
            this.tipoDeEntradaService = tipoDeEntradaService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return await tipoDeEntradaService.GetAll();
        }        
    }
}
