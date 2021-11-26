using ControleDeVacinacaoBovina.Services.TipoDeEntradas;
using Microsoft.AspNetCore.Mvc;
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
