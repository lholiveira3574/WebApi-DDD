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
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));

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
                if (entidade.id == Guid.Empty)
                {
                    entidade.id = Guid.NewGuid();
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

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        public async Task<IEnumerable<T>> selectAsync()
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
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(entidade.id));

                if (result == null)
                {
                    return null;
                }

                entidade.updateAt = DateTime.UtcNow;
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