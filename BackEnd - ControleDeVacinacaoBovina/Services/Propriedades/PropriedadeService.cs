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

        public Propriedade Incluir(Propriedade propriedade)
        {              
            return _propriedadeRepository.Incluir(propriedade);
        }

        public void Editar(Propriedade propriedade)
        {            
            _propriedadeRepository.Editar(propriedade);                       
        }

        public async Task<Propriedade> GetByInscricao(string InscricaoEstadual)
        {
            return await _propriedadeRepository.GetByIncricao(InscricaoEstadual);         
        }

        public IEnumerable<Propriedade> GetByProdutor(int idProdutor)
        {
            return _propriedadeRepository.GetByProdutor(idProdutor);
        }

        public Propriedade GetById(int id)
        {
            return _propriedadeRepository.GetById(id);
        }
                

    }
}
