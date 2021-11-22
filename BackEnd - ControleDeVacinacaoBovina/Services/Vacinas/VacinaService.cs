using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vacinas
{
    public class VacinaService : IVacinaService
    {
        private readonly IVacinaRepository vacinaRepository;

        public VacinaService(IVacinaRepository vacinaRepository)
        {
            this.vacinaRepository = vacinaRepository;
        }

        public void Editar(Vacina vacina)
        {
            vacinaRepository.Editar(vacina);
        }

        public Task<Vacina> GetById(int id)
        {
            return vacinaRepository.GetById(id);
        }

        public void Incluir(Vacina vacina)
        {
            vacinaRepository.Incluir(vacina);
        }

        public async Task<IEnumerable<Vacina>> GetAll()
        {
            return await vacinaRepository.GetAll();
        }
    }
}
