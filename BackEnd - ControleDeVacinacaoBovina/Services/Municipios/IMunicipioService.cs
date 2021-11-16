using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Municipios
{
    interface IMunicipioService
    {
        IEnumerable<Municipio> GetAll();
        Municipio GetId(int Id);
    }
}
