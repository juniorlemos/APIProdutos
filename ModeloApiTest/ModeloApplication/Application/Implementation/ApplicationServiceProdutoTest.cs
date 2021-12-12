using AutoMapper;
using Canducci.Pagination;
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Modelo.Application;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Application.Mappers;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.Application
{
    public class ApplicationServiceProdutoTest
    {
        private readonly IProdutoService _serviceProduto;
        private readonly IMapper _mapper;
        private readonly ApplicationServiceProduto _applicationServiceProduto;
        private readonly Produto _produto;
        private readonly ProdutoDto _produtoDto;
        private readonly AlteraProdutoDto _alteraProdutoDto;
        private readonly List<Produto> _listaprodutos;
       
        private readonly ILogger<ApplicationServiceProduto> _logger;
        public ApplicationServiceProdutoTest()
        {
            _serviceProduto = Substitute.For<IProdutoService>();
            _logger = Substitute.For<ILogger<ApplicationServiceProduto>>();
            _mapper = new MapperConfiguration(p => p.AddProfile<MappingProfileProduto>()).CreateMapper();
            _applicationServiceProduto = new ApplicationServiceProduto(_serviceProduto, _mapper, _logger);
            _produto = new ProdutoFaker().CriarFakes().First() ;
            _produtoDto = new ProdutoDtoFaker().CriarFakes().First();
            _alteraProdutoDto = new AlteraProdutoDtoFaker().CriarFakes().First();
            _listaprodutos = new ProdutoFaker().CriarFakes();
            

        }



        [Fact]

        public async Task ApplicationServiceProduto__Metodo_SelectByIdAsync__Return_Produto_()
        {

            _serviceProduto.SelectByIdAsync(Arg.Any<int>()).Returns(_produto);
            var controle = _mapper.Map<ProdutoView>(_produto);


            var produto = await _applicationServiceProduto.SelectByIdAsync(_produto.Id);



            produto.Should().BeEquivalentTo(controle);

        }

        [Fact]

        public async Task ApplicationServiceProduto__Metodo_DeleteIdAsync__Return_Sucesso_()
        {

            _serviceProduto.DeleteAsync(Arg.Any<int>()).Returns(_produto);

            var controle = _mapper.Map<ProdutoView>(_produto);



            var produto = await _applicationServiceProduto.DeleteAsync(_produto.Id);

            produto.Should().BeEquivalentTo(controle);

        }

        [Fact]

        public async Task ApplicationServiceProduto__Metodo_InsertAsync__Return_Produto_()
        {

            _serviceProduto.InsertAsync(Arg.Any<Produto>()).Returns(_produto);

            var controle = _mapper.Map<ProdutoView>(_produto);


            var produto = await _applicationServiceProduto.InsertAsync(_produtoDto);

            produto.Should().BeEquivalentTo(controle);

        }

        [Fact]
        public async Task ApplicationServiceProduto__Metodo_UpdateAsync__Return_Produto_()
        {
            var controle = _mapper.Map<ProdutoView>(_produto);

            _serviceProduto.UpdateAsync(Arg.Any<Produto>()).Returns(_produto);


            var produto = await _applicationServiceProduto.UpdateAsync(_alteraProdutoDto);

            produto.Should().BeEquivalentTo(controle);

        }


        [Fact]
        public async Task ApplicationServiceProduto__Metodo_SelectAllAsync__Return_PaginatedRest_Produto_()
        {
            Random paginaEprodutos = new Random();

            _serviceProduto.SelectAllAsync().Returns(_listaprodutos);

            var produto = await _applicationServiceProduto.SelectAllAsync(paginaEprodutos.Next(), paginaEprodutos.Next());

            produto.Should().BeOfType<PaginatedRest<ProdutoView>>();

        }

    }
}
