using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Especies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Especies
{
    public class EspecieService: IEspecieService
    {
        private readonly IEspecieRepository especieRepository;

        public EspecieService(IEspecieRepository especieRepository)
        {
            this.especieRepository = especieRepository;
        }

        public async Task<IEnumerable<Especie>> GetAll()
        {
            return await especieRepository.GetAll();
        }

        public Task<Especie> GetById(int id)
        {
            return especieRepository.GetById(id);
        }
    }
}
