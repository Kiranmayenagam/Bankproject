using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static BankModel db = new BankModel();
        public static Account CreateAccount(string emailAddress,decimal amount,AccountTypes typeOfAccount)
        {
            var account = new Account(emailAddress, typeOfAccount);
            account.Deposit(amount);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static List<Account> GetAllAccounts()
        {
            return accounts;
        }
        public static decimal Desposit(int accountNumber,decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentException("Account not found");

            var newBalance = account.Deposit(amount);  
            var transaction = new Transcation
            {
                TransactionDate = DateTime.Now,
                Description = "Branch Deposit",
                TransactionType = TransactionType.Credit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return newBalance;
        }
        public static decimal Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentException("Account not found");
            var newBalance = account.Withdraw(amount);
            var transaction = new Transcation
            {
                TransactionDate = DateTime.Now,
                Description = "Branch Withdraw",
                TransactionType = TransactionType.Debit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return newBalance;


           
        }

    }
}
