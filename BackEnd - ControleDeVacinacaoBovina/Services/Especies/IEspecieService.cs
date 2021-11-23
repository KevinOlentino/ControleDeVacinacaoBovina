using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Especies
{
    public interface IEspecieService
    {
        Task<Especie> GetById(int id);
        Task<ObjectResult> GetAll();
    }
}
