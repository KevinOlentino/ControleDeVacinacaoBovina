using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.Animais;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<List<Animal>> GetByProdutor(int idProdutor)
        {
            List<Animal> ListAnimal;

            try
            {
                ListAnimal = animalService.GetByProdutor(idProdutor).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            

            if (ListAnimal.Count == 0){  return NotFound(); }

            return Ok(ListAnimal);
        }

        [HttpGet("Propriedade/{idPropriedade}")]
        public ActionResult<List<Animal>> GetByPropriedade(int idPropriedade)
        {
            List<Animal> ListAnimal;

            try
            {
                ListAnimal = animalService.GetByPropriedade(idPropriedade).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if(ListAnimal.Count == 0){  return NotFound(); }

            return Ok(ListAnimal);            
        }

        [HttpPost]
        public ActionResult Incluir(AnimalDto animal)
        {
            try
            {
               animalService.Incluir(animal.DtoToAnimal(animal));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            } 
            
            return Ok("Animal foi adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public ActionResult Editar(int id, AnimalDto animal)
        {
            try
            {
                animal.IdAnimal = id;
                animalService.Editar(animal.DtoToAnimal(animal));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }        
            
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Cancelar(int id)
        {
            try
            {
                animalService.Cancelar(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }                     

            return NoContent();
        }

    }
}
