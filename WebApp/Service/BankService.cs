using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Service
{
    public class BankService : IBankService
    {
        private readonly ProfileRepository profileRepository;

        public BankService(ProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }
        public decimal Balance(int userId)
        {
            Account account = profileRepository.GetAccount(userId);
            return account.Balance;
        }

        public decimal Deposit(int userId, decimal depositAmount)
        {
            Account account = profileRepository.GetAccount(userId);
            account.Balance += depositAmount;
            profileRepository.UpdateBalance(userId, account.Balance);
            return account.Balance;
        }

        private bool HasSufficentFunds(decimal amount, decimal balance) => balance > amount;

        public decimal Withdraw(int userId, decimal amount)
        {
            Account account = profileRepository.GetAccount(userId);
            if (HasSufficentFunds(amount, account.Balance))
                account.Balance -= amount;
            else throw new ArgumentException("Insufficent Funds");
            profileRepository.UpdateBalance(userId, account.Balance);
            return account.Balance;
        }
    }
}
