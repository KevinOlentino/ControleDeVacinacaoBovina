using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Propriedades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Propriedades
{
    public class PropriedadeService : IPropriedadeService
    {
        private readonly IPropriedadeRepository _propriedadeRepository;
        public PropriedadeService(IPropriedadeRepository propriedadeRepository)
        {
            _propriedadeRepository = propriedadeRepository;
        }

        public async Task<Propriedade> Incluir(Propriedade propriedade)
        {
            return await _propriedadeRepository.Incluir(propriedade);
        }

        public async void Editar(Propriedade propriedade)
        {            
            await _propriedadeRepository.Editar(propriedade);                       
        }

        public async Task<Propriedade> GetByInscricao(string InscricaoEstadual)
        {
            return await _propriedadeRepository.GetByIncricao(InscricaoEstadual);         
        }

        public async Task<Propriedade> GetByProdutor(Produtor produtor)
        {
            return await _propriedadeRepository.GetByProdutor(produtor);
        }

    }
}
