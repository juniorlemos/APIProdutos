using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureIdentity
    {
        public static void AddIdentityConfigure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<IdentityUser, IdentityRole>(options =>
            {

                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;

            })
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
                   .AddDefaultTokenProviders();
        }
    }
}
