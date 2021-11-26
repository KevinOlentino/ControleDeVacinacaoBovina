using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Animais
{
    public interface IAnimalService
    {
        Task<ObjectResult> Incluir(AnimalDto animalDto);
        Task<ObjectResult> Cancelar(int id);
        Task<ObjectResult> GetByProdutor(int idProdutor);
        Task<ObjectResult> GetByPropriedade(int idPropriedade);
        void AdicionarRebanhoAnimal(Animal animal);
    }
}
