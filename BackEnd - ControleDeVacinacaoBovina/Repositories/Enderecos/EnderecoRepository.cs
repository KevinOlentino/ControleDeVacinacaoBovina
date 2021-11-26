using ControleDeVacinacaoBovina.DbMappings;
using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Enderecos
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Editar(Endereco endereco)
        {
            _contexto.Enderecos.Update(endereco);
            _contexto.SaveChanges();
        }

        public async Task<Endereco> GetById(int id)
        {
            return await _contexto.Enderecos.FirstOrDefaultAsync(x => x.GetMunicipio() == id);
        }

        public void Incluir(Endereco endereco)
        {
            _contexto.Enderecos.Add(endereco);
            _contexto.SaveChanges();
        }
    }
}
