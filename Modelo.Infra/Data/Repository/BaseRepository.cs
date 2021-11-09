using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Canducci.Pagination;
using System.Linq;

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
        public async Task<bool> DeleteAsync(int id)
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

        public async Task<bool> ExistAsync(int id)
        {
           return await _dataset.AnyAsync(e => e.Id ==id );
             
        }

        public async Task InsertAsync(T entity)
        {
            try
            {

               

                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
           

            return await _dataset.AsNoTracking().ToListAsync(); 
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            try
            {

                return await _dataset.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(id));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<T> UpdateAsync(T entity)
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
