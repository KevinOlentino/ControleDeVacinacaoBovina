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
        public Contexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Propriedade>().HasKey(p => p.IdPropriedade);
            builder.Entity<Propriedade>().HasOne<Endereco>().WithOne();
            builder.Entity<Propriedade>().HasOne<Produtor>().WithOne();
            builder.Entity<Propriedade>().Navigation(p => p.Endereco).UsePropertyAccessMode(PropertyAccessMode.Property);
            builder.Entity<Propriedade>().Navigation(p => p.Produtor).UsePropertyAccessMode(PropertyAccessMode.Property);
            builder.Entity<Propriedade>().Property(p => p.IncricaoEstadual).HasMaxLength(10).IsRequired(); ;
            builder.Entity<Propriedade>().Property(p => p.Nome).HasMaxLength(50).IsRequired(); ;

            builder.Entity<Endereco>().HasKey(e => e.IdEndereco);
            builder.Entity<Endereco>().Property(e => e.Rua).HasMaxLength(150).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Numero).HasMaxLength(20).IsRequired();
            builder.Entity<Endereco>().HasOne<Municipio>().WithMany();
            builder.Entity<Endereco>().Navigation(e => e.Municipio).UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Entity<Municipio>().HasKey(m => m.IdMunicipio);
            builder.Entity<Municipio>().Property(m => m.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Municipio>().Property(m => m.Estado).HasMaxLength(2).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BJMO5PO; Database=VacinacaoBovina; User ID=treinamento; Password=senha;");
        }
    }
}
