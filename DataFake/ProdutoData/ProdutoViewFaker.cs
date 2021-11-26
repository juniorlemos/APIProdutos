using Bogus;
using Modelo.Application.DTOs.ModelView;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFake.ProdutoData
{
  public  class ProdutoViewFaker : Faker<ProdutoView>
    {
        public ProdutoViewFaker()
        {
            var produtoViewFaker = new Faker<ProdutoView>("pt_BR")
               .RuleFor(c => c.Id, f => f.IndexFaker)
               .RuleFor(c => c.Nome, f => f.Commerce.Product());

        }   
    }
}
