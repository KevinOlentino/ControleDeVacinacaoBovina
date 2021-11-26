using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repositories.Enderecos
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetById(int id);
        void Incluir(Endereco endereco);
        void Editar(Endereco endereco);
    }
}
