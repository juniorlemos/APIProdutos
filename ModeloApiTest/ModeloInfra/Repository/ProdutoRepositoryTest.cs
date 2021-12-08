
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using Modelo.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.ModeloInfra.Repository
{
    public class ProdutoRepositoryTest : IDisposable
    {
        private readonly IProdutoRepository _repository;
        private readonly Produto _produto;
        private readonly ApplicationDbContext context;
        private readonly List<Produto> _listaprodutos;

        public ProdutoRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _produto = new ProdutoFaker().Generate();

            context = new ApplicationDbContext(optionsBuilder.Options);
            _repository = new ProdutoRepository(context);
            _listaprodutos = new ProdutoFaker().Generate(100);
        }



        private async Task<List<Produto>> InsereRegistros()
        {
            var produtos = _listaprodutos;
            foreach (var cli in _listaprodutos)
            {
                cli.Id = 0;
                await context.Produtos.AddAsync(cli);
            }
            await context.SaveChangesAsync();
            return produtos;
        }


        [Fact]
        public async Task Repository_Produto_SelectAll_Return_AllAsync()
        {


            var registros = await InsereRegistros();
            var produtos = await _repository.SelectAllAsync();


            produtos.Should().HaveCount(registros.Count());
        }



        [Fact]
        public async Task Repository_Produto_SelectById_Return_Produto()
        {


            var registros = await InsereRegistros();
            var produtos = await _repository.SelectByIdAsync(registros.First().Id);


            produtos.Should().BeSameAs(registros.First());
        }

        [Fact]
        public async Task Repository_Produto_Insert_Return_Produto()
        {



            var produtos = await _repository.InsertAsync(_produto);


            produtos.Should().BeSameAs(_produto);
        }


        [Fact]
        public async Task Repository_Produto_Update_Return_Null()
        {



            var produtos = await _repository.UpdateAsync(_produto);


            produtos.Should().BeNull();
        }

        [Fact]
        public async Task Repository_Produto_Update_Return_Produto()
        {

            var registros = await InsereRegistros();

            var produtoalterado = new ProdutoFaker().Generate();
            produtoalterado.Id = registros.First().Id;

            var produtos = await _repository.UpdateAsync(produtoalterado);


            produtos.Should().BeEquivalentTo(produtoalterado);
        }



        [Fact]
        public async Task Repository_Produto_Delete_Return_Null()
        {


            var produtos = await _repository.DeleteAsync(_produto.Id);


            produtos.Should().BeNull();
        }



        [Fact]
        public async Task Repository_Produto_Delete_Return_Produto()
        {

            var registros = await InsereRegistros();
            var produtos = await _repository.DeleteAsync(registros.First().Id);


            produtos.Should().BeSameAs(registros.First());
        }



        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
