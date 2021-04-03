using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;

namespace WebApi.Domain.Repository
{
    public interface IUserRepository: IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);    
    }
}