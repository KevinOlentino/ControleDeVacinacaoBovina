using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Vacinas
{
    public interface IVacinaRepository
    {
        Task<Vacina> GetById(int id);
        Task<IEnumerable<Vacina>> GetAll();
    }
}
