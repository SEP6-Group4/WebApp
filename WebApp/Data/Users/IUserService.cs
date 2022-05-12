using WebApp.Models;

namespace WebApp.Data.Users
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        void SetUserId(int id);
        int GetUserId();
        Task CreateAccount(User user);
    }
}
