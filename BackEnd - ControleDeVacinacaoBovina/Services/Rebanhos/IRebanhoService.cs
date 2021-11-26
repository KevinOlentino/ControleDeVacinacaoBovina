using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Rebanhos
{
    public interface IRebanhoService
    {
        void Incluir(Rebanho rebanho);
        void Editar(Rebanho rebanho);
        void SubtrairRebanho(Rebanho rebanho);
        Task<ObjectResult> GetByProdutor(int idProdutor);
        Task<ObjectResult> GetByPropriedade(int idPropriedade);
    }
}
