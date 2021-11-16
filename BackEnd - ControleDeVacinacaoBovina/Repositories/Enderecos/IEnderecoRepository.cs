﻿using ControleDeVacinacaoBovina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
