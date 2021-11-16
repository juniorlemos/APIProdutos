using Microsoft.Extensions.DependencyInjection;
using Modelo.Application;
using Modelo.Application.Interfaces;
using Modelo.Domain.Interfaces.Services;
using Modelo.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureService
    {

        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped<IApplicationServiceProduto, ApplicationServiceProduto>();


        }
    }
}
