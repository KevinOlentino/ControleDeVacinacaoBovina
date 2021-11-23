using ControleDeVacinacaoBovina.Services.FinalidadeDeVendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetFinalidadeDeVenda()
        {
            return await finalidadeDeVendasService.GetAll();
        }
    }
}
