using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Repositories.Animais
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        public AnimalRepository(Contexto novoContexto) : base(novoContexto){}

        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Animal animal)
        {
            _contexto.Animals.Update(animal);
        }

        public IEnumerable<Animal> GetByProdutor(int idProdutor)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)                                            
                                                .Where(animal => animal.Propriedade.GetProdutor() == idProdutor);
        }

        public IEnumerable<Animal> GetByPropriedade(int idPropriedade)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)
                                                .Where(animal => animal.GetPropriedade() == idPropriedade);
        }

        public void Incluir(Animal animal)
        {
            _contexto.Animals.Add(animal);
        }
    }
}
