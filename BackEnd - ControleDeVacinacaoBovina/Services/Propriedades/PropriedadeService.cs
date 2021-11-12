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
        private PropriedadeService(IPropriedadeRepository propriedadeRepository)
        {
            _propriedadeRepository = propriedadeRepository;
        }

        public Task<IActionResult> AddAsync(Propriedade propriedade)
        {
            throw new NotImplementedException();
        }

        public async Task<Propriedade> Editar(Propriedade propriedade)
        {            
          return await _propriedadeRepository.Editar(propriedade);                       
        }

        public Task<Propriedade> GetByInscricao(string InscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public Task<Propriedade> GetByProdutor(Produtor produtor)
        {
            throw new NotImplementedException();
        }

        #region GerarIncricao
        public string GerarInscricaoEstadualPR()
		{

			int soma = 0;
			int resto = 0;
			int[] multiplicadores = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
			var random = new Random();
			string semente = random.Next(1, 99999999).ToString().PadLeft(8, '0');

			for (var i = 1; i < multiplicadores.Count(); i++)
			{
				soma += int.Parse(semente[i - 1].ToString()) * multiplicadores[i];
			}

			resto = soma % 11;
			if (resto < 2)
			{
				resto = 0;
			}
			else
			{
				resto = 11 - resto;
			}

			semente += resto;
			soma = 0;

			for (var i = 0; i < multiplicadores.Count(); i++)
			{
				soma += int.Parse(semente[i].ToString()) * multiplicadores[i];
			}

			resto = soma % 11;
			if (resto < 2)
			{
				resto = 0;
			}
			else
			{
				resto = 11 - resto;
			}

			semente += resto;

			return semente;

		}
        #endregion
    }
}
