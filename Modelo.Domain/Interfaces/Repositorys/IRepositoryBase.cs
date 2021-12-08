using Modelo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> where T : BaseEntidade
    {
        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);

        Task<T> SelectByIdAsync(int id);

        Task<IEnumerable<T>> SelectAllAsync();


    }
}
