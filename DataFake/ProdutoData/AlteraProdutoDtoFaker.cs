using Bogus;
using Modelo.Application.DTOs;
using System.Collections.Generic;

namespace DataFake.ProdutoData
{
    public class AlteraProdutoDtoFaker : Faker<AlteraProdutoDto>
    {
        

        public List<AlteraProdutoDto> CriarFakes()
        {

            var AlteraProdutoDtoFaker = new Faker<AlteraProdutoDto>("pt_BR")
              .RuleFor(c => c.Id, f => f.IndexFaker)
              .RuleFor(c => c.Nome, f => f.Commerce.Product()).Generate(50);


            return AlteraProdutoDtoFaker;
        }
    }
}
