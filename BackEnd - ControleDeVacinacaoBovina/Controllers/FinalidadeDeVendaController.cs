using ControleDeVacinacaoBovina.Services.FinalidadeDeVendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalidadeDeVendaController : ControllerBase
    {
        private readonly IFinalidadeDeVendasService finalidadeDeVendasService;

        public FinalidadeDeVendaController(IFinalidadeDeVendasService finalidadeDeVendasService)
        {
            this.finalidadeDeVendasService = finalidadeDeVendasService;
        }

        [HttpGet]
        public ActionResult GetFinalidadeDeVenda()
        {
            return Ok(finalidadeDeVendasService.GetAll());
        }
    }
}
