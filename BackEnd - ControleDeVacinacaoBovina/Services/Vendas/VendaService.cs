using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Rebanhos;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Animais;
using ControleDeVacinacaoBovina.Services.Rebanhos;
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
        private readonly IRebanhoRepository rebanhoRepository;
        private readonly IAnimalService animalService;
        private readonly IRebanhoService rebanhoService;

        public VendaService(IVendaRepository vendaRepository, 
                            IRebanhoRepository rebanhoRepository, 
                            IAnimalService animalService,
                            IRebanhoService rebanhoService
                            )
        {
            this.vendaRepository = vendaRepository;
            this.rebanhoRepository = rebanhoRepository;
            this.animalService = animalService;
            this.rebanhoService = rebanhoService;
        }
        public Task<ObjectResult> Cancelar(int id)
        {
            var response = new ResponseDto<Venda>(EStatusCode.NO_CONTENT, null);  
            try
            {
                Venda venda = vendaRepository.GetById(id);

                if (venda == null || venda.Ativo == false)
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return response.ResultAsync();
                }

                Rebanho rebanhoDestino = rebanhoRepository.GetByPropriedade(venda.IdDestino).FirstOrDefault(x => x.IdEspecie == venda.Rebanho.IdEspecie);

                venda.Rebanho.QuantidadeTotal += venda.Quantidade;
                venda.Rebanho.QuantidadeVacinada += venda.Quantidade;

                rebanhoDestino.QuantidadeTotal -= venda.Quantidade;
                rebanhoDestino.QuantidadeVacinada -= venda.Quantidade;

                rebanhoService.Editar(venda.Rebanho);
                rebanhoService.Editar(rebanhoDestino);
          
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
            Rebanho rebanhoOrigem = rebanhoRepository.GetById(venda.IdRebanho);            

            if (rebanhoOrigem == null)
            {
                response.StatusCode = EStatusCode.NOT_FOUND;
                response.AddError("origem:","A origem não foi encontrada e o animal não pode ser vendido");
                return false;
            }

            Rebanho rebanhoDestino = rebanhoRepository.GetByPropriedade(venda.IdDestino).FirstOrDefault(x => x.IdEspecie == rebanhoOrigem.IdEspecie);

            if (rebanhoOrigem.QuantidadeVacinada < venda.Quantidade)
            {
                response.AddError("error",$"Não há {venda.Quantidade} animais vacinados para venda, verificar registro de vacina!");
            }if(rebanhoOrigem.QuantidadeTotal == 0)
            {
                response.AddError("error", $"Não há {venda.Quantidade} animais para venda! ");
            }
            if (response.Errors.Any())
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                return false;
            }

            EditarEntidadesDeAnimais(rebanhoOrigem, venda);

            return true;
        }

        private void EditarEntidadesDeAnimais(Rebanho rebanhoOrigem, Venda venda)
        {
            rebanhoOrigem.QuantidadeVacinada -= venda.Quantidade;
            rebanhoOrigem.QuantidadeTotal -= venda.Quantidade;
            rebanhoRepository.Editar(rebanhoOrigem);

            animalService.AdicionarRebanhoAnimal(new Animal()
            {
                IdPropriedade = venda.IdDestino,
                QuantidadeTotal = venda.Quantidade,
                QuantidadeVacinada = venda.Quantidade,
                IdEspecie = rebanhoOrigem.IdEspecie,
                IdTipoDeEntrada = 1,
                DataDeEntrada = DateTime.Now
            });
            
        }
    }
}
