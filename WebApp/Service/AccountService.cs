using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly ProfileRepository profileRepository;

        public AccountService(ProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }
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
            if (string.IsNullOrEmpty(account.Pin))
            {
                throw new ArgumentNullException(nameof(account.Pin));
            }
            if (string.IsNullOrEmpty(account.Name))
            {
                throw new ArgumentNullException(nameof(account.Name));
            }
            if (account.Username.Length < 6 || account.Password.Length < 6 || account.Pin.Length < 4 || account.Pin.Length > 6)
            {
                return false;
            }
            if(profileRepository.GetAccount(account.Username) != null)
            {
                return false;
            }
           return profileRepository.Create(account) != 0;
            // acount username already exists return false otherwise else create

        }

        public bool Delete(int userId)
        {
            if(userId < 1) throw new ArgumentException($"Provide valid {nameof(userId)}");
           return profileRepository.Delete(userId);
        }
    }
}
