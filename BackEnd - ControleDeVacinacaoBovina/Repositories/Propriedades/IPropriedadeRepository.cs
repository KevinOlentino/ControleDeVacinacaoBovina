using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public interface IPropriedadeRepository
    {
        Propriedade Incluir(Propriedade propriedade);
        void Editar(Propriedade propriedade);
        Task<Propriedade> GetByProdutor(Produtor produtor);
        Task<Propriedade> GetByIncricao(string inscricaoEstadual);
    }
}
