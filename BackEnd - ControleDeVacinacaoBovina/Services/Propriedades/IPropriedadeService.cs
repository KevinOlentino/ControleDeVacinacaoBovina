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
        Propriedade Incluir(PropriedadeDto propriedade);
        void Editar(Propriedade propriedade);
        Task<Propriedade> GetByInscricao(string InscricaoEstadual);
        IEnumerable<Propriedade> GetByProdutor(int idProdutor);
        Propriedade GetById(int id);
    }
}
