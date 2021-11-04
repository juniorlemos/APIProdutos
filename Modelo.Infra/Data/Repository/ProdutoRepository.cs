using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context)
            : base(context)
        {

        }

    }
}
