using Bogus;
using Modelo.Application.DTOs;

namespace DataFake.ProdutoData
{
    public class ProdutoDtoFaker : Faker<ProdutoDto>
    {
        public ProdutoDtoFaker()
        {
            var produtoDtoFaker = new Faker<ProdutoDto>("pt_BR")

               .RuleFor(c => c.Nome, f => f.Commerce.Product());
            
        }
    }
}
