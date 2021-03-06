using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using Modelo.Infra.Data.Repository;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepositoryBase<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient(typeof(IProdutoRepository), typeof(ProdutoRepository));


            var connectionString = "Server=localhost;Database=ApiPro2;Uid=root;Pwd=cesar;";
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        }
    }
}
