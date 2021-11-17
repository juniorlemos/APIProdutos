using AutoMapper;
using Canducci.Pagination;
using Modelo.Application.DTOs;
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


        public ApplicationServiceProduto(IProdutoService serviceProduto, IMapper mapper)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
        }

        public async Task<Produto> InsertAsync(ProdutoDto produtoDto)
        {
           
            var produto = _mapper.Map<Produto>(produtoDto);
            return await _serviceProduto.InsertAsync(produto);
        }

        public async Task<Produto> SelectByIdAsync(int id)
        {
            var produto = await _serviceProduto.SelectByIdAsync(id);
            
            return produto;
        }


        public async Task<PaginatedRest<Produto>> SelectAllAsync(int page, int itens)
        {
            var produtos = await _serviceProduto.SelectAllAsync();
            

            var produtosPaginados = produtos.OrderBy(c => c.Id).ToPaginatedRest(page, itens);


            return produtosPaginados;
        }



        public async Task<Produto> DeleteAsync(int id)
        {

           return await _serviceProduto.DeleteAsync(id);

        }

        public async Task <Produto> UpdateAsync(AlteraProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
             return await _serviceProduto.UpdateAsync(produto);
        }

      
    }
}
