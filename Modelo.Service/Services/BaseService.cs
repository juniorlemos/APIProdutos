using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Domain.Interfaces.Services;
using System.Collections.Generic;
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


        public async Task<T> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }


        public async Task<T> SelectByIdAsync(int id)
        {
            return await _repository.SelectByIdAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {

            return await _repository.InsertAsync(entity);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await _repository.SelectAllAsync();
        }


    }
}
