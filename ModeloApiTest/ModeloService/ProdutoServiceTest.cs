using DataFake.ProdutoData;
using FluentAssertions;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Service.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.ModeloService
{
   public class ProdutoServiceTest
    {
        private readonly IProdutoRepository _repository;
        private readonly ProdutoService _produtoService;
        private readonly Produto _produto;
        private readonly List<Produto> _listaprodutos;

        public ProdutoServiceTest()
        {
            _repository = Substitute.For<IProdutoRepository>();
            _produtoService = new ProdutoService(_repository);
            _produto = new ProdutoFaker().Generate();
            _listaprodutos = new ProdutoFaker().Generate(20);
        }

        [Fact]

        public async Task ProdutoService__Metodo_SelectByIdAsync__Return_Produto_()
        {

            _repository.SelectByIdAsync(Arg.Any<int>()).Returns(_produto);


            var produto = await _produtoService.SelectByIdAsync(_produto.Id);

            produto.Should().BeSameAs(_produto);

        }
        
        [Fact]

        public async Task ProdutoService__Metodo_Delete__Return_NotNull_()
        {

            _repository.DeleteAsync(Arg.Any<int>()).Returns(_produto);


            var produto = await _produtoService.DeleteAsync(_produto.Id);

            produto.Should().NotBeNull();

        }
        [Fact]

        public async Task ProdutoService__Metodo_InsertAsync__Return_Produto_()
        {

            _repository.InsertAsync(Arg.Any<Produto>()).Returns(_produto);


            var produto = await _produtoService.InsertAsync(_produto);

            produto.Should().BeSameAs(_produto);

        }
    
    [Fact]

    public async Task ProdutoService__Metodo_UpdateAsync__Return_Produto_()
    {

        _repository.UpdateAsync(Arg.Any<Produto>()).Returns(_produto);


        var produto = await _produtoService.UpdateAsync(_produto);

        produto.Should().BeSameAs(_produto);

    }

        [Fact]
        public async Task ProdutoService__Metodo_SelectAllAsync__Return_NotEmpty_()
        {

            _repository.SelectAllAsync().Returns(_listaprodutos);


            var produto = await _produtoService.SelectAllAsync();

            produto.Should().NotBeEmpty();

        }

    }
}

