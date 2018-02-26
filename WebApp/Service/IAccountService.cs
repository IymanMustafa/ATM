using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service
{
    interface IAccountService
    {
        bool Create(RegisterAccountModel account);
        bool Delete(string accountNumber = null, string pin = null);
        
    }
}
