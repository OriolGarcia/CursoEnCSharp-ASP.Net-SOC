using _20221124_APINeptuno.Dal;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<User> DoLogin(string login, string password);
    }
}
