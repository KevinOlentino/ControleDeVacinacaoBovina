using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.Propriedades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        private readonly IPropriedadeService propriedadeService;

        public PropriedadeController(IPropriedadeService propriedadeService)
        {
            this.propriedadeService = propriedadeService;
        }

        [HttpGet("{inscricao}")]
        public async Task<ActionResult> GetByInscricao(string inscricao)
        {
            return await propriedadeService.GetByInscricao(inscricao);
        }

        [HttpGet("produtor/{idProdutor}")]
        public async Task<ActionResult> GetByProdutor(int idProdutor)
        {
            return await propriedadeService.GetByProdutor(idProdutor);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(PropriedadeDto propriedade)
        {
            return await propriedadeService.Incluir(propriedade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, PropriedadeDto propriedade)
        {
            return await propriedadeService.Editar(id, propriedade);
        }
    }
}
