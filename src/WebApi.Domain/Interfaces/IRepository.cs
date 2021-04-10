using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
         Task<T> InsertAsync(T entidade);
         Task<T> UpdateAsync(T entidade);
         Task<bool> DeleteAsync(Guid id);
         Task<T> SelectAsync(Guid id);
         Task<IEnumerable<T>> SelectAsync();
         Task<bool> ExistsAsync(Guid id);
    }
}