using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    public enum TransactionType
    {
        Credit,
        Debit

    }
   public class Transcation
    {
        [Key]
        public int TransactionId { get; set; }
        public string  Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }        
        public decimal Amount { get; set; }

        public int  AccountNumber{ get; set; }
    }
}
