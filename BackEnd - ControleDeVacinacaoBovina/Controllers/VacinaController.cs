using ControleDeVacinacaoBovina.Services.Vacinas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly IVacinaService vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            this.vacinaService = vacinaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetVacinas()
        {
            return Ok(await vacinaService.GetAll());
        }
    }
}
