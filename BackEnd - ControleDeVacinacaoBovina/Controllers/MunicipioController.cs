using ControleDeVacinacaoBovina.Services.Municipios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            this.municipioService = municipioService;
        }

        [HttpGet]
        public async Task<ActionResult> GetMunicipios()
        {
            return await municipioService.GetAll();
        }
    }
}
