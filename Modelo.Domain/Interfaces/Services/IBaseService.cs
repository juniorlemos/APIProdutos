using Modelo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Services
{

    public interface IBaseService<T> where T : BaseEntidade
    {



        Task<T> UpdateAsync(T entity);
        Task<T> SelectByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> DeleteAsync(int id);



    }
}

