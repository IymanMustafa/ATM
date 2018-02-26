using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Service
{
    public class LoginService : ILoginService
    {
        private readonly ProfileRepository profileRepository;

        public LoginService(ProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }
       
        public bool IsValidPin(int userId, string Pin)

        {
            if (string.IsNullOrEmpty(Pin))
            {
                throw new ArgumentNullException(nameof(Pin));

            }
            Account account = profileRepository.GetAccount(userId);
            return Pin == account.Pin;
        }

        public Profile Login(string userName, string password)
        {
            return profileRepository.Login(userName, password);
        }

        public bool Logout(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
