using ControleDeVacinacaoBovina.Services.Especies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService especieService;

        public EspecieController(IEspecieService especieService)
        {
            this.especieService = especieService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEspecies()
        {
            return await especieService.GetAll();
        }
    }
}
