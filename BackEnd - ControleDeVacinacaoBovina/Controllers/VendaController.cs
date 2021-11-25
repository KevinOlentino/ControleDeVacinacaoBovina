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

        [HttpGet("Destino/{idProdutor}")]
        public async Task<ActionResult> GetByDestino(int idProdutor)
        {
            return await vendaService.GetByDestino(idProdutor);
        }

        [HttpGet("Origem/{idProdutor}")]
        public async Task<ActionResult> GetByOrigem(int idProdutor)
        {
            return await vendaService.GetByOrigem(idProdutor);
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
