using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Service
{
    public class BankService : IBankService
    {
        public decimal Balance(int userId)
        {
            Account account;
            //read from db

            return account.Balance;
        }

        public decimal Deposit(int userId, decimal depositAmount)
        {
            Account account;
            //read from db
            account.Balance += depositAmount;
            // update db

        }

        private bool HasSufficentFunds(decimal amount, decimal balance) => balance > amount;

        public decimal Withdraw(int userId, decimal amount)
        {
            Account account;
            // read from db
            if (HasSufficentFunds(amount, account.Balance))
            {
                account.Balance -= amount;
            }
            else
            {
                throw new ArgumentException("Insufficent Funds");
            }

            //update db
        }
    }
}
