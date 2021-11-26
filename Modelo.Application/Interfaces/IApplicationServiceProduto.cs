using Canducci.Pagination;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        Task<ProdutoView> InsertAsync(ProdutoDto produtoDto);

        Task<ProdutoView> UpdateAsync(AlteraProdutoDto produtoDto);

      
        Task<PaginatedRest<ProdutoView>> SelectAllAsync(int page , int itens);
        Task<ProdutoView> DeleteAsync(int id);

        Task<ProdutoView> SelectByIdAsync(int id);
    }
}
