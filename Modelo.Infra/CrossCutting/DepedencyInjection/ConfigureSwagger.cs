using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureSwagger
    {

        public static void AddSwaggerConfigure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(x =>
            {
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


              //  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, "APIProduto.xml");
                //x.IncludeXmlComments(xmlPath);
                //xmlPath = Path.Combine(AppContext.BaseDirectory, "Modelo.Application.xml");
                //x.IncludeXmlComments(xmlPath);


            });


        }
        public static void UseSwaggerConfigure(this IApplicationBuilder app)
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
