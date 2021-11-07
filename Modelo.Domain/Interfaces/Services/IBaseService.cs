using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Services
{
  
        public interface IBaseService<T> where T : BaseEntidade
        {



            Task<T> UpdateAsync(T entity);
            Task<T> SelectByIdAsync(int id);
            Task InsertAsync(T entity);
            Task<IEnumerable<T>> SelectAllAsync();
        Task<bool> DeleteAsync(int id);

        }
    }

