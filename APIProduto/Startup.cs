using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Modelo.Application.DTOs;
using Modelo.Application.Validators;
using Modelo.Infra.CrossCutting.DepedencyInjection;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto
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
            services.AddMvc()
   .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProdutoDto>());


            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            

            services.AddSwaggerGen(x => {
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

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi");
                x.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
