using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ControleDeVacinacaoBovina.Models.Dtos;

namespace ControleDeVacinacaoBovina.Repositories.Propriedades
{
    public class PropriedadeRepository : BaseRepository, IPropriedadeRepository
    {
        public PropriedadeRepository(Contexto novoContexto) : base(novoContexto)
        {
        }
        public void Editar(Propriedade propriedade)
        {
            _contexto.Propriedades.Update(propriedade);
            _contexto.SaveChanges();       
        }

        public async Task<Propriedade> GetByIncricao(string inscricaoEstadual)
        {            
            return await _contexto.Propriedades.Include(propriedade => propriedade.Endereco).ThenInclude(endereco => endereco.Municipio)
                                                .Include(propriedade => propriedade.Produtor)
                                                 .FirstOrDefaultAsync(propriedade => propriedade.IncricaoEstadual == inscricaoEstadual);
        }

        public IEnumerable<Propriedade> GetByProdutor(int idProdutor)
        {
            return _contexto.Propriedades.Where(propriedade => propriedade.IdProdutor == idProdutor);
        }

        public Propriedade Incluir(Propriedade propriedade)
        {
            propriedade.Endereco.IdEndereco = null;
            _contexto.Propriedades.Add(propriedade);
            _contexto.SaveChanges();            

            return propriedade;
        }
    }
}
