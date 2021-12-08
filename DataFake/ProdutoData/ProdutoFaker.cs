using Bogus;
using Modelo.Domain.Entities;

namespace DataFake.ProdutoData
{
    public class ProdutoFaker : Faker<Produto>
    {
        public ProdutoFaker()
        {
            var produtoFaker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Nome, f => f.Commerce.Product());
        }
    }
}
