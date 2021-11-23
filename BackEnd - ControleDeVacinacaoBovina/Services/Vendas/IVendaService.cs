using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vendas
{
    public interface IVendaService
    {
        Task<ObjectResult> Incluir(VendaDto vendaDto);
        Task<ObjectResult> Cancelar(int id);
        Task<ObjectResult> GetByDestino(int idPropriedade);
        Task<ObjectResult> GetByOrigem(int idPropriedade);
    }
}
