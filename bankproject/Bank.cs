using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    public static class Bank
    {
        
        private static BankModel db = new BankModel();
        public static Account CreateAccount(string emailAddress,decimal amount,AccountTypes typeOfAccount)
        {
            var account = new Account(emailAddress, typeOfAccount);
            account.Deposit(amount);
            account.CreatedDate = DateTime.Now;
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static List<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress).ToList();
        }
        public static decimal Desposit(int accountNumber,decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
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
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
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
        public static List<Transcation> GetAllTransactionsByAccount(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).ToList();
        }

    }
}
