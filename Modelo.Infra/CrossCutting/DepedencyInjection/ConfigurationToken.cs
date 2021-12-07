using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Modelo.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.CrossCutting.DepedencyInjection
{
   public static class ConfigurationToken
    {
        public static void AuthenticationTokenConfiguration(this IServiceCollection serviceCollection) {

            var key = Encoding.ASCII.GetBytes(TokenServiceSettings.Secret);
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })

               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = true,
                       ValidateAudience = true
                   };

               });

        }
}
}
