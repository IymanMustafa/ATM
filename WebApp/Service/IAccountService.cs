using WebApp.Models;

namespace WebApp.Service
{
    public interface IAccountService
    {
        Account Get(int userId);
        bool Create(RegisterAccountModel account);
        bool Delete(int userId);
        bool IsValidPin(int userId, string Pin);
        Profile Login(string userName, string password);
        bool Logout(int userId);
    }
}
