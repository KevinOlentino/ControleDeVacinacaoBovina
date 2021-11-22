using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Animais
{
    public interface IAnimalService
    {
        void Incluir(Animal animal);
        void Cancelar(int id);
        Task Editar(Animal animal);
        IEnumerable<Animal> GetByProdutor(int idProdutor);
        IEnumerable<Animal> GetByPropriedade(int idPropriedade);
        Animal GetById(int id);
    }
}
