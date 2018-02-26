using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service
{
    public class LoginService : ILoginService
    {
       
        public bool IsValidPin(int userId, string Pin)

        {
            if (string.IsNullOrEmpty(Pin))
            {
                throw new ArgumentNullException(nameof(Pin));

            }
            // read account from db
            Account account;
            return Pin == account.Pin;
        }

        public Account Login(string userName, string password)
        {
        }

        public bool Logout(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
