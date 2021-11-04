using Modelo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        Task Add(ProdutoDto produtoDto);

        Task Update(ProdutoDto produtoDto);

        Task Remove(int id);

        Task<ProdutoDto> GetById(int id);
    }
}
