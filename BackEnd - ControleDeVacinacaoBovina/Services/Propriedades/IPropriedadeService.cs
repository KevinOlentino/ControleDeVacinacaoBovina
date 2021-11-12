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
        Task<IActionResult> AddAsync(Propriedade propriedade);
        Task<Propriedade> Editar(Propriedade propriedade);
        Task<Propriedade> GetByInscricao(string InscricaoEstadual);
        Task<Propriedade> GetByProdutor(Produtor produtor);
    }
}
