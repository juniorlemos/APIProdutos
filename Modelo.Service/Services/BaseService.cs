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


        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }


        public async Task<T> SelectById(int id)
        {
            return await _repository.SelectById(id);
        }

        public async Task Insert(T entity) { 
           
            await _repository.Insert(entity);
        }


        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}
