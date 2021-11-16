using APIProduto.Controllers;
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application.DTOs;
using Modelo.Application.Interfaces;
using Modelo.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.ModeloAPITest.Controllers
{
    public class ProdutosControllerTest
    {

        private readonly IApplicationServiceProduto _applicationServiceProduto;
        private readonly ProdutosController _produtosController;
        private readonly Produto _produto;
        private readonly List<Produto> _listaproduto;
        private readonly ProdutoDto _produtoDto;
        private readonly List<ProdutoDto> _listaprodutosDto;

        public ProdutosControllerTest()
        {
            _applicationServiceProduto = Substitute.For<IApplicationServiceProduto>();
            _produtosController = new ProdutosController(_applicationServiceProduto);

            _produto = new ProdutoFaker().Generate();
            _produtoDto = new ProdutoDtoFaker().Generate();

            _listaproduto = new ProdutoFaker().Generate(20);
            _listaprodutosDto = new ProdutoDtoFaker().Generate(20);
        }

        [Fact]

        public async Task Controller__Metodo_GetId__Return_Ok_()
        {

            _applicationServiceProduto.SelectByIdAsync(Arg.Any<int>()).Returns(_produto);

            
            var produto = (ObjectResult)await _produtosController.GetId(_produto.Id);

            produto.StatusCode.Should().Be(StatusCodes.Status200OK);

        }
        
        [Fact]

        public async Task Controller__Metodo_GetId__Return_NotFound_()
        {

            _applicationServiceProduto.SelectByIdAsync(Arg.Any<int>()).ReturnsNull();



            var produto = (ObjectResult)await _produtosController.GetId(_produto.Id);

            produto.StatusCode.Should().Be(StatusCodes.Status404NotFound);

        }


        [Fact]

        public async Task Controller__Metodo_Delete__Return_NotContent_()
        {

            _applicationServiceProduto.DeleteAsync(Arg.Any<int>()).Returns(_produto);



            var produto = await _produtosController.Delete(_produto.Id);

            produto.Should().BeOfType<NoContentResult>();
       

        }



        [Fact]

        public async Task Controller__Metodo_Delete__Return_NotFound_()
        {

            _applicationServiceProduto.DeleteAsync(Arg.Any<int>()).ReturnsNull();



            var produto = await _produtosController.Delete(_produto.Id);

            produto.Should().BeOfType<NotFoundResult>();

        }




    }
}
