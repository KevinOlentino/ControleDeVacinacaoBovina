using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Vendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("Destino/{idPropriedade}")]
        public async Task<ActionResult> GetByDestino(int idPropriedade)
        {
            return await vendaService.GetByDestino(idPropriedade);
        }

        [HttpGet("Origem/{idPropriedade}")]
        public async Task<ActionResult> GetByOrigem(int idPropriedade)
        {
            return await vendaService.GetByOrigem(idPropriedade);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(VendaDto venda)
        {
            return await vendaService.Incluir(venda);
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> Cancelar(int id)
        {
            return await vendaService.Cancelar(id);
        }
    }
}
