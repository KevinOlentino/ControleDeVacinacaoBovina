using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class VacinaEntityTypeConfiguration : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            builder.ToTable("Vacina");
            builder.HasKey(vacina => vacina.IdVacina);
            builder.Property(vacina => vacina.Marca).HasMaxLength(30).IsRequired();
            builder.Property(vacina => vacina.Doenca).HasMaxLength(50).IsRequired();
            builder.Property(vacina => vacina.Tipo).HasMaxLength(10).IsRequired();
        }
    }
}
