using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    static class Bank
    {
        public static Account CreateAccount(string emailAddress,decimal amount,string typeOfAccount)
        {
            var account = new Account(emailAddress, typeOfAccount);
            account.Deposit(amount);
            return account;
        }

    }
}
