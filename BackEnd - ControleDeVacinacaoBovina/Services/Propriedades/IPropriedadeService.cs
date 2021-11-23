using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Propriedades
{
    public interface IPropriedadeService
    {
        Task<ObjectResult> Incluir(PropriedadeDto propriedadeDto);
        Task<ObjectResult> Editar(int id, PropriedadeDto propriedadeDto);
        Task<ObjectResult> GetByInscricao(string InscricaoEstadual);
        Task<ObjectResult> GetByProdutor(int idProdutor);
    }
}
