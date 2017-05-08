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
                        Console.WriteLine("Please from the type of account:");
                        var accountTypes = Enum.GetNames(typeof(AccountTypes));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                        }
                        var typeOfAccount =(AccountTypes)(Convert.ToInt32(Console.ReadLine()) - 1);
                        Console.WriteLine("Amount :");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress,amount,typeOfAccount);
                        Console.WriteLine($"AcountNumber:{account.AccountNumber}, Type:{account.TypeOfAccount},Balance:{account.Balance :C},Email Address:{account.EmailAddress}");
                       break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Pick an account number to deposit: ");
                        var accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Desposit(accountNum, amount);
                        Console.WriteLine("Deposit succesful!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Pick an account number to withdraw: ");
                        accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNum, amount);
                        Console.WriteLine("Withdraw succesful!");
                        break;
                    case "4":
                        PrintAllAccounts();

                        break;
                    default:
                        break;
                }
             }
         }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var A in accounts)
            {
                Console.WriteLine($"AcountNumber:{A.AccountNumber}, Type:{A.TypeOfAccount},Balance:{A.Balance:C},Email Address:{A.EmailAddress}");

            }
        }
    }
}
