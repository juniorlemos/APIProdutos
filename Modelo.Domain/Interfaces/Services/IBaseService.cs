using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Services
{
  
        public interface IBaseService<T> where T : BaseEntidade
        {



            Task UpdateAsync(T entity);
            Task<T> SelectByIdAsync(int id);
            Task InsertAsync(T entity);
            Task<IEnumerable<T>> SelectAllAsync();
            Task DeleteAsync(int id);
            Task<bool> ExistAsync(int id);


    }
}

