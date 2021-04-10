using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;

namespace WebApi.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context; 
        private DbSet<T> _dataset;
        public BaseRepository(MyContext contexty)
        {
            _context = contexty;    
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> InsertAsync(T entidade)
        {
            try
            {
                if (entidade.Id == Guid.Empty)
                {
                    entidade.Id = Guid.NewGuid();
                }

                entidade.CreateAt = DateTime.UtcNow;
                _dataset.Add(entidade);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
             try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        public async Task<T> UpdateAsync(T entidade)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entidade.Id));

                if (result == null)
                {
                    return null;
                }

                entidade.UpdateAt = DateTime.UtcNow;
                entidade.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(entidade);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }
    }
}