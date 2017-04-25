using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var account = Bank.CreateAccount("test@test.com", 100, "Checking");
            //Console.WriteLine($"AcountNumber:{account.AccountNumber}, Type:{account.TypeOfAccount},Balance:{account.Balance :C},Email Address:{account.EmailAddress}");

            //var account2 = Bank.CreateAccount("test2@test.com", 200, "Saving");
            //Console.WriteLine($"AcountNumber:{account2.AccountNumber}, Type:{account2.TypeOfAccount},Balance:{account2.Balance :C},Email Address:{account2.EmailAddress}");

            Console.WriteLine("*****************Welcome to my Bank**************");
            while(true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1.Create an account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Print all account");
                Console.Write("Please select a the choice for the above");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you visiting the bank");
                        return;
                    case "1":
                        Console.WriteLine("Email Address");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Type Of Account");
                        var typeOfAccount = Console.ReadLine();
                        Console.WriteLine("Amount :");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress,amount,typeOfAccount);
                        Console.WriteLine($"AcountNumber:{account.AccountNumber}, Type:{account.TypeOfAccount},Balance:{account.Balance :C},Email Address:{account.EmailAddress}");
                       break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                    default:
                        break;
                }






            }


        }
    }
}
