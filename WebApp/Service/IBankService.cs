using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Service
{
    public interface IBankService
    {
        decimal Deposit(int userId, decimal depositAmount);
        decimal Withdraw(int userId, decimal amount);
        decimal Balance(int userId);

    }
}
