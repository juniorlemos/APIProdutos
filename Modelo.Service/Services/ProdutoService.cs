using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Domain.Interfaces.Services;

namespace Modelo.Service.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
       

        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {

            
        }


    }






}
