using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVacinaController : ControllerBase
    {
        private readonly IRegistroVacinaService registroVacinaService;

        public RegistroVacinaController(IRegistroVacinaService registroVacinaService)
        {
            this.registroVacinaService = registroVacinaService;
        }

        [HttpGet("{idPropriedade}")]
        public async Task<ActionResult> GetByPropriedade(int idPropriedade)
        {
            return await registroVacinaService.GetByPropriedade(idPropriedade);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(RegistroVacinacaoDto registroVacina)
        {
            return await registroVacinaService.Incluir(registroVacina);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Cancelar(int id)
        {
            return await registroVacinaService.Cancelar(id);
        }
    }
}
