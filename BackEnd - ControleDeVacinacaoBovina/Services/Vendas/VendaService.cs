using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Animais;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IAnimalService animalService;
        private readonly IRegistroVacinaService registroVacinacaoService;

        public VendaService(IVendaRepository vendaRepository, IAnimalService animalService, IRegistroVacinaService registroVacinacaoService )
        {
            this.vendaRepository = vendaRepository;
            this.animalService = animalService;
            this.registroVacinacaoService = registroVacinacaoService;
        }

        public void Cancelar(int id)
        {
            Venda venda = vendaRepository.GetById(id);

            vendaRepository.Cancelar(venda);

        }

        public IEnumerable<Venda> GetByDestino(int idProdutor)
        {
            return vendaRepository.GetByDestino(idProdutor);
        }

        public IEnumerable<Venda> GetByOrigem(int idProdutor)
        {
            return vendaRepository.GetByOrigem(idProdutor);
        }

        public void Incluir(Venda venda)
        {
            if (!ValidarVenda(venda))
            {
                throw new Exception("Venda não pode ser realizada, verifique a quantidade de animais!");
            }

            vendaRepository.Incluir(venda);            
        }

        private bool ValidarVenda(Venda venda)
        {
            Animal animalOrigem = animalService.GetByPropriedade(venda.IdOrigem).FirstOrDefault(x => x.IdEspecie == venda.IdEspecie);
            Animal animalDestino = animalService.GetByPropriedade(venda.IdDestino).FirstOrDefault(x => x.IdEspecie == venda.IdEspecie);
            DateTime ultimaVacina = registroVacinacaoService.ObterUltimaVacinaPorEspecie(animalOrigem.IdAnimal);

            if (animalDestino == null || animalOrigem == null)
            {
                throw new Exception("O Destino ou a Origem não foi encontrado!");
            }

            if(animalOrigem.QuantidadeTotal <= 0)
            {
                return false;
            }
            else if(animalOrigem.QuantidadeVacinada <= 0 || ultimaVacina.Year != DateTime.Now.Year)
            {
                return false;
            }

            animalOrigem.QuantidadeVacinada -= venda.Quantidade;
            animalOrigem.QuantidadeTotal -= venda.Quantidade;

            animalDestino.QuantidadeVacinada += venda.Quantidade;
            animalDestino.QuantidadeTotal += venda.Quantidade;

            animalService.Editar(animalOrigem);
            animalService.Editar(animalDestino);

            return true;
        }
    }
}
