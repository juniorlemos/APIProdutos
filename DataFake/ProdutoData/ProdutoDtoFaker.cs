using Bogus;
using Modelo.Application.DTOs;
using System.Collections.Generic;

namespace DataFake.ProdutoData
{
    public class ProdutoDtoFaker : Faker<ProdutoDto>
    {
      


        public List<ProdutoDto> CriarFakes()
        {

            var produtoFaker = new Faker<ProdutoDto>("pt_BR")
                 .RuleFor(c => c.Nome, f => f.Commerce.Product()).Generate(60);

            return produtoFaker;
        }
    }
}
