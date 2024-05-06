using LoremIpsumLogistica2.Models;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado em tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Configuração do banco de dados
            services.AddDbContext<ApplicationDbContext>();

            services.AddControllers();
        }

        // Este método é chamado em tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Página de erro personalizada em produção
                app.UseExceptionHandler("/Error");
                // Redireciona solicitações HTTP para HTTPS
                app.UseHsts();
            }

            // Redireciona todas as solicitações HTTP para HTTPS
            app.UseHttpsRedirection();

            // Middleware para roteamento de solicitações HTTP
            app.UseRouting();

            // Middleware para autorização
            app.UseAuthorization();

            // Define os endpoints da aplicação
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

