using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Services.Vendas
{
    public interface IVendaService
    {
        void Incluir(Venda venda);
        void Cancelar(int id);
        IEnumerable<Venda> GetByOrigem(int idProdutor);
        IEnumerable<Venda> GetByDestino(int idProdutor);      
    }
}
