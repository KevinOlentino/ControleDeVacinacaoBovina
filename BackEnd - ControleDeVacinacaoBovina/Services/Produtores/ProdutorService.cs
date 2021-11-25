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
                response.AddError("Produtor", $"O produtor com id:{id} e CPF:{produtorOld.CPF} não foi encontrado!");
                response.StatusCode = EStatusCode.NOT_FOUND;
                return response.ResultAsync();
            }
            if (!ValidarCPF(produtorAtualizado.CPF))
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                response.AddError("CPF", "CPF INVALIDO!");
            }
            try
            {
                if (!response.Errors.Any())
                {
                    produtorAtualizado.Endereco.IdEndereco = produtorOld.IdEndereco;
                    produtorAtualizado.IdEndereco = produtorOld.IdEndereco;
                    produtorRepository.Editar(produtorAtualizado);
                }                
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

            if (produtorRepository.ExistByCPF(produtor.CPF))
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                response.AddError("CPF", "Este CPF já foi cadastrado!");
            }
            if (!ValidarCPF(produtor.CPF))
            {
                response.StatusCode = EStatusCode.BAD_REQUEST;
                response.AddError("CPF", "CPF INVALIDO!");
            }
            try
            {
                if(!response.Errors.Any())
                produtorRepository.Incluir(produtor);                
            }
            catch(Exception ex)
            {
                response.AddException(ex, EStatusCode.BAD_REQUEST);            
            }
            return response.ResultAsync();
        }

        public bool ValidarCPF(string CPF)
        {            
            int[] multiplicador1 = new int[9]{ 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11,10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            string tempCPF = CPF.Substring(0,9);            
            int soma = 0;            
     
            if (CPF[0] == CPF[1] && CPF[1] == CPF[2] && CPF[2] == CPF[3] && CPF[3] == CPF[4]
                && CPF[4] == CPF[5] && CPF[5] == CPF[6] && CPF[6] == CPF[7] && CPF[7] == CPF[8]
                && CPF[8] == CPF[9] && CPF[9] == CPF[10])
                return false;

            for (int x = 0; x < 9; x++)
                soma += int.Parse(tempCPF[x].ToString()) * multiplicador1[x];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCPF += digito;
            soma = 0;
            for (int x = 0; x < 10; x++)
                soma += int.Parse(tempCPF[x].ToString()) * multiplicador2[x];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();

            return CPF.EndsWith(digito);
        }
    }
}
