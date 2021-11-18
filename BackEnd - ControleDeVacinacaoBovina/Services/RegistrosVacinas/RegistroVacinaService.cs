using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Animais;
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
        private readonly IAnimalRepository animalRepository;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository, IAnimalRepository animalRepository)
        {
            this.registroVacinaRepository = registroVacinaRepository;
            this.animalRepository = animalRepository;
        }

        public void Cancelar(int id)
        {
            registroVacinaRepository.Cancelar(registroVacinaRepository.GetById(id));
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(int idPropriedade)
        {
            return registroVacinaRepository.GetByPropriedade(idPropriedade);
        }

        public void Incluir(RegistroVacinacao registroVacina)
        {
            RegistroVacinacao registroVacinacao = registroVacinaRepository.GetByAnimal(registroVacina.IdAnimal);
            Animal animaisVacinados = registroVacinacao.Animal;

            if (registroVacinacao.DataDaVacina.Year == DateTime.Now.Year && registroVacinacao.Animal.QuantidadeVacinada == registroVacinacao.Animal.QuantidadeTotal)
            {
                throw new Exception("Todos os animais já foram vacinados esse ano!");
            }

            animaisVacinados.QuantidadeVacinada += registroVacina.Quantidade;

            registroVacinaRepository.Incluir(registroVacina);
            animalRepository.Editar(animaisVacinados);
        }

        public DateTime ObterUltimaVacinaPorEspecie(int idAnimal)
        {
            RegistroVacinacao registro = registroVacinaRepository.GetByAnimal(idAnimal);

            return registro.DataDaVacina;
        }

    }
}
