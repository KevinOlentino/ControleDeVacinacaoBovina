using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repository.Vendas;
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
        private readonly IVendaRepository vendaRepository;

        public VendaController(IVendaRepository vendaRepository)
        {
            this.vendaRepository = vendaRepository;
        }

        [HttpGet("/Destino/{idPropriedade}")]
        public ActionResult<List<Venda>> GetByDestino(int idPropriedade)
        {
            List<Venda> listVenda;
            try
            {
                listVenda = vendaRepository.GetByDestino(idPropriedade).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            if(listVenda.Count == 0)
            {
                return NotFound();
            }

            return Ok(listVenda);
        }

        [HttpGet("/Origem/{idPropriedade}")]
        public ActionResult<List<Venda>> GetByOrigem(int idPropriedade)
        {
            List<Venda> listVenda;
            try
            {
                listVenda = vendaRepository.GetByOrigem(idPropriedade).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
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
                vendaRepository.Incluir(venda.DtoToVenda(venda));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
           
            return Ok();
        }

        [HttpDelete]
        public ActionResult Cancelar(int id)
        {
            vendaRepository.Cancelar(id);
            return Ok();
        }
    }
}
