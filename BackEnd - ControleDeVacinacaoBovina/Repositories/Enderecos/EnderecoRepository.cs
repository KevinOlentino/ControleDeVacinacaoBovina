using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Enderecos
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public Task<Endereco> Editar(Models.Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
