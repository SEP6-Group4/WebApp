using WebApp.Models;

namespace WebApp.Data.Users
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
    }
}
