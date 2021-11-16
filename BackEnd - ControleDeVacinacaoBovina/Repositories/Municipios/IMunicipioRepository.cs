using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Municipios
{
    public interface IMunicipioRepository
    {
        IEnumerable<Municipio> GetAll();
        Municipio GetId(int Id);
    }
}
