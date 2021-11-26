using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.Animais;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService animalService;
        public AnimalController(IAnimalService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet("Produtor/{idProdutor}")]
        public async Task<ActionResult> GetByProdutor(int idProdutor)
        {
            return await animalService.GetByProdutor(idProdutor);    
        }

        [HttpGet("Propriedade/{idPropriedade}")]
        public async Task<ActionResult> GetByPropriedade(int idPropriedade)
        {
            return await animalService.GetByPropriedade(idPropriedade);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(AnimalDto animal)
        {
            return await animalService.Incluir(animal);
        }     

        [HttpDelete("{id}")]
        public async Task<ActionResult> Cancelar(int id)
        {
            return await animalService.Cancelar(id);
        }

    }
}
