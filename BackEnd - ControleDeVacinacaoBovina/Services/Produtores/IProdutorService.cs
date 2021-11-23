using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Produtores
{
    public interface IProdutorService
    {
        Task<ObjectResult> Incluir(ProdutorDto produtorDto);
        Task<ObjectResult> Editar(int id, ProdutorDto produtorDto);
        Task<ObjectResult> GetByCPF(string CPF);
        Task<ObjectResult> GetAll();
    }
}
