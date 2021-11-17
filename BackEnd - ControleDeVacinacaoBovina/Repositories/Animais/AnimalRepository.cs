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

        public void Cancelar(Animal animal)
        {
            _contexto.Entry(animal).State = EntityState.Modified;
        }

        public void Editar(Animal animal)
        {
            _contexto.Animals.Update(animal);
            _contexto.SaveChanges();
        }

        public IEnumerable<Animal> GetByProdutor(int idProdutor)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)                                            
                                                .Where(animal => animal.Propriedade.IdProdutor == idProdutor);
        }

        public IEnumerable<Animal> GetByPropriedade(int idPropriedade)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)
                                                .Where(animal => animal.IdPropriedade == idPropriedade);
        }

        public void Incluir(Animal animal)
        {
            _contexto.Animals.Add(animal);
            _contexto.SaveChanges();
        }

        public Animal GetById(int id)
        {
            return _contexto.Animals.AsNoTracking().FirstOrDefault(x => x.IdAnimal == id);
        }
    }
}
