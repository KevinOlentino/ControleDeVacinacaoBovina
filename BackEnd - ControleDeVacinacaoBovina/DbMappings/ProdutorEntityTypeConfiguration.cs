using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class ProdutorEntityTypeConfiguration : IEntityTypeConfiguration<Produtor>
    {
        public void Configure(EntityTypeBuilder<Produtor> builder)
        {
            builder.ToTable("Produtor");
            builder.HasKey(produtor => produtor.IdProdutor);
            builder.Property(produtor => produtor.IdProdutor).UseIdentityColumn();
            builder.Property(produtor => produtor.Nome).HasMaxLength(50).IsRequired();
            builder.Property(produtor => produtor.CPF).HasMaxLength(11).IsRequired();

            builder.HasOne(produtor => produtor.Endereco)
                .WithMany(endereco => endereco.Produtores)
                .HasForeignKey(nameof(Endereco.IdEndereco));
        }
    }
}
