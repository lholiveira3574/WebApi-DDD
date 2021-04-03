using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Data.Repository;
using WebApi.Domain.Entities;
using WebApi.Domain.Repository;

namespace WebApi.Data.Implementations
{
    public class UserImplementation: BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();   
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
           return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    } 
}