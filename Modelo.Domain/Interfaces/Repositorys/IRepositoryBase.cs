using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> where T : BaseEntidade
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<T> SelectByIdAsync(int id);

        Task <IEnumerable<T>> SelectAllAsync();

        Task<bool> ExistAsync(int id);
    }
}
