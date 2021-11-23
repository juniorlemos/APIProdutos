using Modelo.Application.DTOs;
using Modelo.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentValidation.TestHelper;


namespace ModeloApiTest.ModeloApplication.DTOs
{
   public class ProdutoDtoTest
    {
        


        [Fact]

        public void ProdutoDtoErroNaValidacaoMenosde4Caracteres()
        {

            ProdutoDto produto = new ProdutoDto { Nome = "fer"};


             ProdutoDtoValidator  validator = new ProdutoDtoValidator();

            var result =  validator.TestValidate(produto);

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
