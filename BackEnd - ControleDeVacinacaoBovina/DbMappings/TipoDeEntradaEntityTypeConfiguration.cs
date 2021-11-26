using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
