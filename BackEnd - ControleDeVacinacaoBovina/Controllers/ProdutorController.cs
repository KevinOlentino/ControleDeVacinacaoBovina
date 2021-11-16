using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Services.Produtores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutorController : ControllerBase
    {
        private readonly IProdutorService produtorService;

        public ProdutorController(IProdutorService produtorService)
        {
            this.produtorService = produtorService;
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Produtor>> GetByCPF(string cpf)
        {
            Produtor produtor;
            try
            {
                produtor = await produtorService.GetByCPF(cpf);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            return Ok(produtor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtor>>> GetAll()
        {
            return Ok(await produtorService.GetAll());
        }

        [HttpPost]
        public ActionResult Incluir([FromBody]ProdutorDto produtor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            produtor.Endereco.IdEndereco = null;

            try 
            {
                produtorService.Incluir(produtor.DtoToProdutor(produtor));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }            

            return Ok("Produtor adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public ActionResult Editar(int id, ProdutorDto produtor)
        {
            produtor.Id = id;

            if (!ModelState.IsValid)
            {               
                return BadRequest();
            }
            try
            {
                produtorService.Editar(produtor.DtoToProdutor(produtor));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }            

            return NoContent();
        }

    }
}
