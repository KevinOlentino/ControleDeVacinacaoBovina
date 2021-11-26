using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.FinalidadeDeVendas
{
    public interface IFinalidadeDeVendasService
    {
        Task<ObjectResult> GetAll();
        FinalidadeDeVenda GetById(int id);
    }
}
