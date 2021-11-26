using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");
            builder.HasKey(animal => animal.IdAnimal);
            builder.Property(animal => animal.QuantidadeTotal);
            builder.Property(animal => animal.QuantidadeVacinada);
            builder.Property(animal => animal.Ativo);
            builder.Property(animal => animal.DataDeEntrada);

            builder.HasOne(animal => animal.Especie)
                .WithMany(especie => especie.Animals)
                .HasForeignKey(nameof(Especie.IdEspecie));

            builder.HasOne(animal => animal.Propriedade)
                .WithMany(propriedade => propriedade.Animals)
                .HasForeignKey(x => x.IdPropriedade);

            builder.HasOne(animal => animal.TipoDeEntrada)
                .WithMany(tipoDeEntrada => tipoDeEntrada.Animals)
                .HasForeignKey(x => x.IdTipoDeEntrada);
        }
    }
}
