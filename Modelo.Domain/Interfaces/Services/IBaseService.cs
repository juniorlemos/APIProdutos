using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Services
{
  
        public interface IBaseService<T> where T : BaseEntidade
        {



            Task<T> Update(T entity);
            Task<T> SelectById(int id);
            Task Insert(T entity);

            Task<bool> Delete(int id);

        }
    }

