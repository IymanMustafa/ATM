using WebApp.Models;

namespace WebApp.Service
{
    interface IAccountService
    {
        bool Create(RegisterAccountModel account);
        bool Delete(int userId);
    }
}
