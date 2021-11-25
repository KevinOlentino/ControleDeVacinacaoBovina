using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class TipoDeEntradaEntityTypeConfiguration : IEntityTypeConfiguration<TipoDeEntrada>
    {
        public void Configure(EntityTypeBuilder<TipoDeEntrada> builder)
        {
            builder.ToTable("TipoDeEntrada");
            builder.HasKey(x => x.IdTipoDeEntrada);
            builder.Property(x => x.Nome).HasMaxLength(20).IsRequired();
        }
    }
}
