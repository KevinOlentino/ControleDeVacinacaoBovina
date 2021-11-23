using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class PropriedadeEntityTypeConfiguration : IEntityTypeConfiguration<Propriedade>
    {
        public void Configure(EntityTypeBuilder<Propriedade> builder)
        {
            builder.ToTable("Propriedade");
            builder.HasKey(propriedade => propriedade.IdPropriedade);
            builder.Property(propriedade => propriedade.InscricaoEstadual).HasMaxLength(10).IsRequired(); ;
            builder.Property(propriedade => propriedade.Nome).HasMaxLength(50).IsRequired();

            builder.HasOne(propriedade => propriedade.Endereco)
                .WithMany(endereco => endereco.Propriedades)
                .HasForeignKey(nameof(Endereco.IdEndereco));

            builder.HasOne(propriedade => propriedade.Produtor)
                .WithMany(produtor => produtor.Propriedades)
                .HasForeignKey(nameof(Produtor.IdProdutor));

        }
    }
}
