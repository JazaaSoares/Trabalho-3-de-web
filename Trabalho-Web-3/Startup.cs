using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Repositories;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Persistence;
using Trabalho_Web_3.Persistence.Repositories;
using Trabalho_Web_3.Services;

namespace Trabalho_Web_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("curriculo-api-in-memory");
            });

            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped<IExperienciaService, ExperienciaService>();

            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();

            services.AddScoped<IQualificacaoRepository, QualificacaoRepository>();
            services.AddScoped<IQualificacaoService, QualificacaoService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment enviroment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
