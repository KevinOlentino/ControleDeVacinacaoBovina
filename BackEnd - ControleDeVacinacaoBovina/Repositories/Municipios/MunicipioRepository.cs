using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeVacinacaoBovina.Repositories.Municipios
{
    public class MunicipioRepository : BaseRepository, IMunicipioRepository
    {
        public MunicipioRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public IEnumerable<Municipio> GetAll()
        {
            return _contexto.Municipios.ToList();
        }

        public Municipio GetId(int id)
        {
            return _contexto.Municipios.Find(id);
        }
    }
}
