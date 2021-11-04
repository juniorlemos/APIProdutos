using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> where T : BaseEntidade
    {
        Task Insert(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(int id);

        Task<T> SelectById(int id);


    }
}
