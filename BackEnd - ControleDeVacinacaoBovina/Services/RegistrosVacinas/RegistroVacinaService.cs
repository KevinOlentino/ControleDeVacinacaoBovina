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

        public async Task Incluir(RegistroVacinacao registroVacina)
        {
            RegistroVacinacao registroVacinacaOld = ObterUltimaVacinaPorEspecie(registroVacina.IdAnimal);
            Animal animaisAVacinar = animalRepository.GetById(registroVacina.IdAnimal);

            if (registroVacinacaOld != null && registroVacinacaOld.DataDaVacina.Year == DateTime.Now.Year 
                && animaisAVacinar.QuantidadeVacinada == animaisAVacinar.QuantidadeTotal)
            {
                throw new Exception("Todos os animais já foram vacinados esse ano!");
            }
            if(registroVacina.Quantidade > animaisAVacinar.QuantidadeTotal - animaisAVacinar.QuantidadeVacinada)
            {
                throw new Exception("Valor não pode ser maior que a quantidade total de animais!");
            }

            animaisAVacinar.QuantidadeVacinada += registroVacina.Quantidade;
            
            await registroVacinaRepository.Incluir(registroVacina);   
            await animalRepository.Editar(animaisAVacinar);
        }

        public RegistroVacinacao ObterUltimaVacinaPorEspecie(int idAnimal)
        {
            IEnumerable<RegistroVacinacao> registro = registroVacinaRepository.GetByAnimal(idAnimal);

            if (registro.Any())
            {
                return registro.Last();
            }

            return null;
        }

    }
}
