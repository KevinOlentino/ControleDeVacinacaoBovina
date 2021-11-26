using ControleDeVacinacaoBovina.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.RegistrosVacinas
{
    public interface IRegistroVacinaService
    {
        Task<ObjectResult> Incluir(RegistroVacinacaoDto registroVacinaDto);
        Task<ObjectResult> Cancelar(int id);
        Task<ObjectResult> GetByPropriedade(int idPropriedade);
        //RegistroVacinacao ObterUltimaVacinaPorEspecie(int idAnimal);
    }
}
