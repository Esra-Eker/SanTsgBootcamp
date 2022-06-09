using Bootcamp.Domain.Users;
using System.Threading.Tasks;

namespace Bootcamp.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
    }
}
