using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAngular
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add Cros-origin.
            services.AddCorsForAngular(_configuration);

            // Add Cache Responsivo em memoria.
            services.AddResponseCaching();

            //Add Configuração JSON Response.
            services.AddWebApi();

            // Add BD
            services.AddContextApp(_configuration);

            // Add IoC
            services.AddNativeInjectorBootstrapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // usa CORS na rota do angular 4200
            app.UseCors("CorsPolicy");
            // usa o Cache Responsivo
            app.UseResponseCaching();
            // usa mvc com as rotas padrão.
            app.UseMvcWithDefaultRoute();
        }
    }
}