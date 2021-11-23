﻿using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class EspecieEntityTypeConfiguration : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.ToTable("Especie");
            builder.HasKey(especie => especie.IdEspecie);
            builder.Property(especie => especie.Nome);
        }
    }
}
