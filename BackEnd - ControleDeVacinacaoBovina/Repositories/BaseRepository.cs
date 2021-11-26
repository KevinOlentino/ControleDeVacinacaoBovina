using ControleDeVacinacaoBovina.DbMappings;

namespace ControleDeVacinacaoBovina.Repository
{
    public class BaseRepository
    {
        protected readonly Contexto _contexto;

        public BaseRepository(Contexto novoContexto)
        {
            _contexto = novoContexto;
        }
    }
}
