using ControleDeVacinacaoBovina.Models;
using ControleDeVacinacaoBovina.Repositories.Animais;
using ControleDeVacinacaoBovina.Repositories.Enderecos;
using ControleDeVacinacaoBovina.Repositories.Especies;
using ControleDeVacinacaoBovina.Repositories.FinalidadeDeVendas;
using ControleDeVacinacaoBovina.Repositories.Municipios;
using ControleDeVacinacaoBovina.Repositories.Produtores;
using ControleDeVacinacaoBovina.Repositories.Propriedades;
using ControleDeVacinacaoBovina.Repositories.RegistrosVacinas;
using ControleDeVacinacaoBovina.Repositories.Vacinas;
using ControleDeVacinacaoBovina.Repository.Vendas;
using ControleDeVacinacaoBovina.Services.Animais;
using ControleDeVacinacaoBovina.Services.Enderecos;
using ControleDeVacinacaoBovina.Services.Especies;
using ControleDeVacinacaoBovina.Services.FinalidadeDeVendas;
using ControleDeVacinacaoBovina.Services.Municipios;
using ControleDeVacinacaoBovina.Services.Produtores;
using ControleDeVacinacaoBovina.Services.Propriedades;
using ControleDeVacinacaoBovina.Services.RegistrosVacinas;
using ControleDeVacinacaoBovina.Services.Vacinas;
using ControleDeVacinacaoBovina.Services.Vendas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ControleDeVacinacaoBovina
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                   
            services.AddDbContext<Contexto>(option => option.UseSqlServer(Configuration.GetConnectionString("DbContext")));
            
            services.AddScoped<IPropriedadeService, PropriedadeService>();
            services.AddScoped<IPropriedadeRepository, PropriedadeRepository>();

            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();

            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();

            services.AddScoped<IProdutorService, ProdutorService>();
            services.AddScoped<IProdutorRepository, ProdutorRepository>();

            services.AddScoped<IEspecieService, EspecieService>();
            services.AddScoped<IEspecieRepository, EspecieRepository>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IVacinaService, VacinaService>();
            services.AddScoped<IVacinaRepository, VacinaRepository>();

            services.AddScoped<IRegistroVacinaService, RegistroVacinaService>();
            services.AddScoped<IRegistroVacinaRepository, RegistroVacinaRepository>();

            services.AddScoped<IFinalidadeDeVendasService, FinalidadeDeVendasService>();
            services.AddScoped<IFinalidadeDeVendaRepository, FinalidadeDeVendaRepository>();

            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.AddCors(options => options.AddDefaultPolicy(
                        builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin()
                        ));
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControleDeVacinacaoBovina", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleDeVacinacaoBovina v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
