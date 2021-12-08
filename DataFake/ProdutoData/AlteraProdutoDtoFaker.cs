using Bogus;
using Modelo.Application.DTOs;

namespace DataFake.ProdutoData
{
    public class AlteraProdutoDtoFaker : Faker<AlteraProdutoDto>
    {
        public AlteraProdutoDtoFaker()
        {
            var AlteraProdutoDtoFaker = new Faker<AlteraProdutoDto>("pt_BR")
              .RuleFor(c => c.Id, f => f.IndexFaker)
              .RuleFor(c => c.Nome, f => f.Commerce.Product());

        }
    }
}
