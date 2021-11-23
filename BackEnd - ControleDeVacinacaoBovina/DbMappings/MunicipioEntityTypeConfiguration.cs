using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class MunicipioEntityTypeConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(m => m.IdMunicipio);
            builder.Property(m => m.Nome).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Estado).HasMaxLength(2).IsRequired();
        }
    }
}
