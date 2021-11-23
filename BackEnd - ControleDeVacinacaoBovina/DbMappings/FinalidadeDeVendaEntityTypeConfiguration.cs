using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class FinalidadeDeVendaEntityTypeConfiguration : IEntityTypeConfiguration<FinalidadeDeVenda>
    {
        public void Configure(EntityTypeBuilder<FinalidadeDeVenda> builder)
        {
            builder.ToTable("FinalidadeDeVenda");
            builder.HasKey(finalVenda => finalVenda.IdFinalidadeDeVenda);
            builder.Property(finalVenda => finalVenda.Nome);
        }
    }
}
