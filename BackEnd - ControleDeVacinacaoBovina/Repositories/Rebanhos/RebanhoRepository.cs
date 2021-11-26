using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repositories.Rebanhos
{
    public class RebanhoRepository : BaseRepository, IRebanhoRepository
    {
        public RebanhoRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Rebanho rebanho)
        {
            _contexto.Rebanhos.Update(rebanho);
            _contexto.SaveChanges();
        }

        public IEnumerable<Rebanho> GetByProdutor(int idProdutor)
        {
            return _contexto.Rebanhos.Include(animal => animal.Especie)
                .Include(rebanho => rebanho.Propriedade)
                .ThenInclude(propriedade => propriedade.Endereco)
                .ThenInclude(endereco => endereco.Municipio)
                .Where(animal => animal.Propriedade.IdProdutor == idProdutor);
        }

        public IEnumerable<Rebanho> GetByPropriedade(int idPropriedade)
        {
            return _contexto.Rebanhos.Include(animal => animal.Especie)
                .Include(rebanho => rebanho.Propriedade)
                .ThenInclude(propriedade => propriedade.Endereco)
                .ThenInclude(endereco => endereco.Municipio)
                .Where(rebanho => rebanho.IdPropriedade == idPropriedade);
        }

        public void Incluir(Rebanho rebanho)
        {
            _contexto.Rebanhos.Add(rebanho);
            _contexto.SaveChanges();
        }

        public Rebanho GetById(int id)
        {
            return _contexto.Rebanhos.AsNoTracking().FirstOrDefault(x => x.IdRebanho == id);
        }
    }
}
