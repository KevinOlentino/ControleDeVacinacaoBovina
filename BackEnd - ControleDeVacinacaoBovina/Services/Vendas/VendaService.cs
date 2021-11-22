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
            RegistroVacinacao UltimoRegistro = registroVacinacaoService.ObterUltimaVacinaPorEspecie(animalOrigem.IdAnimal);
            DateTime? ultimaVacina;

            if (animalOrigem == null)
            {
                throw new Exception("A origem não foi encontrada e o animal não pode ser vendido");
            }
            if (UltimoRegistro == null)
            {
                throw new Exception("Nenhum registro de vacina registrado, sendo assim não pode realizar a venda!");
            }

            ultimaVacina = UltimoRegistro.DataDaVacina;

            if (animalOrigem.QuantidadeVacinada <= 0 || ultimaVacina.Value.Year != DateTime.Now.Year)
            {
                return false;
            }

            EditarEntidadesDeAnimais(animalOrigem, animalDestino, venda);

            return true;
        }

        private void EditarEntidadesDeAnimais(Animal animalOrigem, Animal animalDestino, Venda venda)
        {
            animalOrigem.QuantidadeVacinada -= venda.Quantidade;
            animalOrigem.QuantidadeTotal -= venda.Quantidade;
            animalService.Editar(animalOrigem);


            if (animalDestino != null)
            {
                animalDestino.QuantidadeTotal += venda.Quantidade;
                animalDestino.QuantidadeVacinada += venda.Quantidade;
                animalService.Editar(animalDestino);
            }
            else
            {
                animalService.Incluir(new Animal()
                {
                    IdPropriedade = venda.IdDestino,
                    QuantidadeTotal = venda.Quantidade,
                    QuantidadeVacinada = venda.Quantidade,
                    IdEspecie = venda.IdEspecie
                });
            }
        }
    }
}
