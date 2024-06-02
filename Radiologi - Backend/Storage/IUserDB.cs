using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public interface IUserDB
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        User FindUser(User user);
        User FindUserById(string Id);
        List<string> GetClassesByUserId(string userId);
    }
}
