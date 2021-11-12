using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    interface IPropriedadeRepository
    {
        void Incluir(Propriedade propriedade);
        Task<Propriedade> Editar(Propriedade propriedade);
        Task<Propriedade> GetByProdutor(Produtor produtor);
        Task<Propriedade> GetByIncricao(string inscricaoEstadual);
    }
}
