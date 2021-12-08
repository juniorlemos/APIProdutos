using FluentValidation.TestHelper;
using Modelo.Application.DTOs;
using Modelo.Application.Validators;
using Xunit;


namespace ModeloApiTest.ModeloApplication.DTOs
{
    public class ProdutoDtoTest
    {



        [Fact]

        public void ProdutoDtoErroNaValidacaoMenosde4Caracteres()
        {

            ProdutoDto produto = new ProdutoDto { Nome = "fer" };


            ProdutoDtoValidator validator = new ProdutoDtoValidator();

            var result = validator.TestValidate(produto);

            result.ShouldHaveAnyValidationError();

        }

        [Fact]

        public void ProdutoDtoValidaçãoFeitaComSucesso()
        {

            ProdutoDto produto = new ProdutoDto { Nome = "fernando cesar" };


            ProdutoDtoValidator validator = new ProdutoDtoValidator();

            var result = validator.TestValidate(produto);

            result.ShouldNotHaveAnyValidationErrors();

        }


    }
}
