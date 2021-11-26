using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vacinas
{
    public interface IVacinaService
    {
        Vacina GetById(int id);
        Task<ObjectResult> GetAll();
    }
}
