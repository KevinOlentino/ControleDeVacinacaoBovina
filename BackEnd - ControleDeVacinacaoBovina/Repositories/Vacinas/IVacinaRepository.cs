using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Vacinas
{
    interface IVacinaRepository
    {
        Task<Vacina> GetById(int id);
        void Incluir(Vacina vacina);
        Task<Vacina> Editar(Vacina vacina);
    }
}
