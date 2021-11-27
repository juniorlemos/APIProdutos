using APIProduto.Controllers;
using Canducci.Pagination;
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
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
        private readonly AlteraProdutoDto _alteraProdutoDto;
        private readonly ProdutoView _produtoView;

        private readonly PaginatedRest <ProdutoView> paginas;
        private readonly ILogger<ProdutosController> _logger;


        private readonly List<ProdutoDto> _listaprodutosDto;

        public ProdutosControllerTest()
        {
            

            _applicationServiceProduto = Substitute.For<IApplicationServiceProduto>();
            _logger = Substitute.For<ILogger<ProdutosController>>();
            _produtosController = new ProdutosController(_applicationServiceProduto, _logger);

            _alteraProdutoDto = new AlteraProdutoDtoFaker().Generate();
            _produto = new ProdutoFaker().Generate();
            _produtoDto = new ProdutoDtoFaker().Generate();
            _produtoView = new ProdutoViewFaker().Generate();


            _listaproduto = new ProdutoFaker().Generate(20);
            _listaprodutosDto = new ProdutoDtoFaker().Generate(20);

           

             
           
    }

        

        [Fact]

        public async Task Controller__Metodo_GetId__Return_Ok_()
        {

            _applicationServiceProduto.SelectByIdAsync(Arg.Any<int>()).Returns(_produtoView);

            
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

            _applicationServiceProduto.DeleteAsync(Arg.Any<int>()).Returns(_produtoView);



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


        [Fact]

        public async Task Controller__Metodo_Post__Return_Created_()
        {

            _applicationServiceProduto.InsertAsync(_produtoDto).Returns(_produtoView);



            var produto = (ObjectResult)await _produtosController.Post(_produtoDto);

            produto.StatusCode.Should().Be(StatusCodes.Status201Created);

        }


        [Fact]

        public async Task Controller__Metodo_Put__Return_Ok_()
        {

            _applicationServiceProduto.UpdateAsync(_alteraProdutoDto).Returns(_produtoView);



            var produto = (ObjectResult)await _produtosController.Put(_alteraProdutoDto);

            produto.StatusCode.Should().Be(StatusCodes.Status200OK);

        }



        [Fact]

        public async Task Controller__Metodo_Put__Return_NotFound_()
        {

            _applicationServiceProduto.UpdateAsync(_alteraProdutoDto).ReturnsNull();



            var produto = await _produtosController.Put(_alteraProdutoDto);

            produto.Should().BeOfType<NotFoundResult>();

        }



        [Fact]

        public async Task Controller__Metodo_GetAll__Return_ok_()
        {

            _applicationServiceProduto.SelectAllAsync(Arg.Any<int>(),Arg.Any<int>()).Returns(paginas);



            var produto = (ObjectResult)await _produtosController.GetAll();

            produto.StatusCode.Should().Be(StatusCodes.Status200OK);

        }
        [Fact]

        public async Task Controller__Metodo_GetAll__InputPage_0_Return_ok_()
        {

            _applicationServiceProduto.SelectAllAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(paginas);



            var produto = (ObjectResult)await _produtosController.GetAll(0);

            produto.StatusCode.Should().Be(StatusCodes.Status200OK);

        }
    }
}
