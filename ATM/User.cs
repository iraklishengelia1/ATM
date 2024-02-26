using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM
{
    public class User
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public List<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
        }  
    }
    
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
