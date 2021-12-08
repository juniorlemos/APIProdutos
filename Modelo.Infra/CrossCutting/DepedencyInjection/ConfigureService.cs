using Microsoft.Extensions.DependencyInjection;
using Modelo.Application;
using Modelo.Application.Interfaces;
using Modelo.Domain.Interfaces.Services;
using Modelo.Service.Services;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureService
    {

        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped(typeof(ITokenService<>), typeof(TokenService<>));
            serviceCollection.AddScoped<IApplicationServiceProduto, ApplicationServiceProduto>();


        }
    }
}
