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
        Task<Produto> InsertAsync(ProdutoDto produtoDto);

        Task<Produto> UpdateAsync(AlteraProdutoDto produtoDto);

      
        Task<PaginatedRest<Produto>> SelectAllAsync(int page , int itens);
        Task<Produto> DeleteAsync(int id);

        Task<Produto> SelectByIdAsync(int id);
    }
}
