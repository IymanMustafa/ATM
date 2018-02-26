using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service
{
    public class AccountService : IAccountService
    {
        public bool Create(RegisterAccountModel account)
        {
            if (string.IsNullOrEmpty(account.Username))
            {
                throw new ArgumentNullException(nameof(account.Username));
            }
            if (string.IsNullOrEmpty(account.Password))
            {
                throw new ArgumentNullException(nameof(account.Password));
            }
            if (account.Age == 0)
            {
                throw new ArgumentNullException(nameof(account.Age));
            }
            if (string.IsNullOrEmpty(account.PhoneNumber))
            {
                throw new ArgumentNullException(nameof(account.PhoneNumber));
            }
            if (string.IsNullOrEmpty(account.Email))
            {
                throw new ArgumentNullException(nameof(account.Email));
            }
            if (string.IsNullOrEmpty(account.Pin))
            {
                throw new ArgumentNullException(nameof(account.Pin));
            }
            if (string.IsNullOrEmpty(account.Name))
            {
                throw new ArgumentNullException(nameof(account.Name));
            }
            if (account.Age < 18)
            {
                return false;
            }
            if (account.Username.Length < 6 || account.Password.Length < 6 || account.PhoneNumber.Length != 10 || account.Pin.Length < 4 || account.Pin.Length > 6)
            {
                return false;
            }
            // acount username already exists return false otherwise else create
        }

        public bool Delete(string accountNumber = null, string username = null)
        {
            if (!string.IsNullOrEmpty(accountNumber))
            {
                // delete account number
            }
            else if (!string.IsNullOrEmpty(username))
            {
                // delete based on user name
            }
            else throw new ArgumentException("Provide one parameter");
        }
    }
}
