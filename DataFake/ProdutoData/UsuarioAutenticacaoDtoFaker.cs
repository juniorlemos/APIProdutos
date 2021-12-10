using Bogus;
using Modelo.Application.DTOs;
using System.Collections.Generic;

namespace DataFake.ProdutoData
{
    public class UsuarioAutenticacaoDtoFaker : Faker<UsuarioAutenticacaoDto>
    {
      
        public List<UsuarioAutenticacaoDto> CriarFakers (){


            var UsuarioAtenticacaoDtoFaker = new Faker<UsuarioAutenticacaoDto>("pt_BR")


               .RuleFor(u => u.Username, f => f.Name.FirstName())
               .RuleFor(u => u.Password, f => f.Internet.Password()).Generate(50);

            return UsuarioAtenticacaoDtoFaker;
        }

    }
}
