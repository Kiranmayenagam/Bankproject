using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
   public enum AccountTypes
    {
        Checking,
        Savings
    }
    /// <summary>
    /// This class reprents a bank account.
    /// Here you can desposit/withdraw.
    /// </summary>
    public class Account
    {
        #region Variables
        private static int lastAccountNum = 0;
        #endregion
        #region Properties
        /// <summary>
        /// Email Address of the account owner.
        /// </summary>
        public string EmailAddress { get; set; }
        [Key]
        public int AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public AccountTypes TypeOfAccount { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Transcation> Transactions { get; set; }
        #endregion
        #region Constructors 
        public Account()
        {
            AccountNumber = ++lastAccountNum;
        }
        public Account(string emailAddress): this()
        {
            EmailAddress = emailAddress;
        }
        public Account(string emailAddress,AccountTypes typeOfAccount) : this(emailAddress)
        {
            TypeOfAccount = typeOfAccount;
        }

        #endregion
        #region Method
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to Deposit</param>
        /// <returns>The update balance</returns>
        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }
        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion

    }
}
