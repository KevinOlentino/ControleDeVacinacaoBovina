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
            animal.SetAtivo(false);
            _contexto.Entry(animal).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public async Task Editar(Animal animal)
        {
            _contexto.Animals.Update(animal);
            await _contexto.SaveChangesAsync();
        }

        public IEnumerable<Animal> GetByProdutor(int idProdutor)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)
                                                .Include(animal => animal.Especie)
                                                    .Where(animal => animal.Propriedade.IdProdutor == idProdutor)
                                                        .Where(animal => animal.Ativo == true);
        }

        public IEnumerable<Animal> GetByPropriedade(int idPropriedade)
        {
            return _contexto.Animals.Include(animal => animal.Propriedade)
                                        .ThenInclude(propriedade => propriedade.Endereco)
                                            .ThenInclude(endereco => endereco.Municipio)
                                                .Include(animal => animal.Especie)
                                                    .Where(animal => animal.IdPropriedade == idPropriedade)
                                                        .Where(animal => animal.Ativo == true); 
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
