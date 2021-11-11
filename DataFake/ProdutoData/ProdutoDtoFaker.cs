using Bogus;
using Modelo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFake.ProdutoData
{
    public class ProdutoDtoFaker : Faker<ProdutoDto>
    {
        public ProdutoDtoFaker()
        {
            var produtoDtoFaker = new Faker<ProdutoDto>("pt_BR")
               .RuleFor(c => c.Id, f => f.IndexFaker)
               .RuleFor(c => c.Nome, f => f.Commerce.Product());
        }
    }
}
