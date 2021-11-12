using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Repository
{
    public class BaseRepository
    {
        private readonly Contexto _contexto;

        public BaseRepository(Contexto novoContexto)
        {
            _contexto = novoContexto;
        }
    }
}
