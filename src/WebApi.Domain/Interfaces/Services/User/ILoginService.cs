using System.Threading.Tasks;
using WebApi.Domain.Dtos;

namespace WebApi.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
         Task<object> FindByLogin(LoginDto user); 
    }
}