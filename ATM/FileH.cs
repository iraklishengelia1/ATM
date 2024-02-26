using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public class FileH
    {
        private const string FileName = "user_accounts.txt";
        private const string x = "-";
        public static List<User> ReadUsersFromFile()
        {
            List<User> users = new List<User>();

            if (File.Exists(FileName))
            {
                string[] lines = File.ReadAllLines(FileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(x);
                    User user = new User
                    {
                        Name = parts[0].Substring(parts[0].IndexOf("FullName: ") + 5),
                        AccountNumber = int.Parse(parts[1].Substring(parts[1].IndexOf("AccountNumber:") + 14)),
                        Balance = double.Parse(parts[2].Substring(parts[2].IndexOf("Balance:") + 8))
                    };
                    users.Add(user);
                }
            }
            else
            {
                File.Create(FileName).Close();
            }

            return users;
        }

        public static void WriteUsersToFile(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                lines.Add($"Name: {user.Name} {x} AccountNumber: {user.AccountNumber} {x} Balance: {user.Balance} ");
            }

            File.WriteAllLines(FileName, lines);
        }
    }

}




