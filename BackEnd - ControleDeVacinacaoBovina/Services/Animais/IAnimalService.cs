using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Services.Animais
{
    interface IAnimalService
    {
        void Incluir(Animal animal);
        void Cancelar(int id);
        void Editar(Animal animal);
        IEnumerable<Animal> GetByProdutor(int idProdutor);
        IEnumerable<Animal> GetByPropriedade(int idProdutor);
    }
}
