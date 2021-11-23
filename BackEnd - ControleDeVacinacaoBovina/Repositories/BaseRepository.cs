using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.DbMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
