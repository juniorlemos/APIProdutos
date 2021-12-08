using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositorys;
using Modelo.Infra.Data.Context;
using System.Collections.Generic;
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
        public async Task<T> DeleteAsync(int id)
        {

            var consulta = await _dataset.FindAsync(id);

            if (consulta == null)
            {

                return null;
            }

            _dataset.Remove(consulta);
            await _context.SaveChangesAsync();


            return consulta;

        }



        public async Task<T> InsertAsync(T entity)
        {


            _dataset.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {


            return await _dataset.AsNoTracking().ToListAsync();
        }

        public async Task<T> SelectByIdAsync(int id)
        {


            return await _dataset.FindAsync(id);


        }


        public async Task<T> UpdateAsync(T entity)
        {

            var consulta = await _dataset.FindAsync(entity.Id);
            if (consulta == null)
            {
                return null;
            }


            _context.Entry(consulta).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return consulta;


        }

    }
}
