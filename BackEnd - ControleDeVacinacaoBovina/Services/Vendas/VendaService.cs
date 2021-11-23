using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Animais;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IAnimalRepository animalRepository;        

        public VendaService(IVendaRepository vendaRepository, IAnimalRepository animalRepository)
        {
            this.vendaRepository = vendaRepository;
            this.animalRepository = animalRepository;
           
        }

        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<Venda>(EStatusCode.NO_CONTENT, null);  
            try
            {
                Venda venda = vendaRepository.GetById(id);
                if (venda == null)
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                vendaRepository.Cancelar(venda);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();

        }

        public async Task<ObjectResult> GetByDestino(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<Venda>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Venda> listVenda = vendaRepository.GetByDestino(idPropriedade);

                if (!listVenda.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }

                response.Data = listVenda;
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return await response.ResultAsync();

        }

        public async Task<ObjectResult> GetByOrigem(int idPropriedade)
        {
            var response = new ResponseDto<IEnumerable<Venda>>(EStatusCode.OK, null);
            try
            {
                IEnumerable<Venda> listVenda = vendaRepository.GetByOrigem(idPropriedade);

                if (!listVenda.Any())
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }

                response.Data = listVenda;
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return await response.ResultAsync();

        }

        public async Task<ObjectResult> Incluir(VendaDto vendaDto)
        {
            Venda venda = vendaDto.DtoToVenda(vendaDto);
            var response = new ResponseDto<Venda>(EStatusCode.OK, null);          
                        
            try
            {
                if (ValidarVenda(venda, response))
                    vendaRepository.Incluir(venda);
            }
            catch (Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return await response.ResultAsync();          
        }

        private bool ValidarVenda(Venda venda, ResponseDto<Venda> response)
        {
            Animal animalOrigem = animalRepository.GetByPropriedade(venda.IdOrigem).FirstOrDefault(x => x.IdEspecie == venda.IdEspecie);
            Animal animalDestino = animalRepository.GetByPropriedade(venda.IdDestino).FirstOrDefault(x => x.IdEspecie == venda.IdEspecie);            

            if (animalOrigem == null)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                response.Errors.Add("Origem:","A origem não foi encontrada e o animal não pode ser vendido");
                return false;
            }    
            if (animalOrigem.QuantidadeVacinada <= 0 || animalOrigem.QuantidadeVacinada > venda.Quantidade)
            {
                response.Errors.Add("QuantidadeVacinada",$"Não há {venda.Quantidade} animais vacinados para venda");
            }
            if (response.Errors.Any())
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                return false;
            }

            EditarEntidadesDeAnimais(animalOrigem, animalDestino, venda);

            return true;
        }

        private void EditarEntidadesDeAnimais(Animal animalOrigem, Animal animalDestino, Venda venda)
        {
            animalOrigem.QuantidadeVacinada -= venda.Quantidade;
            animalOrigem.QuantidadeTotal -= venda.Quantidade;
            animalRepository.Editar(animalOrigem);


            if (animalDestino != null)
            {
                animalDestino.QuantidadeTotal += venda.Quantidade;
                animalDestino.QuantidadeVacinada += venda.Quantidade;
                animalRepository.Editar(animalDestino);
            }
            else
            {
                animalRepository.Incluir(new Animal()
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
