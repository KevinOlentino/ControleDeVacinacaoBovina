using ControleDeVacinacaoBovina.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVacinacaoBovina.DbMappings
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
        public DbSet<Rebanho> Rebanhos { get; set; }
        public DbSet<TipoDeEntrada> TipoDeEntradas { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ProdutorEntityTypeConfiguration().Configure(builder.Entity<Produtor>());
            new EnderecoEntityTypeConfiguration().Configure(builder.Entity<Endereco>());
            new PropriedadeEntityTypeConfiguration().Configure(builder.Entity<Propriedade>());
            new MunicipioEntityTypeConfiguration().Configure(builder.Entity<Municipio>());
            new AnimalEntityTypeConfiguration().Configure(builder.Entity<Animal>());
            new RegistroVacinaEntityTypeConfiguration().Configure(builder.Entity<RegistroVacinacao>());
            new VendaEntityTypeConfiguration().Configure(builder.Entity<Venda>());
            new EspecieEntityTypeConfiguration().Configure(builder.Entity<Especie>());
            new FinalidadeDeVendaEntityTypeConfiguration().Configure(builder.Entity<FinalidadeDeVenda>());
            new VacinaEntityTypeConfiguration().Configure(builder.Entity<Vacina>());
            new RebanhoEntityTypeConfiguration().Configure(builder.Entity<Rebanho>());
            new TipoDeEntradaEntityTypeConfiguration().Configure(builder.Entity<TipoDeEntrada>());
        }
    }
}
