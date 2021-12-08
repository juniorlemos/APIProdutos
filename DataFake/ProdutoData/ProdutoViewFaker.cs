using Bogus;
using Modelo.Application.DTOs.ModelView;

namespace DataFake.ProdutoData
{
    public class ProdutoViewFaker : Faker<ProdutoView>
    {
        public ProdutoViewFaker()
        {
            var produtoViewFaker = new Faker<ProdutoView>("pt_BR")
               .RuleFor(c => c.Id, f => f.IndexFaker)
               .RuleFor(c => c.Nome, f => f.Commerce.Product());

        }
    }
}
