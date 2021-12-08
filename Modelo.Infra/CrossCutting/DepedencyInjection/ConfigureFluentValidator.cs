using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Application.DTOs;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
    public static class ConfigureFluentValidator
    {

        public static void AddFLuentValidatorConfigure(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddControllers()
              .AddFluentValidation(fv =>
              {
                  fv.RegisterValidatorsFromAssemblyContaining<ProdutoDto>();
                  fv.RegisterValidatorsFromAssemblyContaining<AlteraProdutoDto>();
                  fv.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
              });


        }
    }

}

