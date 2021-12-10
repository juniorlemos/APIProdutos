using Bogus;
using Modelo.Application.DTOs.ModelView;
using System.Collections.Generic;

namespace DataFake.ProdutoData
{
    public class ProdutoViewFaker : Faker<ProdutoView>
    {



        public List<ProdutoView> CriarFakes() 
        {
            var produtoViewFaker = new Faker<ProdutoView>("pt_BR")
                   .RuleFor(c => c.Id, f => f.IndexFaker)
                   .RuleFor(c => c.Nome, f => f.Commerce.Product()).Generate(60) ;

            return produtoViewFaker;
        } 

    }
}
