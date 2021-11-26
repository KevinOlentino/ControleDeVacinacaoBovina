using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;

namespace ControleDeVacinacaoBovina.Repositories.Municipios
{
    public interface IMunicipioRepository
    {
        IEnumerable<Municipio> GetAll();
        Municipio GetId(int Id);
    }
}
