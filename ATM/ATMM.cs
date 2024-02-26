using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMM
    {
        private List<User> users;

        public ATMM()
        {
            users = FileH.ReadUsersFromFile();
        }


        public void CheckBalance(int accountNumber)
        {
            User user = users.Find(u => u.AccountNumber == accountNumber);

            if (user != null)
            {
                Console.WriteLine($"Account balance for {user.Name}: {user.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void Deposit(int accountNumber, double amount)
        {
            User user = users.Find(u => u.AccountNumber == accountNumber);
            if (user != null)
            {
                user.Balance += amount;
                user.Transactions.Add(new Transaction { Date = DateTime.Now, Amount = amount, Type = "Deposit" });
                Console.WriteLine($"Deposited {amount:C} into account {user.AccountNumber}. New balance: {user.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }


        public void Withdraw(int accountNumber, double amount)
        {
            User user = users.Find(users => users.AccountNumber == accountNumber);
            if (user != null)
            {
                if (user.Balance > amount)
                {
                    user.Balance -= amount;
                    user.Transactions.Add(new Transaction { Date = DateTime.Now, Amount = amount, Type = "Withdraw" });
                    Console.WriteLine($"Withdrew {amount:C} from account {user.AccountNumber}. New balance: {user.Balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void RegisterUser(string name, double Ibalance)
        {
            int accountNumber = GenerateAccountNumber();
            User newUser = new User
            {
                Name = name,
                AccountNumber = accountNumber,
                Balance = Ibalance
            };
            users.Add(newUser);
            Console.WriteLine($"Registered new user {name} with account number {accountNumber} and initial balance {Ibalance:C}");
        }

        private int GenerateAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(100, 1000);
            while (users.Exists(users => users.AccountNumber == accountNumber))
            {
                accountNumber = random.Next(100, 1000);
            }
            return accountNumber;
        }

        public void SaveChanges()
        {
            FileH.WriteUsersToFile(users);
        }


        public void ShowTransactionHistory(int accountNumber)
        {
            User user = users.Find(u => u.AccountNumber == accountNumber);
            if (user != null)
            {
                Console.WriteLine($"Transaction history for account {user.AccountNumber}:");
                foreach (Transaction transaction in user.Transactions)
                {
                    Console.WriteLine($"{transaction.Date}: {transaction.Type} {transaction.Amount:C}");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

}
