using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.DbMappings
{
    public class RegistroVacinaEntityTypeConfiguration : IEntityTypeConfiguration<RegistroVacinacao>
    {
        public void Configure(EntityTypeBuilder<RegistroVacinacao> builder)
        {
            builder.ToTable("RegistroVacinacao");
            builder.HasKey(rvacinacao => rvacinacao.IdRegistroVacinacao);
            builder.Property(rvacinacao => rvacinacao.Quantidade);
            builder.Property(rvacinacao => rvacinacao.DataDaVacina);
            builder.Property(rvacinacao => rvacinacao.Ativo);

            builder.HasOne(rvacinacao => rvacinacao.Rebanho)
                .WithMany(rebanho => rebanho.RegistroVacinacoes)
                .HasForeignKey(x => x.IdRebanho);

            builder.HasOne(rvacinacao => rvacinacao.Vacina)
                .WithMany(vacina => vacina.RegistroVacinas)
                .HasForeignKey(nameof(Vacina.IdVacina));            
        }
    }
}
