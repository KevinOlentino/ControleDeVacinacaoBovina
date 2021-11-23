using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Municipios
{
    public interface IMunicipioService
    {
        Task<ObjectResult> GetAll();
        Municipio GetId(int Id);
    }
}
