using ControleDeVacinacaoBovina.Repository;
using ControleDeVacinacaoBovina.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeVacinacaoBovina.DbMappings;

namespace ControleDeVacinacaoBovina.Repositories.RegistrosVacinas
{
    public class RegistroVacinaRepository : BaseRepository, IRegistroVacinaRepository
    {
        public RegistroVacinaRepository(Contexto novoContexto) : base(novoContexto)
        {
        }

        public void Cancelar(RegistroVacinacao registroVacinacao)
        {
            registroVacinacao.SetAtivo(false);
            _contexto.Entry(registroVacinacao).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<RegistroVacinacao> GetByPropriedade(int idPropriedade)
        {
            return _contexto.RegistroVacinacoes.Include(registro => registro.Rebanho)
                .ThenInclude(rebanho => rebanho.Propriedade)
                .Include(rebanho => rebanho.Rebanho.Especie)
                .Include(rebanho => rebanho.Vacina)
                .Where(rebanho => rebanho.Rebanho.Propriedade.IdPropriedade == idPropriedade)
                .Where(x => x.Ativo == true);
        }

        public async Task Incluir(RegistroVacinacao registroVacina)
        {
            await _contexto.RegistroVacinacoes.AddAsync(registroVacina);
            await _contexto.SaveChangesAsync();                                                
        }

        public IEnumerable<RegistroVacinacao> GetByRebanho(int id)
        {
            return _contexto.RegistroVacinacoes.AsNoTracking().Include(registro => registro.Rebanho)
                .ThenInclude(rebanho => rebanho.Especie)
                .Include(rebanho => rebanho.Vacina)
                .OrderBy(registro => registro.IdRegistroVacinacao)
                .Where(registro => registro.IdRebanho == id)
                .Where(x => x.Ativo == true);                     
        }

        public int ObterVacinasDesseAnoContagem(int idRebanho, int idVacina)
        {
            return _contexto.RegistroVacinacoes.AsNoTracking()
                .Where(x => x.IdRebanho == idRebanho)
                .Where(x => x.IdVacina == idVacina)
                .Where(x => x.Ativo == true)
                .Sum(x => x.Quantidade);
        }        

        public RegistroVacinacao GetById(int id)
        {
            return _contexto.RegistroVacinacoes.Include(x => x.Rebanho).FirstOrDefault(x => x.IdRegistroVacinacao == id);
        }
     
    }
}
