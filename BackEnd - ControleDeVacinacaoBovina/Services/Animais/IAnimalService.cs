using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Services.Animais
{
    public interface IAnimalService
    {
        void Incluir(Animal animal);
        void Cancelar(int id);
        void Editar(Animal animal);
        IEnumerable<Animal> GetByProdutor(int idProdutor);
        IEnumerable<Animal> GetByPropriedade(int idPropriedade);
        Animal GetById(int id);
    }
}
