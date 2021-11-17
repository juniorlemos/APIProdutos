using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
   public static class ConfigureSwagger
    {

        public static void AddSwaggerConfigure(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "1.0",
                    Title = "APIProdutos Versão 1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "juniorlemosoi@gmail.com",
                        Name = "Fernando Cesar",
                        Url = new Uri("https://github.com/juniorlemos")
                    },
                    Description = "API de Produtos para aprendizagem de arquitetura",

                });
            });


        }
        public static void UseSwaggerConfigure(IApplicationBuilder app)            
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi");
                x.RoutePrefix = string.Empty;
            });
        }
    }
}
