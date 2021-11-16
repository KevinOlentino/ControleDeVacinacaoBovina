using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Municipios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Municipios
{
    public class MunicipioService:IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
        {
            this.municipioRepository = municipioRepository;
        }

        public IEnumerable<Municipio> GetAll()
        {
            return municipioRepository.GetAll();
        }

        public Municipio GetId(int id)
        {
            return municipioRepository.GetId(id);
        }
    }
}
