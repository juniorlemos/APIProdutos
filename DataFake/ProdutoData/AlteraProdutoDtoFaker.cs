using Bogus;
using Modelo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFake.ProdutoData
{
  public  class AlteraProdutoDtoFaker : Faker<AlteraProdutoDto>
    {
        public AlteraProdutoDtoFaker()
        {
            var AlteraProdutoDtoFaker = new Faker<AlteraProdutoDto>("pt_BR")
              .RuleFor(c => c.Id, f => f.IndexFaker)
              .RuleFor(c => c.Nome, f => f.Commerce.Product());
                        
        }
    }
}
