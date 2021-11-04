using AutoMapper;
using Modelo.Application.DTOs;
using Modelo.Application.Interfaces;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        public async Task Add(ProdutoDto produtoDto)
        {

           


            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.Insert(produto);
        }

        public async Task<ProdutoDto> GetById(int id)
        {
            var produto = await _serviceProduto.SelectById(id);
            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return produtoDto;
        }

        public async Task Remove(int id)
        {

            await _serviceProduto.Delete(id);

        }

        public async Task Update(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.Update(produto);
        }
    }
}
