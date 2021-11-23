using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Models.Dtos;
using ControleDeVacinacaoBovina.Repositories.Produtores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Produtores
{
    public class ProdutorService : IProdutorService
    {
        private readonly IProdutorRepository produtorRepository;

        public ProdutorService(IProdutorRepository produtorRepository)
        {
            this.produtorRepository = produtorRepository;
        }

        public Task<ObjectResult> Editar(int id,ProdutorDto produtorDto)
        {
            var response = new ResponseDto<IEnumerable<Produtor>>(EStatusCode.NO_CONTENT, null);
            Produtor produtorAtualizado = produtorDto.DtoToProdutor(produtorDto);
            Produtor produtorOld = produtorRepository.GetById(id);

            if (produtorOld == null)
            {
                response.Errors.Add("produtor", $"O produtor com id:{id} e CPF:{produtorOld.CPF} não foi encontrado!");
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }
            produtorAtualizado.Endereco.IdEndereco = produtorOld.IdEndereco;
            produtorAtualizado.IdEndereco = produtorOld.IdEndereco;
            try
            {
                produtorRepository.Editar(produtorAtualizado);
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);
            }

            return response.ResultAsync();

        }

        public async Task<ObjectResult> GetAll()
        {
            var response = new ResponseDto<IEnumerable<Produtor>>(EStatusCode.OK, null);
            try
            {
                response.Data = await produtorRepository.GetAll();                              
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }
            return await response.ResultAsync();
        }

        public async Task<ObjectResult> GetByCPF(string CPF)
        {
            var response = new ResponseDto<Produtor>(EStatusCode.OK, null);
            try
            {                
                Produtor produtor = await produtorRepository.GetByCPF(CPF);
                response.Data = produtor;

                if (produtor == null)
                {
                    response.StatusCode = EStatusCode.NOT_FOUND;
                    return await response.ResultAsync();
                }                
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.INTERNAL_SERVER_ERROR);
            }

            return await response.ResultAsync();
        }

        public Task<ObjectResult> Incluir(ProdutorDto produtorDto)
        {
            produtorDto.Endereco.IdEndereco = null;
            Produtor produtor = produtorDto.DtoToProdutor(produtorDto);
            var response = new ResponseDto<Produtor>(EStatusCode.OK, null);

            try
            {
                produtorRepository.Incluir(produtor);                
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);            
            }
            return response.ResultAsync();
        }
    }
}
