using Bogus;
using Modelo.Domain.Entities;
using System.Collections.Generic;

namespace DataFake.ProdutoData
{
    public class ProdutoFaker : Faker<Produto>
    {
        

        public List<Produto> CriarFakes() {
            
            var produtoFaker = new Faker<Produto>("pt_BR")
                  .RuleFor(c => c.Id, f => f.IndexFaker)
                  .RuleFor(c => c.Nome, f => f.Commerce.Product()).Generate(50);

            return produtoFaker;
        }
    }
}
