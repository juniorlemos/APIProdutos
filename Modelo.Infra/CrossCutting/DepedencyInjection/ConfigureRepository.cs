using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using Modelo.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));


            var connectionString = "Server=localhost;Database=ApiPro2;Uid=root;Pwd=cesar;";
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        }
    }
}
