using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.TipoDeEntradas
{
    public interface ITipoDeEntradaService
    {
        TipoDeEntrada GetById(int id);
        Task<ObjectResult> GetAll();
    }
}
