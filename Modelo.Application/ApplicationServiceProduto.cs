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

        public async Task InsertAsync(ProdutoDto produtoDto)
        {
           
            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.InsertAsync(produto);
        }

        public async Task<ProdutoDto> SelectByIdAsync(int id)
        {
            var produto = await _serviceProduto.SelectByIdAsync(id);
            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return produtoDto;
        }


        public async Task<PaginatedRest<ProdutoDto>> SelectAllAsync(int page, int itens)
        {
            var produtos = await _serviceProduto.SelectAllAsync();
            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);


            var produtosPaginados = produtosDto.OrderBy(c => c.Id).ToPaginatedRest(page, itens);




            return produtosPaginados;
        }



        public async Task DeleteAsync(int id)
        {

            await _serviceProduto.DeleteAsync(id);

        }

        public async Task UpdateAsync(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.UpdateAsync(produto);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _serviceProduto.ExistAsync(id);
        }
    }
}
