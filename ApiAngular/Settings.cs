using ApiAngular.Infra.Repository;
using ApiAngular.Infra.Repository.Context;
using ApiAngular.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ApiAngular
{
    public static class Settings
    {
        public static IServiceCollection AddCorsForAngular(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .WithOrigins(configuration["angular-web"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

            return services;
        }

        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
                {
                    // remove os valores nulos do retorno.
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    // ignorar os loops causados pelo ORM caso existam.
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services;
        }


        public static IServiceCollection AddContextApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiAngularContext>(opts =>
                opts.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));

            return services;
        }

        public static IServiceCollection AddNativeInjectorBootstrapper(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}