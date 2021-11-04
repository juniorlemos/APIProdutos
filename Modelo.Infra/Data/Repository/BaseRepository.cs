using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntidade
    {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dataset;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> Delete(int id)
        {

            try
            {
                var target = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (target == null)
                {
                    return false;
                }

                _dataset.Remove(target);
                int processResult = await _context.SaveChangesAsync();

                return processResult > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(T entity)
        {
          

                _dataset.Add(entity);

                await _context.SaveChangesAsync();
           
        }

        public async Task<T> SelectById(int id)
        {
            try
            {

                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));
                if (result == null)
                {
                    return null;
                }


                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }
    }
}
