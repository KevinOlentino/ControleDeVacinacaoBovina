using ControleDeVacinacaoBovina.Models;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Enderecos
{
    interface IEnderecoService
    {
        Task<Endereco> GetById(int id);
        void Incluir(Endereco endereco);
        void Editar(Endereco endereco);
    }
}
