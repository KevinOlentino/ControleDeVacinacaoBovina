using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.RegistrosVacinas
{
    public class RegistroVacinaService : IRegistroVacinaService
    {
        private readonly IRegistroVacinaRepository registroVacinaRepository;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository)
        {
            this.registroVacinaRepository = registroVacinaRepository;
        }

        public void Cancelar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(string IncricaoEstadual)
        {
            return registroVacinaRepository.GetByPropriedade(IncricaoEstadual);
        }

        public void Incluir(RegistroVacinacao registroVacina)
        {
            registroVacinaRepository.Incluir(registroVacina);
        }
    }
}
