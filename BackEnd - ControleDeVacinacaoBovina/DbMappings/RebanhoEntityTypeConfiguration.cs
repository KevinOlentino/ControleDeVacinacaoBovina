using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class RebanhoEntityTypeConfiguration : IEntityTypeConfiguration<Rebanho>
    {
        public void Configure(EntityTypeBuilder<Rebanho> builder)
        {
            builder.ToTable("Rebanho");
            builder.HasKey(x => x.IdRebanho);
            builder.Property(x => x.QuantidadeTotal).IsRequired();
            builder.Property(x => x.QuantidadeVacinada).IsRequired();

            builder.HasOne(x => x.Especie)
                .WithMany(x => x.Rebanhos)
                .HasForeignKey(x => x.IdEspecie);

            builder.HasOne(x => x.Propriedade)
                .WithMany(x => x.Rebanhos)
                .HasForeignKey( x => x.IdPropriedade);
            

        }
    }
}
