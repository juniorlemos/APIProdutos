using AutoMapper;
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.ModeloAPITest.Application
{
   public class ApplicationServiceProdutoTest
    {
        private readonly IProdutoService _serviceProduto;
        private readonly IMapper _mapper;
        private readonly ApplicationServiceProduto _applicationServiceProduto;
        private readonly Produto _produto;

        public ApplicationServiceProdutoTest()
        {
            _serviceProduto = Substitute.For<IProdutoService>();
            _mapper = Substitute.For<IMapper>();
            _applicationServiceProduto = new ApplicationServiceProduto(_serviceProduto, _mapper);
            _produto = new ProdutoFaker().Generate();


        }



        [Fact]

        public async Task ApplicationServiceProduto__Metodo_SelectByIdAsync__Return_Produto_()
        {

            _serviceProduto.SelectByIdAsync(Arg.Any<int>()).Returns(_produto);


            var produto = await _applicationServiceProduto.SelectByIdAsync(_produto.Id);

            produto.Should().BeSameAs(_produto);

        }

        [Fact]

        public async Task ApplicationServiceProduto__Metodo_DeleteIdAsync__Return_NotNull_()
        {

            _serviceProduto.DeleteAsync(Arg.Any<int>()).Returns(_produto);


            var produto = await _applicationServiceProduto.DeleteAsync(_produto.Id);

            produto.Should().NotBeNull();

        }



    }
}
