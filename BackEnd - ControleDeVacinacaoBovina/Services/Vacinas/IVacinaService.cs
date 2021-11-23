using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vacinas
{
    public interface IVacinaService
    {
        Task<Vacina> GetById(int id);
        Task<ObjectResult> GetAll();
    }
}
