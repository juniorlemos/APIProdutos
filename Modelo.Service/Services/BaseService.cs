using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntidade
    {

        private readonly IRepositoryBase<T> _repository;


        public BaseService(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }


        public async Task DeleteAsync(int id)
        {
             await _repository.DeleteAsync(id);
        }


        public async Task<T> SelectByIdAsync(int id)
        {
            return await _repository.SelectByIdAsync(id);
        }

        public async Task InsertAsync(T entity) { 
           
            await _repository.InsertAsync(entity);
        }


        public async Task UpdateAsync(T entity)
        {
             await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _repository.ExistAsync(id);
        }
    }
}
