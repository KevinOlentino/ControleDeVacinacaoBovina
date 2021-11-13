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
            builder.Entity<Municipio>().ToTable("Municipio");            
            builder.Entity<Municipio>().HasKey(m => m.IdMunicipio);
            builder.Entity<Municipio>().Property(m => m.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Municipio>().Property(m => m.Estado).HasMaxLength(2).IsRequired();

            builder.Entity<Propriedade>().ToTable("Propriedade");            
            builder.Entity<Propriedade>().HasKey(propriedade => propriedade.IdPropriedade);
            builder.Entity<Propriedade>().HasOne(propriedade => propriedade.Endereco).WithMany(endereco => endereco.Propriedades).HasForeignKey("IdEndereco");
            builder.Entity<Propriedade>().HasOne(propriedade => propriedade.Produtor).WithMany(produtor => produtor.Propriedades).HasForeignKey("IdProdutor");
            builder.Entity<Propriedade>().Property(propriedade => propriedade.IncricaoEstadual).HasMaxLength(10).IsRequired(); ;
            builder.Entity<Propriedade>().Property(propriedade => propriedade.Nome).HasMaxLength(50).IsRequired();

            builder.Entity<Endereco>().ToTable("Endereco");            
            builder.Entity<Endereco>().HasKey(endereco => endereco.IdEndereco);
            builder.Entity<Endereco>().Property(endereco => endereco.Rua).HasMaxLength(150).IsRequired();
            builder.Entity<Endereco>().Property(endereco => endereco.Numero).HasMaxLength(20).IsRequired();
            builder.Entity<Endereco>().HasOne(endereco => endereco.Municipio).WithMany(municipio => municipio.Endereco).HasForeignKey("IdMunicipio");

            builder.Entity<Produtor>().ToTable("Produtor");
            builder.Entity<Produtor>().Property(produtor => produtor.IdProdutor).HasColumnName("IdProdutor");
            builder.Entity<Produtor>().HasKey(produtor => produtor.IdProdutor);
            builder.Entity<Produtor>().HasOne(produtor => produtor.Endereco).WithMany(endereco => endereco.Produtores).HasForeignKey("IdMunicipio");
            builder.Entity<Produtor>().Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Produtor>().Property(p => p.CPF).HasMaxLength(11).IsRequired();

            /*builder.Entity<Propriedade>().ToTable("Propriedade");
            builder.Entity<Propriedade>().Property(p => p.IdPropriedade).HasColumnName("IdPropriedade");
            builder.Entity<Propriedade>().HasKey(p => p.IdPropriedade);            
            builder.Entity<Propriedade>().HasOne(e => e.Endereco).WithOne().HasForeignKey<Endereco>(c => c.IdEndereco).HasConstraintName("Endereco");
            builder.Entity<Propriedade>().HasMany<Produtor>().WithOne().HasForeignKey(p => p.IdProdutor).HasConstraintName("Produtor");
            builder.Entity<Propriedade>().Navigation(p => p.Endereco).UsePropertyAccessMode(PropertyAccessMode.Property);
            //builder.Entity<Propriedade>().Navigation(p => p.Produtor).UsePropertyAccessMode(PropertyAccessMode.Property);
            builder.Entity<Propriedade>().Property(p => p.IncricaoEstadual).HasMaxLength(10).IsRequired(); ;
            builder.Entity<Propriedade>().Property(p => p.Nome).HasMaxLength(50).IsRequired(); ;

            builder.Entity<Endereco>().ToTable("Endereco");
            builder.Entity<Endereco>().Property(p => p.IdEndereco).HasColumnName("IdEndereco");
            builder.Entity<Endereco>().HasKey(e => e.IdEndereco);           
            builder.Entity<Endereco>().Property(e => e.Rua).HasMaxLength(150).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Numero).HasMaxLength(20).IsRequired();
            builder.Entity<Endereco>().HasMany<Municipio>().WithOne();   
            builder.Entity<Endereco>().Navigation(e => e.Municipio).UsePropertyAccessMode(PropertyAccessMode.Property);


            builder.Entity<Produtor>().ToTable("Produtor");
            builder.Entity<Produtor>().Property(p => p.IdProdutor).HasColumnName("IdProdutor");
            builder.Entity<Produtor>().HasKey(p => p.IdProdutor);           
            builder.Entity<Produtor>().Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<Produtor>().Property(p => p.CPF).HasMaxLength(11).IsRequired();
            //builder.Entity<Produtor>().HasOne(e => e.Endereco).WithOne().HasForeignKey<Produtor>(c => c.Endereco).HasConstraintName("Endereco");
            */
        }
    }
}
