using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service
{
    public interface ILoginService
    {
        bool IsValidPin(int userId,string Pin);
        Account Login(string userName, string password);
        bool Logout (int userId);
    }
}
