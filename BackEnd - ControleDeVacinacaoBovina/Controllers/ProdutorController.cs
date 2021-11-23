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
        public async Task<ActionResult> GetByCPF(string cpf)
        {
            return await produtorService.GetByCPF(cpf);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return await produtorService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(ProdutorDto produtor)
        {
            return await produtorService.Incluir(produtor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, ProdutorDto produtor)
        {
            return await produtorService.Editar(id,produtor);
        }

    }
}
