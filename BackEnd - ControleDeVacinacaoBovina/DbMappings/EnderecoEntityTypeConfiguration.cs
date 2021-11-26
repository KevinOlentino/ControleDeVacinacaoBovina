using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(endereco => endereco.IdEndereco);
            builder.Property(endereco => endereco.IdEndereco).UseIdentityColumn(1, 1);
            builder.Property(endereco => endereco.Rua).HasMaxLength(150).IsRequired();
            builder.Property(endereco => endereco.Numero).HasMaxLength(20).IsRequired();

            builder.HasOne(endereco => endereco.Municipio)
                .WithMany(municipio => municipio.Endereco)
                .HasForeignKey(nameof(Municipio.IdMunicipio));
        }
    }
}
