using FluentValidation.TestHelper;
using Modelo.Application.DTOs;
using Modelo.Application.Validators;
using Xunit;

namespace ModeloApiTest.ModeloApplication.DTOs
{
    public class AlteraProdutoDTOTest
    {
        [Fact]

        public void ProdutoDtoErroNaValidacaovalorIdMenorQueUm()
        {

            AlteraProdutoDto alteraproduto = new AlteraProdutoDto { Id = 0, Nome = "fernando" };


            AlteraProdutoDtoValidator validator = new AlteraProdutoDtoValidator();

            var result = validator.TestValidate(alteraproduto);

            result.ShouldHaveValidationErrorFor(x => x.Id);

        }





        [Fact]
        public void ProdutoDtoErroNaValidacaoNomeComValorNull()
        {

            AlteraProdutoDto alteraproduto = new AlteraProdutoDto { Id = 3, Nome = null };


            AlteraProdutoDtoValidator validator = new AlteraProdutoDtoValidator();

            var result = validator.TestValidate(alteraproduto);

            result.ShouldHaveValidationErrorFor(x => x.Nome);

        }


        [Fact]

        public void ProdutoDtoValidaçãoFeitaComSucesso()
        {

            AlteraProdutoDto alteraproduto = new AlteraProdutoDto { Id = 1, Nome = "junior lemos" };


            AlteraProdutoDtoValidator validator = new AlteraProdutoDtoValidator();

            var result = validator.TestValidate(alteraproduto);


            result.ShouldNotHaveAnyValidationErrors();

        }

    }
}
