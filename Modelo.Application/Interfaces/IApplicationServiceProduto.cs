using Canducci.Pagination;
using Modelo.Application.DTOs;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        Task InsertAsync(ProdutoDto produtoDto);

        Task UpdateAsync(ProdutoDto produtoDto);
        
        Task<PaginatedRest<ProdutoDto>> SelectAllAsync(int page , int itens);
        Task DeleteAsync(int id);

        Task<ProdutoDto> SelectByIdAsync(int id);
    }
}
