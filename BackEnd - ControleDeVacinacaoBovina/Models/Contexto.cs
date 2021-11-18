using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVacinacaoBovina.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Propriedade> Propriedades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Produtor> Produtores { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<RegistroVacinacao> RegistroVacinacoes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<FinalidadeDeVenda> FinalidadeDeVendas { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Municipio>().ToTable("Municipio");            
            builder.Entity<Municipio>().HasKey(m => m.IdMunicipio);
            builder.Entity<Municipio>().Property(m => m.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Municipio>().Property(m => m.Estado).HasMaxLength(2).IsRequired();

            builder.Entity<Propriedade>().ToTable("Propriedade");            
            builder.Entity<Propriedade>().HasKey(propriedade => propriedade.IdPropriedade);
            builder.Entity<Propriedade>().HasOne(propriedade => propriedade.Endereco).WithMany(endereco => endereco.Propriedades).HasForeignKey(nameof(Endereco.IdEndereco));
            builder.Entity<Propriedade>().HasOne(propriedade => propriedade.Produtor).WithMany(produtor => produtor.Propriedades).HasForeignKey(nameof(Produtor.IdProdutor));
            builder.Entity<Propriedade>().Property(propriedade => propriedade.InscricaoEstadual).HasMaxLength(10).IsRequired(); ;
            builder.Entity<Propriedade>().Property(propriedade => propriedade.Nome).HasMaxLength(50).IsRequired();

            builder.Entity<Endereco>().ToTable("Endereco");            
            builder.Entity<Endereco>().HasKey(endereco => endereco.IdEndereco);
            builder.Entity<Endereco>().Property(endereco => endereco.IdEndereco).UseIdentityColumn(1,1);
            builder.Entity<Endereco>().Property(endereco => endereco.Rua).HasMaxLength(150).IsRequired();
            builder.Entity<Endereco>().Property(endereco => endereco.Numero).HasMaxLength(20).IsRequired();
            builder.Entity<Endereco>().HasOne(endereco => endereco.Municipio).WithMany(municipio => municipio.Endereco).HasForeignKey(nameof(Municipio.IdMunicipio));

            builder.Entity<Produtor>().ToTable("Produtor");
            builder.Entity<Produtor>().HasKey(produtor => produtor.IdProdutor);
            builder.Entity<Produtor>().Property(produtor => produtor.IdProdutor).UseIdentityColumn();
            builder.Entity<Produtor>().HasOne(produtor => produtor.Endereco).WithMany(endereco => endereco.Produtores).HasForeignKey(nameof(Endereco.IdEndereco));
            builder.Entity<Produtor>().Property(produtor => produtor.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Produtor>().Property(produtor => produtor.CPF).HasMaxLength(11).IsRequired();

            builder.Entity<Animal>().ToTable("Animal");
            builder.Entity<Animal>().HasKey(animal => animal.IdAnimal);
            builder.Entity<Animal>().Property(animal => animal.QuantidadeTotal);
            builder.Entity<Animal>().Property(animal => animal.QuantidadeVacinada);
            builder.Entity<Animal>().HasOne(animal => animal.Especie).WithMany(especie => especie.Animals).HasForeignKey(nameof(Especie.IdEspecie));
            builder.Entity<Animal>().HasOne(animal => animal.Propriedade).WithMany(propriedade => propriedade.Animals).HasForeignKey(nameof(Propriedade.IdPropriedade));
            builder.Entity<Animal>().Property(animal => animal.Ativo);

            builder.Entity<Vacina>().ToTable("Vacina");
            builder.Entity<Vacina>().HasKey(vacina => vacina.IdVacina);
            builder.Entity<Vacina>().Property(vacina => vacina.Marca).HasMaxLength(30).IsRequired();
            builder.Entity<Vacina>().Property(vacina => vacina.Doenca).HasMaxLength(50).IsRequired();
            builder.Entity<Vacina>().Property(vacina => vacina.Tipo).HasMaxLength(10).IsRequired();

            builder.Entity<RegistroVacinacao>().ToTable("RegistroVacinacao");
            builder.Entity<RegistroVacinacao>().HasKey(rvacinacao => rvacinacao.IdRegistroVacinacao);
            builder.Entity<RegistroVacinacao>().Property(rvacinacao => rvacinacao.Quantidade);
            builder.Entity<RegistroVacinacao>().Property(rvacinacao => rvacinacao.DataDaVacina);
            builder.Entity<RegistroVacinacao>().HasOne(rvacinacao => rvacinacao.Animal).WithMany(animal => animal.RegistroVacinas).HasForeignKey(nameof(Animal.IdAnimal));
            builder.Entity<RegistroVacinacao>().HasOne(rvacinacao => rvacinacao.Vacina).WithMany(vacina => vacina.RegistroVacinas).HasForeignKey(nameof(Vacina.IdVacina));
            builder.Entity<RegistroVacinacao>().Property(rvacinacao => rvacinacao.Ativo);

            builder.Entity<Venda>().ToTable("Venda");
            builder.Entity<Venda>().HasKey(venda => venda.IdVenda);
            builder.Entity<Venda>().Property(venda => venda.Quantidade);
            builder.Entity<Venda>().HasOne(venda => venda.Especie).WithMany(especie => especie.Vendas).HasForeignKey(nameof(Especie.IdEspecie));
            builder.Entity<Venda>().HasOne(venda => venda.Origem).WithMany(venda => venda.Origem).HasForeignKey(nameof(Venda.IdOrigem));
            builder.Entity<Venda>().HasOne(venda => venda.Destino).WithMany(propriedade => propriedade.Destino).HasForeignKey(nameof(Venda.IdDestino));
            builder.Entity<Venda>().HasOne(venda => venda.FinalidadeDeVenda).WithMany(finalidadeDeVenda => finalidadeDeVenda.Vendas).HasForeignKey(nameof(FinalidadeDeVenda.IdFinalidadeDeVenda));
            builder.Entity<Venda>().Property(venda => venda.Ativo);

            builder.Entity<Especie>().ToTable("Especie");
            builder.Entity<Especie>().HasKey(especie => especie.IdEspecie);
            builder.Entity<Especie>().Property(especie => especie.Nome);

            builder.Entity<FinalidadeDeVenda>().ToTable("FinalidadeDeVenda");
            builder.Entity<FinalidadeDeVenda>().HasKey(finalVenda => finalVenda.IdFinalidadeDeVenda);
            builder.Entity<FinalidadeDeVenda>().Property(finalVenda => finalVenda.Nome);
        }
    }
}
