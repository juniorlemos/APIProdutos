using APIProduto.Controllers;
using DataFake.ProdutoData;
using Modelo.Application.DTOs;
using Modelo.Application.Interfaces;
using Modelo.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

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
            _listaprodutosDto= new ProdutoDtoFaker().Generate(20);
        }
    }
}
