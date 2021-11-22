using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Vendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService vendaService;

        public VendaController(IVendaService vendaService)
        {
            this.vendaService = vendaService;
        }

        [HttpGet("Destino/{idProdutor}")]
        public ActionResult<List<Venda>> GetByDestino(int idProdutor)
        {
            List<Venda> listVenda;
            try
            {
                listVenda = vendaService.GetByDestino(idProdutor).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if(listVenda.Count == 0)
            {
                return NotFound();
            }

            return Ok(listVenda);
        }

        [HttpGet("Origem/{idProdutor}")]
        public ActionResult<List<Venda>> GetByOrigem(int idProdutor)
        {
            List<Venda> listVenda;
            try
            {
                listVenda = vendaService.GetByOrigem(idProdutor).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (listVenda.Count == 0)
            {
                return NotFound();
            }

            return Ok(listVenda);
        }


        [HttpPost]
        public ActionResult Incluir(VendaDto venda)
        {
            try
            {
                vendaService.Incluir(venda.DtoToVenda(venda));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Cancelar(int id)
        {
            try
            {
                vendaService.Cancelar(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
