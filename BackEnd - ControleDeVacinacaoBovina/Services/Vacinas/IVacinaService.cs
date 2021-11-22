using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vacinas
{
    public interface IVacinaService
    {
        Task<Vacina> GetById(int id);
        Task<IEnumerable<Vacina>> GetAll();
        void Incluir(Vacina vacina);
        void Editar(Vacina vacina);
    }
}
