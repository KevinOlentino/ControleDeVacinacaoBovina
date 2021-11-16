using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Enderecos
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            this.enderecoRepository = enderecoRepository;
        }

        public void Editar(Endereco endereco)
        {
            enderecoRepository.Editar(endereco);
        }

        public Task<Endereco> GetById(int id)
        {
            return enderecoRepository.GetById(id);
        }

        public void Incluir(Endereco endereco)
        {
            enderecoRepository.Incluir(endereco);
        }
    }
}
