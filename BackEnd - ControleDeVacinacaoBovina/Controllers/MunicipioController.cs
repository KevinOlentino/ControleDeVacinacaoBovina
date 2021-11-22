using ControleDeVacinacaoBovina.Services.Municipios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult GetMunicipios()
        {
            return Ok(municipioService.GetAll());
        }
    }
}
