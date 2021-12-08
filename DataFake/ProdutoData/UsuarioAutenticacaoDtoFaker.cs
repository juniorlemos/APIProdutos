using Bogus;
using Modelo.Application.DTOs;

namespace DataFake.ProdutoData
{
    public class UsuarioAutenticacaoDtoFaker : Faker<UsuarioAutenticacaoDto>
    {
        public UsuarioAutenticacaoDtoFaker()
        {


            var UsuarioAtenticacaoDtoFaker = new Faker<UsuarioAutenticacaoDto>("pt_BR")


            .RuleFor(u => u.Username, f => f.Name.FirstName())
            .RuleFor(u => u.Password, f => f.Internet.Password());


        }

    }
}
