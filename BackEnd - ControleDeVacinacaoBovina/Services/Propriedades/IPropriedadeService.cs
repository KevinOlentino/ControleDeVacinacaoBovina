using ControleDeVacinacaoBovina.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Propriedades
{
    public interface IPropriedadeService
    {
        Task<Propriedade> Incluir(Propriedade propriedade);
        void Editar(Propriedade propriedade);
        Task<Propriedade> GetByInscricao(string InscricaoEstadual);
        Task<Propriedade> GetByProdutor(Produtor produtor);
    }
}
