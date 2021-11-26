using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Municipios
{
    public interface IMunicipioService
    {
        Task<ObjectResult> GetAll();
        Municipio GetId(int Id);
    }
}
