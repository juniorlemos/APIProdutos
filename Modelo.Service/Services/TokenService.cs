﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Modelo.Application.DTOs;
using Modelo.Domain.Interfaces.Services;

namespace Modelo.Service.Services
{
    public  class TokenService :ITokenService<UsuarioAutenticacaoDto>
    {
        public  string GenerateToken(UsuarioAutenticacaoDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenServiceSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                  
                }),
                Expires = DateTime.UtcNow.AddHours(TokenServiceSettings.Expiration),
                Issuer = TokenServiceSettings.myIssuer,
                Audience = TokenServiceSettings.myAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

