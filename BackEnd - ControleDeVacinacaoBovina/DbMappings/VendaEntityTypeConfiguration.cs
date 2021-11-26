using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class VendaEntityTypeConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");
            builder.HasKey(venda => venda.IdVenda);
            builder.Property(venda => venda.Quantidade);
            builder.Property(venda => venda.Ativo);
            builder.Property(venda => venda.DataDeVenda);

            builder.HasOne(venda => venda.Rebanho)
                .WithMany(rebanho => rebanho.Vendas)
                .HasForeignKey(x => x.IdRebanho);

            builder.HasOne(venda => venda.Origem)
                .WithMany(venda => venda.Origem)
                .HasForeignKey(nameof(Venda.IdOrigem));

            builder.HasOne(venda => venda.Destino)
                .WithMany(propriedade => propriedade.Destino)
                .HasForeignKey(nameof(Venda.IdDestino));

            builder.HasOne(venda => venda.FinalidadeDeVenda)
                .WithMany(finalidadeDeVenda => finalidadeDeVenda.Vendas)
                .HasForeignKey(nameof(FinalidadeDeVenda.IdFinalidadeDeVenda));
        }
    }
}
