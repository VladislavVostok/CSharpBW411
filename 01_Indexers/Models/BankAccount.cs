using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public BankAccount(string accountNumber, string accountType, decimal balance, string currency = "RUB")
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
            Currency = currency;
        }

        public void Deposit(decimal amount) => Balance += amount;

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString() => $"{AccountNumber} ({Balance:C}) : {Currency}";
    }
}
