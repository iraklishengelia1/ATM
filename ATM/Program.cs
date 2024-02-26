


using ATM;

ATMM atm = new ATMM();


while (true)
{
    Console.WriteLine("Choose operation:");
    Console.WriteLine("1. Check balance");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Register");
    Console.WriteLine("5. Show transaction history");
    Console.WriteLine("6. Exit");

    try
    {
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter account number: ");
                int accountNumber = int.Parse(Console.ReadLine());
                atm.CheckBalance(accountNumber);
                break;
            case 2:
                Console.WriteLine("Enter account number:");
                int depositAccountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount to deposit:");
                double depositAmount = double.Parse(Console.ReadLine());
                atm.Deposit(depositAccountNumber, depositAmount);
                break;
            case 3:
                Console.WriteLine("Enter account number:");
                int withdrawAccountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount to withdraw:");
                double withdrawAmount = double.Parse(Console.ReadLine());
                atm.Withdraw(withdrawAccountNumber, withdrawAmount);
                break;
            case 4:
                Console.WriteLine("Enter Name and Lastname:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter initial balance:");
                double initialBalance = double.Parse(Console.ReadLine());
                atm.RegisterUser(name, initialBalance);
                break;
            case 5:
                Console.WriteLine("Enter account number:");
                int historyAccountNumber = int.Parse(Console.ReadLine());
                atm.ShowTransactionHistory(historyAccountNumber);
                break;
            case 6:
                atm.SaveChanges();
                Console.WriteLine("Goodbye! Thanks for using ATM! ");
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;

        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}
