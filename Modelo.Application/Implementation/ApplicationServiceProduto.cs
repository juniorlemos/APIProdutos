using AutoMapper;
using Canducci.Pagination;
using Microsoft.Extensions.Logging;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Application.Interfaces;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {

        private readonly IProdutoService _serviceProduto;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicationServiceProduto> _logger;


        public ApplicationServiceProduto(IProdutoService serviceProduto, IMapper mapper, ILogger<ApplicationServiceProduto> logger)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProdutoView> InsertAsync(ProdutoDto produtoDto)
        {
           
            var produto = _mapper.Map<Produto>(produtoDto);
            produto= await _serviceProduto.InsertAsync(produto);
            return _mapper.Map<ProdutoView>(produto);
        }

        public async Task<ProdutoView> SelectByIdAsync(int id)
        {
            var produto = await _serviceProduto.SelectByIdAsync(id);
            
            return _mapper.Map<ProdutoView>(produto);
        }


        public async Task<PaginatedRest<ProdutoView>> SelectAllAsync(int page, int itens)
        {
            var produtos = await _serviceProduto.SelectAllAsync();
            var produtosView = _mapper.Map<List<ProdutoView>>(produtos);

            var produtosPaginados = produtosView.OrderBy(c => c.Id).ToPaginatedRest(page, itens);


            return produtosPaginados;
        }



        public async Task<ProdutoView> DeleteAsync(int id)
        {

            var produto =await _serviceProduto.DeleteAsync(id);
            return _mapper.Map<ProdutoView>(produto);

        }

        public async Task <ProdutoView> UpdateAsync(AlteraProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            produto = await _serviceProduto.UpdateAsync(produto);
            return _mapper.Map<ProdutoView>(produto);
        }

      
    }
}
